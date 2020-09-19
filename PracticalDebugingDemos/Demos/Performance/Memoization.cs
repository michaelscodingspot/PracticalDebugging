using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    public class Memoization : DemoBase
    {
        public override void Start()
        {
            var memoized = ((Func<int, int>)LongCalculate).Memoize();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int x = memoized(12); 
            Debug.WriteLine(sw.ElapsedMilliseconds);//500
            sw.Restart();
            x = memoized(12);
            Debug.WriteLine(sw.ElapsedMilliseconds);//0
        }

        public static int LongCalculate(int y)
        {
            Thread.Sleep(500);
            return y * y;
        }
    }

    static class MemoizeExtensions
    {
        public static Func<T1, TResult> Memoize<T1, TResult>(this Func<T1, TResult> func)
        {
            var cache = new ConcurrentDictionary<T1, TResult>();
            return key => cache.GetOrAdd(key, func);
        }
    }
}
