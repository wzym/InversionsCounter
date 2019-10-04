using System;

namespace InversionCounter
{
    internal class Program
    {
        public static void Main()
        {
            var arrayToCount = GetInArray();
            Console.WriteLine(CountInversions(arrayToCount));
        }

        private static int CountInversions(int[] arrayToCount)
        {
            
            return 0;
        }

        private static int[] GetInArray()
        {
            var size = int.Parse(Console.ReadLine());
            var arrayAsSubstrings = Console.ReadLine().Split();
            var result = new int[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = int.Parse(arrayAsSubstrings[i]);
            }

            return result;
        }
    }
}