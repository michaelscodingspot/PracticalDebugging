using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class MemoryExceeds2Gb : DemoBase
    {
        public override void Start()
        {
            try
            {
                Double[] values = GetData();
                // Compute mean.
                AppendTextToContent("Sample mean: {0}, N = {1}",
                    GetMean(values), values.Length);
            }
            catch (Exception e)
            {
                AppendTextToContent(e);
                AppendTextToContent("Program can keep running");
            }

        }

        

        private Double[] GetData()
        {
            Random rnd = new Random();
            List<Double> values = new List<Double>();
            for (int ctr = 1; ctr <= 200000000; ctr++) {
                values.Add(rnd.NextDouble());
                if (ctr % 10000000 == 0)
                    AppendTextToContent("Retrieved {0:N0} items of data.",
                        ctr);
            }
            return values.ToArray();
        }

        private static Double GetMean(Double[] values)
        {
            Double sum = 0;
            foreach (var value in values)
                sum += value;

            return sum / values.Length;
        }
    }
}
