using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine
{
    class SolidContainer
    {
        public List<Solid> Contains { get; set; }

        public SolidContainer()
        {
            Contains = new List<Solid>();
        }
        public void FillUp(Solid content)
        {
            Contains.Add(content);
        }

        public void Empty()
        {
            Contains = new List<Solid>();
        }
    }
}
