using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lone
{
    public class Witch : Caster, ITeleport, IHeal, IThrowMagicMissile
    {
        public Witch(string name) :base(name)
        {
            Name = name;
            HP = 90;
        }
        public override void Die()
        {
            throw new NotImplementedException();
        }

        public void Teleport()
        {
            throw new NotImplementedException();
        }

        public void Heal()
        {
            throw new NotImplementedException();
        }


        public void ThrowMagicMissile()
        {
            throw new NotImplementedException();
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }
    }
}
