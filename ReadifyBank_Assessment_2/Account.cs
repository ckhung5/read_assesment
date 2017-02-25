using System;



namespace ReadifyBank.Interfaces
{
    public class Account : IAccount
    {
        public DateTimeOffset openDate;
        public string customerName;
        public string accountNumber;
        public decimal balance;

        public Account(string name, DateTimeOffset opendate,string type,int AccountNum)
        {
            this.openDate = opendate;
            this.customerName = name;
            this.balance = 0;
            if (type == "Loan")
            {
                
                this.accountNumber = "LN-00000" + Convert.ToString(AccountNum);
            }

            if (type == "Savings")
            {
                this.accountNumber = "SV-00000" + Convert.ToString(AccountNum);
            }

        }

        public DateTimeOffset OpenedDate { get { return openDate; } }
        public string CustomerName { get { return customerName;} }
        public string AccountNumber { get { return accountNumber; } }
        public decimal Balance { get { return balance; } }

        public void AddUp(decimal amount)
        {
            this.balance = this.balance + amount;
        }

        public void Minus(decimal amount)
        {
            this.balance = this.balance - amount;
        }
 
 
    }
}
