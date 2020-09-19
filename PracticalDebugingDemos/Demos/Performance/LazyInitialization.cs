using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    public class LazyInitialization : DemoBase
    {
        Lazy<string> _companyName = new Lazy<string>(() => GetCompanyNameFromDatabase());

        public override void Start()
        {
            Foo();
        }

        public void Foo()
        {
            var created = _companyName.IsValueCreated;//false
            var companyName = _companyName.Value;//Lambda will be called for the first time
            Console.WriteLine($"Company name is {companyName}");
            created = _companyName.IsValueCreated;//true
            var secondTime = _companyName.Value;//Lambda won't be called for the first time
        }



        private static string GetCompanyNameFromDatabase()
        {
            Thread.Sleep(1000);
            return "Evil Corp";
        }
    }

}
