using System
    ;

namespace CoffeeMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create machine
            CoffeeMachine coffeeMachine = new CoffeeMachine();


            //Add Beans
            for (int i = 0; i < 20; i++)
            {
                coffeeMachine.AddBeans();

            }

            //Add Water
            for (int i = 0; i < 5; i++)
            {
                coffeeMachine.AddWater();
            }

            //Add filter
            coffeeMachine.AddFilter();

            //Turn on machine
            coffeeMachine.Power = true;

            //Print status
            Console.WriteLine(coffeeMachine.Status()+"\n");

            //Make a cup of Tea
            Cup cup = coffeeMachine.Make("Tea");
            if(cup == null)
            {
                Console.WriteLine("Couldn't make " + cup.Name);
            }
            else
            {
                Console.WriteLine("Made a cup of "+cup.Name);
            }

            //Make a cup of Espresso
            Cup cup3 = coffeeMachine.Make("Espresso");
            if (cup3 == null)
            {
                Console.WriteLine("Failed... Check status...");
            }
            else
            {
                Console.WriteLine("Made a cup of " + cup3.Name);
            }

            //Make a cup of Coffee
            Cup cup2 = coffeeMachine.Make("Coffee");
            if (cup2 == null)
            {
                Console.WriteLine("Failed... Check status...");
            }
            else
            {
                Console.WriteLine("Made a cup of " + cup2.Name);
            }

            


            Console.WriteLine("\n"+coffeeMachine.Status());

            Console.ReadKey();
        }
    }
}
