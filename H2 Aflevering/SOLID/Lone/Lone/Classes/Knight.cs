using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public class Knight : Fighter, IRaiseShield, IShieldGlare, ISlash, ICleave
    {
        public Knight(string name) :base(name)
        {
            Name = name;
            HP = 200;
        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void RaiseShield()
        {
            throw new NotImplementedException();
        }

        public void ShieldGlare()
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

        public override void Fight()
        {
            throw new NotImplementedException();
        }

        
    }
}
