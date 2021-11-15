using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    [MarkupExtensionReturnType(typeof(StrToUpper))]
    internal class StrToUpper : Converter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var str = value as string;
            return str.ToUpper();
        }
    }
}
