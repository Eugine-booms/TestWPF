using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TestWPFApp.Model
{
    internal class CountryInfo : PlaceInfo
    {

        private Point? _location;
        public override Point Location
        {
            get
            {
                if (_location != null)
                    return (Point)_location;

                //if (_location is null)
                //    return default;

                var avg_x = ProvinceCount.Average(p => p.Location.X);
                var avg_y = ProvinceCount.Average(y => y.Location.Y);
                return new Point(avg_x, avg_y);
            }
            set => _location = value;
        }
        private IEnumerable<ConfimedCount> _counts;
        public override IEnumerable<ConfimedCount> InfectedCounts
        {
            get
            {
                if (_counts != null) return _counts;
                var confimedCount = ProvinceCount
                    .SelectMany(x => x.InfectedCounts)
                    .Select(x => (x.Date, x.Count))
                    .GroupBy(x=>x.Date )
                    .Select(x=>new ConfimedCount() 
                    { 
                        Date=x.Key, Count=x.Sum(y=>y.Count )
                    }).ToArray();

                return confimedCount;
            }

            set { _counts = value; }
             
        }
        public IEnumerable<PlaceInfo> ProvinceCount { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ProvinceCount.Count()}; {Location.X:N2} , {Location.Y:N2})";
        }
    }

}
