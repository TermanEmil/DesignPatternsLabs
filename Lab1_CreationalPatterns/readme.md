# Creational patterns

## Used patterns
1. Singleton - to provide a Random instance

```C#
public static class RandomProvider
{
    private static Random instance;

    public static Random Instance
    {
        get
        {
            if (instance == null)
                instance = new Random(1);

            return instance;
        }
    }
}
```

2. Builder - to build a base car

```C#
... BaseCar.Builder
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
...
```

3. Abstract Factory - different car factories

```C#
LadaCarFactory : ICarFactory
McLarenCarFactory : ICarFactory
...
```
4. Prototype

```C#
public object Clone()
{
    return new BaseCar(description, showOffStr);
}
```

5. Factory method

```C#
public class Vulcanization
{
    public IWheel CreateWheel(String wheelType)
    {
        IWheel result;

        if (wheelType == "winter")
            result = new WinterWheel();
        else
            result = new SummerWheel();

        result.Inflate();
        return result;
    }
}
```
