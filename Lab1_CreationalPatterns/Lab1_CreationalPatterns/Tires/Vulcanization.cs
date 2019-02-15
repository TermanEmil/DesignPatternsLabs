using System;
namespace Lab1_CreationalPatterns.Tires
{
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
}
