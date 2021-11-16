using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model;

namespace TestWPFApp.Services.Interfaces
{
   internal interface IDataService
    {
        public IEnumerable<CountryInfo> GetData();
    }
}
