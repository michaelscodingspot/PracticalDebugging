using PracticalDebuggingDemos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Crashes.Tools
{
    public class TraceWriteLine : DemoBase
    {
        public override void Start()
        {
            AppendTextToContent("Starting to write Trace.WriteLine()");
            Task.Run(() =>
            {
                while (true)
                {
                    System.Diagnostics.Trace.WriteLine("Current time is: " + DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }

            });
        }
    }
}
