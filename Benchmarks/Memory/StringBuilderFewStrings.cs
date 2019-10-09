using BenchmarkDotNet.Attributes;
using System.Text;

namespace Benchmarks.Memory
{
    public class StringBuilderFewStrings
    {
        public static string A = "asdf";
        public static string B = "ghjkl";
        public static string C = ";lkjqwer";
        public static string D = "zx";
 
 
        [Benchmark]
        public string ExecuteA()
        {
            return A + B + C + D;
        }
 
        [Benchmark]
        public string ExecuteB()
        {
            StringBuilder sb = new StringBuilder(A);
            sb.Append(B);
            sb.Append(C);
            sb.Append(D);
            return sb.ToString();
        }
    }
}
