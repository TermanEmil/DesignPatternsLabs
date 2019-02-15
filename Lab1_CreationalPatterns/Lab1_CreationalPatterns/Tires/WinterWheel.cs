using System;
namespace Lab1_CreationalPatterns.Tires
{
    public class WinterWheel : IWheel
    {
        public void Inflate()
        {
            Console.WriteLine("Inflating a Winter wheel");
        }

        public bool WorksOnIce()
        {
            return true;
        }
    }
}
