using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Atms;
using Lab3_Behavioral.Atms.Observers;
using Lab3_Behavioral.Repositories;
using Lab3_Behavioral.Transactions;

namespace Lab3_Behavioral
{
    class Program
    {
        static void Main(string[] args)
        {
            var atm = new CashMachine(new[] { new OnLoginNotifier() });

            var rickAccount = new IndividualAccount(new MoneyDbContext(100));
            var mortyAccount = new IndividualAccount(new MoneyDbContext(200));

            // Should fail
            atm.DisplayAccountBalance();

            atm.LogIn(rickAccount);
            atm.DisplayAccountBalance();

            // Withdraw from atm
            atm.ExecuteTransaction(CreateTransaction(rickAccount, atm, 20));
            atm.DisplayAccountBalance();

            // Deposit to atm
            atm.ExecuteTransaction(CreateTransaction(rickAccount, atm, -10));
            atm.DisplayAccountBalance();

            // Nothing happens
            atm.ExecuteTransaction(CreateTransaction(rickAccount, atm, 0));
            atm.DisplayAccountBalance();

            // Should fail
            atm.LogIn(mortyAccount);

            atm.LogOut();
            atm.LogIn(mortyAccount);

            // Should fail - not enough money in atm
            atm.ExecuteTransaction(CreateTransaction(mortyAccount, atm, 1000));

            // Should fail - morty doesn't have the money
            atm.ExecuteTransaction(CreateTransaction(mortyAccount, atm, -1000));
        }

        static ITransaction CreateTransaction(
            IAccount account,
            CashMachine cashMachine,
            decimal moneyBalance)
        {
            if (moneyBalance == 0)
                return new NullTransaction();

            if (moneyBalance > 0)
                return new Withdrawl(cashMachine.MoneySource, account, moneyBalance);

            if (moneyBalance < 0)
                return new Deposit(cashMachine.MoneySource, account, -moneyBalance);

            throw new Exception();
        }
    }
}
