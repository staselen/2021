using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public abstract class Caster : Character
    {   //Superclass of caster. In current version might aswell not be there, but for future implementation.
        //Fight and Caster fx might have different restrictions for armor...
        public Caster(string name) : base(name)
        {
            Name = name;
        }
    }
}
