using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class VisaElectron : Card, IDebetCard, IGlobalUsage, IAgeRestricted
    {
        public VisaElectron(Account connectedAccount, Type type, string owner, int[] cardNumber) : base(connectedAccount, type, owner, cardNumber)
        {
            RequiredAge = 15;
            MonthlySpendingLimit = 10000;
            MonthlySpending = 0;
        }
        private double MonthlySpendingLimit { get; set; } //Monthly max allowed amount to spent
        private double MonthlySpending { get; set; }      //Monthly amount spent
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
            "\nMonthly Spending Limit: " + MonthlySpendingLimit +
            "\nRequired Age: " + RequiredAge;
        }
    }
}
