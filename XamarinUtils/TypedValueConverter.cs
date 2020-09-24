using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinUtils
{
    public abstract class TypedValueConverter<To, From> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TypedConvert((From) (value ?? default(From)));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TypedConvertBack((To) value);
        }

        public abstract To TypedConvert(in From input);

        public From TypedConvertBack(in To input)
        {
            throw new NotSupportedException($"{GetType().Name} cannot be used on two-way bindings.");
        }
    }
}
