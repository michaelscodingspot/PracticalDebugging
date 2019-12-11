using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using Jil;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using SST = ServiceStack.Text;

namespace Benchmarks.Serializers
{
    public class SerializeToStream<T> where  T : new()
    {
        private Newtonsoft.Json.JsonSerializer _newtonSoftSerializer;

        private T _instance;
        private DataContractJsonSerializer _dataContractJsonSerializer;
        private MemoryStream _memoryStream;
        private StreamWriter _streamWriter;
        private Utf8JsonWriter _utf8JsonWriter;

        [GlobalSetup]
        public void Setup()
        {
            _instance = new T();
            _newtonSoftSerializer = new Newtonsoft.Json.JsonSerializer();
            _dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
            _memoryStream = new MemoryStream(capacity: short.MaxValue);
            _streamWriter = new StreamWriter(_memoryStream, Encoding.UTF8);
            _utf8JsonWriter = new Utf8JsonWriter(_memoryStream);

        }

        public MemoryStream GetMemoryStream()
        {
            return _memoryStream;
        }

        public StreamWriter GetStreamWriter()
        {
            return _streamWriter;
        }

        [Benchmark]
        public void RunSystemTextJson()
        {
            _memoryStream.Position = 0;
            _utf8JsonWriter.Reset();
            JsonSerializer.Serialize(_utf8JsonWriter, _instance);
        }

        [Benchmark]
        public void RunNewtonsoft()
        {
            _memoryStream.Position = 0;
            _newtonSoftSerializer.Serialize(_streamWriter, _instance);
        }

        [Benchmark]
        public void RunDataContractJsonSerializer()
        {
            _memoryStream.Position = 0;
            _dataContractJsonSerializer.WriteObject(_memoryStream, _instance);
        }

        [GlobalSetup(Target = nameof(RunJil))]
        public void JilSetup()
        {
            Setup();
            RunJil();
        }
        [Benchmark]
        public void RunJil()
        {
            _memoryStream.Position = 0;
            
            JSON.Serialize(
                _instance,
                _streamWriter
            );
        }

        [Benchmark]
        public void RunUtf8Json()
        {
            _memoryStream.Position = 0;
            Utf8Json.JsonSerializer.Serialize(_memoryStream, _instance);
        }

        [Benchmark]
        public void RunServiceStack()
        {
            _memoryStream.Position = 0;
            SST.JsonSerializer.SerializeToStream(_instance, _memoryStream);
        }

        
    }
}
