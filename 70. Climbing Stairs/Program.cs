using System;

namespace _70._Climbing_Stairs
{
    class Program
    {
        static int fibonaciClimbStairs(int n)
        {
            if (n == 1) return 1;
            int first = 1, second = 2, result = second;
            for (int i = 3; i <= n; ++i)     
            {
                result = first + second;
                first = second;
                second = result;
            }
            return result;
        }
        static int ClimbStairs(int n)
        {
            if (n <= 1) return 1;
            CheckConstraints(n);
            return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }

        static void CheckConstraints(int n)
        {
            //1 <= n <= 45.
            if (n < 1 || n > 45)
            {
                throw new Exception("ERROR: 1 <= n <= 45.");
            }
        }
        static void RunTests()
        {
            TestFunction(1, 1);
            TestFunction(2, 2);
            TestFunction(3, 3);
            TestFunction(4, 5);
            TestFunction(5,8);
            TestFunction(6,13);
            TestFunction(7,21);
            TestFunction(8,34);
            TestFunction(9,55);
            TestFunction(10,89);
            TestFunction(11,144);
            TestFunction(12,233);
            TestFunction(13,377);
            TestFunction(14, 610);
            TestFunction(15, 987);
            TestFunction(16, 1597);
            TestFunction(17, 2584);
            TestFunction(18, 4181);
        }
        static void TestFunction(int n, int expectedResult)
        {
            int returnedValue = ClimbStairs(n);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'ClimbStairs\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter a number:");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(fibonaciClimbStairs(n));
            }
            //RunTests();
            //int result = ClimbStairs(44);
            //Console.WriteLine(result);
        }
    }
}
