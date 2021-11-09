using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TestWPFApp.Model
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point MyProperty { get; set; }

        public IEnumerable<ConfimedCount> Counts { get; set; }
        
    }
}
