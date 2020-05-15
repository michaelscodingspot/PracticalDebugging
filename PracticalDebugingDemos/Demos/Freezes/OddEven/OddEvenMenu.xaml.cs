using System;
using System.Collections.Generic;
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

namespace PracticalDebuggingDemos.Demos.Freezes.OddEven
{
    /// <summary>
    /// Interaction logic for OddEvenMenu.xaml
    /// </summary>
    public partial class OddEvenMenu : UserControl
    {
        public OddEvenMenu()
        {
            InitializeComponent();
        }

        private void StartCount(object sender, RoutedEventArgs e)
        {
            var numbers = int.Parse(numItems.Text);
            var rnd = new Random();
            var array = Enumerable.Range(0, numbers).Select(x => rnd.Next()).ToArray();
            var counter = new OddEvenCounter();
            counter.Count(array, out int numberOfOdds, out int numberOfEvens);
            resultTextBlock.Text = $"Odds: {numberOfOdds} and evens: {numberOfEvens}";
        }
    }
}
