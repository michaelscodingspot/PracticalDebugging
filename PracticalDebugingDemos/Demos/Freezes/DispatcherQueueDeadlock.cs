using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PracticalDebuggingDemos.Demos.Freezes
{
    public class DispatcherQueueDeadlock : DemoBase
    {
        public override void Start()
        {
            var dispatcher = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                Console.WriteLine("Long operation on another thread");
                dispatcher.Invoke(() =>
                {
                    Application.Current.MainWindow.Title += "a";
        //AppendTextToContent("inside dispatcher");
    });
    // This will occur on the UI Thread
    //MyTextBox.Text = "operation finished");
}).Wait();
            Console.WriteLine("Do more stuff after the long operation is finished");
        }
    }
}
