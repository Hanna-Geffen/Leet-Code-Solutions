using System;

namespace _69._Sqrt_x_
{
    class Program
    {
        static int MySqrt(int x)
        {
            try
            {
                CheckConstraints(x);
                if (x == 0 || x == 1){ return x; }
                int mid;
                int left = 0, right = x; 
                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (mid == x / mid)
                    {
                        return mid;
                    }
                    if (mid < x / mid)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return left - 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(int x)
        {
            //0 <= x <= 2^31 - 1

            long max = Convert.ToInt64(Math.Pow(2, 31)) - 1;

            if (x < 0 || x > max)
            {
                throw new Exception("ERROR: 0 <= x <= 2^31 - 1.");
            }
        }

        static void RunTests()
        {
            //test examples:
            TestFunction(0, 0);
            TestFunction(1, 1);
            TestFunction(2, 1);
            TestFunction(3, 1);
            TestFunction(4, 2);
            TestFunction(5, 2);
            TestFunction(6, 2);
            TestFunction(7, 2);
            TestFunction(8, 2);
            TestFunction(9, 3);
            TestFunction(10, 3);
            TestFunction(11, 3);
            TestFunction(12, 3);
            TestFunction(13, 3);
            TestFunction(14, 3);
            TestFunction(15, 3);
            TestFunction(16, 4);
            TestFunction(17, 4);
            TestFunction(18, 4);
            TestFunction(19, 4);
            TestFunction(20, 4);
            TestFunction(21, 4);
            TestFunction(22, 4);
            TestFunction(23, 4);
            TestFunction(24, 4);
            TestFunction(25, 5);
            TestFunction(26, 5);
            TestFunction(27, 5);
            TestFunction(28, 5);
            TestFunction(29, 5);
            TestFunction(30, 5);
            TestFunction(31, 5);

            //check constraints error:
            TestFunction(Convert.ToInt32(Math.Pow(2, 30)) * 2, -1);
            TestFunction(-1, -1);
        }

        static void TestFunction(int x, int expectedResult)
        {
            int returnedValue = MySqrt(x);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'MySqrt\' returned for x=" + x + ": " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }


        static void Main(string[] args)
        {
            RunTests();
            int result = MySqrt(2147483647);
            Console.WriteLine(result);
        }
    }
}
