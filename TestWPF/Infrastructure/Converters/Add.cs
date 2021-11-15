using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Converters
{
    /// <summary>
    /// выполняет преобразование вида f(x)=x+B;
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    [MarkupExtensionReturnType(typeof(Add))]
    internal class Add : Converter
    {
        public Add(double b) => B = b;
        
        public Add() { }
        [ConstructorArgument("B")]
        public double B { get; set; } = 0;
        override  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var x = System.Convert.ToDouble(value, culture);
            return B + x;
        }

        override public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var y = System.Convert.ToDouble(value, culture);
            return y-B;
        }

    }
}
