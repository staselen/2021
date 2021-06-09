using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Hævekort : Card, IDebetCard
    {
        public Hævekort(Account connectedAccount, Type type, string owner, int[] cardNumber): base (connectedAccount,type, owner, cardNumber)
        {

        }
        public double ImmediatePayment(double amount)
        {
            if(Account.Balance >= amount)
            {
                Account.Withdraw(amount);
                return amount;
            }
            else
            {
                return 0;
            }
        }
        //No ToString because no new information is added
    }
}
