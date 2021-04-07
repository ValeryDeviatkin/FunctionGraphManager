using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace FunctionGraphManager.Converters
{
    internal class IntToBrushConverter : MarkupExtension, IValueConverter
    {
        private static readonly Dictionary<int, Brush> Brushes = new Dictionary<int, Brush>
        {
            {0, System.Windows.Media.Brushes.Red},
            {1, System.Windows.Media.Brushes.LimeGreen},
            {2, System.Windows.Media.Brushes.Blue},
            {3, System.Windows.Media.Brushes.Yellow},
            {4, System.Windows.Media.Brushes.MediumVioletRed},
            {5, System.Windows.Media.Brushes.SandyBrown},
            {6, System.Windows.Media.Brushes.Aqua},
            {7, System.Windows.Media.Brushes.DarkSlateGray}
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return Brushes[intValue % Brushes.Count];
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}