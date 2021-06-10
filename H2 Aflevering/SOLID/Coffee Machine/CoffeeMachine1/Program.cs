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


            //Add a single bean
            coffeeMachine.AddBeans(10);

            //Add Water
            coffeeMachine.AddWater(10);

            //Add filter
            coffeeMachine.AddFilter();

            //Turn on machine
            coffeeMachine.PowerButton();

            //Print status
            Console.WriteLine(coffeeMachine.ToString());
            Console.WriteLine("Press enter to make coffee");
            Console.ReadKey();

            //Make a cup of coffe
            Drink drink = coffeeMachine.CoffeeButton();

            if(drink == null)
            {
                Console.WriteLine("Couldn't make coffee");
            }
            else
            {
                Console.WriteLine("Made a cup of "+ drink.Name);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(coffeeMachine.ToString());

            Console.ReadKey();
        }
    }
}
