using System;
using System.Collections.Generic;
using Database.Dto;
using Unity;
using ViewModels.Graph;
using ViewModels.Interfaces;

namespace Database.Services
{
    internal class StateHub : IStateHub
    {
        private readonly Dictionary<Guid, GraphDto> _savedStates = new Dictionary<Guid, GraphDto>();

        public StateHub(IUnityContainer container)
        {
            container
               .RegisterInstance<IStateHub>(this)
               .RegisterInstance(this)
                ;
        }

        public bool HasChanged(GraphViewModel graph)
        {
            if (graph == null)
            {
                throw new ArgumentException(nameof(graph));
            }

            if (!_savedStates.TryGetValue(graph.Id, out var savedState))
            {
                throw new NotSupportedException();
            }

            if (savedState.Name != graph.Name ||
                savedState.Points.Length != graph.Points.Count)
            {
                return true;
            }

            var pointCount = graph.Points.Count;

            for (var i = 0; i < pointCount; i++)
            {
                var point1 = savedState.Points[i];
                var point2 = graph.Points[i];

                if (point1.X != point2.X || point1.Y != point2.Y)
                {
                    return true;
                }
            }

            return false;
        }

        public void Save(GraphDto graph)
        {
            if (graph == null)
            {
                throw new ArgumentException(nameof(graph));
            }

            var id = graph.Id;

            if (_savedStates.ContainsKey(id))
            {
                _savedStates[id] = graph;
            }
            else
            {
                _savedStates.Add(id, graph);
            }
        }

        public void Delete(Guid id)
        {
            if (!_savedStates.ContainsKey(id))
            {
                throw new NotSupportedException();
            }

            _savedStates.Remove(id);
        }
    }
}