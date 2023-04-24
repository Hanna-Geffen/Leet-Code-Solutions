using System;
using System.Collections.Generic;

namespace _119._Pascal_s_Triangle_II
{
    // https://leetcode.com/problems/pascals-triangle-ii/
    // Description:
    // Given an integer rowIndex, return the rowIndexth(0-indexed) row of the Pascal's triangle.
    // In Pascal's triangle, each number is the sum of the two numbers directly above it.
    // Follow up: Could you optimize your algorithm to use only O(rowIndex) extra space?
       
    // Constraints:
    // 0 <= rowIndex <= 33

    class Program
    {
        static int[] GetRow(int rowIndex)
        {
            try
            {
                CheckConstraints(rowIndex);
                if (rowIndex == 0) { return new int[1] { 1 }; }

                int[] result = new int[rowIndex + 1];
                int[][] memo = new int[34][];

                for (int i = 0; i < result.Length; i++)
                {
                    if (memo[rowIndex - 1] == null)
                    {
                        memo[rowIndex - 1] = GetRow(rowIndex - 1);
                    }
                    if (i == 0 || i == rowIndex)//for the first and last index: put 1
                    {
                        result[i] = 1;
                    }
                    else
                    {
                        result[i] = memo[rowIndex - 1][i - 1] + memo[rowIndex - 1][i];
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

/*        public IList<int> GetRow2(int rowIndex)//iterativ solution using lists.
        {

            List<int> cur = new List<int>() { 1 }, prev = null;
            if (rowIndex == 0) return cur;
            int len;
            for (int i = 1; i <= rowIndex; i++)
            {
                prev = cur;
                cur = new List<int>() { 1 };
                len = prev.Count + 1;
                for (int j = 1; j < len - 1; j++)
                {
                    cur.Add(prev[j - 1] + prev[j]);
                }
                cur.Add(1);
            }
            return cur;
        }*/

        static void CheckConstraints(int rowIndex)
        {
            //0 <= rowIndex <= 33.

            if (rowIndex < 0 || rowIndex > 33)
            {
                throw new Exception("ERROR: 0 <= rowIndex <= 33.");
            }
        }

        static void PrintPascalRow(int[] result)
        {
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();
        }
        static void RunTests()
        {
            int[] expectedResult1 = new int[1] { 1 };
            TestFunction(0, expectedResult1);

            int[] expectedResult2 = new int[2] { 1, 1 };
            TestFunction(1, expectedResult2);

            int[] expectedResult3 = new int[3] { 1, 2, 1 };
            TestFunction(2, expectedResult3);

            int[] expectedResult4 = new int[4] { 1, 3, 3, 1 };
            TestFunction(3, expectedResult4);

            int[] expectedResult5 = new int[5] { 1, 4, 6, 4, 1 };
            TestFunction(4, expectedResult5);

            //check constraints:
            TestFunction(-1, null);
            TestFunction(34, null);
        }

        static void TestFunction(int rowIndex, int[] expectedResult)
        {
            int[] returnedValue = GetRow(rowIndex);
            if ((returnedValue == null && expectedResult != null) || (returnedValue != null && expectedResult == null))
            {
                Console.WriteLine("Error: the returned value doesn't match the expected value.");
                return;
            }
            if (returnedValue == null && expectedResult == null)
            {
                return;
            }
            if (returnedValue.Length != expectedResult.Length)
            {
                Console.WriteLine("Error: the function \'GetRow\' returned an array of Length: " + returnedValue.Length + ", but the expected Length was: " + expectedResult.Length + ".");
                return;
            }
            for (int i = 0; i < returnedValue.Length; i++)
            {
                if (returnedValue[i] != expectedResult[i])
                {
                    Console.WriteLine("Error: the function \'GetRow\' returned at index " + i + ": " + returnedValue[i] + ", but the expected value was: " + expectedResult[i] + ".");
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            for (int i = 0; i < 34; i++)
            {
                int[] result = GetRow(i);
                PrintPascalRow(result);
            }
        }
    }
}
