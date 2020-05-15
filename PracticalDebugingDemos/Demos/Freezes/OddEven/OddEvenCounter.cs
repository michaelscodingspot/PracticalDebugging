using System;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Freezes.OddEven
{
    internal class OddEvenCounter
    {
        internal void Count(int[] array, out int numberOfOdds, out int numberOfEvens)
        {
            int odds = 0;
            int evens = 0;
            var oddTask = Task.Run(() =>
            {
                odds = CountOdds(array);
            });

            var evenTask = Task.Run(() =>
            {
                evens = CountEvens(array);
            });
            Task.WaitAll(oddTask, evenTask);
            numberOfEvens = evens;
            numberOfOdds = odds;
        }

        private int CountEvens(int[] array)
        {
            int index = 0;
            int count = 0;
            while (index < array.Length)
            {
                if (array[index] % 2 == 1)
                {
                    continue;
                }
                else
                {
                    count++;
                    index++;
                }
            }
            return count;
        }

        private int CountOdds(int[] array)
        {
            int index = 0;
            int count = 0;
            while (index < array.Length)
            {
                if (array[index] % 2 == 0)
                {
                    continue;
                }
                else
                {
                    count++;
                    index++;
                }
            }
            return count;
        }
    }
}