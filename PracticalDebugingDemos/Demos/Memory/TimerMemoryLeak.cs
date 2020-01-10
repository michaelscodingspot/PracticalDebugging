using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Threading.Timer;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class TimerMemoryLeak : DemoBase
    {
        public class MyClass
        {
            private readonly DemoBase _demoBase;

            public MyClass(DemoBase demoBase)
            {
                _demoBase = demoBase;
                Timer timer = new Timer(HandleTick);
                timer.Change(TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2));
            }

            private void HandleTick(object state)
            {
                _demoBase.AppendTextToContent("Tick");
                Debug.WriteLine("Tick");
            }
        }

        public override void Start()
        {
            new MyClass(this);
        }

    }
}
