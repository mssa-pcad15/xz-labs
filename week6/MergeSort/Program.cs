using System;

namespace DSA
{
    public class MergeSort
    {
        /* main method as entry point */
        static void Main(String[] args)
        {
            Console.WriteLine("Please enter numbers separated by spaces");
            //int[] array = { 38, 27, 43, 3, 9, 82, 10 };
            String userInput = Console.ReadLine();
            String[] stringArray = userInput.Split(' ');
            int[] intArray = Array.ConvertAll(stringArray, int.Parse);

            Console.Write("Original array elements are: ");
            foreach (int num in intArray)
                Console.Write($"{num} ");

            Console.WriteLine();

            RecursiveSort(intArray, 0, intArray.Length - 1);

            Console.Write("After sort, array elements are: ");

            foreach (int num in intArray)
            {
                Console.Write($"{num} ");
            }
        }

        /* RecursiveMerge() method */
        public static void RecursiveSort(int[] array, int left, int right)
        {
            // | find a middle point
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                //| keep dividing left side
                RecursiveSort(array, left, mid);
                //| keep dividing right side
                RecursiveSort(array, mid+1, right);

                //| once both RecursiveSort return, put them into Merge method to merge
                Merge(array, left, mid, right);
            }
        }
        public static void Merge(int[] array, int left, int mid, int right)
        {

            int[] leftTempArray = new int[mid - left + 1];
            int[] rightTempArray = new int[right - mid];

            //| copy elements to left temp array and right temp array
            Array.Copy(array, left, leftTempArray, 0, mid - left + 1); //source index shouldn't be 0, because it's not always start from 0
            Array.Copy(array, mid + 1, rightTempArray, 0, right - mid);

            /* start merge, by comparing two integers at each recursion, and put them into array */
            int i = 0, j = 0, z = left;
            while (i < mid - left + 1 && j < right - mid)
            {
                if (leftTempArray[i] < rightTempArray[j])
                    array[z++] = leftTempArray[i++];
                else
                    array[z++] = rightTempArray[j++];
            }

            /* In case either left temp array or right temp array has left over elements */
            while (i < mid - left + 1)
                array[z++] = leftTempArray[i++];

            while (j < right - mid)
                array[z++] = rightTempArray[j++];
        }
    }
}

