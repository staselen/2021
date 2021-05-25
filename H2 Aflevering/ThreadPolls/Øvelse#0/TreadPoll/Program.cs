using System;
using System.Threading;
class ThreadPoolDemo
{
    //Print to console 2. times
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    //Print to console 2. times
    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        //Create threadpool
        ThreadPoolDemo tpd = new ThreadPoolDemo();
        //Add two threads to threadpool tree times.
        //For a total of 12 console prints 2*3*2
        for (int i = 0; i < 2; i++)
        {
            //There's no difference in the output.
            //WaitCallback puts it in a queue awaiting execution.
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
        }

        Console.Read();
    }
}