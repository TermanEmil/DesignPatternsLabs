using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Atms.Observers;
using Lab3_Behavioral.Repositories;
using Lab3_Behavioral.Transactions;

namespace Lab3_Behavioral.Atms
{
    public class CashMachine
    {
        public IMoneyRepository MoneySource { get; }

        private ICashMachineState state;
        private readonly IEnumerable<ILoginObserver> loginObservers;

        public CashMachine(IEnumerable<ILoginObserver> loginObservers)
        {
            this.loginObservers = loginObservers;
            MoneySource = new MoneyDbContext();

            SetState(new LoggedOutState(this));
        }

        public void SetState(ICashMachineState state)
        {
            this.state = state;
        }

        public void LogIn(IAccount account)
        {
            state.LogIn(account);
            loginObservers.ToList().ForEach(x => x.OnLoggedIn(account));
        }

        public void LogOut()
        {
            state.LogOut();
        }

        public void ExecuteTransaction(ITransaction transaction)
        {
            state.ExecuteTransaction(transaction);
        }

        public void DisplayAccountBalance()
        {
            state.DisplayAccountBalance();
        }
    }
}
