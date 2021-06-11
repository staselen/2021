using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public class Wizard : Caster , ITeleport, IThrowFrostNova, IThrowMagicMissile
    {
        public Wizard(string name) :base(name)
        {
            Name = name;
            HP = 100;
        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }

        public void Teleport(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ThrowFrostNova()
        {
            throw new NotImplementedException();
        }

        public void ThrowMagicMissile()
        {
            throw new NotImplementedException();
        }

        
    }
}
