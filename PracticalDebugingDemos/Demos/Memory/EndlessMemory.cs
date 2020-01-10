using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class EndlessMemory : DemoBase
    {
        List<Double> values = new List<Double>();
        public static List<double[]> big= new List<double[]>();

        public override void Start()
        {
            try
            {
                for (int i = 0; i < 100000000; i++)
                {
                    big.Add(GetData());

                }
                // Compute mean.
                
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
            for (long ctr = 1; ctr <= 200000000; ctr++) {
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
