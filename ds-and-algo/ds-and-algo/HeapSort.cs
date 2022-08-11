using NUnit.Framework;
using System.Collections.Generic;

namespace ds_and_algo
{
    public class HeapSort
    {

        [TestCase(3, 4, 1, 2, 3, 4, 6, 7)]
        public void Tests(params int[] data)
        {
            var sum = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum = sum + data[i];
            }

            Sort(data);

            var sum1 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum1 = sum1 + data[i];
            }

            Assert.AreEqual(sum, sum1);
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i - 1] > data[i]) Assert.Fail("Not sorted");
            }
        }

        public void Sort(int[] data)
        {
            Heap heap = new Heap();
            for (int i = 0; i < data.Length; i++) 
            {
                heap.Insert(data[i]);
            }

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = heap.GetTopOfHeap();
            }

        }

        public class Heap
        {
            List<int> data = new List<int>();

            int size = 0;

            bool IsValid(int index)
            {
                if (index < size) return true;
                return false;
            }

            public int GetTopOfHeap()
            {
                var result = data[0];
                data[0] = data[size - 1];

                var current = 0;

                while (true) {
                    var c1 = 2 * current + 1;
                    var c2 = 2 * current + 2;
                    if (!IsValid(c1)) break;

                    var smallerChildIndex = c1;
                    if (IsValid(c2) && data[c2] < data[c1]) smallerChildIndex = c2;

                    if (data[current] <= data[smallerChildIndex]) break;
                    Swap(current, smallerChildIndex);
                    current = smallerChildIndex;
                }

                size--;
                return result;
            }

            public void Insert(int x)
            {
                data.Add(x);
                size++;
                var currentIndex = size - 1;
                while (true) {
                    var parent = GetParentIndex(currentIndex);
                    if (data[currentIndex] >= data[parent]) break;
                    Swap(currentIndex, parent);
                    currentIndex = parent;
                    if (currentIndex <= 0) break;
                }
            }

            public int GetSizeOfHeap()
            {
                return size;
            }

            private int GetParentIndex(int x)
            {
                return (x - 1) / 2;
            }

            private void Swap(int index1, int index2) 
            {
                var temp = data[index1];
                data[index1] = data[index2];
                data[index2] = temp;
            }
        }
    
    }
}