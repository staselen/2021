using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public interface IAgeRestricted
    {
        public int RequiredAge { get; set; }
    }
}
