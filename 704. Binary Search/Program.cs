using System;

namespace _704._Binary_Search
{
    class Program
    {
        static int Search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            int m = 0;
            while (left <= right)
            {
                m = (left + right) / 2;
                if (nums[m] == target) { return m; }
                if (nums[m] < target) { left = m + 1;  }
                else { right = m - 1; }

            }
            return -1;

        }
        static void Main(string[] args)
        {
            int[] nums = { -1, 0, 3, 5, 9, 12 };
            int result = Search(nums, 9);

            Console.WriteLine(result);
        }
    }
}