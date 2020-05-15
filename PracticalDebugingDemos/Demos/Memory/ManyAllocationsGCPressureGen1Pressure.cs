using PracticalDebuggingDemos.Demos.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.Memory
{
    public class ManyAllocationsGCPressureGen1Pressure : DemoBase
    {
        static List<Person> listStatic;

        public override void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    List<Person> list = new List<Person>();
                    for (int i = 0; i < 12000; i++)
                    {

                        var person = new Person()
                        {
                            Age = 1242,
                            Name = "Bill Gates"
                        };
                        list.Add(person);
                    }
                    Task.Run(() =>
                    {
                        Thread.Sleep(1000);
                        var list2 = list;
                        listStatic = list2;
                    });
                }
            });
        }
    }
}
