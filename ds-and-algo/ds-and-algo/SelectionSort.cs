using NUnit.Framework;

namespace ds_and_algo
{
    //The best, worst and average time is  O (n ^ 2)
    //This is an in place sorting algorithm
    //This is not a stable sort
    public class SelectionSort
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
            for (int selectionIndex = 0; selectionIndex < data.Length; selectionIndex++) {
                var minIndex = selectionIndex;
                for (int traversal = selectionIndex + 1; traversal < data.Length; traversal++) {
                    if (data[traversal] < data[minIndex]) minIndex = traversal;       
                }
                var temp = data[minIndex];
                data[minIndex] = data[selectionIndex];
                data[selectionIndex] = temp;
            }
        }
    }
}