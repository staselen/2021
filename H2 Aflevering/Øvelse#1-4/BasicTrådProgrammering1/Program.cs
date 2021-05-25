using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BasicTrådProgrammering1
{
    class Program
    {


        static void Main(string[] args)
        {
            //#1: Thread printing: "C#-trådning er nemt!"
            //Work class contains work(methods) for #1 & #2
            Work work = new Work();
            Thread thread1 = new Thread(work.CSharpEasy);
            thread1.Start();

            //#2: Thread printing: " Også med flere tråde …"
            Thread thread2 = new Thread(work.MoreThreads);
            thread2.Start();

            //Display #1 & #2 for 2sec, then clear console.
            Thread.Sleep(2000);
            Console.Clear();

            Temperature temperature = new Temperature();
            //Øvelse #3: Generate temperature and check for critical levels.
            Thread thread3 = new Thread(temperature.TemperatureStatus);
            thread3.Start();
            //As long as thread3 is alive, continue printing temperature in console.
            Stopwatch sw = new Stopwatch();
            while (thread3.IsAlive)
            {
                TemperaturePrint(temperature);
            }

            //Display 3# for 2sec, then clear console.
            Thread.Sleep(2000);
            Console.Clear();

            //Øvelse #4: Input/Output tråde


            //Create object of shared data for the two threads
            //You can only send objects with parameterized threads
            object obj = new SharedData();

            Thread reader = new Thread(new ParameterizedThreadStart(Reader));
            reader.Start(obj);

            Thread printer = new Thread(new ParameterizedThreadStart(Printer));
            printer.Start(obj);



        }

        //Reads user input
        static void Reader(object obj)
        {
            char temp = new char(); //temp variable
            SharedData sharedData = (SharedData)obj; //Cast the object to the class with the shared data

            while (true)
            {

                //Uden enter før input bliver registeret
                //Sets shareddata to keyboard input, printer then reads and prints it.
                sharedData.ch = Convert.ToChar(Console.ReadKey().Key);


                //Syntes at det så bedre ud uden enter før input bliver registeret
                //Men har lavet versionen med enter som er udkommenteret nedenunder

                //Saves last input to temp
                //Sets Shared varible to temp
                //Med enter før input bliver registeret
                //temp = Convert.ToChar(Console.ReadKey().Key); 
                //if (Console.ReadKey().Key == ConsoleKey.Enter)
                //{
                //    sharedData.ch = temp;
                //}
            }
        }

        //Prints user input repetedly
        static void Printer(object obj)
        {
            SharedData sharedData = (SharedData)obj;

            while (true)
            {
                Console.Write(sharedData.ch);
            }
        }

        static void TemperaturePrint(Temperature temperature)
        {
            lock (temperature.x) //Grabs the lock, forcing the status method to wait for it to be realsed.
            {
                //Checks temperature is critical or acceptable
                if (temperature.Celsius < 0 || temperature.Celsius > 100)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                //If there has not been 3 warnings, print the temperature.
                //If there has been 3 warnings notify that thread3 is terminated.
                if (temperature.Warnings < 3)
                {
                    Console.WriteLine("Temperature is: " + temperature.Celsius + "C");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Alarm... Alarm... Alarm...");
                    Console.WriteLine("Temperature changer thread terminated");
                }
                Console.ResetColor();
                Monitor.PulseAll(temperature.x); //Notifies the status method that the lock is free.
            }
            //Thread.Sleep to make sure the lock bounces back and fourth between
            //TemperaturePrint and TemperatureChange
            Thread.Sleep(50);

        }
    }
}
