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


            //Add beans
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
            Drink coffee = coffeeMachine.CoffeeButton();

            if(coffee == null)
            {
                Console.WriteLine("Couldn't make coffee");
            }
            else
            {
                Console.WriteLine("Made a cup of "+ coffee.Name);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(coffeeMachine.ToString());

            Console.WriteLine("Press enter to make Tea");
            Console.ReadKey();

            //Make a cup of coffe
            Drink tea = coffeeMachine.TeaButton();

            if (tea == null)
            {
                Console.WriteLine("Couldn't make Tea");
            }
            else
            {
                Console.WriteLine("Made a cup of " + tea.Name);
            }

            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(coffeeMachine.ToString());


            Console.ReadKey();
        }
    }
}
