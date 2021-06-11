using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public abstract class Character
    {   //Class containing the things that all the classes have in common.
        //Name, hp, die and fight.
        public string Name { get; protected set; }
        public int HP { get; protected set; }

        public Character(string name)
        {
            Name = name;
        }
        public abstract void Die();
        public abstract void Fight();
    }
}
