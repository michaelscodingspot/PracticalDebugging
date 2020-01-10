using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticalDebuggingDemos.Demos.CPUBound
{
    /// <summary>
    /// Interaction logic for SortingMenu.xaml
    /// </summary>
    public partial class SortingMenu : UserControl
    {
        public SortingMenu()
        {
            InitializeComponent();
        }

        private void StartSorting(object sender, RoutedEventArgs e)
        {
            var strategy = GetSortingStrategy();
            var items = GetItems();

            Stopwatch sw = new Stopwatch();
            sw.Start();
            strategy.Sort(items);
            sw.Stop();
            resultTextBlock.Text = "Finished. Operation time in seconds: " + sw.Elapsed.TotalSeconds;
        }

        private ISortingStrategy GetSortingStrategy()
        {
            ISortingStrategy s;
            switch (sortStrategy.Text)
            {
                case "Quick Sort":
                    s = new QuickSort();
                    break;
                case "Bubble":
                default:
                    s = new Bubble();
                    break;
            }

            return s;
        }

        private int[] GetItems()
        {
            int[] res = new int[int.Parse(numItems.Text)];
            Random rnd = new Random();
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = rnd.Next();
            }

            return res;
        }
    }
}
