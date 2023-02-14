using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Source
{
    public class Program
    {
        static void Main()
        {
            // Example1();
            // Example2();
            // Example3();
            // Example4();
            // Example5();




            //for (int i = 0; i < 10; i++)
            //{
            //    int x = i;
            //    new Thread(() => Console.WriteLine(x)).Start();
            //}



            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 10; i++)
            {
                int x = i;
                threads.Add(new Thread(() => Console.WriteLine(x)));
            }



            foreach (var thread in threads)
            {
                thread.Start();
                Thread.Sleep(10);
            }







            //List<Action> actions = new List<Action>();

            //for (int i = 0; i < 10; i++)
            //{
            //    int x = i;
            //    actions.Add(() => Console.WriteLine(x));
            //}



            //foreach (var action in actions)
            //    action();

        }

        private static void Example5()
        {
            string text = "Hakuna";

            Thread t1 = new Thread(() =>
            {
                Console.WriteLine(text);
            });

            text = "Matata";

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine(text);
            });

            t1.Start();
            t2.Start();
        }

        private static void Example4()
        {
            Thread thread = new Thread(() =>
            {
                Console.WriteLine($"Thread id: {Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"Thread name: {Thread.CurrentThread.Name}");

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(i);
                }
            });

            thread.Name = "Worker thread";
            thread.Start();

            // // Thread.Sleep(2000);
            // // thread.Suspend();
            // 
            // Thread.Sleep(2000);
            // // thread.Resume();
            // thread.Abort();


            //thread.Suspend();

            thread.IsBackground = true;
            thread.Join();

            Console.WriteLine("Terminated");
        }

        private static void Example3()
        {
            Thread thread1 = new Thread(() =>
            {
                int count = 0;
                while (true)
                {
                    Console.WriteLine($"thread 1 {count++}");
                }
            });
            thread1.Priority = ThreadPriority.Lowest;



            Thread thread2 = new Thread(() =>
            {
                int count = 0;
                while (true)
                {
                    Console.WriteLine($"thread 2 {count++}");
                }
            });
            thread2.Priority = ThreadPriority.Highest;


            thread1.Start();
            thread2.Start();


            Console.WriteLine("xxx");
            Console.WriteLine("xxx");
            Console.WriteLine("xxx");

            // foreground and background

            thread1.IsBackground = true;
            thread2.IsBackground = true;
            Console.ReadLine();
        }
























        ////////////////////////////////////////////////////////
        private static void Example2()
        {
            //Thread thread = new Thread(delegate()
            //{
            //    while (true)
            //    {
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Worker thread");
            //        Thread.Sleep(500);
            //    }
            //});




            new Thread(obj =>
            {
                while (true)
                {
                    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - Worker thread - {obj}");
                    Thread.Sleep(500);
                }
            }).Start(DayOfWeek.Monday);
        }














        ////////////////////////////////////////////////////////
        private static void Example1()
        {
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine(Thread.CurrentThread.Name);

            //ThreadStart  (void foo())
            //ParameterizedThreadStart (void foo(object))


            Thread thread = new Thread(Boo);
            thread.Start("own");


            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - xxx");
                Thread.Sleep(500);
            }
        }



        static void Foo()
        {
            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - yyy");
                Thread.Sleep(500);
            }
        }


        static void Boo(object obj)
        {
            while (true)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {obj}");
                Thread.Sleep(500);
            }
        }
    }
}
