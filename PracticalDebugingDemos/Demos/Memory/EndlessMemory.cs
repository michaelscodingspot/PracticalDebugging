using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class ValuesHolder
    {
        public ValuesHolder()
        {

        }
        public List<double[]> Values { get; set; } = new List<double[]>();
    }

    public class EndlessMemory : DemoBase
    {
        public static ValuesHolder ValuesHolder = new ValuesHolder();
        private static Random rnd = new Random();

        public override void Start()
        {
            try
            {
                ClearContent();
                AppendTextToContent("Start calculating...");
                Task.Run((Action)Calc).ContinueWith((s) =>
                {
                    var mean = GetMean();
                    AppendTextToContent($"Mean is: {mean}");
                }, TaskScheduler.FromCurrentSynchronizationContext());


            }
            catch (Exception e)
            {
                AppendTextToContent(e);
                AppendTextToContent("Program can keep running");
            }

        }

        private void Calc()
        {
            for (int i = 0; i < 1000; i++)
            {
                ValuesHolder.Values.Add(GetData());
                Thread.Sleep(2);

            }
        }

        private Double[] GetData()
        {
            List<Double> values = new List<Double>();

            for (long ctr = 1; ctr <= 10000; ctr++) 
            {
                values.Add(rnd.NextDouble());
            }
            return values.ToArray();
        }

        private static Double GetMean()
        {
            int count = 0;
            Double sum = 0;
            foreach (var numbers in ValuesHolder.Values)
            {
                foreach (var num in numbers)
                {
                    count++;
                    sum += num;
                }
            }

            return sum / count;
        }
    }
}
