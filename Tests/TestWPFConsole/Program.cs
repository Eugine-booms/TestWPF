using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestWPFConsole
{
    
    class Program
    {
        private static bool _threadUp=true;
        static void Main(string[] args)
        {
            
            Thread.CurrentThread.Name = "Main Thread";
            var clock_thread = new Thread(ThreadMetod);
            clock_thread.Name = "Second Thread";
            clock_thread.IsBackground = true;
            var priority = clock_thread.Priority;
            clock_thread.Start();

            if(!(clock_thread.Join(100))) //синхронизирует поток
            {
                //   clock_thread.Abort(); //прерывает в любой точке процесса выполнения не поддерживается в настоящее время
                
                clock_thread.Interrupt(); //
            }
            

            //var count = 5;
            //var msg = "Пипец";
            //var timeout = 150;
            //new Thread(() => PrintMethod(msg, count, timeout)) {  IsBackground = true }.Start();



            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //CheckThread();

            //Содержит в себе коллекции конкурентных штук
            //System.Collections.Concurrent.
            //var sdfsd = new System.Collections.Concurrent.ConcurrentQueue<int>();


            //var list = new List<int>();
            //object lock_object = new object();
            //var thread = new Thread[10];

            //for (int i = 0; i < clock_thread.Length; i++)
            //{
            //    clock_thread[i] = new Thread(() =>
            //    {
            //        for (int i = 0; i < 100; i++)
            //        {
            //            lock (lock_object)
            //            {
            //                list.Add(Thread.CurrentThread.ManagedThreadId);
            //            }
                       
            //        }

            //    });
            //}
            //// это разворачивается 
            //lock (lock_object)
            //{

            //}
            ////вот в это
            //Monitor.Enter(lock_object);
            //try
            //{
            //    //Критическая секция
            //}
            //finally
            //{
            //    Monitor.Exit(lock_object);
            //}



            //foreach (var item in clock_thread)
            //{
            //    item.Start();
            //}




            
            //Console.WriteLine(string.Join(",", list));

            Console.ReadLine();
        }
        private static void PrintMethod(string message, int count, int timeout)
        {
            for (int i = 0; i < count; i++)
            {
                
                Console.WriteLine(message);
                Thread.Sleep(timeout);
            }
        }
        private static void ThreadMetod(object parametr)
        {
            
            CheckThread();

            while (_threadUp)
            {
                //Thread.Sleep(100);
                //Thread.SpinWait(1000);
                Console.Title = DateTime.Now.ToString("ss:FFFFFFF");
            }
        }
        private static void CheckThread()
        {
            var thead = Thread.CurrentThread;
            Console.WriteLine("{0}:{1}", thead.ManagedThreadId, thead.Name);

        }
    }

}

