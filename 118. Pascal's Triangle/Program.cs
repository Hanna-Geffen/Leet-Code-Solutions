using System;

namespace _118._Pascal_s_Triangle
{
    // https://leetcode.com/problems/pascals-triangle/
    // Description:
    // Given an integer numRows, return the first numRows of Pascal's triangle.
    // In Pascal's triangle, each number is the sum of the two numbers directly above it.
       
    // Constraints:
    // 1 <= numRows <= 30

    class Program
    {
        static int[][] Generate(int numRows)
        {
            try
            {
                CheckConstraints(numRows);
                int[][] result = new int[numRows][];

                for (int i = 0; i < numRows; i++)
                {
                    result[i] = new int[i + 1];
                    for (int j = 0; j < i + 1; j++)
                    {
                        if (j == 0 || j == i)//for the first and last index: put 1
                        {
                            result[i][j] = 1;
                        }
                        else
                        {
                            result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                        }
                    }
                }
                PrintPascal(result);

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static void CheckConstraints(int numRows)
        {
            //1 <= numRows <= 30.

            if (numRows < 1 || numRows > 30)
            {
                throw new Exception("ERROR: 1 <= numRows <= 30.");
            }
        }

        static void PrintPascal(int[][] result)
        {
            int MaxShift = result.Length - 1;

            for (int i = 0; i < result.Length; i++)
            {
                if (MaxShift != 0)
                {
                    int Space = MaxShift;
                    while (Space != 0)
                    {
                        Console.Write(" ");
                        Space--;
                    }
                }
                for (int j = 0; j < result[i].Length; j++)
                {
                    Console.Write(result[i][j] + " ");
                }
                MaxShift--;
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        static void RunTests()
        {
            int[][] expectedResult1 = new int[1][] { new int[1] { 1 } };
            TestFunction(1, expectedResult1);

            int[][] expectedResult2 = new int[2][] { new int[1] { 1 }, new int[2] { 1, 1 } };
            TestFunction(2, expectedResult2);

            int[][] expectedResult3 = new int[3][] { new int[1] { 1 }, new int[2] { 1, 1 }, new int[3] { 1, 2, 1 } };
            TestFunction(3, expectedResult3);

            int[][] expectedResult4 = new int[4][] { new int[1] { 1 }, new int[2] { 1, 1 }, new int[3] { 1, 2, 1 }, new int[4] { 1, 3, 3, 1 } };
            TestFunction(4, expectedResult4);

            int[][] expectedResult5 = new int[5][] { new int[1] { 1 }, new int[2] { 1, 1 }, new int[3] { 1, 2, 1 }, new int[4] { 1, 3, 3, 1 }, new int[5] { 1, 4, 6, 4, 1 } };
            TestFunction(5, expectedResult5);

            //check constraints:
            TestFunction(0, null);
            TestFunction(31, null);
        }

        static void TestFunction(int numRows, int[][] expectedResult)
        {
            int[][] returnedValue = Generate(numRows);
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
                Console.WriteLine("Error: the function \'Generate\' returned an array of Length: " + returnedValue.Length + ", but the expected Length was: " + expectedResult.Length + ".");
                return;
            }
            for (int i = 0; i < returnedValue.Length; i++)
            {
                if (returnedValue[i].Length != expectedResult[i].Length)
                {
                    Console.WriteLine("Error: the function \'Generate\' returned an array at index: " + i + " of Length: " + returnedValue.Length + ", but the expected Length was: " + expectedResult.Length + ".");
                    return;
                }
                for (int j = 0; j < returnedValue[i].Length; j++)
                {
                    if (returnedValue[i][j] != expectedResult[i][j])
                    {
                        Console.WriteLine("Error: the function \'Generate\' returned at index " + i + ": " + returnedValue[i] + ", but the expected val was: " + expectedResult[i] + ".");
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            RunTests();
            for (int i = 1; i < 31; i++)
            {
                Generate(i);
            }
        }
    }
}
