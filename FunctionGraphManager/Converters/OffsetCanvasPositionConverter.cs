using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace FunctionGraphManager.Converters
{
    internal class OffsetCanvasPositionConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 &&
                values[0] is double coordinate &&
                values[1] is double elementSize)
            {
                return coordinate - elementSize * 0.5d;
            }

            throw new NotSupportedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}