using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Maestro : Card, IDebetCard, IGlobalUsage, IAgeRestricted, IExpirationDate
    {
        public Maestro(Account connectedAccount, Type type, string owner, int[] cardNumber) : base(connectedAccount, type, owner, cardNumber)
        {
            RequiredAge = 18;
            ExpirationDate = DateTime.Now.AddYears(5).AddMonths(8);
        }
        public DateTime ExpirationDate { get; set; }
        public int RequiredAge { get; set; }

        public void UseInternationally(double amount)
        {
            ImmediatePayment(amount);
        }

        public void UseOnline(double amount)
        {
            ImmediatePayment(amount);
        }

        public double ImmediatePayment(double amount)
        {
            if (Account.Balance >= amount)
            {
                Account.Withdraw(amount);
                return amount;
            }
            else
            {
                return 0;
            }

        }

        public override string ToString()
        {
            return base.ToString() +
            "\nRequired Age: " + RequiredAge +
            "\nExpirtion Date: " + ExpirationDate;
        }

    }
}
