using System.Threading;

namespace PracticalDebuggingDemos.Demos.PerformanceCounters
{
    public class PerformanceCountersThreeCpuThreads : DemoBase
    {

        public override void Start()
        {
            ThreadPool.QueueUserWorkItem((s) => DoCpuWork());
            ThreadPool.QueueUserWorkItem((s) => DoCpuWork());
            ThreadPool.QueueUserWorkItem((s) => DoCpuWork());
        }

        private void DoCpuWork()
        {
            long count = 0;
            while (true)
            {
                count += 5;
                count = count & long.MaxValue;
            }
        }
    }
}
