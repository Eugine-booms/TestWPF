using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace TestWPFApp.Model
{
    internal class CountryInfo : PlaceInfo
    {

        private Point? _location;
        public override Point Locatoin
        {
            get
            {
                if (_location != null)
                    return (Point)_location;

                if (_location is null)
                    return default;

                var avg_x = ProvinceCount.Average(p => p.Locatoin.X);
                var avg_y = ProvinceCount.Average(y => y.Locatoin.Y);
                return new Point(avg_x, avg_y);
            }
            set => _location = value;
        }
        public override IEnumerable<ConfimedCount> InfectedCounts
        {
            get
            {
                var confimedCount = ProvinceCount
                    .SelectMany(x => x.InfectedCounts)
                    .Select(x => (x.Date, x.Count))
                    .GroupBy(x=>x.Date )
                    .Select(x=>new ConfimedCount() 
                    { 
                        Date=x.Key, Count=x.Sum(y=>y.Count )
                    });
                
                return confimedCount;
            }
             
        }
        public IEnumerable<PlaceInfo> ProvinceCount { get; set; }
    }

}
