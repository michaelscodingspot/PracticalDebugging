using System;

namespace PracticalDebuggingDemos.Demos.Memory
{


    public class StockMarketMemoryLeak : DemoBase
    {
        public static StockMarketManager Manager = new StockMarketManager();
        public override void Start()
        {
            var actionWindow = new StockMarketWindow(Manager);
            actionWindow.Show();
        }
    }


    public class StockMarketManager
    {
        public event Action<StockChangeEvent> StockChanged;
    }

    public class StockChangeEvent
    {
    }
}

