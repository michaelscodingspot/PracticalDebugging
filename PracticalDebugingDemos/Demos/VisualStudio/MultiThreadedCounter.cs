using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebugingDemos.Demos.VisualStudio
{
    public class MultiThreadedCounter : DemoBase
    {
        private int _counter;

        public override void Start()
        {
            _counter = 1;
            Task.Run(IncreaseCounter);
            Task.Run(DoubleCounter);
            Task.Run(LogCounter);

        }

        private void IncreaseCounter()
        {
            while (true)
            {
                Interlocked.Add(ref _counter, 1);
                Thread.Sleep(15);
            }
        }

        private void DoubleCounter()
        {
            while (true)
            {
                var counterNow = _counter;
                Interlocked.Add(ref _counter, counterNow);
                Thread.Sleep(200);
            }
        }

        private void LogCounter()
        {
            while (true)
            {
                AppendTextToContent($"Counter: {_counter}");
                Thread.Sleep(500);
            }
        }

        
    }
}
