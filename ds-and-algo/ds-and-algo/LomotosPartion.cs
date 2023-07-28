using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ds_and_algo
{
    public class LomotosPartion
    {
        [TestCase(3, 4, 1, 2, 3, 4, 6, 7, 4)]
        [TestCase(3, 4, 1, 2, 3, 4, 6, 7, 5)]
        public void PartitionTest(params int[] data)
        {
            var pivortIndex = Partition(data, 0, data.Length - 1);
            Console.WriteLine($"Pivot Index is {pivortIndex}");
            foreach(var x in data)
            {
                Console.Write($"{x} \t");
            }
            Console.WriteLine();
            Assert.True(true);
        }

        int Partition(int[] data1, int low, int high)
        {
            int lowerPartition = low;
            var pivot = data1[high];

            for(int i = low; i < high; i++) 
            {
                if (data1[i] < pivot)
                {
                    Swap(data1, i, lowerPartition);
                    lowerPartition++;
                }
            }
            Swap(data1, lowerPartition, high);
            return lowerPartition;
        }

        void Swap(int[] data1, int i, int j)
        {
            var d = data1[i];
            data1[i] = data1[j];
            data1[j] = d;
        }
    }

    public class HoarsePartition
    { 
        
    }


    /*
     https://leetcode.com/problems/merge-k-sorted-lists/
	Min Heap
	Put all Linked list in head
	Get the linked list on top of the heap
	Pull the first element out of it and add it to the result linked list
	push the linked list to the head when it has elements



     
     */

    public class CombinatorialProblem
    {

        public void Test()
        { 
        
        }

        public class PartialSolution
        {
            List<char> charArray = new List<char>();

            public void Add(char x)
            { 
                charArray.Add(x);
            }

            public void Pop()
            {
                charArray.RemoveAt(charArray.Count - 1);
            }
        }
    
    }
}