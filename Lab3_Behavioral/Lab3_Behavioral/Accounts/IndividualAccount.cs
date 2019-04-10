using System;
using Lab3_Behavioral.Repositories;

namespace Lab3_Behavioral.Accounts
{
    public class IndividualAccount : IAccount
    {
        public IMoneyRepository MoneyRepository { get; }

        public IndividualAccount(IMoneyRepository moneyRepository)
        {
            this.MoneyRepository = moneyRepository;
        }

        public void AddMoney(decimal money)
        {
            MoneyRepository.Money += money;
        }

        public bool CanGetMoney(decimal money)
        {
            return true;
        }

        public bool CanWithdrawMoney(decimal money)
        {
            return MoneyRepository.Money >= money;
        }

        public void WithdrawMoney(decimal money)
        {
            MoneyRepository.Money -= money;
        }
    }
}
