namespace AllSort
{
    // Quickest of the three algorithms (in worst case scenario, but in average is equal to QuickSort), consuming the most space
    // MergeSort is the best choice when you are not concerned with the memory consuption.
    //  [Time] - O(n log n) in all scenarios (best - average - worst)
    //  [Space] - O(n)
    public class MergeSort<T> : RecursiveSort<T>
    {
        public MergeSort(T[] array, int count) : base(array, count) { }
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

            //Is equavalent to (l + r) / 2, but wont cause an overflow in case of huge numbers
            int m = l + (r - l) / 2;

            //Dividing the array
            _Sort(array, l, m, comparison);
            _Sort(array, m + 1, r, comparison);
            
            //Merging two halves
            Merge(array, l, m, r, comparison);
        }
        private static void Merge(T[] array, int l, int m, int r, Comparison<T> comparison)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            T[] L = new T[n1],
                R = new T[n2];

            for (i = 0; i < n1; i++)
                L[i] = array[l + i];
            for (j = 0; j < n2; j++)
                R[j] = array[m + j + 1];

            i = j = 0;
            k = l;
            while(i < n1 && j < n2)
            {
                if (comparison.Invoke(R[j], L[i]) == 1)
                    array[k] = L[i++];
                else
                    array[k] = R[j++];
                k++;
            }
            while (i < n1)
                array[k++] = L[i++];
            while (j < n2)
                array[k++] = R[j++];
        }
    }
}