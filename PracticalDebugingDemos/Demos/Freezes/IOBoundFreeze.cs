using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    public class IOBoundFreeze : DemoBase
    {
        public override void Start()
        {
            var url = "http://localhost:60258/Home/LongRunning";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.Method = "GET"; 
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        string res = myStreamReader.ReadToEnd();
                    }
                }
            }
        }

        public async Task AsyncStart()
        {
            var url = "http://localhost:60260/Home/LongRunning";
            var client = new HttpClient();
            var resp = await client.GetAsync(new Uri(url)).ConfigureAwait(false);
            var content = await resp.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

    }
}
