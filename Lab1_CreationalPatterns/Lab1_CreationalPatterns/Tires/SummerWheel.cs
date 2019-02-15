using System;
namespace Lab1_CreationalPatterns.Tires
{
    public class SummerWheel : IWheel
    {
        public void Inflate()
        {
            Console.WriteLine("Inflating a Summer wheel");
        }

        public bool WorksOnIce()
        {
            return false;
        }
    }
}
