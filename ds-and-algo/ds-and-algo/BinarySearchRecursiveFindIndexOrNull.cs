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
            return GetIndex(data, x, 0, data.Length - 1);
        }

        public static int GetIndex(int[] data, int x, int startIndex, int endIndex)
        {
            var midIndex = (startIndex + endIndex) / 2;
            if (data[midIndex] == x) return midIndex;
            if (data[endIndex] == x) return endIndex;

            if (endIndex - startIndex <= 1) return -1;

            if (x < data[midIndex]) return GetIndex(data, x, startIndex, midIndex);
            return GetIndex(data, x, midIndex, endIndex);
        }
    }
}