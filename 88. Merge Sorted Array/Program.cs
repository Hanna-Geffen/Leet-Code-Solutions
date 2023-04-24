using System;

namespace _88._Merge_Sorted_Array
{
    class Program
    {
        static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0) { return; }
            if (m == 0)
            {
                for (int l = 0; l < n; l++)
                {
                    nums1[l] = nums2[l];
                }
                return;
            }
            //CheckConstraints(nums1, m, nums2, n);
            int[] result = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < m)
            {
                if (nums1[i] <= nums2[j])
                {
                    result[k] = nums1[i];
                    i++;
                }
                else
                {
                    result[k] = nums2[j];
                    j++;
                }
                k++;
            }
            //Print(result, result.Length);
            while (j < n)
            {
                result[k] = nums2[j];
                j++;
                k++;
            }
            for (i = 0; i < nums1.Length; i++)
            {
                nums1[i] = result[i];
            }
            //Print(nums1, m + n);
        }
        static void CheckConstraints(int[] nums1, int m, int[] nums2, int n)
        {
            //nums1.length == m + n.
            //nums2.length == n.
            //0 <= m, n <= 200.
            //1 <= m + n <= 200.
            //- 10^9 <= nums1[i], nums2[i] <= 10^9.

            int max = Convert.ToInt32(Math.Pow(10, 9));

            if (m < 0 || m > 200)
            {
                throw new Exception("ERROR: 0 <= m <= 200.");
            }
            if (n < 0 || n > 200)
            {
                throw new Exception("ERROR: 0 <= n <= 200.");
            }
            if (m + n < 1 || m + n > 200)
            {
                throw new Exception("ERROR: 1 <= m + n <= 200.");
            }
            if (nums1.Length != m + n)
            {
                throw new Exception("ERROR: nums1.length == m + n.");
            }
            if (nums2.Length != n)
            {
                throw new Exception("ERROR: nums2.length == n.");
            }
            for (int i = 0, j = 0; i < nums1.Length || j < nums2.Length; i++,j++)
            {
                if (i < nums1.Length && (nums1[i] < -max || nums1[i] > max))
                {
                    throw new Exception("ERROR: - 10^9 <= nums1[i] <= 10^9.");
                }
                if (j < nums2.Length && (nums2[j] < -max || nums2[j] > max))
                {
                    throw new Exception("ERROR: - 10^9 <= nums2[i] <= 10^9.");
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

            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int[] nums2 = { 2, 5, 6 };
            int[] expectedResult0 = { 1, 2, 2, 3, 5, 6 };
            TestFunction(nums1, 3, nums2, 3, expectedResult0);

            int[] nums3 = { 1 };
            int[] nums4 = { };
            int[] expectedResult1 = { 1 };
            TestFunction(nums3, 1, nums4, 0, expectedResult1);

            //other examples:

            int[] nums5 = { 1, 1, 3, 3, 5, 5, 0, 0, 0, 0, 0, 0 };
            int[] nums6 = { 2, 2, 4, 4, 6, 6 };
            int[] expectedResult2 = { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
            TestFunction(nums5, 6, nums6, 6, expectedResult2);

            int max = Convert.ToInt32(Math.Pow(10, 9));

            //check constraints error:
            int[] nums7 = new int[201];
            TestFunction(nums7, 201, nums3, 1, null);//m Length >200
            TestFunction(nums3, 1, nums7, 201, null);//n Length >200

            int[] nums8 = new int[200];
            TestFunction(nums8, 200, nums3, 1, null);//m + n Length >200

            TestFunction(new int[0], 0, new int[0], 0, null);//m + n <1

            TestFunction(nums2, 3, nums2, 3, null);//nums2.Length != m+n
            TestFunction(nums1, nums1.Length, nums2, 4, null);//nums2.Length != n

            int[] nums9 = { 1, 1, max + 1 };
            TestFunction(nums1, 6, nums9, 3, null);//-10^9 <= nums1[i], nums2[i] <= 10^9

            int[] nums10 = { -max - 1, 1, 1 };
            TestFunction(nums1, 6, nums10, 3, null);//-10^9 <= nums1[i], nums2[i] <= 10^9
        }

        static void TestFunction(int[] nums1, int m, int[] nums2, int n, int[] expectedResult)
        {
            Merge(nums1, m, nums2, n);
            if (nums1.Length != expectedResult.Length)
            {
                Console.WriteLine("Error: the function \'Merge\' changed nums1.Length: " + nums1.Length + ", but the expected Length was: " + expectedResult.Length + ".");
            }
            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1[i] != expectedResult[i])
                {
                    Console.WriteLine("Error: the function \'Merge\' returned at index " + i + ": " + nums1[i] + ", but the expected val was: " + expectedResult[i] + ".");
                }
            }
        }

        static void Main(string[] args)
        {
            //RunTests();
            int[] nums1 = { 1, 2, 2, 3, 4, 0, 0, 0, 0, 0, 0, 0 };
            int[] nums2 = { 1, 1, 2, 3, 3, 4, 4 };
            //int[] nums1 = { 1, 5, 7, 0, 0, 0 };
            //int[] nums2 = { 2, 4, 6 };
            Console.WriteLine("The arrays contains:");
            Print(nums1, nums1.Length - nums2.Length);
            Print(nums2, nums2.Length);
            Merge(nums1, 5, nums2, 7);
            Console.WriteLine("The merged array contains:");
            Print(nums1, nums1.Length);
        }
    }
}
