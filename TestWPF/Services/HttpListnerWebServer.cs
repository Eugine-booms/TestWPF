using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestWPFApp.Services.Interfaces;
using WPFTest.WebServer;

namespace TestWPFApp.Services
{
    internal class HttpListnerWebServer : IWebServerService
    {
        private WebServer webServer = new WebServer(8080);

        public bool Enabled { get=> webServer.Enabled ; set => webServer.Enabled = value ; }

        public void Start() => webServer.Start();
        public HttpListnerWebServer() => webServer.RequestReceiver += OnRequestReceived;
        private void OnRequestReceived(object sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;
            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.WriteLine("Hello from Test Web Server !!!!");
            }
        }

        public void Stop() => webServer.Stop();
    }
}
