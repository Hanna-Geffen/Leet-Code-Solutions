using System;

namespace _1._Two_Sum
{
    // https://leetcode.com/problems/two-sum/
    // Description of the Problem:
    // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    // You may assume that each input would have exactly one solution, and you may not use the same element twice.
    // You can return the answer in any order.
    // Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
       
    // Constraints:
    // 2 <= nums.length <= 104
    // -109 <= nums[i] <= 109
    // -109 <= target <= 109
    // Only one valid answer exists.

    class Program
    {
        //If indexes found- return indexes. Else return negative indexes {-1, -1} to let know that you didn't find.

<<<<<<< Updated upstream
=======
        static int[] TwoSum(int[] nums, int target)
        {
            int[] result = { -1, -1 };
            Dictionary<int, int> h_nums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (h_nums.ContainsKey(target - nums[i]))
                {
                    h_nums.TryGetValue(target - nums[i], out int index);
                    if (i != index)
                    {
                        result[0] = index;
                        result[1] = i;
                        return result;
                    }
                }                
                h_nums.Add(nums[i],i);

            }
            return result;
        }

        static int[] TwoSumII_sorted_array(int[] numbers, int target)//two pointers
        {
            int i = 0, j = numbers.Length - 1;
            int[] result = { -1, -1 };

            while (i < j)
            {
                int sum = numbers[i] + numbers[j];
                if (sum == target)
                {
                    result[0] = i + 1;
                    result[1] = j + 1;
                    return result;
                }
                else if (sum < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return result;
        }
>>>>>>> Stashed changes
        static void CheckConstraints(int[] nums, int target)
        {
            //2 <= nums.length <= 10^3
            //- 10^9 <= target <= 10^9
            //- 10^9 <= nums[i] <= 10^9
            
            int max103 = Convert.ToInt32(Math.Pow(10, 3));
            int max109 = Convert.ToInt32(Math.Pow(10, 9));

            if (nums.Length < 2 || nums.Length > max103)
            {
                throw new Exception("ERROR: 2 <= nums.length <= 10^3.");
            }

            if (target < -max109 || target > max109)
            {
                throw new Exception("ERROR: - 10^9 <= target <= 10^9.");
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < -max109 || nums[i] > max109)
                {
                    throw new Exception("ERROR: - 10^9 <= nums[i] <= 10^9.");
                }
            }
        }

        private static void TestFunction(int Test_Number, int[] nums, int target, int[] expectedResult)
        {
            int[] returnedValue = TwoSum(nums, target);
            if ((expectedResult[0] != returnedValue[0]) || ((expectedResult[1] != returnedValue[1])))
            {
                Console.WriteLine("Error: Test Number " + Test_Number + " failed: the function \'TwoSum\' returned: (" + returnedValue[0] + ", " + returnedValue[1] + ") , but the expected result was: (" + expectedResult[0] + ", " + expectedResult[1] + ").");
            }
        }

        static void RunTests()
        {
            int[] nums = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expectedResult = new int[2] { -1, -1 };

            TestFunction(1, nums, 1, expectedResult);
            TestFunction(2, nums, 2, expectedResult);
            expectedResult[0] = 0;
            expectedResult[1] = 1;
            TestFunction(3, nums, 3, expectedResult);
            expectedResult[1] = 2;
            TestFunction(4, nums, 4, expectedResult);
            expectedResult[1] = 3;
            TestFunction(5, nums, 5, expectedResult);
            expectedResult[1] = 4;
            TestFunction(6, nums, 6, expectedResult);
        }

        static int[] Init_Array()
        {
            int Length = Input_Number_In_Range(2, 103, "size", "Enter a size for your array:");
            int[] nums = new int[Length];

            Console.WriteLine("Enter nums to initialize your array.");
            for (int i = 0; i < Length; i++)
            {
                nums[i] = Input_Number_In_Range(-109, 109, "nums", "Enter a number for Array[" + i + "]:");
            }
            return nums;
        }

        private static int Init_Target()
        {
            return Input_Number_In_Range(-109, 109, "target", "Enter a target number or 0 to exit: ");
        }

        private static int Input_Number(string message)
        {
            bool OK = true;
            int number = -1;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    number = Convert.ToInt32(Console.ReadLine());
                    OK = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    OK = false;
                }
            } while (!OK);
            return number;
        }

        private static int Input_Number_In_Range(int min, int max, string name, string message)
        {
            bool OK = true;
            int number;
            do
            {
                OK = true;
                number = Input_Number(message);

                if (number < min || number > max)
                {
                    Console.WriteLine("The {0} must be: {1} <= {0} <= {2}.\n", name, min, max);
                    OK = false;
                }
            } while (!OK);
            return number;
        }
        static void Main(string[] args)
        {
            RunTests();

            int[] nums = Init_Array();
            int target;
            int[] result;
            do
            {
                target = Init_Target();
                if (target == 0)
                {
                    break;
                }

                result = TwoSum(nums, target);

                if (result[0] != -1)//&& result[1] != -1)
                {
                    Console.WriteLine("The indexes are: " + "(" + result[0] + "," + result[1] + ")");
                    Console.WriteLine("Because: " + nums[result[0]] + " + " + nums[result[1]] + " = " + target + "\n");
                }
                else
                {
                    Console.WriteLine("There aren't two nums such that they add up to target.\n");
                }
            }
            while (true);
            Console.WriteLine("Good Bye.");
        }
    }
}
