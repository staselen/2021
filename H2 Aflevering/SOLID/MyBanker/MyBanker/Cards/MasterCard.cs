using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class MasterCard : Card, ICreditCard, IExpirationDate 
    {
        public MasterCard(Account connetedAccount, Type type, string owner, int[] cardNumber) : base(connetedAccount, type, owner, cardNumber)
        {
            MonthlyWithdrawalLimit = 30000;
            DailyWithdrawalLimit = 5000;
            MonthlyCreditLimit = 40000;
            ExpirationDate = DateTime.Now.AddYears(5);
        }

        public DateTime ExpirationDate { get; set; }
        public double MonthlyWithdrawalLimit { get; set; }
        public double DailyWithdrawalLimit { get; set; }
        public double MonthlySpentCredit { get; set; }
        public double MonthlyCreditLimit { get; set; }
        public double CreditPayment(double amount)
        {
            if (Account.Balance >= amount) //If there's enough money on the account
            {
                Account.Withdraw(amount);
                return amount;
            }
            else
            {
                if (MonthlyCreditLimit + Account.Balance > MonthlyCreditLimit + amount)
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
            "\nMonthly Withdrawal Limit: " + MonthlyWithdrawalLimit+
            "\nDaily Withdrawal Limit: " + DailyWithdrawalLimit +
            "\nMonthly Credit Limit: " + MonthlyCreditLimit +
            "\nExpirtion Date: " + ExpirationDate;
        }
    }
}
