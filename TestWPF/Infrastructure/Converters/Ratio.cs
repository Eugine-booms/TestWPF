using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Converters
{
    /// <summary>
    /// выполняет преобразование вида f(x)=K*x;
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    internal class Ratio : Base.Converter
    {
        public Ratio(double k) => K = k;
        
        public Ratio() { }
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;
        override  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var x = System.Convert.ToDouble(value, culture);
            return K * x;
        }

        override public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (string.IsNullOrEmpty(value as string)) return 0;
            var y = System.Convert.ToDouble(value, culture);
            return y / K;
        }

    }
}
