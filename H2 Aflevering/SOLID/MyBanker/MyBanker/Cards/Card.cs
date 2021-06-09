using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    abstract class Card
    {
        private Type CardType { get; set; }
        private string Owner { get; set; }
        private int[] CardNumber { get; set; }
        private double Balance { get; set; }
        protected Account Account { get; set; }

        public Card(Account connectedAccount, Type type, string owner, int[] cardNumber)
        {
            Account = connectedAccount;
            CardType = type;
            Owner = owner;
            CardNumber = cardNumber;
        }

        //ToString of all the information all the cards have in common,
        //subclasses then uses scafolding to add on top of the default value
        public override string ToString()
        {
            string scn = string.Join("", CardNumber);

            return
                "Card type: " + CardType + "\n" +
                "Owner by: " + Owner + "\n" +
                "Card number: " + scn + "\n" +
                "Balance: " + Balance;

        }




    }






}
