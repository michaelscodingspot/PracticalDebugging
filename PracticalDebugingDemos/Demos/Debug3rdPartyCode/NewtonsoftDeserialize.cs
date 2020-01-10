using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Debug3rdPartyCode
{
    public class NewtonsoftDeserialize : DemoBase
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

public override void Start()
{
    var serialized = "{\"Nadsafsdfds"; 
    Person deserialized = JsonConvert.DeserializeObject<Person>(serialized);
}
    }
}
