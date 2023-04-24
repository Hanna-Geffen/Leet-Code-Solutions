using System;

namespace _9._Palindrome_Number
{
    class Program
    {
        static int Reverse(int x)
        {
            //CheckInput(x);
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
                    Console.WriteLine("Something went wrong: " + e.Message + "\n");
                    return -1;
                }
            }
        }

        static bool IsPalindrome(int x)
        {
            return (x < 0) ? false : (x == Reverse(x));
        }

        static void TestFunction(int x, bool expectedResult)
        {
            bool returnedValue = IsPalindrome(x);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'IsPalindrome\' returned: " + returnedValue + ", but the expected result for the number \"" + x + "\" was: " + expectedResult + ".");
            }
        }

        static void RunTests()
        {
            TestFunction(21312, true);
            TestFunction(0, true);
            TestFunction(111, true);
            TestFunction(-121, false);
            TestFunction(121, true);
            TestFunction(12344321, true);
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
                    Console.WriteLine(e.Message + "\n");
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
            bool result;
            do
            {
                x = Input_Number_In_Range(-231, 230, "value", "Enter a number to to check if Polindrom or not:");
                if (x == 0)
                {
                    break;
                }
                result = IsPalindrome(x);
                Console.WriteLine("The result is: " + result + "\n");
            }
            while (true);
            Console.WriteLine("Good Bye.");
        }
    }
}
