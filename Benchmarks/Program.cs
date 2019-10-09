using System;
using BenchmarkDotNet.Running;
using Benchmarks.Memory;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<StringBuilderFewStrings>();
            BenchmarkRunner.Run<StringBuilderManyStrings>();
        }
    }
}
