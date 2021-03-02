using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banksystem
{
    class Bank
    {
        private string bankName;
        private Account[] myBank;

        public Bank(string bankName)
        {
            this.bankName = bankName;
            myBank = new Account[400];
        }
        public void addAccount(Account account)
        {
            if (myBank[0] == null)
            {
                myBank[0] = account;
            }
            else
            {
                for (int i = 0; myBank[i] != null; i++)
                {
                    if (myBank[i + 1] == null)
                    {
                        myBank[i + 1] = account;
                        break;
                    }
                }
            }

        }
        public void deleteAccount(int accountNumber)
        {
            for (int i = 0; myBank[i] != null; i++)
            {
                if (myBank[i].getAccountNumber() == accountNumber)
                {
                    for (int j = i; myBank[j] != null; j++)
                    {
                        myBank[j] = myBank[j + 1];
                    }
                }
            }
        }
        public void Transaction(int transactionType, double amount, Account accOwner, Account reciver = null)
        {
            if (transactionType == 1)
            {
                accOwner.Deposit(amount);
            }
            else if (transactionType == 2)
            {
                accOwner.Withdraw(amount);
            }
            else if (transactionType == 3)
            {
                if (reciver == null)
                {
                    Console.WriteLine("Reciver not specified");
                }
                else
                {
                    accOwner.Transfer(reciver, amount);
                }
            }
        }
        public void PrintAccountDetails()
        {
            for (int i = 0; myBank[i] != null; i++)
            {
                myBank[i].ShowAccountInformation();
            }
        }
        static void Main(string[] args)
        {
            Bank b1 = new Bank("USSA");
            Account a1 = new Account("Tasnia Tapti", 5000.0, "5", "131", "Dhaka", "Bangladesh");
            Account a2 = new Account("Nazrul Islam", 3500.0, "7", "107", "Dhaka", "Bangladesh");
            Account a3 = new Account("Khadiza Himu", 7500.0, "9", "111", "Dhaka", "Bangladesh");
            b1.addAccount(a1);
            b1.addAccount(a2);
            b1.addAccount(a3);
            b1.PrintAccountDetails();
            Console.WriteLine("Write Account number to delete");
            int x = Convert.ToInt32(Console.ReadLine());
            b1.deleteAccount(x);
            b1.PrintAccountDetails();
            b1.Transaction(1, 2000.0, a1);
            b1.Transaction(2, 2500.0, a3);
            b1.Transaction(3, 1200, a1, a2);
            b1.Transaction(3, 1000, a1);
            b1.PrintAccountDetails();

        }
    }
}
