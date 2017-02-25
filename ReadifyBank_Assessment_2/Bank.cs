using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReadifyBank.Interfaces
{
    public class Bank : IReadifyBank
    {
        List<IAccount> accountlist = new List<IAccount>();
        List<IStatementRow> StateList = new List<IStatementRow>();

        public IList<IAccount> AccountList
        {
            get
            {
                return accountlist;
            }
        }

        public IList<IStatementRow> TransactionLog { get { return StateList; } }

        public IAccount OpenHomeLoanAccount(string customerName, DateTimeOffset openDate)
        {
            int count = 1;
            for (int t = 0; t < accountlist.Count; t++)
            {

                if (accountlist[t].AccountNumber.Contains("LN"))
                {
                    count += 1;
                    Console.WriteLine(count);
                }

            }
            IAccount HomeLoanAccount = new Account(customerName, openDate, "Loan", count);
            Console.WriteLine("Home Loan Account open succeed!!");
            accountlist.Add(HomeLoanAccount);
            return HomeLoanAccount;

        }

        public IAccount OpenSavingsAccount(string customerName, DateTimeOffset openDate)
        {
            int count = 1;
            for (int t = 0; t < accountlist.Count; t++)
            {

                if (accountlist[t].AccountNumber.Contains("SV"))
                {
                    count += 1;
                }

            }
            IAccount SavingsAccount = new Account(customerName, openDate, "Savings", count);
            Console.WriteLine("Savings Account open succeed!!");
            accountlist.Add(SavingsAccount);
            return SavingsAccount;
        }

        public void PerformDeposit(IAccount account, decimal amount, string description, DateTimeOffset depositDate)
        {
            IStatementRow DepositStatement = new Statement(account, depositDate, amount, description);
            Console.WriteLine("Desposit succeed!!");
            StateList.Add(DepositStatement);

        }

        public void PerformWithdrawal(IAccount account, decimal amount, string description, DateTimeOffset withdrawalDate)
        {
            IStatementRow WithdrawStatement = new Statement(account, withdrawalDate, -(amount), description);
            Console.WriteLine("Withdraw succeed!!");
            StateList.Add(WithdrawStatement);
        }

        public void PerformTransfer(IAccount from, IAccount to, decimal amount, string description, DateTimeOffset transferDate)
        {
            //Transfer From
            IStatementRow TransferFromStatement = new Statement(from, transferDate, -(amount), description);
            Console.WriteLine("Transferring From!!");
            StateList.Add(TransferFromStatement);
            //Transfer To
            IStatementRow TransferToStatement = new Statement(to, transferDate, amount, description);
            Console.WriteLine("Transferring to!!");
            StateList.Add(TransferToStatement);
        }

        public decimal GetBalance(IAccount account)
        {
            return account.Balance;
        }

        public decimal CalculateInterestToDate(IAccount account, DateTimeOffset toDate)
        {
            TimeSpan difference;
            difference = toDate - account.OpenedDate;
            Console.WriteLine("Interest According to Days");
            Console.WriteLine(" {0} days", difference.Days);
            decimal result = 0;
            if (account.AccountNumber.Contains("LN"))
            {
                Console.WriteLine("Home Loan Account Interest is 3.99 per year");
                result = Convert.ToDecimal((3.99 / 100.0) * (difference.Days / 365.0));

            }
            if (account.AccountNumber.Contains("SV"))
            {
                Console.WriteLine("Home Loan Account Interest is 6.0% per month");
                result = Convert.ToDecimal((6.0 / 100.0) * (difference.Days / 30.0));

            }
            Console.Write("Total current Interest:");
            Console.Write("$");
            return result;
        }

        public IEnumerable<IStatementRow> GetMiniStatement(IAccount account)
        {
            // in bank transaction log find related transactoin of account 
            // reverse and then return last 5 transaction
            List<IStatementRow> NewList = new List<IStatementRow>();
            for (int a = 0; a < StateList.Count; a++)
            {
                if (StateList[a].Account.AccountNumber == account.AccountNumber)
                {
                    NewList.Add(StateList[a]);
                }
            }
            int cal = NewList.Count - 5;
            if (cal < 5)
            {
                cal = 0;
            }
            return NewList.Skip(cal);

            // IEnumerable<IStatementRow> list = GetMiniStatement(arg1).OrderByDescending(x => x.FieldName).Take(5);
            // return Enumerable.Reverse(account).Take(5);

        }

        public IEnumerable<IStatementRow> CloseAccount(IAccount account, DateTimeOffset closeDate)
        {
            List<IStatementRow> NewList = new List<IStatementRow>();
            for (int a = 0; a < StateList.Count; a++)
            {
                
                if (StateList[a].Account.AccountNumber == account.AccountNumber)
                {
                    
                    NewList.Add(StateList[a]);
                }
                
            }
  
            return NewList;
        }
    }
}
