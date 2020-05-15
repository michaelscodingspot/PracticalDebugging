using PracticalDebuggingDemos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Dumps
{
    public class FirstChanceException : DemoBase
    {
        public override void Start()
        {
            string mystring = "1234,523";
            Foo(mystring);
        }

        private void Foo(string mystring)
        {
            try
            {
                int parsed = Parse(mystring);
                AppendTextToContent("Convert succeeded " + parsed.ToString());
            }
            catch (Exception ex)
            {
                AppendTextToContent("Parsing failed " + ex.ToString());
            }
        }

        private int Parse(string mystring)
        {
            var result = int.Parse(mystring);
            return result;
        }
    }
}
