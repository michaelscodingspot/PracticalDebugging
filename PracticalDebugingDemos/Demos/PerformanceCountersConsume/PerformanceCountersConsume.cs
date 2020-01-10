using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PracticalDebuggingDemos.Demos.PerformanceCountersThreeCPUThreads.PerformanceCountersConsume
{
    public class PerformanceCountersConsume : DemoBase
    {
        public override void Start()
        {
            ConsumeCounters();

            //CreateCustomCounter();
        }

        private void ConsumeCounters()
        {
            var currentProcess = Process.GetCurrentProcess().ProcessName;
            PerformanceCounter privateBytes =
                new PerformanceCounter(categoryName: "Process", counterName: "Private Bytes", instanceName: currentProcess);
            PerformanceCounter gen2Collections =
                new PerformanceCounter(categoryName: ".NET CLR Memory", counterName: "# Gen 2 Collections", instanceName: currentProcess);

            Debug.WriteLine("private bytes = " + privateBytes.NextValue());
            Debug.WriteLine("gen 2 collections = " + gen2Collections.NextValue());

            Content = "private bytes = " + privateBytes.NextValue() + "\n" + "gen 2 collections = " + gen2Collections.NextValue();
        }

        private void CreateCustomCounter()
        {
            bool exists = PerformanceCounterCategory.Exists("MyTimeCategory");
            if (!exists)
            {
                PerformanceCounterCategory.Create("MyTimeCategory", "My category help",
                    PerformanceCounterCategoryType.SingleInstance, "Current Seconds",
                    "My counter help");
            }

            PerformanceCounter pc = new PerformanceCounter("MyTimeCategory", "Current Seconds", false);
            while (true)
            {
                Thread.Sleep(1000);
                pc.RawValue = DateTime.Now.Second;
            }
        }
    }
}
