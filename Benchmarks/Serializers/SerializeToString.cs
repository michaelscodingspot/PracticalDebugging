using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using SST = ServiceStack.Text;

namespace Benchmarks.Serializers
{
    public class SerializeToString<T> where  T : class, new()
    {

        private T _instance;
        private DataContractJsonSerializer _dataContractJsonSerializer;

        [GlobalSetup]
        public void Setup()
        {
            _instance = _instance ?? new T();
            _dataContractJsonSerializer = _dataContractJsonSerializer ?? new DataContractJsonSerializer(typeof(T));
        }

        [Benchmark]
        public string RunSystemTextJson()
        {
            return JsonSerializer.Serialize(_instance);
        }

        [Benchmark]
        public string RunNewtonsoft()
        {
            return JsonConvert.SerializeObject(_instance);
        }

        [Benchmark]
        public string RunDataContractJsonSerializer()
        {
            using (MemoryStream stream1 = new MemoryStream())
            {
                _dataContractJsonSerializer.WriteObject(stream1, _instance);
                stream1.Position = 0;
                using var sr = new StreamReader(stream1);
                return sr.ReadToEnd();
            }
        }

        [GlobalSetup(Target = nameof(RunJil))]
        public void JilSetup()
        {
            Setup();
            RunJil();
        }
        [Benchmark]
        public string RunJil()
        {
            return Jil.JSON.Serialize(_instance);
        }

        [Benchmark]
        public string RunUtf8Json()
        {
            return Utf8Json.JsonSerializer.ToJsonString(_instance);
        }

        [Benchmark]
        public string RunServiceStack()
        {
            return SST.JsonSerializer.SerializeToString(_instance);
        }

        
    }
}
