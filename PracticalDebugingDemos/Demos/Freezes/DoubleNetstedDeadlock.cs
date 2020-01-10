using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    public class DoubleNetstedDeadlock : DemoBase
    {
        public override void Start()
        {
            object lock1 = new object();
            object lock2 = new object();
            Debug.WriteLine("Starting...");
            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Debug.WriteLine("Entered lock1 in task1...");
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        Debug.WriteLine("Finished Thread 1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lock2)
                {
                    Debug.WriteLine("Entered lock2 in task2...");
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        Debug.WriteLine("Finished Thread 2");
                    }
                }
            });
            Task.WaitAll(task1, task2);
        }
    }
}
