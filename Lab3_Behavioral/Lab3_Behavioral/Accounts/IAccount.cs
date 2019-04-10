using System;
using Lab3_Behavioral.Repositories;

namespace Lab3_Behavioral.Accounts
{
    public interface IAccount
    {
        IMoneyRepository MoneyRepository { get; }

        bool CanWithdrawMoney(decimal money);
        void WithdrawMoney(decimal money);

        bool CanGetMoney(decimal money);
        void AddMoney(decimal money);
    }
}
