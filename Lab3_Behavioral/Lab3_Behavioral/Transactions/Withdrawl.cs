using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Repositories;

namespace Lab3_Behavioral.Transactions
{
    public class Withdrawl : BaseTransaction
    {
        private readonly decimal moneyToBeWithdrawn;

        public Withdrawl(
            IMoneyRepository moneySource,
            IAccount account,
            decimal moneyToBeWithdrawn
            ) : base(moneySource, account)
        {
            this.moneyToBeWithdrawn = moneyToBeWithdrawn;
        }

        protected override void CoreTransactionExecution()
        {
            if (moneySource.Money < moneyToBeWithdrawn)
                throw new Exception("Not enough cash");

            if (!account.CanGetMoney(moneyToBeWithdrawn))
                throw new Exception("Account cannot take this money");

            moneySource.Money -= moneyToBeWithdrawn;
            account.AddMoney(moneyToBeWithdrawn);
        }
    }
}
