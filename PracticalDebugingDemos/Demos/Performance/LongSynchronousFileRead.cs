using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Performance
{
    class LongSynchronousFileRead : DemoBase
    {
        public override void Start()
        {
            var file = @"C:\Windows\System32\mspaint.exe";
            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed.TotalSeconds < 20)
            {
                ReadFileSync(file);
                //WithHttpClient(url).GetAwaiter().GetResult();

            }
        }

        private void ReadFileSync(string file)
        {
            var str = File.ReadAllText(file);
        }

    }
}
