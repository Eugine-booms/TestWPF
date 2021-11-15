using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace TestWPFApp.Infrastructure.Converters
{
    [ValueConversion(typeof(object[]), typeof(double))]
    internal class ToArrayConverter : MultiConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToArray();
        }

        //public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        //{
        //   // return value as object[];
        //}
    }
}
