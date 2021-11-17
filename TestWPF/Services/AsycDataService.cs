using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.Services
{
    internal class AsycDataService : IAsycDataService
    {
        private const int _slipTime =7000;
        public string GetResult(DateTime dateTime)
        {
            Thread.Sleep(_slipTime);
            return $"Result value {dateTime}";
        }

        
    }
}
