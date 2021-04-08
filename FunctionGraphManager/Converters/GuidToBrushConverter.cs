using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace FunctionGraphManager.Converters
{
    public class GuidToBrushConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Guid guid)
            {
                var stringGuid = guid.ToString();

                return new SolidColorBrush(
                    (Color) ColorConverter.ConvertFromString($"#{stringGuid.Substring(0, 5)}F"));
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}