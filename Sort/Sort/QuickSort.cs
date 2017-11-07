using System;
using System.Collections.Generic;

namespace AllSort
{
    // Quickest alogirthm in average case but slower than MergeSort in worst case, although consumes less space
    // If MergeSort algorithm consumes too much space, QuickSort will be the best choice
    //  [Time] - O(n log n) in average and n^2 in worst case scenario
    //  [Space] - O(log n)
    public class QuickSort<T> : RecursiveSort<T>
    {
        public QuickSort(T[] array, int count) : base(array, count) { }
        public override T[] Do(Comparison<T> comparison)
        {
            return sortedArray = Sort(array, 0, count, comparison);
        }
        public static T[] Sort(T[] array, int startIndex, int length, Comparison<T> comparison)
        {
            _Sort(array, startIndex, startIndex + length - 1, comparison);
            return array;
        }
        private static void _Sort(T[] array, int l, int r, Comparison<T> comparison)
        {
            if (l >= r)
                return;

            int p = Partition(array, l, r, comparison);
            _Sort(array, l, p - 1, comparison);
            _Sort(array, p, r, comparison);
        }
        private static int Partition(T[] array, int l, int r, Comparison<T> comparison)
        {
            //Is equavalent to (l + r) / 2, but wont cause an overflow in case of huge numbers
            T pivot = array[l + (r - l) / 2];
            while (l <= r)
            {
                while (comparison.Invoke(pivot, array[l]) == 1)
                    l++;
                while (comparison.Invoke(array[r], pivot) == 1)
                    r--;

                if (l <= r)
                    Swap(ref array[l++], ref array[r--]);
            }
            return l;
        }
    }
}
