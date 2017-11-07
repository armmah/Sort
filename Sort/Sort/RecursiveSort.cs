namespace AllSort
{
    public abstract class RecursiveSort<T> : Sort<T>
    {
        public RecursiveSort(T[] array, int count) : base(array, count) { }
    }
}
