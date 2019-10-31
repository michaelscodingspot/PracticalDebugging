using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingStrategies
{
    public class Sorter
    {
        public void Start()
        {
            Console.WriteLine("How many random numbers to sort?");
            var items = int.Parse(Console.ReadLine());
            var numbers = GetRandomNumbers(items);
            int[] arrClone = new int[items];
            
            numbers.CopyTo(arrClone, 0);
            new Bubble().Sort(arrClone);
            numbers.CopyTo(arrClone, 0);
            new QuickSort().Sort(arrClone);
            numbers.CopyTo(arrClone, 0);
            new MergeSort().Sort(arrClone);
            Console.WriteLine("Finished Bubble sort, QuickSort, and MergeSort. Profile to find out times.");
        }

        public static int[] GetRandomNumbers(int items)
        {
            int[] res = new int[items];
            var rnd = new Random();
            for (int i = 0; i < items; i++)
            {
                res[i] = rnd.Next(1000);
            }

            return res;
        }
    }
}
