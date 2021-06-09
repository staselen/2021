using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBanker
{
    class Customer
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        //Taking inspiration from real life I wanted customer to have the ability to have multiple accounts
        public Customer(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}
