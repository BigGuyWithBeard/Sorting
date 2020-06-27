// /*
// * PROJECT:    Sorting
// * NAME:        Program.cs
// */

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Sorting
{

    public class ReverseComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x );
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Exploring Sorting - johnpaulsmith.co.uk\n");
            Console.WriteLine("\n");

            int arraySize = 1000;
            int[] unsortedArray = CreateUnsortedArray(arraySize);

            Stopwatch stopWatch = new Stopwatch();

            Console.Write("Custom Bubble Sort:");
            stopWatch.Start();
            BubbleSort(unsortedArray.Clone() as int[]);
            stopWatch.Stop();
            Console.WriteLine($"\t {stopWatch.Elapsed.ToString()}");

            Console.Write("Custom Quick Sort:");
            stopWatch.Reset();
            stopWatch.Start();
            QuickSort(unsortedArray.Clone() as int[]);
            stopWatch.Stop();
            Console.WriteLine($"\t {stopWatch.Elapsed.ToString()}");

            // Sort an array using the default comparer.
            int[] tempArray = unsortedArray.Clone() as int[];
            Console.Write("Array.Sort:");
            stopWatch.Reset();
            stopWatch.Start();
            Array.Sort(tempArray);
            stopWatch.Stop();
            Console.WriteLine($"\t\t {stopWatch.Elapsed.ToString()}");




            // Sort an array using the reverse case-insensitive comparer.
            tempArray = unsortedArray.Clone() as int[];
            Console.Write("Array.Sort (Reverse):");
            // Instantiate the reverse comparer.
            IComparer revComparer = new ReverseComparer();
            stopWatch.Reset();
            stopWatch.Start();
            Array.Sort(tempArray, revComparer);
            stopWatch.Stop();
            Console.WriteLine($"\t {stopWatch.Elapsed.ToString()}");






            Console.WriteLine("Press any Key to continue...");
            Console.ReadKey();
        }


        private static int[] CreateUnsortedArray(int arraySize)
        {
            Random randNum = new Random();

            // use LINQ to populate the array with random integers
            int[] unsortedArray = Enumerable
                                 .Repeat(0, arraySize)
                                 .Select(i => randNum.Next(-100, 100))
                                 .ToArray();

            return unsortedArray;
        }

        private static void QuickSort(int[] array, int left = -1, int right = -1)
        {
            if (left == -1 && right == -1)
            {
                left = 0;
                right = array.Length - 1;
            }

            if (left < right)
            {
                int pivot = QuickSortPartition(array, left, right);

                if (pivot > 1) QuickSort(array, left, pivot - 1);
                if (pivot + 1 < right) QuickSort(array, pivot + 1, right);
            }
        }

        private static int QuickSortPartition(int[] array, int left, int right)
        {
            int pivot = array[left];

            while (true)
            {
                while (array[left] < pivot) left++;

                while (array[right] > pivot) right--;

                if (left < right)
                {
                    if (array[left] == array[right]) return right;

                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private static int[] BubbleSort(int[] array)
        {
            int t;

            for (int p = 0; p <= array.Length - 2; p++)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                    if (array[i] > array[i + 1])
                    {
                        t = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = t;
                    }
            }

            return array;
        }
    }
}