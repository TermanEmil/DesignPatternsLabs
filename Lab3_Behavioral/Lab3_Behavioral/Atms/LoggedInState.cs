using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Transactions;

namespace Lab3_Behavioral.Atms
{
    public class LoggedInState : ICashMachineState
    {
        private readonly CashMachine context;
        private readonly IAccount account;

        public LoggedInState(CashMachine context, IAccount account)
        {
            this.context = context;
            this.account = account;
        }

        public void DisplayAccountBalance()
        {
            Console.WriteLine("This account has a balance of {0:00}$", account.MoneyRepository.Money);
        }

        public void ExecuteTransaction(ITransaction transaction)
        {
            try
            {
                transaction.ExecuteTransaction();
                Console.WriteLine("Transaction succeeded");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Transaction failed: {e.Message}");
            }
        }

        public void LogIn(IAccount account)
        {
            Console.Error.WriteLine("Another account is currently logged in. Logout first");
        }

        public void LogOut()
        {
            Console.WriteLine("Logging out");
            context.SetState(new LoggedOutState(context));
        }
    }
}
