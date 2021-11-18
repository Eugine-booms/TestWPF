using System;
using System.Collections.Generic;
using System.Text;

namespace TestWPFApp.Services.Interfaces
{
    internal interface IWebServerService
    {
        bool Enabled { get; set; }
        void Start(int port);
        void Stop();
    }
}
