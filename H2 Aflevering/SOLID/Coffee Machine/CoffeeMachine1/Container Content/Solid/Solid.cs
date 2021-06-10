using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    abstract class Solid //Things that can be grinded in the coffee machine
    {
        public string Name { get; protected set; }
        public Solid()
        {

        }
    }
}
