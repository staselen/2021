using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public class Barbarian : Fighter, IBash, ISlash, ICleave
    {
        public Barbarian(string name) : base(name)
        {
            Name = name;
            HP = 150;
        }
        public void Bash()
        {
            throw new NotImplementedException();
        }
        public void Slash()
        {
            throw new NotImplementedException();
        }

        public void Cleave()
        {
            throw new NotImplementedException();
        }


        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }


        
    }
}
