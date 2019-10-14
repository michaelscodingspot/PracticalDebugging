using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Benchmarks.Serializers
{
    public class RequestPerSecondClient
    {
        public async Task Run()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            
            var client = new HttpClient();
            
            //var obj = new Models.ThousandSmallClassList();
            (Uri uri, var obj, bool serialize) = SerializeThousandSmallClassList();
            //(Uri uri, var obj, bool serialize) = DeserializeThousandSmallClassList();

            var serializer = new SerializeToString<Models.ThousandSmallClassList>();
            serializer.Setup();
            //serializer.ut();
            var json = serializer.RunUtf8Json();//System.Text.Json.JsonSerializer.Serialize(obj);

            // Warmup, just in case
            for (int i = 0; i < 100; i++)
            {
                //await DoDeserializeRequest(json, client, uri);
                await DoRequest(json, client, uri, serialize);
            }


            int count = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, int.MaxValue, async (iter, state) =>
            {
                Interlocked.Increment(ref count);
                if (sw.Elapsed > TimeSpan.FromSeconds(10)) state.Break();

                //await DoDeserializeRequest(json, client, uri);
                //await DoSerializeRequest(json, client, uri);
                await DoRequest(json, client, uri, serialize);

            });

            int countAverage = count / 10;
            Console.Beep(); 
            Console.WriteLine("Requests in one second: " + countAverage);
            Console.ReadLine();
        }

        private static Uri SmallClassUri()
        {
            var base1 = "https://localhost:44337/";
            var base2 = "https://localhost:5001/";
            return new Uri(base2 + "mvc/DeserializeSmallClass");
        }

        private static (Uri, object, bool serialize) DeserializeThousandSmallClassList()
        {
            var base1 = "https://localhost:44337/";
            var base2 = "https://localhost:5001/";
            return (new Uri(base2 + "mvc/DeserializeThousandSmallClassList"), new Models.ThousandSmallClassList(), false);
        }

        private static (Uri, object, bool serialize) SerializeThousandSmallClassList()
        {
            var base1 = "https://localhost:44337/";
            var base2 = "https://localhost:5001/";
            return (new Uri(base2 + "mvc/SerializeThousandSmallClassList"), new Models.ThousandSmallClassList(), true);
        }

        private static async Task DoRequest(string json, HttpClient client, Uri uri, bool serialize)
        {
            if (serialize)
                DoSerializeRequest(json, client, uri);
            else
                DoDeserializeRequest(json, client, uri);
        }
        private static async Task DoDeserializeRequest(string json, HttpClient client, Uri uri)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            result.Dispose();
        }

        private static async Task DoSerializeRequest(string json, HttpClient client, Uri uri)
        {
            var result = await client.GetAsync(uri);
            result.Dispose();
        }


        //public Entry GetEntry()
        //{
        //    var BaseDateTime = DateTime.Now;
        //    return new Entry()
        //    {
        //        Attributes = new Attributes
        //        {
        //            Created = BaseDateTime.AddDays(1),
        //            Enabled = true,
        //            Expires = BaseDateTime.AddDays(1).AddYears(1),
        //            NotBefore = BaseDateTime,
        //            RecoveryLevel = "Purgeable",
        //            Updated = BaseDateTime.AddSeconds(1),
        //        },
        //        ContentType = "application/xml",
        //        Id = "https://benchmarktest.id/item/value" + 2,
        //        Tags = new[] {"test", "perf", "json"},
        //    };
            
        //}


        //public class Entry
        //{
        //    public Attributes Attributes { get; set; }
        //    public string ContentType { get; set; }
        //    public string Id { get; set; }
        //    public bool Managed { get; set; }
        //    public string[] Tags { get; set; }
        //}
        //public partial class Attributes
        //{
        //    public DateTimeOffset Created { get; set; }
        //    public bool Enabled { get; set; }
        //    public DateTimeOffset Expires { get; set; }
        //    public DateTimeOffset NotBefore { get; set; }
        //    public string RecoveryLevel { get; set; }
        //    public DateTimeOffset Updated { get; set; }
        //}
    }
}
