using System.Collections.Generic;

namespace TestWPFApp.Model
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCount { get; set; }

       
    }
        
}
