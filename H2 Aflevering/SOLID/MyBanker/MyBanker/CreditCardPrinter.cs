using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class CreditCardPrinter
    {
        public Card PrintCard(Type type, string name, Account account)
        {
            switch (type)
            {
                case Type.Mastercard:
                    return new MasterCard(account, type, name, GenerateCardNumber(type));
                case Type.Maestro:
                    return new Maestro(account, type, name, GenerateCardNumber(type));
                case Type.Visa:
                    return new Visa(account, type, name, GenerateCardNumber(type));
                case Type.VisaElectron:
                    return new VisaElectron(account, type, name, GenerateCardNumber(type));
                case Type.Hævekort:
                    return new Hævekort(account, type, name, GenerateCardNumber(type));
                default: //Never reached, but need a default for method to work.
                    return new MasterCard(account, type, "error", GenerateCardNumber(type));
            }
        }

        public int[] GenerateCardNumber(Type type)
        {
            Random r = new Random();
            List<string> Prefixes = new List<string>();
            switch (type)
            {
                case Type.Mastercard:
                    Prefixes = new List<string>{ "51", "52", "53", "54", "55" };
                    break;
                case Type.Maestro:
                    Prefixes = new List<string> { "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763" };
                    break;
                case Type.Visa:
                    Prefixes = new List<string> { "4" };
                    break;
                case Type.VisaElectron:
                    Prefixes = new List<string> { "4026", "417500", "4508", "4844", "4913", "4917" };
                    break;
                case Type.Hævekort:
                    Prefixes = new List<string> { "2400" };
                    break;
            }

            int index = r.Next(Prefixes.Count); //Random index of the prefixes

            char[] c = Prefixes[index].ToCharArray(); //Make the chosen prefix into a char array(2400 >> 2,4,0,0)


            List<int> CardNumber = new List<int>();

            for (int i = 0; i < c.Length; i++)
            {
                CardNumber.Add(Convert.ToInt32(Char.GetNumericValue(c[i])));
            }


            if (type == Type.Maestro)
            {
                for (int i = 0; i < 19 - c.Length; i++)
                {
                    CardNumber.Add(r.Next(10));
                }
            }
            else
            {
                for (int i = 0; i < 16 - c.Length; i++)
                {
                    CardNumber.Add(r.Next(10));
                }
            }

            return CardNumber.ToArray();
        }
    }
}
