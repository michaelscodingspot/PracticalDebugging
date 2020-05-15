using System.Collections.ObjectModel;
using System.Windows;

namespace PracticalDebuggingDemos.Demos.Memory
{

    public class Stock
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsUp { get; set; }
    }
    /// <summary>
    /// Interaction logic for StockActionWindow.xaml
    /// </summary>
    public partial class StockMarketWindow : Window
    {
        public StockMarketWindow(StockMarketManager manager)
        {
            manager.StockChanged += OnStockChanged;

            Stocks = new ObservableCollection<Stock>();
            Stocks.Add(new Stock()
            {
                Name = "Tesla",
                Price = 750,
                IsUp = false,
            });
            Stocks.Add(new Stock()
            {
                Name = "Microsoft",
                Price = 183,
                IsUp = true,
            });
            Stocks.Add(new Stock()
            {
                Name = "Intel",
                Price = 183,
                IsUp = true,
            });
            Stocks.Add(new Stock()
            {
                Name = "ALPHABET",
                Price = 66,
                IsUp = true,
            });
            Stocks.Add(new Stock()
            {
                Name = "Oracle",
                Price = 54,
                IsUp = false,

            });
            Stocks.Add(new Stock()
            {
                Name = "Apple",
                Price = 320,
                IsUp = true,
            });
            InitializeComponent();
        }

        private void OnStockChanged(StockChangeEvent obj)
        {
        }

        public ObservableCollection<Stock> Stocks
        {
            get { return (ObservableCollection<Stock> )GetValue(StocksProperty); }
            set { SetValue(StocksProperty, value); }
        }
        public static readonly DependencyProperty StocksProperty =
            DependencyProperty.Register("Stocks", typeof(ObservableCollection<Stock> ), typeof(StockMarketWindow), new PropertyMetadata());




        



    }
}
