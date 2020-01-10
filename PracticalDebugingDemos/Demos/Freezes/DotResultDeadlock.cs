using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    class DotResultDeadlock : DemoBase
    {
        public override void Start()
        {
            var x = Do().Result;
        }

        private async Task<int> Do()
        {
            await Task.Delay(1000);
            return 5;
        }
    }
}
