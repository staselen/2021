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

            //Make a cup of coffe
            Cup cup = coffeeMachine.Make("Coffee");


            if(cup == null)
            {
                Console.WriteLine("Couldn't make coffee");
            }
            else
            {
                Console.WriteLine("Made a cup of "+cup.Name);
            }


            Console.ReadKey();
        }
    }
}
