namespace AllSort
{
    public abstract class IterativeSort<T> : Sort<T>
    {
        public IterativeSort(T[] array, int count) : base(array, count) { }
    }
}
