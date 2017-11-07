using System;
using AllSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortTestModule
{
    [TestClass]
    public class SortTests
    {
        #region Prepareations
        Sort<int> sorter;
        const int N = 10000;
        int[] array;
        List<int> list;

        [TestInitialize]
        public void InitializeTestResources_int()
        {
            Random random = new Random();
            array = new int[N];
            for (int i = 0; i < N; i++)
                array[i] = random.Next();
            
            if (N > 3) // Add repeting values
            {
                array[N / 2 + 1] = 1;
                array[N / 2] = 1;
                array[N / 2 - 1] = 1;
            }

            list = new List<int>(array);
            list.Sort();
        }
        #endregion

        #region BubbleSort
        [TestMethod]
        public void CheckBubbleSortSemiRecursive()
        {
            if (array.Length > 10000)
                throw new Exception("The array is too long for Recursive BubbleSort, it will cause an overflow.");

            sorter = new BubbleSortRecursive<int>(array.Clone() as int[], array.Length);
            sorter.Do();

            Assert.IsTrue(IsEqualToSortedList(sorter.SortedArray));
        }
        [TestMethod]
        public void CheckBubbleSortIterative()
        {
            sorter = new BubbleSort<int>(array.Clone() as int[], array.Length);
            sorter.Do();
            
            Assert.IsTrue(IsEqualToSortedList(sorter.SortedArray));
        }
        #endregion
        #region QuickSort
        [TestMethod]
        public void CheckQuickSortRecursive()
        {
            sorter = new QuickSort<int>(array.Clone() as int[], array.Length);
            sorter.Do();

            Assert.IsTrue(IsEqualToSortedList(sorter.SortedArray));
        }
        #endregion
        #region MergeSort
        [TestMethod]
        public void CheckMergeSortRecursive()
        {
            sorter = new MergeSort<int>(array.Clone() as int[], array.Length);
            sorter.Do();

            Assert.IsTrue(IsEqualToSortedList(sorter.SortedArray));
        }
        #endregion
        #region Compare to the sorted List
        public bool IsEqualToSortedList(int[] sorted)
        {
            if (list.Count == sorted.Length)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == sorted[i])
                        continue;
                    else
                        return false;
                }
            }
            else
                return false;

            return true;
        }
        #endregion
    }
}
