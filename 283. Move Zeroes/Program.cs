using System;

namespace _283._Move_Zeroes
{
    class Program
    {
        static void MoveZeroes(int[] nums)
        {
            //Input: nums = [0,1,0,3,12]//1 3 12 0 0
            //Output:[1,3,12,0,0]
            int i = 1, p_zero = 0;
            while (i < nums.Length && p_zero < nums.Length)
            {
                if (nums[p_zero] == 0 && nums[i] != 0)
                {
                    nums[p_zero] = nums[i];
                    nums[i] = 0;
                    p_zero++;
                }
                else if (nums[p_zero] != 0)
                {
                    p_zero++;
                }
                i++;
            }
        }
        static void Main(string[] args)
        {
            int[] nums = {1,0,1};
            MoveZeroes(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
    }
}
