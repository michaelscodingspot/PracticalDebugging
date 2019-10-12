using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Attributes;
using Jil;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using SST = ServiceStack.Text;

namespace Benchmarks.Serializers
{
    //public class SerializeCustomer
    //{
    //    [DataContract]  
    //    class BigClass
    //    {
    //        [DataMember]
    //        public DateTime DateOfBirth { get; set; }
    //        [DataMember]
    //        public string FirstName { get; set; }
    //        [DataMember]
    //        public string LastName { get; set; }
    //        [DataMember]
    //        public int NumPurchases { get; set; }
    //    }

    //    private BigClass _customer;

    //    [GlobalSetup]
    //    public void Setup()
    //    {
    //        _customer = new BigClass()
    //        {
    //            DateOfBirth = new DateTime(1955, 10, 28),
    //            FirstName = "Bill",
    //            LastName = "Gates",
    //            NumPurchases = 1521
    //        };
    //    }

    //    [Benchmark]
    //    public string RunSystemTextJson()
    //    {
    //        return JsonSerializer.Serialize(_customer);
    //    }

    //    [Benchmark]
    //    public string Newtonsoft()
    //    {
    //        return JsonConvert.SerializeObject(_customer);
    //    }

    //    [Benchmark]
    //    public string DataContractJsonSerializer()
    //    {
    //        using (MemoryStream stream1 = new MemoryStream())
    //        {
    //            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BigClass));
    //            //TODO: Possibly change MemoryStream to StringWriter for performance
    //            ser.WriteObject(stream1, _customer);
    //            stream1.Position = 0;

    //            // deserialize:
    //            //var p2 = (BigClass)ser.ReadObject(stream1);  

    //            using var sr = new StreamReader(stream1);
    //            return sr.ReadToEnd();
    //        }
    //    }

    //    [Benchmark]
    //    public string Jil()
    //    {
    //        using var output = new StringWriter();
    //        JSON.Serialize(
    //            _customer,
    //            output
    //        );
    //        return output.ToString();
    //    }

    //    [Benchmark]
    //    public string Utf8Json()
    //    {
    //        return JsonSerializer.Serialize(_customer); //.ToJsonString(_customer);
    //    }

    //    [Benchmark]
    //    public string ServiceStack()
    //    {
    //        return SST.JsonSerializer.SerializeToString(_customer);
    //    }

        
    //}
}
