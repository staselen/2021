using System;
using System.Threading;
using System.Diagnostics;
class ThreadPoolDemo
{
    static void Main()
    {
        Stopwatch mywatch = new Stopwatch();
        Console.WriteLine("Thread Pool Execution");
        mywatch.Start();
        ProcessWithThreadPoolMethod();
        mywatch.Stop();
        Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
        mywatch.Reset();
        Console.WriteLine("Thread Execution");
        mywatch.Start();
        ProcessWithThreadMethod();
        mywatch.Stop();
        Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
        

        Console.ReadKey();
    }

    //Metoden Process skal includere et object i den parameter
    //Det er et krav for threadpools, og uden objected kan threadpollen ikke kalde den.
    static void Process(object obj)
    {
        //Øvelse#2
        //100000 for loop ændre stort set ikke tiden
        //Time consumed by ProcessWithThreadPoolMethod is : 408420
        //Time consumed by ProcessWithThreadMethod is : 521824


        //Dog ved 100000 * 100000 er der et tydeligt delay
        //Time consumed by ProcessWithThreadPoolMethod is : 175087
        //Time consumed by ProcessWithThreadMethod is : 22018494
        //ProcessWithThreadMethod er tydeligtvis meget hurtigere
        for (int i = 0; i < 100000; i++)
        {
            for (int j = 0; j < 100000; j++)
            {
            }
        }
    }
    static void ProcessWithThreadMethod()
    {
        for (int i = 0; i <= 10; i++)
        {
            Thread obj = new Thread(Process);
            obj.Start();
        }
    }
    static void ProcessWithThreadPoolMethod()
    {
        for (int i = 0; i <= 10; i++)
        {
            ThreadPool.QueueUserWorkItem(Process);
        }
    }
}