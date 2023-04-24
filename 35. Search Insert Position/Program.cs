using System;

namespace _35._Search_Insert_Position
{
    class Program
    {
        static int SearchInsert(int[] nums, int target)
        {
            if (target <= nums[0]) { return 0; }
            if (target > nums[nums.Length - 1]) { return nums.Length; }

            //Iterative implementation of Binary Search

            try
            {
                CheckConstraints(nums, target);
                int left = 0, right = nums.Length - 1;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    if (nums[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return left;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
        static int SearchInsert2(int[] nums, int l, int r, int target)
        {
            //Recursive implementation of Binary Search
            try
            {
                CheckConstraints(nums, target);
                if (l <= r)
                {
                    int mid = (l + r) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    if (nums[mid] < target)
                    {
                        return SearchInsert2(nums, mid + 1, r, target);
                    }
                    else
                    {
                        return SearchInsert2(nums, l, mid - 1, target);
                    }
                }

                return l;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(int[] nums, int target)
        {
            //1 <= nums.length <= 10^4
            //- 10^4 <= target <= 10^4
            //- 10^4 <= nums[i] <= 10^4
            //nums contains distinct values sorted in ascending order.

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (nums.Length < 1 || nums.Length > max)
                throw new Exception("ERROR: 1 <= nums.length <= 10^4.");

            if (target < -max || target >max)
                throw new Exception("ERROR: - 10^4 <= target <= 10^4.");

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < -max || nums[i] > max)
                    throw new Exception("ERROR: - 10^4 <= nums[i] <= 10^4.");

                if ((i < nums.Length - 1) && (nums[i] > nums[i + 1]))
                    throw new Exception("ERROR: The array should be sorted in ascending order.");
            }

            //here i know that the array is sorted in ascending order, 
            //but i'm not sure it contains only distinct values.
            //so- i'm calling the last version of Remove_Duplicates_from_Sorted_Array,
            //if it isn't the same length- it means that there were some duplicates values to remove,
            //therfore throw an Error because it didn't contain only distinct values as requested.
            if (nums.Length != RemoveDuplicates4(nums))
                throw new Exception("ERROR: The array should contain only distinct values.");
        }

        static int RemoveDuplicates4(int[] nums)
        {
            try
            {
                if (nums.Length <= 1) return nums.Length;//there are no possible duplicates.
                int unique = 0;
                //unique==index of the last unique val.
                //initialized to 0 because the first item is unique for now.
                //current==index of the current val. 
                //initialized to 1 because thereare no duplicates possible before.
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

        static void RunTests()
        {
            //test examples:
            int[] nums0 = { 1, 3, 5, 6 };
            TestFunction(nums0, 5, 2);

            int[] nums1 = { 1, 3, 5, 6 };
            TestFunction(nums1, 2, 1);

            int[] nums2 = { 1, 3, 5, 6 };
            TestFunction(nums2, 7, 4);

            int[] nums3 = { 1, 3, 5, 6 };
            TestFunction(nums3, 0, 0);

            int[] nums4 = { 1 };
            TestFunction(nums4, 0, 0);

            //check constraints error:
            int max = Convert.ToInt32(Math.Pow(10, 4));

            int[] nums5 = new int[max + 1];//Length too big
            TestFunction(nums5, 2, -1);

            int[] nums6 = { };//Length too low
            TestFunction(nums6, 7, -1);

            int[] nums7 = { 1, 2, 3 };//target too big
            TestFunction(nums7, max + 1, -1);

            int[] nums8 = { 1, 2, 3 };//target too low
            TestFunction(nums8, -max - 1, -1);

            int[] nums9 = { 1, 1, 2, 3 };//contains duplicates
            TestFunction(nums9, 7, -1);

            int[] nums10 = { 8, 5, 1 };//not ascending order
            TestFunction(nums10, 5, -1);

            int[] nums11 = { 1, max + 1 };//nums[i] too big
            TestFunction(nums11, 1, -1);

            int[] nums12 = { -max - 1, 3 };//nums[i] too low
            TestFunction(nums12, 1, -1);
        }

        static void TestFunction(int[] nums, int target, int expectedResult)
        {
            int returnedValue = SearchInsert(nums, target);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'SearchInsert2\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            int[] nums = { 2, 4, 5, 6, 8, 9, 10, 12, 14, 16, 18 };
            int result = SearchInsert2(nums, 0, nums.Length - 1, 8);
            Console.WriteLine(result);
        }
    }
}
