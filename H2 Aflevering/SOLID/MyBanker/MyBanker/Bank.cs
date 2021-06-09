using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    //Class responsible for creating the cards
    class Bank
    {
        //Bank has access to a credit card printer
        public CreditCardPrinter CreditCardPrinter { get; private set; }

        public Bank()
        {
            //Credit card printer is created with the bank, as it is apart of the bank entity
            this.CreditCardPrinter = new CreditCardPrinter();
        }

        public void ConnectCardToAccount(Account Account, Card card)
        {
            Account.AddCard(card);
        }

        public void RegisterAccount(Customer customer)
        {
            customer.AddAccount( new Account(GenerateAccountNumber(), 0, new List<Card>()));
        }

        public int[] GenerateAccountNumber()
        {
            Random r = new Random();
            int[] Prefix = { 3, 5, 2, 0 };
            int[] AccountNumber = new int[Prefix.Length + 14];


            for (int i = Prefix.Length; i < 14; i++)
            {
                AccountNumber[i] = r.Next(10);
            }
            return AccountNumber;
        }
    }

    
}
