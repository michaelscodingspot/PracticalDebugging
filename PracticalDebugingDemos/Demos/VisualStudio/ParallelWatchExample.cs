using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.VisualStudio
{
    public class ParallelWatchExample : DemoBase
    {
        public override void Start()
        {
            for (int i = 0; i < 6; i++)
            {
                var localIndex = i;
                Task.Run(() => StartCalculating(localIndex));
            }
        }

        private void StartCalculating(int i)
        {
            int count = 0;
            while (true)
            {
                count += i;
            }
        }
    }
}
