//#define UTF8JSON
//#define DESERIALIZE // default is serialize

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks.Serializers
{
    public class RequestPerSecondClient
    {
        private const string HttpsLocalhost = "https://localhost:5001/";

        public async Task Run(bool isSerialize, bool isUtf8Json)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            
            var client = new HttpClient();
            (Uri uri, bool serialize) = isSerialize ? SerializeThousandSmallClassList() : DeserializeThousandSmallClassList();
            var serializer = new SerializeToString<Models.ThousandSmallClassList>();
            serializer.Setup();

            var json = isUtf8Json ? serializer.RunUtf8Json() : serializer.RunSystemTextJson();

            // Warmup, just in case
            for (int i = 0; i < 100; i++)
            {
                await DoRequest(json, client, uri, serialize);
            }

            int count = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(1))
            {
                Interlocked.Increment(ref count);
                await DoRequest(json, client, uri, serialize);
            }
            
            Console.Beep(); 
            Console.WriteLine("Requests in one second: " + count);
            Console.ReadLine();
        }

        
        private static (Uri, bool serialize) DeserializeThousandSmallClassList()
            =>(new Uri(HttpsLocalhost + "mvc/DeserializeThousandSmallClassList"), false);
        

        private static (Uri, bool serialize) SerializeThousandSmallClassList() =>
            (new Uri(HttpsLocalhost + "mvc/SerializeThousandSmallClassList"), true);
        

        private async Task DoRequest(string json, HttpClient client, Uri uri, bool serialize)
        {
            if (serialize)
                await DoSerializeRequest(client, uri);
            else
                await DoDeserializeRequest(json, client, uri);
        }
        private async Task DoDeserializeRequest(string json, HttpClient client, Uri uri)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            result.Dispose();
        }

        private async Task DoSerializeRequest(HttpClient client, Uri uri)
        {
            var result = await client.GetAsync(uri);
            result.Dispose();
        }
    }
}
