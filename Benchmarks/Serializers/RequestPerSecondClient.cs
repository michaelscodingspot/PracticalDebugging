//#define UTF8JSON
//#define DESERIALIZE // default is serialize

using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Benchmarks.Serializers
{
    public class RequestPerSecondClient
    {
        private const string HttpsLocalhost = "https://localhost:5001/";

        public async Task Run(bool serialize, bool isUtf8Json)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(new Models.ThousandSmallClassList());

            // Warmup, just in case
            for (int i = 0; i < 100; i++)
            {
                await DoRequest(json, client, serialize);
            }

            int count = 0;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed < TimeSpan.FromSeconds(1))
            {
                Interlocked.Increment(ref count);
                await DoRequest(json, client, serialize);
            }
            
            Console.Beep(); 
            Console.WriteLine("Requests in one second: " + count);
            Console.ReadLine();
        }

        
        private async Task DoRequest(string json, HttpClient client, bool serialize)
        {
            if (serialize)
                await DoSerializeRequest(client);
            else
                await DoDeserializeRequest(json, client);
        }
        private async Task DoDeserializeRequest(string json, HttpClient client)
        {
            var uri = new Uri(HttpsLocalhost + "mvc/DeserializeThousandSmallClassList");
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(uri, content);
            result.Dispose();
        }

        private async Task DoSerializeRequest(HttpClient client)
        {
            var uri = HttpsLocalhost + "mvc/SerializeThousandSmallClassList";
            var result = await client.GetAsync(uri);
            result.Dispose();
        }
    }
}
