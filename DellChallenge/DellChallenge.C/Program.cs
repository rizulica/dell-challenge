using System;
using System.Linq;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            CalculateSums();
            Console.ReadKey();
        }

        private static void CalculateSums()
        {
            var sum = SumCalculator.CalculateSum(new int[] { 1, 3 });
            var extendedSum = SumCalculator.CalculateSum(new int[] { 1, 3, 5 });

            Console.WriteLine(sum);
            Console.WriteLine(extendedSum);
        }
    }

    static class SumCalculator
    {
        public static int CalculateSum(int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
