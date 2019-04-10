using System;
using Lab3_Behavioral.Accounts;

namespace Lab3_Behavioral.Atms.Observers
{
    public interface ILoginObserver
    {
        void OnLoggedIn(IAccount account);
    }
}
