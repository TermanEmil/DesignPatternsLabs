using System;
using Lab3_Behavioral.Accounts;

namespace Lab3_Behavioral.Atms.Observers
{
    public class OnLoginNotifier : ILoginObserver
    {
        public void OnLoggedIn(IAccount account)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login attempt!!!");
            Console.ResetColor();
        }
    }
}
