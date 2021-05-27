using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tråde
{
    class Philosopher
    {
        public int Position { get; set; } //The position of the Philosopher on the table 
        public Plate Plate { get; set; } //The plate assigned to the Philosopher

        public Philosopher(int position)
        {
            Position = position; //Sets the position with the parameter
            Plate = new Plate(); //New plate
            Plate.Food = new List<string>(); //New list of food on plate
        }

        public void Dining(object forksConverted)
        {
            //Converts object back to fork array
            object[] forks = (object[])forksConverted;

            Random r = new Random();

            //Run while there is food on the plate of the philosopher
            while (Plate.Food.Count != 0)
            {
                //Philosopher is thinking
                Console.WriteLine("Philospher[{0}] Is thinking...", Position + 1, Math.Min(Position, (Position + 1) % 5));
                Thread.Sleep(r.Next(5000));

                //Calculation explained:
                //% is Modulus, which returns the remainder of the division of two numbers
                //If you calculate the modulus of two of the same number it will return 0
                //This means that we can use modulus here to ensure that one philosopher
                //(The last one) Grabs the forks in a different order than the rest.
                //Every philosopher aside from the last will first take the fork correspondeing to their position
                //(Philo#0 starts with fork#0) but the last philosopher will also start with 0
                //Therefore preventing the possibilty of a deadlock.
                //First - Last
                //0     - 1
                //1     - 2
                //2     - 3
                //3     - 4
                //0     - 4

                //Philosopher picks up first fork
                lock (forks[Math.Min(Position, (Position + 1) % 5)])
                {
                    //Philosopher picks up second fork
                    Console.WriteLine("Philospher[{0}] picked up fork[{1}]", Position + 1, Math.Min(Position, (Position + 1) % 5) + 1);
                    lock (forks[Math.Max(Position, (Position + 1) % 5)])
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Philospher[{0}] picked up fork[{1}]", Position + 1, Math.Max(Position, (Position + 1) % 5) + 1);
                        Thread.Sleep(200);
                        Console.WriteLine("Philospher[{0}] starts eating", Position + 1);
                        Thread.Sleep(5000);
                        //Philosopher has eaten
                        Plate.Food.RemoveAt(0); //Removes the eaten piece of food from plate
                        Console.WriteLine("Philospher[{0}] is done eating", Position + 1);

                        Thread.Sleep(350);
                        //Philosopher puts down second fork
                        Console.WriteLine("Philospher[{0}] puts down fork[{1}]", Position + 1, Math.Max(Position, (Position + 1) % 5) + 1);
                    }
                    Thread.Sleep(500);
                    //Philosopher puts down fork first
                    Console.WriteLine("Philospher[{0}] puts down fork[{1}]", Position + 1, Math.Min(Position, (Position + 1) % 5) + 1);
                }

            }
            //Philosophers plate is empty
            Console.WriteLine("Philospher[{0}] plate is empty", Position + 1);
        }





    }
}
