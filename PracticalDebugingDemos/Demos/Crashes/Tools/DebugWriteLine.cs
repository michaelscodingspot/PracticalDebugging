using PracticalDebuggingDemos;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Crashes.Tools
{
    public class DebugWriteLine : DemoBase
    {
        public override void Start()
        {
            AppendTextToContent("Starting to write Debug.WriteLine()");
            Task.Run(() =>
            {
                while (true)
                {
                    System.Diagnostics.Debug.WriteLine("Current time is: " + DateTime.Now.ToString());
                    Thread.Sleep(1000);
                }
            });
        }
    }
}
