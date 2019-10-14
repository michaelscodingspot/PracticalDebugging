using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Running;
using Benchmarks.Memory;
using Benchmarks.Serializers;

namespace Benchmarks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //BenchmarkRunner.Run<StringBuilderFewStrings>();
            //BenchmarkRunner.Run<StringBuilderManyStrings>();
            //BenchmarkRunner.Run<SerializeCustomer>();
            //BenchmarkRunner.Run<SerializeToString<Models.SmallClass>>();
            //BenchmarkRunner.Run<SerializeToString<Models.ThousandSmallClassDictionary>>();
            //BenchmarkRunner.Run<SerializeToStream<Models.ThousandSmallClassDictionary>>();
            //BenchmarkRunner.Run<DeserializeFromString<Models.ThousandSmallClassDictionary>>();
            await new RequestPerSecondClient().Run(false, false);

            //var x = new SerializeToStream<Models.SmallClass>();
            //x.Setup();
            //x.RunSystemTextJson();
            //var memoryStream = x.GetMemoryStream();
            //x.GetStreamWriter().Flush();

            //memoryStream.Position = 0;
            //using var sr = new StreamReader(memoryStream);
            //var res = sr.ReadToEnd();
            //Console.WriteLine(res);


            //var x = new SerializeToString<Models.SmallClass>();
            //x.Setup();
            //var s1 = x.RunSystemTextJson();
            //var s2 = x.RunNewtonsoft();
            //var s3 = x.RunDataContractJsonSerializer(); //with UTC
            //var s4 = x.RunJil();
            //var s5 = x.RunUtf8Json(); //same output as newtonsoft 
            //var s6 = x.RunServiceStack();// with wrong UTC 0000

            //var x = new DeserializeFromString<Models.SmallClass>();
            //x.ServiceStackSetup();
            //var y = x.RunServiceStack();
        }
    }
}
