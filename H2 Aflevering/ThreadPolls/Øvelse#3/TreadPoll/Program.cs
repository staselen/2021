using System;
using System.Threading;
using System.Diagnostics;
class ThreadPoolDemo
{
    static void Main()
    {
        for (int i = 0; i <= 10; i++)
        {
            ThreadPool.QueueUserWorkItem(ThreadStatus);
        }

        Thread thread1 = new Thread(Procces);

        thread1.Start();

        Thread.Sleep(1000);

        Console.WriteLine(thread2.ThreadState); 

        //Suspend, Resume, Abort is no longer supported...

        Console.ReadKey();
    }
    static Thread thread2 = new Thread(Procces2);
    static void Procces(object obj)
    {
        thread2.Start();
        
        thread2.Join();
    }
    static void Procces2(object obj)
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {

            }
        }
    }

    static void ThreadStatus(object obj)
    {

        //Gives some slightly random properties for the threads.
        ThreadRandomize(obj);

        //Prints state of thread with their respective thread IDs.
        Console.WriteLine("Thread(" + Thread.CurrentThread.ManagedThreadId + ")IsAlive: " + Thread.CurrentThread.IsAlive);
        Console.WriteLine("Thread(" + Thread.CurrentThread.ManagedThreadId + ")IsBackground: " + Thread.CurrentThread.IsBackground);
        Console.WriteLine("Thread(" + Thread.CurrentThread.ManagedThreadId + ")Priority: " + Thread.CurrentThread.Priority);

    }

    static void ThreadRandomize(object obj)
    {
        Random r = new Random();
        if (r.Next(0, 2) == 1)
        {
            Thread.CurrentThread.IsBackground = false;
        }
        if (r.Next(0, 2) == 1)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
        }
        if (r.Next(0, 2) == 1)
        {
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
        }
    }

}