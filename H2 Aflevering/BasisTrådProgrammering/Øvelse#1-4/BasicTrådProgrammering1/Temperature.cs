using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BasicTrådProgrammering1
{
    public class Temperature
    {
        public object x = false; //Lock object for threads
        public int Celsius { get; set; }
        public int Warnings { get; set; }

        public Temperature()
        {
            Celsius = 100; //Initial temperature
            Warnings = 0;  //Initial warnings
        }

        Random r = new Random();

        //Function keep track of the statue of the temperature(celsius and warnings).
        public void TemperatureStatus()
        {
            //As long as there has not been 3 warnings the thread will continue to run
            while (Warnings < 3) 
            {
                lock(x) //Grabs the lock, forcing the print method to wait for it to be realsed.
                {
                    Thread.Sleep(100); //Waits for 1 sec
                    TemperatureWarning(); 
                    TemperatureUpdate();  
                    Monitor.PulseAll(x); //Notifies the print method that the lock is free.
                }
            }
        }

        public void TemperatureWarning()
        {
            if (Celsius < 0 || Celsius > 100) //Checks if temperature is critical.
            {
                Warnings++; //Adds a warning, if temperature is critical.
            }
        }
        public void TemperatureUpdate()
        {
            Celsius = r.Next(-20, 121); //Sets a new temperature
        }

        
    }
}
