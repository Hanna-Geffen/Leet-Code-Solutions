using System;

namespace _27._Remove_Element
{
    // https://leetcode.com/problems/remove-element/
    // Description:
    // Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The relative order of the elements may be changed.
    // Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
    // Return k after placing the final result in the first k slots of nums.
    // Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
       
    // Constraints:
    // 0 <= nums.length <= 100
    // 0 <= nums[i] <= 50
    // 0 <= val <= 100

    class Program
    {
        static int RemoveElement(int[] nums, int val)
        {
            try
            {
                CheckConstraints(nums, val);
                int len = nums.Length;
                for (int i = 0; i < len; i++)
                {
                    if (nums[i] == val)
                    {
                        nums[i] = nums[len - 1];
                        len--;
                        i--;
                    }
                }

                return len;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(int[] nums, int val)
        {
            //0 <= nums.length <= 100
            //0 <= nums[i] <= 50
            //0 <= val <= 100
            if (nums.Length > 100)
            {
                throw new Exception("ERROR: 0 <= nums.length <= 100.");
            }
            if (val < 0 || val > 100)
            {
                throw new Exception("ERROR: 0 <= val <= 100.");
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < 0 || nums[i] > 50)
                {
                    throw new Exception("ERROR: 0 <= nums[i] <= 50.");
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
            int[] nums = { 2, 2, 2 };
            TestFunction(nums, 2, 0);

            int[] nums1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            TestFunction(nums1, 1, 7);

            //check constraints error:
            int[] nums3 = new int[101];
            TestFunction(nums3, 5, -1);

            int[] nums4 = { 1, -52, 1 };
            TestFunction(nums4, 1, -1);

            int[] nums6 = { 1, 1, 51 };
            TestFunction(nums6, 1, -1);

            int[] nums5 = { 8, 5, 1 };
            TestFunction(nums5, 101, -1);
        }

        static void TestFunction(int[] nums, int val, int expectedResult)
        {
            int returnedValue = RemoveElement(nums, val);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'RemoveElement\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
            //Print(nums, nums.Length);
        }

        static void Main(string[] args)
        {
            RunTests();
            int[] nums = { 1, 1, 2, 1, 1 };
            int result = RemoveElement(nums, 1);
            Console.WriteLine(result);
            Print(nums, result);
        }
    }
}
