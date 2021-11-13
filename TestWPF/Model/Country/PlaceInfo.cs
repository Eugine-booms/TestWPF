using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace TestWPFApp.Model
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public virtual Point Location { get; set; }
        public virtual IEnumerable<ConfimedCount> InfectedCounts { get; set; }
        
    }
}
