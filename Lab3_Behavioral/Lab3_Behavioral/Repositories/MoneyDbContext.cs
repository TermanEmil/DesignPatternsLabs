namespace Lab3_Behavioral.Repositories
{
    public class MoneyDbContext : IMoneyRepository
    {
        public decimal Money { get; set; }

        public MoneyDbContext(decimal initialAmmountOfMoney = 100)
        {
            Money = initialAmmountOfMoney;
        }
    }
}
