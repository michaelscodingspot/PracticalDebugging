using PracticalDebugingDemos.Demos.Freezes.OddEven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    public class OddEvenFreeze : DemoBase
    {
        public override void Start()
        {
            Content = new OddEvenMenu();
        }
    }


}
