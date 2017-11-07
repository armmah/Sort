using System;
using AllSort;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        StringBuilder text = new StringBuilder();
        int[] line = { 3, 4, 5, 6, 412, 23, 454, 243, 1, 1, 1, 56, 132, 0, 2134, -34, 12, -23, 32 };

        AppendTo(line, text);
        Sort<int> sorter = new MergeSort<int>(line.Clone() as int[], line.Length);
        sorter.Do();
        AppendTo(sorter.SortedArray, text);
        text.Append(Environment.NewLine + Environment.NewLine);


        AppendTo(line, text);
        sorter = new QuickSort<int>(line.Clone() as int[], line.Length);
        sorter.Do();
        AppendTo(sorter.SortedArray, text);
        text.Append(Environment.NewLine + Environment.NewLine);
        

        AppendTo(line, text);
        sorter = new BubbleSort<int>(line.Clone() as int[], line.Length);
        sorter.Do();
        AppendTo(sorter.SortedArray, text);
        text.Append(Environment.NewLine + Environment.NewLine);

        Console.Write(text.ToString());
    }
    static void AppendTo(int[] arr, StringBuilder text)
    {
        foreach (var el in arr)
            text.Append($"{el} ");
        text.Append(Environment.NewLine);
    }
}