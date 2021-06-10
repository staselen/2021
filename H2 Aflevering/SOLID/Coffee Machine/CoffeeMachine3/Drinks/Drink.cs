using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    abstract class Drink
    {
        public string Name { get; protected set; }
        public Drink() 
        {
            
        }
    }
}
