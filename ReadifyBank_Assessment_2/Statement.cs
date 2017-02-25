using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadifyBank.Interfaces
{
    public class Statement : IStatementRow
    {

        public IAccount account;
        public DateTimeOffset date;
        public decimal amount;
        public string description;
        public decimal balance;

        public Statement(IAccount account1, DateTimeOffset date1, decimal amount1, string description1)
        {
            this.account = account1;
            this.date = date1;
            this.amount = amount1;
            this.description = description1;
            this.balance = account1.Balance + amount1;
        }

        public IAccount Account { get { return account; } }
        public DateTimeOffset Date { get { return date; } }
        public decimal Amount { get { return amount; } }
        public decimal Balance { get { return balance; } }
        public string Description { get { return description; } }

            
    }
}
