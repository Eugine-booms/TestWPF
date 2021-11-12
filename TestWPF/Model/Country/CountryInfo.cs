using System.Collections.Generic;

namespace TestWPFApp.Model
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<PlaceInfo> ProvinceCount { get; set; }

       
    }
        
}
