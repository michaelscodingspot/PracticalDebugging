using PracticalDebuggingDemos.Demos.Models;

namespace PracticalDebuggingDemos.Demos.Debug3rdPartyCode
{
    public partial class NewtonsoftDeserialize : DemoBase
    {

        public override void Start()
        {
            var serialized = "{\"Nadsafsdfds";
            Person deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<Person>(serialized);
        }
    }
}
