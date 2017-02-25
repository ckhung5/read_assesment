using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ReadifyBank.Interfaces
{
    class program
    {
        static void Main(string[] args)
        {
            //create bank object
            IReadifyBank NewBank = new Bank();
            string input;
            //Program Start
            do
            {
                //Select Options:
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Welcome to the IReadify BANK");
                Console.WriteLine("1-Create a New bank account");
                Console.WriteLine("2-View all the account in this bank");
                Console.WriteLine("3-Deposit");
                Console.WriteLine("4-Withdraw");
                Console.WriteLine("5-Transfer");
                Console.WriteLine("6-View All Statements");
                Console.WriteLine("7-Check current Interest");
                Console.WriteLine("8-Close Account");
                Console.WriteLine("9-Get Mini Statement");
                Console.WriteLine("10-Get Account Balance");
                Console.WriteLine("exit-To end program");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();
              
               input = Console.ReadLine();
               // Creating new Account base one selection
               if (input == "1")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Create Account Page");
                   Console.WriteLine("----------------");
                   string selector;
                   Console.WriteLine("1-Home Load Account");
                   Console.WriteLine("2-Savings Account");
                   selector = Console.ReadLine();
                   // Having to choose which type of account to create as
                   if (selector == "1")
                   {
                       Console.WriteLine("Please key in a name for your account");
                       string name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                       var newAcc = NewBank.OpenHomeLoanAccount(name, DateTimeOffset.Now);
                       Console.WriteLine();
                       Console.WriteLine("Home Loan Account Details");
                       Console.WriteLine("------");
                       Console.Write("Customer Name:");
                       Console.WriteLine(newAcc.CustomerName);
                       Console.Write("Account Number:");
                       Console.WriteLine(newAcc.AccountNumber);
                       Console.Write("Balance:");
                       Console.WriteLine(newAcc.Balance);
                       Console.Write("Open Date:");
                       Console.WriteLine(newAcc.OpenedDate);
                       Console.WriteLine("------");
                       Console.WriteLine();

                   }
                   if (selector == "2")
                   {
                       Console.WriteLine("Please key in a name for your account");
                       string name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                       var newAcc = NewBank.OpenSavingsAccount(name, DateTimeOffset.Now);
                       Console.WriteLine();
                       Console.WriteLine("Savings Account Details");
                       Console.WriteLine("------");
                       Console.Write("Customer Name:");
                       Console.WriteLine(newAcc.CustomerName);
                       Console.Write("Account Number:");
                       Console.WriteLine(newAcc.AccountNumber);
                       Console.Write("Balance:");
                       Console.WriteLine(newAcc.Balance);
                       Console.Write("Open Date:");
                       Console.WriteLine(newAcc.OpenedDate);
                       Console.WriteLine("------");
                       Console.WriteLine();
                   }

                   if (selector != "2" && selector != "1") // IF nothing is selected or selected wrong, there will be no account created.
                   {
                       Console.WriteLine();
                       Console.WriteLine("------");
                       Console.WriteLine("No Account is created.");
                       Console.WriteLine("------");
                       Console.WriteLine();
                   }
               }
               // To view all accounts in the bank.
               if (input == "2")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Listing Page");
                   Console.WriteLine("----------------");
                   if (NewBank.AccountList.Count != 0)
                   {
                       for (int i = 0; i < NewBank.AccountList.Count; i++)
                       {
                           Console.WriteLine();
                           Console.WriteLine("Account Details");
                           Console.WriteLine("------");
                           Console.Write("Customer Name:");
                           Console.WriteLine(NewBank.AccountList[i].CustomerName);
                           Console.Write("Account Number:");
                           Console.WriteLine(NewBank.AccountList[i].AccountNumber);
                           Console.Write("Balance:");
                           Console.WriteLine(NewBank.AccountList[i].Balance);
                           Console.Write("Member Since:");
                           Console.WriteLine(NewBank.AccountList[i].OpenedDate);
                           Console.WriteLine("------");
                           Console.WriteLine();
                       }
                   }
                   else
                   {
                       Console.WriteLine();
                       Console.WriteLine("----------------");
                       Console.WriteLine("There is no account in this bank");
                       Console.WriteLine("----------------");
                       Console.WriteLine();
                   }
               }

               // To Deposit into the Account.
               if (input == "3")
               {
                       Console.WriteLine("----------------");
                       Console.WriteLine("Account Deposit Page");
                       Console.WriteLine("----------------");
                       int w = 0;
                       Console.WriteLine("Deposit to Account");
                       Console.WriteLine("Please Key in your account number");
                       string accNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                       Console.WriteLine("Please Key in your name");
                       string CusName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                       do
                       {
                           //check whether there is the account that keyed in
                           if (w == NewBank.AccountList.Count)
                           {
                               Console.WriteLine();
                               Console.WriteLine("--------------");
                               Console.WriteLine("No such account");
                               Console.WriteLine("Please key in the right information");
                               Console.WriteLine("---------------");
                               Console.WriteLine();
                               break;
                           }
                           else
                           {
                               //Check the details meets the Account List or not.
                               if (NewBank.AccountList[w].AccountNumber == accNum && NewBank.AccountList[w].CustomerName == CusName)
                               {

                                   Console.WriteLine();
                                   Console.WriteLine("Account Details");
                                   Console.WriteLine("------");
                                   Console.Write("Customer Name:");
                                   Console.WriteLine(NewBank.AccountList[w].CustomerName);
                                   Console.Write("Account Number:");
                                   Console.WriteLine(NewBank.AccountList[w].AccountNumber);
                                   Console.Write("Balance:");
                                   Console.WriteLine(NewBank.AccountList[w].Balance);
                                   Console.Write("Member Since:");
                                   Console.WriteLine(NewBank.AccountList[w].OpenedDate);
                                   Console.WriteLine("------");
                                   Console.WriteLine();
                                   Console.WriteLine("Amount to Deposit?");
                                   string deposit = Console.ReadLine();
                                   Console.WriteLine("Description?");
                                   string Ddescription = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                                   NewBank.PerformDeposit(NewBank.AccountList[w], Convert.ToDecimal(deposit), Ddescription, DateTimeOffset.Now);
                                   Console.WriteLine();
                                   Console.Write("Before Deposit Account Balance:");
                                   Console.Write("$");
                                   Console.WriteLine(NewBank.AccountList[w].Balance);
                                   NewBank.AccountList[w].AddUp(Convert.ToDecimal(deposit));
                                   Console.WriteLine();
                                   Console.Write("After Deposit Account Balance:");
                                   Console.Write("$");
                                   Console.WriteLine(NewBank.AccountList[w].Balance);
                                   Console.Write("Description:");
                                   Console.WriteLine(Ddescription);
                                   Console.WriteLine();
                                   break;
                               }
                               else
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("Searching Account");
                                   w++;
                                   Console.WriteLine();
                               }
                           }
                       }
                       while (w <= NewBank.AccountList.Count);
                   }


               // To withdraw from the Account.
               if (input == "4")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Withdraw Page");
                   Console.WriteLine("----------------");
                   int k = 0;
                   Console.WriteLine("Withdraw From Account");
                   Console.WriteLine("Please Key in your account number");
                   string accNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                   Console.WriteLine("Please Key in your name");
                   string CusName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                   do
                   {
                       // check the specific account is listed in the bank or not.
                       if (k == NewBank.AccountList.Count)
                       {
                           Console.WriteLine();
                           Console.WriteLine("--------------");
                           Console.WriteLine("No such account");
                           Console.WriteLine("Please key in the right information");
                           Console.WriteLine("--------------");
                           Console.WriteLine();
                           break;
                       }
                       else
                       {

                           if (NewBank.AccountList[k].AccountNumber == accNum && NewBank.AccountList[k].CustomerName == CusName)
                           {

                               Console.WriteLine();
                               Console.WriteLine("Account Details");
                               Console.WriteLine("------");
                               Console.Write("Customer Name:");
                               Console.WriteLine(NewBank.AccountList[k].CustomerName);
                               Console.Write("Account Number:");
                               Console.WriteLine(NewBank.AccountList[k].AccountNumber);
                               Console.Write("Balance:");
                               Console.WriteLine(NewBank.AccountList[k].Balance);
                               Console.Write("Member Since:");
                               Console.WriteLine(NewBank.AccountList[k].OpenedDate);
                               Console.WriteLine("------");
                               // Account Insufficient funds.
                               if (NewBank.AccountList[k].Balance <= 0)
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("-------------");
                                   Console.WriteLine("Account insufficient to withdraw.");
                                   Console.WriteLine("-------------");
                                   Console.WriteLine();
                                   break;
                               }
                               else
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("Amount to Withdraw?");
                                   string withdraw = Console.ReadLine();
                                   Console.WriteLine("Description?");
                                   string Wdescription = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                                   NewBank.PerformWithdrawal(NewBank.AccountList[k], Convert.ToDecimal(withdraw), Wdescription, DateTimeOffset.Now);
                                   Console.WriteLine();
                                   Console.Write("Before Withdraw Account Balance:");
                                   Console.WriteLine(NewBank.AccountList[k].Balance);
                                   Console.WriteLine();
                                   NewBank.AccountList[k].Minus(Convert.ToDecimal(withdraw));
                                   Console.Write("After Withdraw Account Balance:");
                                   Console.WriteLine(NewBank.AccountList[k].Balance);
                                   Console.Write("Description:");
                                   Console.WriteLine(Wdescription);
                                   Console.WriteLine();
                                   break;
                               }
                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Searching Account");
                               k++;
                               Console.WriteLine();
                           }
                       }
                   }
                   while (k <= NewBank.AccountList.Count);
               }

               // Transferring amount between two accounts.
               if (input == "5")
               {
                       Console.WriteLine("----------------");
                       Console.WriteLine("Account Transfer Page");
                       Console.WriteLine("----------------");
                       int k1 = 0;
                       int k2 = 0;
                       Console.WriteLine();
                       Console.WriteLine("-------");
                       Console.WriteLine("Account Transfer From");
                       Console.WriteLine("Please Key in your account number");
                       string OwnAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                       Console.WriteLine("Please Key in your name");
                       string OwnCusName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                       Console.WriteLine("-------");
                       Console.WriteLine();
                       Console.WriteLine("-------");
                       Console.WriteLine("To");
                       bool checking = false;
                       string OtherAccNum;
                       string OtherCusName;
                       // Compare whether two account keyed is the same or not
                       do
                       {
                           Console.WriteLine("Account Transfer To");
                           Console.WriteLine("Please Key in other account number");
                           OtherAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                           Console.WriteLine("Please Key in other name");
                           OtherCusName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                           
                           if ((OtherAccNum == OwnAccNum))
                           {
                               checking = false;
                               Console.WriteLine("Please Key again, the account number is the same");
                           }
                           if ((OtherAccNum != OwnAccNum))
                           {
                               checking = true;
                           }
                       }
                       while (checking == false);
                       Console.WriteLine("-------");
                       Console.WriteLine();
                       //Check Validation for both accounts
                       Console.WriteLine("Checking Both Accounts for verification");
                       //Global Variable
                       bool AccVeri1 = false;
                       bool AccVeri2 = false;

                       //Own Account Verification
                       do
                       {
                           // check the specific account is listed in the bank or not
                           if (k1 == NewBank.AccountList.Count)
                           {
                               Console.WriteLine();
                               Console.WriteLine("---------------");
                               Console.WriteLine("No such account");
                               Console.WriteLine("Please key in the right information");
                               Console.WriteLine("---------------");
                               Console.WriteLine();
                               AccVeri1 = false;
                               break;
                           }
                           else
                           {
                               if (NewBank.AccountList[k1].AccountNumber == OwnAccNum && NewBank.AccountList[k1].CustomerName == OwnCusName)
                               {

                                       Console.WriteLine();
                                       Console.WriteLine("Your Account");
                                       Console.WriteLine();
                                       Console.WriteLine("Account Details");
                                       Console.WriteLine("------");
                                       Console.Write("Customer Name:");
                                       Console.WriteLine(NewBank.AccountList[k1].CustomerName);
                                       Console.Write("Account Number:");
                                       Console.WriteLine(NewBank.AccountList[k1].AccountNumber);
                                       Console.Write("Balance:");
                                       Console.WriteLine(NewBank.AccountList[k1].Balance);
                                       Console.Write("Member Since:");
                                       Console.WriteLine(NewBank.AccountList[k1].OpenedDate);
                                       Console.WriteLine("------");
                                       Console.WriteLine();
                                       AccVeri1 = true;
                                       break;
                                   }
                               
                               else
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("Searching Account");
                                   k1++;
                                   Console.WriteLine();
                               }
                           }
                       }
                       while (k1 <= NewBank.AccountList.Count);



                       //Other Account Verification
                       do
                       {
                           // check the specific account is listed in the bank or not
                           if (k2 == NewBank.AccountList.Count)
                           {
                               Console.WriteLine();
                               Console.WriteLine("---------------");
                               Console.WriteLine("No such account");
                               Console.WriteLine("Please key in the right information");
                               Console.WriteLine("---------------");
                               Console.WriteLine();
                               AccVeri2 = false;
                               break;
                           }
                           else
                           {
                               if (NewBank.AccountList[k2].AccountNumber == OtherAccNum && NewBank.AccountList[k2].CustomerName == OtherCusName)
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("Other Account");
                                   Console.WriteLine();
                                   Console.WriteLine("Account Details");
                                   Console.WriteLine("------");
                                   Console.Write("Customer Name:");
                                   Console.WriteLine(NewBank.AccountList[k2].CustomerName);
                                   Console.Write("Account Number:");
                                   Console.WriteLine(NewBank.AccountList[k2].AccountNumber);
                                   Console.Write("Member Since:");
                                   Console.WriteLine(NewBank.AccountList[k2].OpenedDate);
                                   Console.WriteLine("------");
                                   Console.WriteLine();
                                   AccVeri2 = true;

                                   break;
                               }
                               else
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("Searching Account");
                                   k2++;
                                   Console.WriteLine();
                               }
                           }

                       }
                       while (k2 <= NewBank.AccountList.Count);

                       // Account Insufficient funds.
                       if (NewBank.AccountList[k1].Balance <= 0)
                       {
                           Console.WriteLine();
                           Console.WriteLine("-------------");
                           Console.WriteLine("Account insufficient to Transfer.");
                           Console.WriteLine("-------------");
                           Console.WriteLine();
                       }
                       else
                       {
                           //Compare both verification
                           if (AccVeri1 && AccVeri2)
                           {
                               Console.WriteLine();
                               Console.WriteLine("Verification Completed");
                               Console.WriteLine();
                               Console.WriteLine("Amount to Transfer?");
                               string transfer = Console.ReadLine();
                               Console.WriteLine("Description?");
                               string description = Console.ReadLine();
                               NewBank.PerformTransfer(NewBank.AccountList[k1], NewBank.AccountList[k2], Convert.ToDecimal(transfer), description, DateTimeOffset.Now);
                               Console.WriteLine();
                               Console.Write("Before Transfer Account Balance:");
                               Console.WriteLine(NewBank.AccountList[k1].Balance);
                               NewBank.AccountList[k2].AddUp(Convert.ToDecimal(transfer));
                               Console.WriteLine();
                               Console.Write("After Transfer Account Balance:");
                               Console.Write("$");
                               NewBank.AccountList[k1].Minus(Convert.ToDecimal(transfer));
                               Console.WriteLine(NewBank.AccountList[k1].Balance);
                               Console.Write("Description:");
                               Console.WriteLine(description);
                               Console.WriteLine();

                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Verification Failed");
                               Console.WriteLine();
                           }
                       }
               }

              // Print All statements in this bank
               if (input == "6")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("ReadifyBank Statements Page");
                   Console.WriteLine("----------------");
                   //Check the bank has any transaction log
                   if (NewBank.TransactionLog.Count != 0)
                   {
                       Console.WriteLine();
                       Console.WriteLine("All statements");
                       Console.WriteLine("------");
                       for (int e = 0; e < NewBank.TransactionLog.Count; e++)
                       {
                           Console.WriteLine();
                           Console.Write("Customer Name:");
                           NewBank.TransactionLog.Reverse();
                           Console.WriteLine(NewBank.TransactionLog[e].Account.CustomerName);
                           Console.Write("Account Number:");
                           Console.WriteLine(NewBank.TransactionLog[e].Account.AccountNumber);
                           Console.Write("Amount:");
                           Console.WriteLine(NewBank.TransactionLog[e].Amount);
                           Console.Write("Balance:");
                           Console.Write("$");
                           Console.WriteLine(NewBank.TransactionLog[e].Balance);
                           Console.Write("Date:");
                           Console.WriteLine(NewBank.TransactionLog[e].Date);
                           Console.Write("Description:");
                           Console.WriteLine(NewBank.TransactionLog[e].Description);
                           Console.WriteLine("------");
                           Console.WriteLine();
                           
                       }
                   }
                   if (NewBank.TransactionLog.Count == 0)
                   {
                       Console.WriteLine();
                       Console.WriteLine("No Transaction");
                       Console.WriteLine();
                   }
                   
               }

             // Calculate Interest
               if (input == "7")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Interest Page");
                   Console.WriteLine("----------------");
                   Console.WriteLine("Please Key in your account number");
                   string IstAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                   Console.WriteLine("Please Key in your name");
                   string IstCusName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                   int t1 = 0;
                   do
                   {
                       // check the specific account is listed in the bank or not
                       if (t1 == NewBank.AccountList.Count)
                       {
                           Console.WriteLine();
                           Console.WriteLine("---------------");
                           Console.WriteLine("No such account");
                           Console.WriteLine("Please key in the right information");
                           Console.WriteLine("---------------");
                           Console.WriteLine();
                           break;
                       }
                       else
                       {
                           //Scan and find the correct account
                           if (NewBank.AccountList[t1].AccountNumber == IstAccNum && NewBank.AccountList[t1].CustomerName == IstCusName)
                           {
                               Console.WriteLine();
                               Console.WriteLine("Your Account");
                               Console.WriteLine();
                               Console.WriteLine("Account Details");
                               Console.WriteLine("------");
                               Console.Write("Customer Name:");
                               Console.WriteLine(NewBank.AccountList[t1].CustomerName);
                               Console.Write("Account Number:");
                               Console.WriteLine(NewBank.AccountList[t1].AccountNumber);
                               Console.Write("Balance:");
                               Console.Write("$");
                               Console.WriteLine(NewBank.AccountList[t1].Balance);
                               Console.Write("Member Since:");
                               Console.WriteLine(NewBank.AccountList[t1].OpenedDate);
                               Console.WriteLine("------");
                               Console.WriteLine();
                               Console.WriteLine(NewBank.CalculateInterestToDate(NewBank.AccountList[t1], DateTimeOffset.Now));
                               Console.WriteLine();
                               Console.WriteLine();
                               Console.WriteLine("------");
                               break;
                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Searching Account");
                               t1++;
                               Console.WriteLine();
                           }
                       }
                   }
                   while (t1 <= NewBank.AccountList.Count);

               }
                //Close Account
               if (input == "8")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Close Page");
                   Console.WriteLine("----------------");
                   Console.WriteLine("Close Account");
                   Console.WriteLine("Please Key in your account number");
                   string CloseAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                   Console.WriteLine("Please Key in your name");
                   string CloseAccName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                   int t1 = 0;
                   do
                   {
                       // check the specific account is listed in the bank or not
                       if (t1 == NewBank.AccountList.Count)
                       {
                           Console.WriteLine();
                           Console.WriteLine("No such account");
                           Console.WriteLine("Please key in the right information");
                           Console.WriteLine();
                           break;
                       }
                       else
                       {
                           //scan and find the correct account
                           if (NewBank.AccountList[t1].AccountNumber == CloseAccNum && NewBank.AccountList[t1].CustomerName == CloseAccName)
                           {
                               Console.WriteLine();
                               Console.WriteLine("Your Account");
                               Console.WriteLine();
                               Console.WriteLine("Account Details");
                               Console.WriteLine("------");
                               Console.Write("Customer Name:");
                               Console.WriteLine(NewBank.AccountList[t1].CustomerName);
                               Console.Write("Account Number:");
                               Console.WriteLine(NewBank.AccountList[t1].AccountNumber);
                               Console.Write("Balance:");
                               Console.Write("$");
                               Console.WriteLine(NewBank.AccountList[t1].Balance);
                               Console.Write("Member Since:");
                               Console.WriteLine(NewBank.AccountList[t1].OpenedDate);
                               Console.WriteLine("------");
                               Console.WriteLine();
                               List<IStatementRow> NewList = new List<IStatementRow>();
                               NewList = NewBank.CloseAccount(NewBank.AccountList[t1], DateTimeOffset.Now).ToList();
                               Console.WriteLine();
                               Console.WriteLine("All Transactions");
                               Console.WriteLine("------");
                               // check whether there is list of transaction or not.
                               if (NewList.Count == 0)
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("------");
                                   Console.WriteLine("There is no Transactions in this account.");
                                   Console.WriteLine("------");
                                   Console.WriteLine();
                               }
                               else
                               {
                                   // Print All Statement in this account
                                   for (int l = 0; l < NewList.Count; l++)
                                   {
                                       Console.Write("Customer Name:");
                                       Console.WriteLine(NewList[l].Account.CustomerName);
                                       Console.Write("Account Number:");
                                       Console.WriteLine(NewList[l].Account.AccountNumber);
                                       Console.Write("Transaction Amount:");
                                       Console.WriteLine(NewList[l].Amount);
                                       Console.Write("Transaction Balance:");
                                       Console.Write("$");
                                       Console.WriteLine(NewList[l].Balance);
                                       Console.Write("Transaction Date:");
                                       Console.WriteLine(NewList[l].Date);
                                       Console.Write("Transaction Description:");
                                       Console.WriteLine(NewList[l].Description);
                                       Console.WriteLine("------");
                                       Console.WriteLine();
                                   }
                                   Console.WriteLine();
                                   Console.WriteLine("------");
                                   // Delete Account Object in the Account list
                                   Console.WriteLine("Successfully Closed the Account");
                                   NewBank.AccountList.Remove(NewBank.AccountList[t1]);
                                   Console.WriteLine("------");
                                   Console.WriteLine();

                                   break;
                               }
                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Searching Account");
                               t1++;
                               Console.WriteLine();
                           }

                       }
                   }
                   while (t1 <= NewBank.AccountList.Count);

               }

               //Mini Statement of 5 transaction
               if (input == "9")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Statement Page");
                   Console.WriteLine("----------------");
                   List<IStatementRow> NewList = new List<IStatementRow>();
                   Console.WriteLine("Mini Statement");
                   Console.WriteLine("Please Key in your account number");
                   string MinAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                   Console.WriteLine("Please Key in your name");
                   string MinAccName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                   int t1 = 0;
                   do
                   {
                       // check the specific account is listed in the bank or not
                       if (t1 == NewBank.AccountList.Count)
                       {
                           Console.WriteLine();
                           Console.WriteLine("---------------");
                           Console.WriteLine("No such account");
                           Console.WriteLine("Please key in the right information");
                           Console.WriteLine("---------------");
                           Console.WriteLine();
                           break;
                       }
                       else
                       {
                           // Scan and find the correct account
                           if (NewBank.AccountList[t1].AccountNumber == MinAccNum && NewBank.AccountList[t1].CustomerName == MinAccName)
                           {
                               Console.WriteLine();
                               Console.WriteLine("Your Account");
                               Console.WriteLine();
                               Console.WriteLine("Account Details");
                               Console.WriteLine("------");
                               Console.Write("Customer Name:");
                               Console.WriteLine(NewBank.AccountList[t1].CustomerName);
                               Console.Write("Account Number:");
                               Console.WriteLine(NewBank.AccountList[t1].AccountNumber);
                               Console.Write("Balance:");
                               Console.Write("$");
                               Console.WriteLine(NewBank.AccountList[t1].Balance);
                               Console.Write("Member Since:");
                               Console.WriteLine(NewBank.AccountList[t1].OpenedDate);
                               Console.WriteLine("------");
                               Console.WriteLine();
                               NewList = NewBank.GetMiniStatement(NewBank.AccountList[t1]).ToList();
                               if (NewList.Count <= 0)
                               {
                                   Console.WriteLine();
                                   Console.WriteLine("------");
                                   Console.WriteLine("No transaction");
                                   Console.WriteLine("------");
                                   Console.WriteLine();
                                   break;
                               }
                               else
                               {
                                   Console.WriteLine("5 lastest transactions");
                                   Console.WriteLine("------");
                                   // Print 5 Latest Transaction of this account
                                   for (int l = 0; l < NewList.Count; l++)
                                   {
                                       Console.Write("Customer Name:");
                                       Console.WriteLine(NewList[l].Account.CustomerName);
                                       Console.Write("Account Number:");
                                       Console.WriteLine(NewList[l].Account.AccountNumber);
                                       Console.Write("Transaction Amount:");
                                       Console.WriteLine(NewList[l].Amount);
                                       Console.Write("Transaction Balance:");
                                       Console.Write("$");
                                       Console.WriteLine(NewList[l].Balance);
                                       Console.Write("Transaction Date:");
                                       Console.WriteLine(NewList[l].Date);
                                       Console.Write("Transaction Description:");
                                       Console.WriteLine(NewList[l].Description);
                                       Console.WriteLine("------");
                                       Console.WriteLine();
                                   }

                                   break;
                               }
                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Searching Account");
                               t1++;
                               Console.WriteLine();
                           }
                       }
                   }
                   while (t1 <= NewBank.AccountList.Count);
               }

               //Get account Balance
               if (input == "10")
               {
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Balance Page");
                   Console.WriteLine("----------------");
                   Console.WriteLine("Account Balance");
                   Console.WriteLine("Please Key in your account number");
                   string CheckAccNum = CultureInfo.CurrentCulture.TextInfo.ToUpper(Console.ReadLine());
                   Console.WriteLine("Please Key in your name");
                   string CheckAccName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
                   int t1 = 0;
                   do
                   {
                       // check the specific account is listed in the bank or not
                       if (t1 == NewBank.AccountList.Count)
                       {
                           Console.WriteLine();
                           Console.WriteLine("---------------");
                           Console.WriteLine("No such account");
                           Console.WriteLine("Please key in the right information");
                           Console.WriteLine("---------------");
                           Console.WriteLine();
                           break;
                       }
                       else
                       {
                           // Scan and find the correct account
                           if (NewBank.AccountList[t1].AccountNumber == CheckAccNum && NewBank.AccountList[t1].CustomerName == CheckAccName)
                           {
                               Console.WriteLine();
                               Console.WriteLine("Your Account");
                               Console.WriteLine();
                               Console.WriteLine("Account Details");
                               Console.WriteLine("------");
                               Console.Write("Customer Name:");
                               Console.WriteLine(NewBank.AccountList[t1].CustomerName);
                               Console.Write("Account Number:");
                               Console.WriteLine(NewBank.AccountList[t1].AccountNumber);
                               Console.Write("Balance:");
                               Console.Write("$");
                               Console.WriteLine(NewBank.GetBalance(NewBank.AccountList[t1]));
                               Console.WriteLine("------");
                               Console.WriteLine();
                               break;
                           }
                           else
                           {
                               Console.WriteLine();
                               Console.WriteLine("Searching Account");
                               t1++;
                               Console.WriteLine();
                           }
                       }
                   }
                   while (t1 <= NewBank.AccountList.Count);
               }
           }
           while (input != "exit");
          
        }
    }
}
