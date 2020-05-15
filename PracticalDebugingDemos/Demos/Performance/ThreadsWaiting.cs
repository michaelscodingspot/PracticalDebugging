using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    class ThreadsWaiting : DemoBase
    {
        public override void Start()
        {
            object lock1 = new object();
            AppendTextToContent("Started");

            var task1 = Task.Run(() => { ThreadOperation(lock1, "Thread A"); });
            var task2 = Task.Run(() => { ThreadOperation(lock1, "Thread B"); });
            Task.WhenAll(task1, task2).ContinueWith((t) =>
            {
                AppendTextToContent("Finished");
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ThreadOperation(object lock1, string threadName)
        {
            for (int i = 0; i < 10; i++)
            {
                lock (lock1)
                {
                    AppendTextToContent($"{threadName} is running iteration {i}");
                    Thread.Sleep(5000);
                }
            }


        }
    }
}
