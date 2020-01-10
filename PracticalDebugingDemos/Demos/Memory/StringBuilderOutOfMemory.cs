using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class StringBuilderOutOfMemory : DemoBase
    {
        public override void Start()
        {
            StringBuilder sb = new StringBuilder(15, 15);
            sb.Append("Substring #1 ");
            try {
                sb.Insert(0, "Substring #2 ", 1);
            }
            catch (OutOfMemoryException e) {
                AppendTextToContent("Out of Memory: {0}", e.Message);
            }

            AppendTextToContent("OutOfMemoryException thrown and program keeps running");
        }
    }
}
