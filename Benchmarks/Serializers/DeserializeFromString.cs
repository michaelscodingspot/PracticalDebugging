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
    public class DeserializeFromString<T> where  T : new()
    {

        private T _instance;
        private string _json;
        private DataContractJsonSerializer _dataContractJsonSerializer;
        private SerializeToString<T> _serializer;

        public void Setup()
        {
            _serializer = new SerializeToString<T>();
            _serializer.Setup();
            _instance = new T();
            _dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
        }


        [GlobalSetup(Target = nameof(SystemTextJson))]
        public void SystemTextJsonSetup()
        {
            Setup();
            _json = _serializer.RunSystemTextJson();
        }
        [Benchmark]
        public T SystemTextJson()
        {
            return JsonSerializer.Deserialize<T>(_json);
        }

        [GlobalSetup(Target = nameof(RunNewtonsoft))]
        public void NewtonsoftSetup()
        {
            Setup(); 
            _json = _serializer.RunNewtonsoft();
        }
        [Benchmark]
        public T RunNewtonsoft()
        {
            return JsonConvert.DeserializeObject<T>(_json);
        }

        
        [GlobalSetup(Target = nameof(RunJil))]
        public void JilSetup()
        {
            Setup();
            _json = _serializer.RunJil();
        }
        [Benchmark]
        public T RunJil()
        {
            return Jil.JSON.Deserialize<T>(_json);
        }

        [GlobalSetup(Target = nameof(RunUtf8Json))]
        public void Utf8JsonSetup()
        {
            Setup();
            _json = _serializer.RunUtf8Json();
        }
        [Benchmark]
        public T RunUtf8Json()
        {
            return Utf8Json.JsonSerializer.Deserialize<T>(_json);
        }

        [GlobalSetup(Target = nameof(RunServiceStack))]
        public void ServiceStackSetup()
        {
            Setup();
            _json = _serializer.RunServiceStack();
        }
        [Benchmark]
        public T RunServiceStack()
        {
            return SST.JsonSerializer.DeserializeFromString<T>(_json);
        }

        
    }
}
