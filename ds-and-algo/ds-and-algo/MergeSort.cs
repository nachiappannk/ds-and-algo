using NUnit.Framework;

namespace ds_and_algo
{
    public class MergeSort
    {
        [TestCase(3, 4, 1, 2, 3, 4, 6, 7)]
        public void Tests(params int[] data)
        {
            var sum = 0;
            for (int i = 0; i < data.Length; i++) {
                sum = sum = data[i];
            }

            Sort(data);

            var sum1 = 0;
            for (int i = 0; i < data.Length; i++)
            {
                sum1 = sum1 = data[i];
            }

            Assert.AreEqual(sum, sum1);
            for (int i = 1; i < data.Length; i++) {
                if (data[i - 1] > data[i]) Assert.Fail("Not sorted");
            }

        }

        private void Sort(int[] data)
        {
            Sort(data, 0, data.Length - 1);
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
                if (data[i] < data[j]) {
                    temp[k] = data[i];
                    i++;

                }
                else {
                    temp[k] = data[j];
                    j++;
                }
                k++;
            }
            while (i <= mid)
            {
                temp[k] = data[i];
                i++;
                k++;
            }
            while (j <= endIndex)
            {
                temp[k] = data[j];
                j++;
                k++;
            }

            for (int x = 0; x < endIndex + 1 - startIndex; x++) {
                data[startIndex + x] = temp[x];
            }
        }

    }
}