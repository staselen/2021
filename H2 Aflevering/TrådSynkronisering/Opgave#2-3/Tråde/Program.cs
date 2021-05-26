using System;
using System.Threading;


namespace Tråd2
{
    class Program
    {
        static int count = 0; //Global count variable
        static object x = new object(); //Lock object

        //Extra validation, sometimes the threads would not execute in the desired order.
        //To circumvent this I added the global variable lastSymbol, then the methods can check on it
        //And if it is not their turn, then they're put on wait, untill the other method notifies them that the lock is free.
        //This also means the threads always run in correct order even without a thread.sleep to slow them down
        static string lastSymbol = null; 
        static void Main(string[] args)
        {
            //Create two threads
            //1st responsible for printing stars
            //2nd responsible for printing fences
            Thread t1 = new Thread(Star);
            Thread t2 = new Thread(Fence);

            //Start both threads
            t1.Start();
            t2.Start();
        }


        static void Star()
        {
            while (true) //The method continues looping untill application is shut down
            {
                Monitor.Enter(x); //Grabs the lock object 'x'
                try
                {
                    //Checks if the last symbol is the symbol that the method produces
                    //If it is, then puts the current thread on wait, allowing the other method to print
                    //Therefore changing the last symbol and this thread can continue executing
                    //when the other thread pulses and notifies this one.
                    while(lastSymbol == "*") 
                    {
                        Monitor.Wait(x);
                    }

                    //Loops 60 times, increasing count with one every time and writing a symbol in chat
                    for (int i = 0; i < 60; i++)
                    {
                        count++;
                        Console.Write("*");
                    }
                    lastSymbol = "*"; //Changes the global variable lastSymbol(Validation)
                    Console.Write(" " + count); //Prints the count of the global variable after it is done printing symbols
                    Console.WriteLine(); 

                }
                finally
                {
                    Monitor.PulseAll(x); //Notifies all other threads, in this case there's only one other thread
                    Monitor.Exit(x); //Releases the lock
                }
            } //Restarts the while loop.
        }

        //Both methods are practically identical so only commented the one above.
        static void Fence()
        {
            while (true)
            {
                Monitor.Enter(x);
                try
                {
                    while(lastSymbol == "#")
                    {
                        Monitor.Wait(x);
                    }
                    for (int i = 0; i < 60; i++)
                    {
                        count++;
                        Console.Write("#");
                    }
                    lastSymbol = "#";
                    Console.Write(" " + count);
                    Console.WriteLine();

                }
                finally
                {
                    Monitor.PulseAll(x);
                    Monitor.Exit(x);
                }
            }
        }
    }
}