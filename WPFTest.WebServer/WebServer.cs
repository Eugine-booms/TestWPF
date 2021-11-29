using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest.WebServer
{
    public class WebServer
    {
        //сложный метод делать много самому напрямую с драйвера  сетевой карты
        //private TcpListener tcpListener = new TcpListener(IPAddress.Any, 8080);

        public event EventHandler<RequestReceiverEventArgs> RequestReceiver;

        //легкий способ (могут быть проблемы с разрешением файвола и доступа к драйверу карты
        private HttpListener listener;
        private readonly int port;
        private bool enabled;
        private readonly object syncRoot = new object();

        public int Port => port;

        public bool Enabled
        {
            get => enabled;
            set { if (enabled) Start(); else Stop(); }
        }

        public WebServer(int port)
        {
            this.port = port;
        }
        public void Start()
        {
            if (enabled) return;
            lock (syncRoot)
            {
                if (enabled) return;
                listener = new HttpListener();
                listener.Prefixes.Add($"http://*:{Port}/"); //если не разрешено получим исключение
                                                            //Команда для добавления порта в терминале
                                                            // netsh http add urlacl url=http://*:8080/ user= *user_name*
                listener.Prefixes.Add($"http://+:{Port}/"); //если не разрешено получим исключение
                enabled = true;
            }
            ListenAsync();
        }
        public void Stop()
        {
            if (!enabled) return;
            lock (syncRoot)
            {
                if (!enabled) return;
                listener = null;
                this.enabled = false;
            }
        }
        private async void ListenAsync()
        {

            var listener = this.listener;
            listener.Start();
            Console.WriteLine("Ожидаем подключения");
            HttpListenerContext context = null;
            while (enabled)
            {
                var getContestTask = listener.GetContextAsync();
                if (context != null)
                    ProcessRequestAsync(context);
                context = await getContestTask.ConfigureAwait(false);
            }
            listener.Stop();


        }
        private async void ProcessRequestAsync(HttpListenerContext context)
        {
            await Task.Run(() => RequestReceiver?.Invoke(this, new RequestReceiverEventArgs(context)));
        }

    }

    public class RequestReceiverEventArgs : EventArgs
    {
        public RequestReceiverEventArgs(HttpListenerContext context) => Context = context;

        public HttpListenerContext Context { get; }
    }
}
