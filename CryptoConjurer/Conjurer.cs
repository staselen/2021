using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoConjurer
{
    class Conjurer
    {
        public double Ethereum { get; set; }
        public double Epc { get; set; }
        public double Eps { get; set; }

        public Conjurer(double e, double epc, double eps)
        {
            Ethereum = e;
            Epc = epc;
            Eps = eps;
        }


    }
}
