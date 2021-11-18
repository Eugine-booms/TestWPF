using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.Services
{
    internal class HttpListnerWebServer : IWebServerService
    {
       

        public bool Enabled { get ; set ; }

        public void Start(int port)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
