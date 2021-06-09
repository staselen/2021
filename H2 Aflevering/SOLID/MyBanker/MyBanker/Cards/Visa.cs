using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Visa : Card, ICreditCard, IAgeRestricted, IExpirationDate
    {
        public Visa(Account connectedAccount, Type type, string owner, int[] cardNumber) : base(connectedAccount, type, owner, cardNumber)
        {
            RequiredAge = 18;
            MonthlyCreditLimit = 20000;
            MonthlyWithdrawalLimit = 25000;
            DailyWithdrawalLimit = 25000;
            ExpirationDate = DateTime.Now.AddYears(5);
        }

        public DateTime ExpirationDate { get; set; }
        public int RequiredAge { get; set; }
        public double MonthlyWithdrawalLimit { get; set; }
        public double DailyWithdrawalLimit { get; set; }
        public double MonthlySpentCredit { get; set; }
        public double MonthlyCreditLimit { get; set; }
        public double CreditPayment(double amount)
        {
            if(Account.Balance >= amount) //If there's enough money on the account
            {
                Account.Withdraw(amount);
                return amount;
            }
            else
            {
                if(MonthlyCreditLimit + Account.Balance > MonthlyCreditLimit+amount)
                {
                    MonthlyCreditLimit += amount - Account.Balance;
                    Account.Withdraw(Account.Balance);
                    return amount;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString() +
            "\nMonthly Withdrawal Limit: " + MonthlyWithdrawalLimit +
            "\nDaily Withdrawal Limit: " + DailyWithdrawalLimit +
            "\nMonthly Credit Limit: " + MonthlyCreditLimit +
            "\nRequired Age: " + RequiredAge +
            "\nExpirtion Date: " + ExpirationDate;
        }
    }
}
