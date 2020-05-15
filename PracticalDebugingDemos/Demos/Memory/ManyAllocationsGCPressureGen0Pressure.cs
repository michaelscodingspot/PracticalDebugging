using PracticalDebuggingDemos;
using PracticalDebuggingDemos.Demos.Models;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class ManyAllocationsGCPressureGen0Pressure : DemoBase
    {
        /// <summary>
        /// In this test, there's constant allocations of short-lived objects on 5 threads.
        /// Even though there's non-stop allocations, GC pressure isn't created. 
        /// You'll see the performance counter "% Time in GC" rise to be around a fixed range - maybe 10 to 20%. 
        /// Decreasing the threads to 1 thread will reduce it even more.
        /// </summary>
        public override void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        var person = new Person()
                        {
                            Age = 1242,
                            Name = "Bill Gates"
                        };
                    }
                });
            }
            

        }
    }
}
