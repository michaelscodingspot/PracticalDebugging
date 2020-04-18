using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    public class BeginInvokeFreeze : DemoBase
    {
        public override void Start()
        {
            A();
        }

private void A()
{
    Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => B()));
}

private void B()
{
    Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => A()));
}
    }
}
