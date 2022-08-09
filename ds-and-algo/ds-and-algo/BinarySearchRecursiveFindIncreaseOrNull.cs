using NUnit.Framework;

namespace ds_and_algo
{
    public class BinarySearchRecursiveFindIncreaseOrNull
    {
        [TestCase(-1, 0, 0, 0, 0, 0, 0)]
        [TestCase(-1, 1, 1, 1, 1, 1, 1)]
        [TestCase(1, 0, 1, 1, 1, 1, 1)]
        [TestCase(5, 0, 0, 0, 0, 0, 1)]
        [TestCase(4, 0, 0, 0, 0, 1, 1)]
        public void Tests(int result, params int[] data)
        {
            var actual = GetIndex(data);
            Assert.AreEqual(result, actual);
        }


        public static int GetIndex(int[] data)
        {
            int min = 0;
            int max = data.Length - 1;

            if (data[min] == 1) return -1;
            if (data[max] == 0) return -1;

            while (true)
            {
                var mid = (min + max) / 2;
                if (max - min == 1) {
                    return max;
                }
                if (data[mid] == 0)
                    min = mid;
                else
                    max = mid;
            }
        }
    }
}