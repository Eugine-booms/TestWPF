using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TestWPFApp.Model
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Coordinates { get; set; }

        public IEnumerable<ConfimedCount> InfectedCounts { get; set; }
        
    }
}
