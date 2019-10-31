using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AddingNumbersInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how many random numbers to add");
            var items = int.Parse(Console.ReadLine());
            var numbers = GetRandomNumbers(items);
            var sum = Sum(numbers);
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine("Finished");
        }

        private static object _lock = new object();


        public static int[] GetRandomNumbers(int items)
        {
            int[] res = new int[items];
            var rnd = new Random();
            for (int i = 0; i < items; i++)
            {
                res[i] = rnd.Next(100);
            }

            return res;
        }

        public static int Sum(int[] arr)
        {
            int items = arr.Length;
            int total = 0;
            int threads = Math.Min(items, 8);
            var partSize = Math.Round(items / (double)threads + 0.5);
            Task[] tasks = new Task[threads];
            for (int iThread = 0; iThread <  threads; iThread++)
            {
                var localThread = iThread;
                tasks[localThread] = Task.Run(() =>
                {
                    var to = Math.Min(items, Math.Round((localThread + 1) * partSize + 0.5));
                    for (int j = (int)(localThread * partSize); j < to; j++)
                    {
                        lock (_lock)
                        {
                            total += arr[j];
                        }
                    }
                });
            }
 
            Task.WaitAll(tasks);
            //var verifySum = arr.Sum();
            return total;
        }

    }
}
