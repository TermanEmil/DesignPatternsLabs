using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Transactions;

namespace Lab3_Behavioral.Atms
{
    public class LoggedOutState : ICashMachineState
    {
        private readonly CashMachine context;

        public LoggedOutState(CashMachine context)
        {
            this.context = context;
        }

        public void DisplayAccountBalance()
        {
            LoggedInRequiredError();
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
            Console.WriteLine("Logging in...");
            context.SetState(new LoggedInState(context, account));
        }

        public void LogOut()
        {
            LoggedInRequiredError();
        }

        private void LoggedInRequiredError()
        {
            Console.Error.WriteLine("You must log in first!");
        }
    }
}
