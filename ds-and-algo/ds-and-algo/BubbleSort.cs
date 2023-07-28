using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ds_and_algo
{
    //The best, worst and average time complexity is O (n)
    //This is an in place and stable sorting algorithm

    public class BubbleSort
    {
        [TestCase(3, 4, 1, 2, 3, 4, 6, 7)]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        [TestCase(8, 7, 6, 5, 4, 3, 2, 1)]
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
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        var temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
    }

    public class SortedSet
    {
        [Test]
        public void Test() 
        {
            
            //IComparer can be passed as input
            SortedSet<int> sortedSet = new SortedSet<int>();
            //Add method takes Log N
            //Min method takes Log N
            //Remove Method takes Log N
            //ContainsKey takes Log N
            
            sortedSet.Add(5);
            sortedSet.Add(3);
            sortedSet.Add(2);
            sortedSet.Add(8);
            sortedSet.Add(1);

            
            //Duplicate elements are not allowed. Adding a duplicate element will ignore it
            var result = sortedSet.Add(1);

            

            Console.WriteLine(result);


            foreach (int i in sortedSet)
            { 
                Console.WriteLine(i);
            }


            Console.WriteLine("Contained 5 " + sortedSet.Contains(5));
            Console.WriteLine("Contained 7 " + sortedSet.Contains(7));

        }
        

    }
}