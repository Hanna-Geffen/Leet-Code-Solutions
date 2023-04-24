using System;

namespace _26._1_Remove_Duplicates_from_Unsorted_Array
{
    class Program
    {

        static int RemoveDuplicates(int[] nums)//change to hashmap
        {
            try
            {
                CheckConstraints(nums);
                if (nums.Length <= 1) return nums.Length;//there are no possible duplicates.

                //the first pointer runs from 1 to nums.Length
                //we check from 0 to the biggest item known to be unique
                //if it doesnt appear in the uniques then write it after the last unique item
                //else continue.
                bool isUnique;
                int unique = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    isUnique = true;
                    for (int j = 0; j <= unique; j++)
                    {
                        if (nums[i] == nums[j])
                        {
                            isUnique = false;
                        }
                    }
                    if (isUnique)
                    {
                        nums[unique + 1] = nums[i];
                        unique++;
                    }
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

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (nums.Length > 3 * max)
            {
                throw new Exception("ERROR: 0 <= nums.length <= 3 * 10^4");
            }
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < -max || nums[i] > max)
                {
                    throw new Exception("ERROR: - 10^4 <= nums[i] <= 10^4");
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
            int[] nums = { 4, 1, 1 };
            TestFunction(nums, 2);

            int[] nums1 = { 4, 3, 1, 1, 1, 2, 2, 3, 0, 0 };
            TestFunction(nums1, 5);

            int[] nums2 = { 8, 5, 1 };
            TestFunction(nums2, 3);
            
            int max = Convert.ToInt32(Math.Pow(10, 4));

            //check constraints error:
            int[] nums3 = new int[3*max+1];
            TestFunction(nums3, -1);

            int[] nums4 = { 1, 1, max+1 };
            TestFunction(nums4, -1);

            int[] nums5 = { -max - 1, 1, 1 };
            TestFunction(nums5, -1);


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
            int[] nums = { 4, 4, 4, 2, 5, 6, 2, 6, 5, 4, 6, 3, 5 };
            Console.WriteLine("The array contains:");
            Print(nums, nums.Length);
            int result = RemoveDuplicates(nums);
            Console.WriteLine("The new length is: {0}", result);
            Console.WriteLine("The new array contains:");
            Print(nums, result);
        }
    }
}
