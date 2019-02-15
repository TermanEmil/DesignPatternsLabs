using System;
using System.Collections.Generic;
using Lab1_CreationalPatterns.McLaren;

namespace Lab1_CreationalPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var carFactories = new List<ICarFactory>();

            SeasonManager.seasonName = "summer";
            carFactories.Add(new McLarenCarFactory());
            carFactories.Add(new McLarenCarFactory("Switzerland"));

            carFactories.Add(new LadaCarFactory("China"));
            carFactories.Add(new LadaCarFactory());

            carFactories.Add(new AvodlomCarFactory("Moldova"));
            carFactories.Add(new AvodlomCarFactory());

            var cars = new List<ICar>();
            foreach (var factory in carFactories)
            {
                cars.Add(factory.CreateCar());
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.GetDescription());
                car.ShowOff();
            }
        }
    }
}
