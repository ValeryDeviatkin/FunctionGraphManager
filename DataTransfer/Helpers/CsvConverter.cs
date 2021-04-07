using System;
using System.Collections.Generic;
using ViewModels.Graph;

namespace DataTransfer.Helpers
{
    internal static class CsvConverter
    {
        private const string Delimiter = "\t";

        public static IEnumerable<string> ToCsv(this GraphViewModel item)
        {
            var result = new List<string>();

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            result.Add($"{nameof(GraphPointViewModel.X)}{Delimiter}{nameof(GraphPointViewModel.Y)}");

            foreach (var point in item.Points)
            {
                result.Add($"{point.X}{Delimiter}{point.Y}");
            }

            return result;
        }

        public static IReadOnlyList<GraphPointViewModel> ToPointList(string[] csv)
        {
            var result = new List<GraphPointViewModel>();

            foreach (var line in csv)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var values = line.Split(new[] {Delimiter}, StringSplitOptions.RemoveEmptyEntries);

                    if (values.Length == 2 &&
                        double.TryParse(values[0], out var x) &&
                        double.TryParse(values[1], out var y))
                    {
                        result.Add(new GraphPointViewModel {X = x, Y = y});
                    }
                }
            }

            return result;
        }
    }
}