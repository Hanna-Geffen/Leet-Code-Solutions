using System;
using System.Collections.Generic;

namespace _977._Squares_of_a_Sorted_Array
{
    class Program
    {
        static int[] SortedSquares(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int k = 0; k < nums.Length; k++)
            {
                nums[k] *= nums[k];
            }

            int i = 0, j = nums.Length - 1, position = nums.Length - 1;
            while (i <= j)
            {
                if (nums[i] < nums[j])
                {
                    result[position] = nums[j];
                    j--;
                }
                else
                {
                    result[position] = nums[i];
                    i++;
                }
                position--;
            }

            return result;
        }
        static int[] SortedSquares2(int[] nums)
        {
            SortedSet<int> bst = new SortedSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = nums[i] * nums[i];
                bst.Add(nums[i]);
                Print(bst);
            }
            int j = 0;
            foreach (var item in bst)
            {
                nums[j++] = item;
            }
            return nums;
        }

        static void Print(SortedSet<int> bst)
        {
            foreach (var item in bst)
            {
                Console.Write(item + "--->");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //          -7,-3,2,3,11    
            int[] nums = { -4, -1, 0, 3, 10 };
            nums = SortedSquares2(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + "--->");
            }
        }
    }
}
