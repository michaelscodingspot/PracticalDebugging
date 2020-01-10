using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Debug3rdPartyCode
{
    public class NewtonsoftSerialize : DemoBase
    {

        public override void Start()
        {
            var anon = new
            {
                Name = "Elon Musk",
                Companies = new string[] { "Tesla", "SpaceX", "PayPal" },
                Age = 48
            };
            var serialized = JsonConvert.SerializeObject(anon);
            AppendTextToContent(serialized);
        }
    }
}
