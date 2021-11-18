using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WPFTest.WebServer;

namespace TestWPFConsole
{
    public class WebServerTest
    {
        public static void Run()
        {
            var server = new WebServer(8080);
            server.RequestReceiver += OnRequestReceived;

            server.Start();
            Console.WriteLine("Server was started");
            Console.ReadLine();
        }

        private static void OnRequestReceived(object sender, RequestReceiverEventArgs e)
        {
            var context = e.Context;
            Console.WriteLine("Connection {0}", context.Request.UserHostAddress);

            using (var writer = new StreamWriter(context.Response.OutputStream))
            {
                writer.WriteLine("Hello from Test Web Server !!!!");
            }
        }
    }
}
