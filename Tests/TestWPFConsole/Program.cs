using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace TestWPFConsole
{
    
    class Program
    {
        private static bool _threadUp=true;
        static void Main(string[] args)
        {


            //Mutex mutex = new Mutex(); //если есть несколько приложений то тот кто его создал не первым будет уведомлен о том что он создал не первый
            //                            /// через него можно производить синхронизацию
            //Semaphore semaphore = new Semaphore(0,10); //позволяет блокировать критическую секцию через ядро операционной системы
            //                                           // ограничивает количество входов внутри себя
            //semaphore.WaitOne();                        // для ограничения нагрузки на сервер НАПРИМЕР
            ////действия в критической секции
            //semaphore.Release();

            //как стартовый пистолет для бегунов
            ManualResetEvent manualResetEvent = new ManualResetEvent(false); //не сбрасывает все делается в ручную set reset
            AutoResetEvent autoResetEvent = new AutoResetEvent(false); //сбрасывает  thread_guidance.WaitOne(); при прохождении через него в false

            EventWaitHandle thread_guidance = autoResetEvent;

            var test_threads = new Thread[10];

            for (int i = 0; i < test_threads.Length; i++)
            {
                var local_i = i;
                test_threads[i] = new Thread(() => 
                {
                    Console.WriteLine("Поток id:{0}-стартовал", Thread.CurrentThread.ManagedThreadId);
                    thread_guidance.WaitOne();   //Ждут отмашки thread_guidance.Set();
                    Console.WriteLine("Value:{0}",local_i);
                    Console.WriteLine("Поток Id:{0}- завершился", Thread.CurrentThread.ManagedThreadId);

                });
                test_threads[i].Start();
            }

            Console.WriteLine("Готов к запуску потоков");
            Console.ReadLine();

            //стартует все потоки
            thread_guidance.Set();














            //Thread.CurrentThread.Name = "Main Thread";
            //var clock_thread = new Thread(ThreadMetod);
            //clock_thread.Name = "Second Thread";
            //clock_thread.IsBackground = true;
            //var priority = clock_thread.Priority;
            //clock_thread.Start();

            //if(!(clock_thread.Join(100))) //синхронизирует поток
            //{
            //    //   clock_thread.Abort(); //прерывает в любой точке процесса выполнения не поддерживается в настоящее время

            //    clock_thread.Interrupt(); //
            //}


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


        //атрибут позволяет  сделать метод атомарным для потоков
        [MethodImpl(MethodImplOptions.Synchronized)]
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

