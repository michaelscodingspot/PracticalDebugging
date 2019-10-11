using System;
using BenchmarkDotNet.Running;
using Benchmarks.Memory;
using Benchmarks.Serializers;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //BenchmarkRunner.Run<StringBuilderFewStrings>();
            //BenchmarkRunner.Run<StringBuilderManyStrings>();
            BenchmarkRunner.Run<SerializeCustomer>();
            //var x = new SerializeCustomer();
            //var s1 = x.SystemTextJson();
            //var s2 = x.Newtonsoft();
            //var s3 = x.DataContractJsonSerializer(); //with UTC
            //var s4 = x.Jil();
            //var s5 = x.Utf8Json(); //same output as newtonsoft 
            //var s6 = x.ServiceStack();// with wrong UTC 0000
        }
    }
}
