using System;

namespace SortingStrategies
{
    public class QuickSort 
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
            if (_countOperations % 10 == 0)
            {
                Console.WriteLine($"Time elapsed seconds: {(DateTime.Now - _startTime).TotalSeconds}");
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
