using System;
using System.Collections.Generic;

namespace MyBanker
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(); 

            Customer customer = new Customer("Mads"); 

            //Add account to customer by registering an account in the bank class.
            //(The bank is responsible for the connection)
            bank.RegisterAccount(customer);

            //Use bank.CreditCardPrinter to print a new card foreach type of credit card 
            //Then connect it to the first account in customers list of accounts
            //Using the method ConnectCardToAccount from the bank.
            foreach (var type in Enum.GetValues(typeof(Type)))
            {
                bank.ConnectCardToAccount(customer.Accounts[0], bank.CreditCardPrinter.PrintCard((Type)type, customer.Name, customer.Accounts[0]));
            }


            //Prints out information of all cards.

            for (int i = 0; i < customer.Accounts[0].Cards.Count; i++)
            {
                Console.WriteLine(customer.Accounts[0].Cards[i].ToString());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
