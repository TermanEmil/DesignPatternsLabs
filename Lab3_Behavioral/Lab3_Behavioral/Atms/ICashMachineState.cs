using System;
using Lab3_Behavioral.Accounts;
using Lab3_Behavioral.Transactions;

namespace Lab3_Behavioral.Atms
{
    public interface ICashMachineState
    {
        void LogIn(IAccount account);
        void LogOut();
        void ExecuteTransaction(ITransaction transaction);
        void DisplayAccountBalance();
    }
}
