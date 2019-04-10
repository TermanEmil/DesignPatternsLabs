using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Repositories;

namespace Lab3_Behavioral.Transactions
{
    public abstract class BaseTransaction : ITransaction
    {
        protected readonly IMoneyRepository moneySource;
        protected readonly IAccount account;

        protected BaseTransaction(IMoneyRepository moneySource, IAccount account)
        {
            this.moneySource = moneySource;
            this.account = account;
        }

        public void ExecuteTransaction()
        {
            Console.WriteLine("Transaction is being executed...");
            CoreTransactionExecution();
            Console.WriteLine("Transaction has ended");
        }

        protected abstract void CoreTransactionExecution();
    }
}
