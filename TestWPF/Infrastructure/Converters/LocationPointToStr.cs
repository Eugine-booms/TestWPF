using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TestWPFApp.Infrastructure.Converters
{
    internal class LocationPointToStr : IValueConverter
    {
        public object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is Point point)) return null;
            return $"Lat:{point.X};Lon{point.Y}";
        }

        public object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            if (!(value is string str)) return null;

            var component = str.Split(';');
            var lat_str = component[0].Split(';')[1];
            var lot_str= component[1].Split(';')[1];

            var lat= double.Parse(lat_str, CultureInfo.InvariantCulture );
            var lot = double.Parse(lot_str, CultureInfo.InvariantCulture);

            return new Point(lat, lot);
        }
    }
}
