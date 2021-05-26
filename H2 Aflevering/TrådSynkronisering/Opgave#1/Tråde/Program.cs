using System;
using System.Threading;


namespace Tråd2
{
    class Program
    {
        //Global variable
        static int count = 0; 

        //'Lock' used to lock the global variable 'count'
        static object x = new object(); 

        static void Main(string[] args)
        {
            //Create two threads,
            //1st to increment by two
            //2nd to minus by one
            Thread t1 = new Thread(IncrementTwo);
            Thread t2 = new Thread(MinusOne);

            //Start both threads
            t1.Start();
            t2.Start();
        }

        //Function to increment the global variable 'count' by two
        static void IncrementTwo(object arg)
        {
            while (true)
            {
                Monitor.Enter(x); //Thread grabs the lock
                try
                {
                    count += 2; //Increments count by two
                    //Displays Thread ID, plus signs visuals to indicate increment and the value of the global variable
                    Console.WriteLine("ThreadID:{0} | +   + | Total:{1}", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(1000); //Sleep for one sec

                }
                finally
                {
                    Monitor.Exit(x); //Thread releases the lock
                }

            }
        }

        //Function to minus the global variable 'count' by one
        static void MinusOne(object arg)
        {
            while (true)
            {
                Monitor.Enter(x);  //Thread grabs the lock
                try
                {
                    count--; //Minus count by one
                    //Displays Thread ID, minus sign to indicate reduction and the value of the global variable
                    Console.WriteLine("ThreadID:{0} |   -   | Total:{1}", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(1000); //Sleep for one sec
                }
                finally
                {
                    Monitor.Exit(x);  //Thread releases the lock
                }

            }
        }
    }
}