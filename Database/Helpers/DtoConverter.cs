using System;
using System.Linq;
using Database.Dto;
using ViewModels.Graph;
using ViewModels.Helpers;

namespace Database.Helpers
{
    internal static class DtoConverter
    {
        public static GraphPointDto ToDto(this GraphPointViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new GraphPointDto
            {
                X = item.X,
                Y = item.Y
            };
        }

        public static GraphPointViewModel ToViewModel(this GraphPointDto item, GraphViewModel graph)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new GraphPointViewModel
            {
                X = item.X,
                Y = item.Y
            };
        }

        public static GraphDto ToDto(this GraphViewModel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new GraphDto
            {
                Id = item.Id,
                Name = item.Name,
                Points = item.Points.Select(ToDto).ToArray()
            };
        }

        public static GraphViewModel ToViewModel(this GraphDto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var vm = GraphViewModelCreator.Create(item.Id);
            vm.Name = item.Name;

            foreach (var point in item.Points)
            {
                vm.Points.Add(point.ToViewModel(vm));
            }

            return vm;
        }
    }
}