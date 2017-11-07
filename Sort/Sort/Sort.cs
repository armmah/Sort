using System.Collections.Generic;

namespace AllSort
{
    public abstract class Sort<T>
    {
        protected T[] array, sortedArray;
        protected int count;
        protected Comparison<T> comparison;

        public delegate int Comparison<T>(T x, T y);
        public Sort(T[] array, int count) { Set(array, count); }
        public T[] Array { get { return array; } }
        public T[] SortedArray
        {
            get
            {
                if (sortedArray == null)
                    throw new System.Exception("Array is not sorted! Call DoRecursive or DoIterative first.");
                return sortedArray;
            }
        }
        public int Count { get { return count; } }

        public void Set(T[] array, int count)
        {
            this.sortedArray = null;
            this.array = array;
            this.count = count;
            this.comparison = Comparer<T>.Default.Compare;
        }
        protected static void Swap(ref T a, ref T b)
        {
            T copy = a;
            a = b;
            b = copy;
        }
        protected static void Swap(ref T[] array, int i, int k)
        {
            T copy = array[i];
            array[i] = array[k];
            array[k] = copy;
        }
        public T[] Do() { return Do(comparison); }
        public abstract T[] Do(Comparison<T> comparison);
    }
}