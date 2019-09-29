using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebugingDemos.Demos.Memory
{
    
        
    public class StockMarketMemoryLeak : DemoBase 
    {
        public static StockMarketManager Manager = new StockMarketManager();
public override void Start()
{
    var actionWindow = new StockActionWindow(Manager);
    actionWindow.DoSomething();
    // actionWindow is not used again
}
    }

public class StockActionWindow
{
    public StockActionWindow(StockMarketManager manager)
    {
        manager.StockChanged += OnStockChanged;
    }

    private void OnStockChanged(StockChangeEvent obj)
    {
        // ...
    }

    public void DoSomething()
    {
        
    }
}

public class StockMarketManager
{
    public event Action<StockChangeEvent> StockChanged;
    // ...
}

    public class StockChangeEvent
    {
    }
}

