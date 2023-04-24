using System;

namespace _7._Reverse_Integer
{
    class Program
    {
        static int Reverse(int x)
        {
            checked
            {
                try
                {
                    int reverse = 0;
                    while (x != 0)
                    {
                        reverse *= 10;
                        reverse += (x % 10);
                        x /= 10;
                    }
                    return reverse;
                }
                catch (Exception e)
                {
                    if (e is OverflowException) // also possible to write (e.GetType().Name == "OverflowException")
                    {
                        Console.WriteLine("Cannot reverse your number due to overflow problem!\n");
                        return -1;
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong: " + e.Message+"\n");
                        return -1;
                    }
                }
            }

        }

        static void TestFunction(int x, int expectedResult)
        {
            int returnedValue = Reverse(x);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'Reverse\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }

        static void RunTests()
        {
            TestFunction(123, 321);
            TestFunction(-123, -321);
            TestFunction(0, 0);
            TestFunction(9, 9);
            TestFunction(10, 1);
            TestFunction(21312, 21312);
            TestFunction(2147483647, -1);
        }

        private static int Input_Number(string message)
        {
            bool OK = true;
            int number = -1;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    number = Convert.ToInt32(Console.ReadLine());
                    OK = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message+"\n");
                    OK = false;
                }
            } while (!OK);
            return number;
        }

        private static int Input_Number_In_Range(int min, int max, string name, string message)
        {
            bool OK = true;
            int number;
            do
            {
                OK = true;
                number = Input_Number(message);

                if (number < min || number > max)
                {
                    Console.WriteLine("The {0} must be: {1} <= {0} <= {2}.\n", name, min, max);
                    OK = false;
                }
            } while (!OK);
            return number;
        }

        static void Main(string[] args)
        {
            RunTests();

            int x;
            int result;
            do
            {
                x = Input_Number_In_Range(-2147483648, 2147483647, "value", "Enter a number to Reverse or 0 to exit:");
                if (x == 0)
                {
                    break;
                }
                result = Reverse(x);
                Console.WriteLine("The result is: " + result+"\n");
            }
            while (true);
            Console.WriteLine("Good Bye.");
        }
    }
}

