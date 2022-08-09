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
            if (data[0] == 1) return -1;
            if (data[data.Length - 1] == 0) return -1;
            return GetIndex(data, 0, data.Length - 1);
        }

        public static int GetIndex(int[] data, int startIndex, int endIndex)
        {
            if (endIndex - startIndex == 1) {
                return endIndex;
            }
            var mid = (startIndex + endIndex) / 2;
            if (data[mid] == 0) return GetIndex(data, mid, endIndex);
            return GetIndex(data, startIndex, mid);
        }
    }
}