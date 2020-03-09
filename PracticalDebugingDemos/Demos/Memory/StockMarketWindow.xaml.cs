using PracticalDebuggingDemos.Demos.Memory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PracticalDebugingDemos.Demos.Memory
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
            this.Closed += (s, e) => manager.StockChanged -= OnStockChanged;

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

        // Using a DependencyProperty as the backing store for Stocks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StocksProperty =
            DependencyProperty.Register("Stocks", typeof(ObservableCollection<Stock> ), typeof(StockMarketWindow), new PropertyMetadata());




        



    }
}
