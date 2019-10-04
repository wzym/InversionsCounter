using System;
using System.Collections.Generic;

namespace InversionCounter
{
    internal class Program
    {
        public static void Main()
        {
            var queue = GetInArray();
            Console.WriteLine(CountInversions(queue));
        }

        private static int CountInversions(Queue<int[]> q)
        {
            while (q.Count > 1)
                q.Enqueue(Merge(q.Dequeue(), q.Dequeue()));
            
            return 0;
        }

        private static int[] Merge(IReadOnlyList<int> a, IReadOnlyList<int> b)
        {
            var result = new int[a.Count + b.Count];
            var resPointer = 0;
            var aPointer = 0;
            var bPointer = 0;

            while (resPointer < result.Length)
            {
                result[resPointer++] =
                    (aPointer == a.Count ||
                     (bPointer < b.Count && b[bPointer] <= a[aPointer]))
                        ? b[bPointer++]
                        : a[aPointer++];
            }

            return result;
        }

        private static Queue<int[]> GetInArray()
        {
            var size = int.Parse(Console.ReadLine());
            var arrayAsSubstrings = Console.ReadLine().Split();
            var result = new Queue<int[]>();
            for (var i = 0; i < size; i++)
                result.Enqueue(new[] {int.Parse(arrayAsSubstrings[i])});

            return result;
        }
    }
}