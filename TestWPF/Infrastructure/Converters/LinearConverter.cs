using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Converters
{
    /// <summary>
    /// Выполняет преобразование вида f(x)=k*x+b
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    internal class LinearConverter : Base.Converter
    {
        public LinearConverter() { }
        public LinearConverter(double k) => K = k;

        public LinearConverter(double k, double b) : this(k) => B = b;
        //Подсказки для дизайнера
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;
        [ConstructorArgument("B")]
        public double B { get; set; } = 0;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var x = System.Convert.ToDouble(value, culture);
            return K * x + B;

        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (string.IsNullOrEmpty(value as string)) return 0;
            var f_x = System.Convert.ToDouble(value, culture);
            return (f_x - B) / K;
        }

    }
}
