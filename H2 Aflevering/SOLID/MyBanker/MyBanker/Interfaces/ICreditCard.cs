using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    public interface ICreditCard
    {
        public double MonthlyWithdrawalLimit { get; set; }
        public double DailyWithdrawalLimit { get; set; }
        public double MonthlySpentCredit { get; set; }
        public double MonthlyCreditLimit { get; set; }
        double CreditPayment(double amount);
    }
}
