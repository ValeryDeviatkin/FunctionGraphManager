using System;
using ViewModels.Graph;
using Wpf.Tools;

namespace ViewModels.Helpers
{
    public static class GraphViewModelCreator
    {
        public static GraphViewModel Create()
        {
            var id = Guid.NewGuid();

            return new GraphViewModel(ServiceLocator.Container, id)
            {
                Name = id.ToString()
            };
        }

        public static GraphViewModel Create(Guid id) => new GraphViewModel(ServiceLocator.Container, id);
    }
}