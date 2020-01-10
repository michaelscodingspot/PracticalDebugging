using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Misc
{
    public class Break : DemoBase
    {
        public override void Start()
        {
            Debugger.Break();
        }
    }
}
