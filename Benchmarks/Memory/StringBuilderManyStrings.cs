using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Benchmarks.Memory
{
    public class StringBuilderManyStrings
    {
        [Benchmark]
        public string RegularConcatenation()
        {
            string s = "";
            for (int i = 0; i < 1000; i++)
            {
                s += "a";
            }

            return s;
        }
 
        [Benchmark]
        public string StringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append("a");
            }

            return sb.ToString();
        }
    }
}
