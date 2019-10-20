using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebugingDemos.Demos.CPUBound
{
    public class Sorting : DemoBase
    {
        public override void Start()
        {
            Content = new SortingMenu();
        }
    }
}
