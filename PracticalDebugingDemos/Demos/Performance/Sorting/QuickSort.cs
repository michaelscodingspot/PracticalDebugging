using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalDebuggingDemos.Demos.CPUBound
{
    public class QuickSort : ISortingStrategy
    {
        private DateTime _startTime;
        private int _countOperations;

        public void Sort(int[] data)
        {
            _startTime = DateTime.Now;
            _countOperations = 0;
            Quick_Sort(data, 0, data.Length - 1);
        }

        private void Quick_Sort(int[] arr, int left, int right) 
        {
            _countOperations++;
            if (_countOperations % 50 == 0)
            {
                    WriteLog($"Time elapsed seconds: {(DateTime.Now - _startTime).TotalSeconds}");
            }

            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1) {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right) {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }
        
        }

        private void WriteLog(string msg)
        {
            var file = Path.GetTempPath() + @"\PracticalDebugging\quick_sort.txt";
            File.AppendAllLines(file, new string[] { msg });
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true) 
            {

                while (arr[left] < pivot) 
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else 
                {
                    return right;
                }
            }
        }
    }
}
