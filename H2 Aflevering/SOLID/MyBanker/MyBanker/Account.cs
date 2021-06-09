using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Account
    {
        private int[] AccountNumber { get; set; }
        public double Balance { get; private set; }
        public List<Card> Cards { get; private set; }
        //Can have multiple cards connected to same account (Shared economy between couples)
        public Account(int[] accountNumber, double balance, List<Card> cards)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Cards = cards;
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }
        
    }

    
}
