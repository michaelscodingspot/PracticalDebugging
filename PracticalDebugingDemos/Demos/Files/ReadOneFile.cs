using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Files
{
    public class ReadOneFile : DemoBase
    {
        public override void Start()
        {
            var files = Directory.GetFiles(@"C:\Windows");
            ReadFirstFile(files);
            AppendTextToContent("Finished");
        }

        private void ReadFirstFile(string[] files)
        {
            var firstFile = files.First();
            ReadFile(firstFile);
        }

        private void ReadFile(string file)
        {
            var lines = File.ReadAllLines(file);
        }
    }
}
