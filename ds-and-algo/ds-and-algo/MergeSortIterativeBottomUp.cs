using NUnit.Framework;

namespace ds_and_algo
{
    public class MergeSortIterativeBottomUp
    {
        [TestCase(7, 6, 5, 4, 3, 2, 1)]
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

        private void Sort(int[] data)
        {
            for (int subArraySize = 1; subArraySize <= data.Length; subArraySize = subArraySize * 2) 
            {
                for (int startIndex = 0; startIndex < data.Length; startIndex = startIndex + subArraySize * 2)
                {
                    int s1 = startIndex;
                    int e1 = startIndex + subArraySize - 1;
                    int s2 = startIndex + subArraySize;
                    int e2 = startIndex + subArraySize * 2 - 1;

                    if (e1 > data.Length - 1) e1 = data.Length - 1;
                    if (e2 > data.Length - 1) e2 = data.Length - 1;

                    int[] result = new int[e2 - s1 + 1];

                    int i = s1;
                    int j = s2;
                    int k = 0;

                    while (i <= e1 && j <= e2)
                    {
                        if (data[i] <= data[j]) result[k++] = data[i++];
                        else result[k++] = data[j++];
                    }

                    while (i <= e1)
                    {
                        result[k++] = data[i++];
                    }

                    while (j <= e2)
                    {
                        result[k++] = data[j++];
                    }

                    for (int z = 0; z < result.Length; z++)
                    {
                        data[s1 + z] = result[z];
                    }
                }
            }
        }


        private void Sort(int[] data, int startIndex, int endIndex)
        {
            if (endIndex - startIndex == 1) return;

            var mid = (startIndex + endIndex) / 2;

            Sort(data, startIndex, mid);
            Sort(data, mid + 1, endIndex);

            int[] temp = new int[endIndex - startIndex + 1];

            int i = startIndex;
            int j = mid + 1;
            int k = 0;
            while (i <= mid && j <= endIndex)
            {
                if (data[i] < data[j]) temp[k++] = data[i++];
                else temp[k++] = data[j++];
            }

            while (i <= mid) temp[k++] = data[i++];

            while (j <= endIndex) temp[k++] = data[j++];

            for (int x = 0; x < endIndex + 1 - startIndex; x++)
            {
                data[startIndex + x] = temp[x];
            }
        }

    }
}