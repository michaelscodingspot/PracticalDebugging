using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Crashes
{
    public class SimpleCrash : DemoBase
    {
        public override void Start()
        {
            StartCalculation(15, 0);
        }

        private int StartCalculation(int a, int b)
        {
            int first = a;
            int second = b;
            return Divide(a, b);
        }

        private int Divide(int num1, int num2)
        {
            return num1 / num2;
        }
    }
}
