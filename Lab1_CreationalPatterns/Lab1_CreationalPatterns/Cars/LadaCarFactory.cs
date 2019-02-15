using System;
namespace Lab1_CreationalPatterns
{
    public class LadaCarFactory : ICarFactory
    {
        private BaseCar.Builder carBuilder;

        public LadaCarFactory(string country = null)
        {
            carBuilder = new BaseCar.Builder()
                .SetManufacturer("Lada")
                .SetHorsePower(RandomProvider.Instance.Next(10, 25))
                .SetCountry(country);
        }

        public ICar CreateCar()
        {
            return carBuilder.Build();
        }
    }
}
