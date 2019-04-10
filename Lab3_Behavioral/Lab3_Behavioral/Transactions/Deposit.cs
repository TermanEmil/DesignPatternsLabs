using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Repositories;

namespace Lab3_Behavioral.Transactions
{
    public class Deposit : BaseTransaction
    {
        private readonly decimal moneyToBeDeposited;

        public Deposit(
            IMoneyRepository moneySource,
            IAccount account,
            decimal moneyToBeWithdrawn
            ) : base(moneySource, account)
        {
            this.moneyToBeDeposited = moneyToBeWithdrawn;
        }

        protected override void CoreTransactionExecution()
        {
            if (!account.CanWithdrawMoney(moneyToBeDeposited))
                throw new Exception("Account can't deposit this amount of money");

            account.WithdrawMoney(moneyToBeDeposited);
            moneySource.Money += moneyToBeDeposited;
        }
    }
}
