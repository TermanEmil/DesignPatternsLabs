using System;
namespace Lab1_CreationalPatterns
{
    public class AvodlomCarFactory : ICarFactory
    {
        private BaseCar.Builder carBuilder;

        public AvodlomCarFactory(string country = null)
        {
            carBuilder = new BaseCar.Builder()
                .SetManufacturer("Avodlom")
                .SetHorsePower(RandomProvider.Instance.Next(100, 150))
                .SetCountry(country);
        }

        public ICar CreateCar()
        {
            return carBuilder.Build();
        }
    }
}
