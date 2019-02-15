using System;
namespace Lab1_CreationalPatterns.McLaren
{
    public class McLarenCarFactory : ICarFactory
    {
        private BaseCar.Builder carBuilder;

        public McLarenCarFactory(string country = null)
        {
            carBuilder = new BaseCar.Builder()
                .SetManufacturer("McLaren")
                .SetHorsePower(RandomProvider.Instance.Next(700, 800))
                .SetCountry(country);
        }

        public ICar CreateCar()
        {
            return carBuilder.Build();
        }
    }
}
