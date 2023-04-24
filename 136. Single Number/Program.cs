using System;

namespace _136._Single_Number
{
    // https://leetcode.com/problems/single-number/
    // Description:
    // Given a non-empty array of integers nums, every element appears twice except for one. Find that single one.
    // You must implement a solution with a linear runtime complexity and use only constant extra space.
       
    // Constraints:
    // 1 <= nums.length <= 3 * 104
    // -3 * 104 <= nums[i] <= 3 * 104
    // Each element in the array appears twice except for one element which appears only once.

    class Program
    {
        static int SingleNumber2(int[] nums)//xor: a xor a = 0 , a xor 0 = a.   
        {
            int single = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                single ^= nums[i];
            }
            return single;
        }        
        
        static int SingleNumber(int[] nums)//sort: the only number which hasn't its duplicate after him- is the single number.  
        {
            if (nums.Length == 1) { return nums[0]; }

            QuickSort(nums, 0, nums.Length - 1);

            for (int i = 0; i < nums.Length-1; i+=2)
            {
                if (nums[i] != nums[i + 1])
                {
                    return nums[i];
                }
            }

            return nums[nums.Length-1];
        }

        static int SingleNumber3(int[] nums)//math: 2*(a+b+c)-(a+b+c+a+b)==c
        {
            int sumOfNums = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sumOfNums += nums[i];
            }
            int newNumsLength = RemoveDuplicates2(nums);
            int sumSet = 0;//set with no duplicates
            for (int i = 0; i < newNumsLength; i++)
            {
                sumSet += nums[i];
            }
            return 2 * sumSet - sumOfNums;
        }

        static int RemoveDuplicates2(int[] nums)
        {
            try
            {
                //CheckConstraints(nums);
                if (nums.Length <= 1) return nums.Length;//there are no possible duplicates.

                //the first pointer runs from 1 to nums.Length
                //we check from 0 to the biggest item known to be unique
                //if it doesnt appear in the uniques then write it after the last unique item
                //else continue.
                bool different;
                int unique = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    different = true;
                    for (int j = 0; j <= unique; j++)
                    {
                        if (nums[i] == nums[j])
                        {
                            different = false;
                        }
                    }
                    if (different)
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

        static void QuickSort(int[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);

                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }

        static int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
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

        static void Main(string[] args)
        {
            int[] arr = new int[] { 8, 6, 4, 3, 7, 1,5, 2,8, 6, 9, 4, 3, 7, 2, 1, 5 };
            int result = SingleNumber3(arr);
            Console.WriteLine(result);
        }
    }
}
