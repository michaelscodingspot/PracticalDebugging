using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    public class ManyExceptions : DemoBase
    {
        public override void Start()
        {
            var array =  new string[]
                { "1", "a", "2", "sdf1", "5", "b", "b", "6", "7", "y" };
            var times = 100_000;
            Stopwatch sw = new Stopwatch();
            AppendTextToContent("Starting...");
            sw.Start();
            for (int i = 0; i < times; i++)
            {
                ParseWithPossibleException(array);
            }
            sw.Stop();
            AppendTextToContent($"Finished {times} times withing {sw.Elapsed.TotalSeconds} seconds.");
        }

        public void ParseWithPossibleException(string[] arr)
        {
            int count = 0;
            foreach (var item in arr)
            {
                try
                {
                    var casted = int.Parse(item);
                    count += casted;
                }
                catch { }
            }
        }
    }
}
