using System;

namespace Sorter
{
    public class SortUtility
    {
        // Sort method should be implemented here
        // It should accept an int[] and a delegate you define that performs the actual comparison

        public delegate bool compareFunction(int i, int j);

        public static void Sort(int[] arr, compareFunction compare)
        {
            QuickSort(arr, 0, arr.Length - 1, compare);
        }

        private static void QuickSort(int[] arr, int low, int high, compareFunction compare)
        {
            int pivot = arr[low + (high - low) / 2];
            //Console.WriteLine("pivot: " + pivot + " low: " + low + " high: " + high);

            int i = low;
            int j = high;

            while (i <= j)
            {
                while (compare(arr[i], pivot))
                {
                    i++;
                }
                while (compare(pivot, arr[j]))
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (low < j)
            {
                QuickSort(arr, low, j, compare);
            }
            if (i < high)
            {
                QuickSort(arr, i, high, compare);
            }
        }

    }
}
