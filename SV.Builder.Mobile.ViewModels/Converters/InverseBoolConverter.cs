using System;
using System.Globalization;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException($"Only one way binding supported for {nameof(InverseBoolConverter)}");
        }
    }
}
