using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class StringBuilderFewStrings : DemoBase
    {
        public override void Start()
        {
            
        }


        static string A = "asd";
        static string B = "fgh";
        static string C = "qwer";
        static string D = "tyuuiop";

        private static string s;

        
        public void ExecuteA()
        {
            s = A + B + C + D;
        }
 
        public void ExecuteB()
        {
            StringBuilder sb = new StringBuilder(A);
            sb.Append(B);
            sb.Append(C);
            sb.Append(D);
            s = sb.ToString();
        }
    }
}
