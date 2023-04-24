using System;
using System.Collections.Generic;

namespace _189._Rotate_Array
{
    // https://leetcode.com/problems/rotate-array/
    // Description:
    // Given an array, rotate the array to the right by k steps, where k is non-negative.
    // Follow up:
    // Try to come up with as many solutions as you can. There are at least three different ways to solve this problem.
    // Could you do it in-place with O(1) extra space?
       
    // Constraints:
    // 1 <= nums.length <= 105
    // -231 <= nums[i] <= 231 - 1
    // 0 <= k <= 105

    class Program
    {
        static void Rotate2(int[] nums, int k)//O(N) Time, in place 0(1) place used
        {
            k = k % nums.Length;

            reverse(nums, 0, nums.Length - k - 1);
            reverse(nums, nums.Length - k, nums.Length - 1);
            reverse(nums, 0, nums.Length - 1);
        }

        static void reverse(int[] nums, int left, int right)
        {
            while (left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }

        static void Rotate(int[] nums, int k)//O(N) using another array
        {
            int[] result = new int[nums.Length];
            k = k % nums.Length;
            if (k <= 0) { return; }

            for (int i = nums.Length - k, j = 0; i < nums.Length && j < k; i++, j++)
            {
                result[j] = nums[i];
            }
            for (int i = 0, j = k; i < nums.Length - k && j < result.Length; i++, j++)
            {
                result[j] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = result[i];
            }
        }
        
        static void Rotate3(int[] nums, int k) //O(N*K)
        {
            k = k % nums.Length;
            if (k == 0||nums.Length<=1) { return; }

            int first = nums[nums.Length - 1];
            int tmp = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                tmp = nums[i];
                nums[i] = first;
                first = tmp;
            }
            Rotate3(nums, --k);
        }

        static void Main(string[] args)
        {
             //int[] nums = { -1, -100, 3, 99 };
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };

            //int[] nums = { 1};
            Rotate2(nums, 3);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
