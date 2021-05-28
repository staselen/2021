using System;
using System.Threading;

namespace Tråde
{
    class Program
    {
        //There's a fork for every philosopher, but they need two to eat so they must share.
        static void Main(string[] args)
        {
            //Craete array for 5 Philosophers
            Philosopher[] philosophers = new Philosopher[5];
            //Populate philosophers array
            for (int i = 0; i < 5; i++)
            {
                philosophers[i] = new Philosopher(i);
            }

            //Add 5 Spaghetto to each philosophers plate
            for (int i = 0; i < 5; i++)
            {
                //Spaghetto is the word for a Singular Spaghetti
                for (int s = 0; s < 5; s++)
                {
                    philosophers[i].Plate.Food.Add("Spaghetto");
                }
            }


            //Create object array of forks(locks)
            object[] forks = new object[5] { new object(), new object(), new object(), new object(), new object()};
            //Convert object array to object
            //Paramaterized Thread Starts can only take objects
            object forksConverted = forks; 
            //Create array of 5 threads(I wanted a reference to join the threads)
            Thread[] thread = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                thread[i] = new Thread(new ParameterizedThreadStart(philosophers[i].Dining));
                thread[i].Start(forksConverted); //Pass the converted fork array
            }

            //For every thread in the thread array join them
            //Makes the main thread pause untill all threads are done running.
            //Allows me to print in console when all the philosophers are done eating.
            for (int i = 0; i < 5; i++)
            {
                thread[i].Join();
            }

            Console.WriteLine("All philosophers has finished eating");

            Console.ReadKey();
        }



    }
}