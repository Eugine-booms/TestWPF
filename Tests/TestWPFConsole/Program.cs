﻿using System;
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

        static void Main(string[] args)
        {

            Thread.CurrentThread.Name = "Main Thread";
            var thread = new Thread(ThreadMetod);
            thread.Name = "Second Thread";
            thread.IsBackground = true;
            var priority = thread.Priority;


            thread.Start("Hello World!");

            var count = 5;
            var msg = "Пипец";
            var timeout = 150;
            new Thread(() => PrintMethod(msg, count, timeout)) {  IsBackground = true }.Start();



            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            CheckThread();
            Console.ReadLine();
            Console.WriteLine("Hello World!");
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
            var value = (string)parametr;
            Console.WriteLine(value);
            CheckThread();

            while (true)
            {
                Thread.Sleep(100);
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

