using System;
using System.Collections.Generic;

namespace _26._Remove_Duplicates_from_Sorted_Array
{
    // https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    // Description:
    // Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
    // Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
    // Return k after placing the final result in the first k slots of nums.
    // Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
       
    // Constraints:
    // 1 <= nums.length <= 3 * 104
    // -100 <= nums[i] <= 100
    // nums is sorted in non-decreasing order.

    class Program
    {
        static int RemoveDuplicates(int[] nums)
        {
            try
            {
                CheckConstraints(nums);
                if (nums.Length <= 1) return nums.Length;//there are no possible duplicates.
                int unique = 0;
                //unique==index of the last unique val.
                //initialized to 0 because the first item is unique for now.
                //current==index of the current val. 
                //initialized to 1 because there are no duplicates possible before.
                for (int current = 1; current < nums.Length; current++)
                {
                    if (nums[unique] != nums[current])
                    {
                        nums[++unique] = nums[current];//insert the new unique value found after the last unique value.
                    }
                    //continue until you reach the next unique value.
                }

                return unique + 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(int[] nums)
        {
            //0 <= nums.length <= 3 * 10^4
            //- 10^4 <= nums[i] <= 10^4
            //nums is sorted in ascending order.

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (nums.Length > 3 *max)
            {
                throw new Exception("ERROR: 0 <= nums.length <= 3 * 10^4.");
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if ((i < nums.Length - 1) && (nums[i] > nums[i + 1]))
                {
                    throw new Exception("ERROR: The array should be sorted in ascending order.");
                }
                if (nums[i] < -max || nums[i] >max)
                {
                    throw new Exception("ERROR: - 10^4 <= nums[i] <= 10^4.");
                }
            }
        }

        static void Print(int[] nums, int len)
        {
            Console.Write("[");
            for (int i = 0; i < len; i++)
            {
                Console.Write(nums[i]);
                if (i != len - 1)//checking if not last element
                {
                    Console.Write(",");
                }
            }
            Console.Write("]\n");
        }
        static void Print2(int[] nums, int len)
        {
            Console.Write("[");
            for (int i = 0; i < len; i++)
            {
                if (i != 0)//checking if not first element
                {
                    Console.Write(",");
                }
                Console.Write(nums[i]);
            }
            Console.Write("]\n");
        }

        static void RunTests()
        {
            //test examples:
            int[] nums = { 1, 1, 2 };
            TestFunction(nums, 2);

            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            TestFunction(nums1, 5);

            int max = Convert.ToInt32(Math.Pow(10, 4));

            //check constraints error:
            int[] nums3 = new int[3*max+1];
            TestFunction(nums3, -1);

            int[] nums4 = { 1, 1, max + 1 };
            TestFunction(nums4, -1);

            int[] nums5 = { -max - 1, 1, 1 };
            TestFunction(nums5, -1);

            int[] nums6 = { 8, 5, 1 };
            TestFunction(nums6, -1);
        }

        static void TestFunction(int[] nums, int expectedResult)
        {
            int returnedValue = RemoveDuplicates(nums);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'RemoveDuplicates\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
            //Print(nums, returnedValue);
        }

        static void Main(string[] args)
        {
            RunTests();
            int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 454 };
            Console.WriteLine("The array contains:");
            Print(nums, nums.Length);
            int result = RemoveDuplicates(nums);
            Console.WriteLine("The new length is: {0}", result);
            Console.WriteLine("The new array contains:");
            Print(nums, result);
        }
    }
}
