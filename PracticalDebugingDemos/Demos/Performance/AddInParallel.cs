using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    class AddInParallel : DemoBase
    {
        private static object _lock = new object();

        public override void Start()
        {
            int numbers = 500_500_000;
            AppendTextToContent($"Adding {numbers} in parallel.");
            Stopwatch sw = new Stopwatch();
            int sum = 0;
            Task.Run(() =>
            {
                //var numbersArr = CreateArray(numbers);
                sw.Start();
                sum = SumParallel(numbers); //SumSimple(numbersArr);// 
                sw.Stop();
            }).ContinueWith((t) =>
            {
                AppendTextToContent($"Finished in {sw.Elapsed.TotalSeconds} seconds. SumParallel = {sum}");
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }

        private static int[] CreateArray(int numbers)
        {
            return Enumerable.Range(0, numbers).Reverse().ToArray();
        }

        static int SumParallel(int items)
        {
            int total = 0;
            int threads = Math.Min(items, 8);
            var partSize = Math.Round(items / (double)threads + 0.5);
            Task[] tasks = new Task[threads];
            for (int iThread = 0; iThread < threads; iThread++)
            {
                var localThread = iThread;
                tasks[localThread] = Task.Run(() =>
                {
                    var to = Math.Min(items, Math.Round((localThread + 1) * partSize + 0.5));
                    for (int j = (int)(localThread * partSize); j < to; j++)
                    {
                        lock (_lock)
                        {
                            total += j;
                        }
                    }
                });
            }

            Task.WaitAll(tasks);
            //var verifySum = arr.SumParallel();
            return total;
        }

        static int SumSimple(int items)
        {
            int sum = 0;
            for (int i = 0; i < items; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
