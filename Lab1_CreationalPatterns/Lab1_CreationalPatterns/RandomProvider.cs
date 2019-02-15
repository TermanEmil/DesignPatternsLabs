using System;
namespace Lab1_CreationalPatterns
{
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
}
