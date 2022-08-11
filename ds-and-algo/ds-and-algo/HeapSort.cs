using NUnit.Framework;
using System.Collections.Generic;

namespace ds_and_algo
{
    // The best case time complexity is n log n
    // the worst case time complexity is n log n
    // the average case time complexity is n log n
    // This is NOT a stable sort
    // The memory requirment for heap sort in O(1) (This implementation has to be done)

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

                while (true) {  // Its easier to run loop always and break when conditions are not met
                    var c1 = 2 * current + 1;
                    var c2 = 2 * current + 2;
                    if (!IsValid(c1)) break; //Break when no valid child

                    var smallerChildIndex = c1;
                    if (IsValid(c2) && data[c2] < data[c1]) smallerChildIndex = c2;

                    if (data[current] <= data[smallerChildIndex]) break; // Break when parent is smaller than smallest child
                    Swap(current, smallerChildIndex);
                    current = smallerChildIndex;
                }

                size--; //Make sure to decrent this last
                return result;
            }

            public void Insert(int x)
            {
                data.Add(x);
                size++;
                var currentIndex = size - 1;
                while (true) { // Its easier to run loop always and break when conditions are not met
                    var parent = GetParentIndex(currentIndex);
                    if (data[currentIndex] >= data[parent]) break; //Break when parent is smaller already
                    Swap(currentIndex, parent);
                    currentIndex = parent;
                    if (currentIndex <= 0) break; // break when reached the top of the heap
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