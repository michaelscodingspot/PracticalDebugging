using System;
using System.IO;
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
            //BenchmarkRunner.Run<SerializeCustomer>();
            //BenchmarkRunner.Run<SerializeToString<Models.SmallClass>>();
            //BenchmarkRunner.Run<SerializeToStream<Models.SmallClass>>();

            var x = new SerializeToStream<Models.SmallClass>();
            x.Setup();
            x.RunServiceStack();
            var memoryStream = x.GetMemoryStream();
            x.GetStreamWriter().Flush();

            memoryStream.Position = 0;
            using var sr = new StreamReader(memoryStream);
            var res = sr.ReadToEnd();
            //var x = new SerializeToString<Models.SmallClass>();
            //x.Setup();
            //var s1 = x.SystemTextJson();
            //var s2 = x.RunNewtonsoft();
            //var s3 = x.RunDataContractJsonSerializer(); //with UTC
            //var s4 = x.RunJil();
            //var s5 = x.RunUtf8Json(); //same output as newtonsoft 
            //var s6 = x.RunServiceStack();// with wrong UTC 0000
        }
    }
}
