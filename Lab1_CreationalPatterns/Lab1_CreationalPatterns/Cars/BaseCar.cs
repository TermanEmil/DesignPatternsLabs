using System;
using Lab1_CreationalPatterns.Tires;

namespace Lab1_CreationalPatterns
{
    public class BaseCar : ICar, ICloneable
    {
        private readonly string description;
        private readonly string showOffStr;

        public BaseCar(string description, string showOff)
        {
            this.description = description;
            this.showOffStr = showOff;
        }

        public object Clone()
        {
            return new BaseCar(description, showOffStr);
        }

        public string GetDescription()
        {
            return description;
        }

        public void ShowOff()
        {
            Console.WriteLine(showOffStr);
        }

        public class Builder
        {
            private const string basicCarNoise = "Brum brum brum";
            private int nbOfWheels = 4;
            private string manufacturer = null;
            private string country = null;
            private int horsePower = -1;

            public BaseCar Build()
            {
                if (ItsABasicCar())
                    return new BaseCar("Basic car...", basicCarNoise);

                string description = "";
                string showOffStr = "";

                if (nbOfWheels != 4)
                {
                    description += string.Format("It has {0} wheel(s). ", nbOfWheels);
                    if (nbOfWheels == 1)
                    {
                        description += "It's interesting how it manages to work. ";
                    }
                }

                if (manufacturer != null)
                {
                    description += string.Format("It's produced by {0}. ", manufacturer);
                    if (manufacturer.Equals("McLaren"))
                    {
                        description += "Very cool!!! ";
                    }
                }

                if (country != null)
                {
                    description += string.Format("It was made in {0}. ", country);
                    if (country.Equals("China"))
                    {
                        description += "It seems to barely work, but ok. ";
                        showOffStr += "Brum brum brum brum. A wheel has detached but ok. ";
                    }
                    else if (country.Equals("Switzerland"))
                    {
                        description += "It should work like a clockwork. ";
                        showOffStr += "Tic tac tic tac. ";
                    }
                }

                if (horsePower != -1)
                {
                    description += string.Format("It has {0} horsepower. ", horsePower);
                    if (horsePower <= 20)
                    {
                        description += "Mmmmm what?... ";
                        showOffStr += "*snail noise* ";
                    }
                    else if (horsePower <= 700)
                    {
                        description += "Yeah, it won't fly. ";
                        showOffStr += "Bjjjjjjjjjjj.... ";
                    }
                    else
                    {
                        description += "Why it's not flying?! ";
                        showOffStr += "Weeeeeeeee ";
                    }
                }

                if (showOffStr == "")
                    showOffStr = basicCarNoise;

                Vulcanization vulcanization = new Vulcanization();
                for (int i = 0; i < nbOfWheels; i++)
                    vulcanization.CreateWheel(SeasonManager.seasonName);

                return new BaseCar(description, showOffStr);
            }

            private bool ItsABasicCar()
            {
                return nbOfWheels == 4 && manufacturer == null && country == null && horsePower == -1;
            }

            public Builder SetNbOfWheels(int nbOfWheels)
            {
                this.nbOfWheels = nbOfWheels;
                return this;
            }

            public Builder SetManufacturer(string manufacturer)
            {
                this.manufacturer = manufacturer;
                return this;
            }

            public Builder SetCountry(string country)
            {
                this.country = country;
                return this;
            }

            public Builder SetHorsePower(int horsePower)
            {
                this.horsePower = horsePower;
                return this;
            }
        }
    }
}
