using System;
using System.Collections.Generic;
using System.Data;

namespace InversionCounter
{
    internal static class Program
    {
        private static long _inversionCounter;
        
        public static void Main()
        {
            var arrayToCount = GetArray();
            SortAndCount(arrayToCount);
            Console.WriteLine(_inversionCounter);
        }

        private static int[] SortAndCount(int[] arrayToCount)
        {
            if (arrayToCount.Length == 1) return arrayToCount;
            var middle = arrayToCount.Length / 2;
            var left = new int[middle];
            var right = new int[arrayToCount.Length - middle];
            Array.Copy(arrayToCount, 0
                  , left, 0, left.Length);
            Array.Copy(arrayToCount, middle
                , right, 0, right.Length);
            return Merge(SortAndCount(left), SortAndCount(right));
        }

        private static int[] Merge(IReadOnlyList<int> a, IReadOnlyList<int> b)
        {
            var result = new int[a.Count + b.Count];
            var resPointer = 0;
            var aPointer = 0;
            var bPointer = 0;

            while (resPointer < result.Length)
            {
                if (bPointer == b.Count ||
                    (aPointer < a.Count && a[aPointer] <= b[bPointer]))
                {
                    result[resPointer++] = a[aPointer++];
                }
                else
                {
                    result[resPointer++] = b[bPointer++];
                    _inversionCounter += a.Count - aPointer;
                }
            }

            return result;
        }

        private static int[] GetArray()
        {
            var size = int.Parse(Console.ReadLine() ?? throw new DataException());
            var arrayAsString = Console.ReadLine();
            if (string.IsNullOrEmpty(arrayAsString)) return new int[0];
            var arrayAsSubstrings = arrayAsString.Split();
            var result = new int[size];
            for (var i = 0; i < size; i++)
                result[i] = int.Parse(arrayAsSubstrings[i]);

            return result;
        }
    }
}