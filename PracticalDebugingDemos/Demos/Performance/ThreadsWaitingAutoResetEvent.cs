using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    class ThreadsWaitingAutoResetEvent : DemoBase
    {
        private AutoResetEvent _are;

        public override void Start()
        {
            AppendTextToContent("Started");
            _are = new AutoResetEvent(true);
            var task1 = Task.Run(() => { ThreadOperation("Thread A"); });
            var task2 = Task.Run(() => { ThreadOperation("Thread B"); });
            Task.WhenAll(task1, task2).ContinueWith((t) =>
            {
                AppendTextToContent("Finished");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ThreadOperation(string threadName)
        {
            for (int i = 0; i < 10; i++)
            {
                _are.WaitOne();
                {
                    System.Diagnostics.Debug.WriteLine($"{threadName} is running iteration {i}");
                    Thread.Sleep(2000);
                }
                _are.Set();
            }


        }
    }
}
