namespace AllSort
{
    // Slowest of the three algorithms, but consumes the least space.
    //  [Time] - O(n^2)
    //  [Space] - O(1)
    public class BubbleSort<T> : IterativeSort<T>
    {
        public BubbleSort(T[] array, int count) : base(array, count) { }
        public override T[] Do(Comparison<T> comparison)
        {
            return sortedArray = Sort(array, 0, count, comparison);
        }
        public static T[] Sort(T[] array,
            int startIndex, int length, Comparison<T> comparison)
        {
            for (int i = startIndex; i < startIndex + length; i++)
                for (int k = startIndex; k < startIndex + length - i - 1; k++)
                    if (comparison.Invoke(array[k], array[k + 1]) == 1)
                        Swap(ref array[k], ref array[k + 1]);

            return array;
        }
    }
    public class BubbleSortRecursive<T> : RecursiveSort<T>
    {
        public BubbleSortRecursive(T[] array, int count) : base(array, count) { }
        public override T[] Do(Comparison<T> comparison)
        {
            return sortedArray = Sort(array, 0, count, comparison);
        }
        public static T[] Sort(T[] array,
            int startIndex, int length, Comparison<T> comparison)
        {
            for (int i = startIndex; i < startIndex + length - 1; i++)
                if (comparison.Invoke(array[i], array[i + 1]) == 1)
                    Swap(ref array[i], ref array[i + 1]);

            if (length <= startIndex + 2)
                return array;
            return Sort(array, startIndex, length - 1, comparison);
        }
    }
}
