using System;
using System.Collections.Generic;

namespace Lone
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create all classes
            List<Character> characters = new List<Character>
            {
                new Wizard("Eric"),
                new Barbarian("Smog-Smog"),
                new Knight("Alex"),
                new Witch("Ulla")
            };

            //Demonstration that it works.
            if (characters[0] is Wizard wizard)
                wizard.Teleport(8101, 419);

            if (characters[1] is Barbarian)
                ((Barbarian)characters[0]).Slash();
        }
    }
}
