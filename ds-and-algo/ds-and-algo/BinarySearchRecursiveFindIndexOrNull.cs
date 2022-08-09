using NUnit.Framework;

namespace ds_and_algo
{
    public class BinarySearchRecursiveFindIndexOrNull
    {
        [TestCase(-1, 7, 1, 2, 3, 4, 5, 6)]
        [TestCase(-1, 0, 1, 2, 3, 4, 5, 6)]
        [TestCase(0, 1, 1, 2, 3, 4, 5, 6)]
        [TestCase(5, 6, 1, 2, 3, 4, 5, 6)]
        [TestCase(-1, 4, 1, 2, 3, 5, 6, 7)]
        [TestCase(3, 4, 1, 2, 3, 4, 6, 7)]
        public void Tests(int result, int x, params int[] data)
        {
            var actual = GetIndex(data, x);
            Assert.AreEqual(result, actual);
        }


        public static int GetIndex(int[] data, int x)
        {
            int min = 0;
            int max = data.Length - 1;

            while (true) {
                var mid = (min + max) / 2;
                if (data[mid] == x) return mid;
                if (data[max] == x) return max;
                if (max - min <= 1) return -1;

                if (data[mid] < x) min = mid;
                if (data[mid] > x) max = mid;
            }
        }
    }
}