using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BasicTrådProgrammering1
{
    public class Work
    {
        public void CSharpEasy()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("C#-trådning er nemt!");
                Thread.Sleep(50);
            }
        }
        public void MoreThreads()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(" Også med flere tråde …");
                Thread.Sleep(50);
            }
        }
    }
}
