using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalDebugingDemos.Demos.CPUBound;

namespace PracticalDebugingDemos.Demos.Performance
{
    public class Sorting : DemoBase
    {
        public override void Start()
        {
            Content = new SortingMenu();
        }
    }
}
