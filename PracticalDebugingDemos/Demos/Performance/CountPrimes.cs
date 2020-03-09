using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    class CountPrimes : DemoBase
    {
        public override void Start()
        {
            int number = 1000;
            AppendTextToContent($"Checking how many prime numbers exist between 2 and {number}.");
            Stopwatch sw = new Stopwatch();
            int sum = 0;
            Task.Run(() =>
            {
                sw.Start();
                sum = HowManyPrimes(number);
                sw.Stop();
                return sum;
            }).ContinueWith((t) =>
            {
                AppendTextToContent($"There are {t.Result} primes from 2 to {number}");
                AppendTextToContent($"Finished within {sw.Elapsed.TotalSeconds} seconds.");
            }, TaskScheduler.FromCurrentSynchronizationContext());


        }

        private int HowManyPrimes(int number)
        {
            int count = 0;
            for (int num = 2; num <= number; num++)
            {
                if (IsPrime(num))
                {
                    count++;
                }
            }
            return count;
        }

        private bool IsPrime(int num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    Thread.Sleep(5);
                    return false;
                }
            }
            return true;
        }
    }
}
