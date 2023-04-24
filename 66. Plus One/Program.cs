using System;

namespace _66._Plus_One
{
    class Program
    {
        static int[] PlusOne(int[] digits)
        {
            try
            {
                CheckConstraints(digits);
                int i = digits.Length - 1;
                do
                {
                    digits[i] = ++digits[i] % 10;
                    i--;
                } while (i >= 0 && digits[i + 1] == 0);

                if (digits[0] == 0)
                {
                    int[] newdigits = new int[digits.Length + 1];
                    newdigits[0] = 1;
                    for (int j = 1; j < newdigits.Length; j++)
                    {
                        newdigits[j] = digits[j - 1];
                    }
                    return newdigits;
                }
                return digits;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new int[1] { -1 };
            }
        }

        static void CheckConstraints(int[] digits)
        {
            //1 <= digits.length <= 100
            //0 <= digits[i] <= 9

            if (digits.Length < 1 || digits.Length > 100)
            {
                throw new Exception("ERROR: 1 <= digits.length <= 100.");
            }

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] < 0 || digits[i] > 9)
                {
                    throw new Exception("ERROR: 0 <= digits[i] <= 9.");
                }
            }
        }

        static void RunTests()
        {
            //test examples:
            int[] digits0 = { 1, 3, 5, 6 };
            int[] expectedResultOfDigits0 = { 1, 3, 5, 7 };
            TestFunction(digits0, expectedResultOfDigits0);

            int[] digits1 = { 1, 2, 3 };
            int[] expectedResultOfDigits1 = { 1, 2, 4 };
            TestFunction(digits1, expectedResultOfDigits1);

            int[] digits2 = { 4, 3, 2, 1 };
            int[] expectedResultOfDigits2 = { 4, 3, 2, 2 };
            TestFunction(digits2, expectedResultOfDigits2);

            int[] digits3 = { 0 };
            int[] expectedResultOfDigits3 = { 1 };
            TestFunction(digits3, expectedResultOfDigits3);


            //check constraints error:
            int[] digits4 = new int[101];//Length too big
            int[] ConstraintsError = { -1 };
            TestFunction(digits4, ConstraintsError);

            int[] digits5 = { };//Length too low
            TestFunction(digits5, ConstraintsError);

            int[] digits6 = { 10 };//digits[i] too big
            TestFunction(digits6, ConstraintsError);

            int[] digits8 = { -1 };//digits[i] too low
            TestFunction(digits8, ConstraintsError);

            //check overflow of array
            int[] digits9 = { 1, 9, 9 };
            int[] expectedResultOfDigits9 = { 2, 0, 0 };
            TestFunction(digits9, expectedResultOfDigits9);

            int[] digits10 = { 9, 9, 9 };
            int[] expectedResultOfDigits10 = { 1, 0, 0, 0 };
            TestFunction(digits10, expectedResultOfDigits10);
        }

        static void TestFunction(int[] digits, int[] expectedResult)
        {
            int[] returnedValue = PlusOne(digits);
            for (int i = 0; i < expectedResult.Length; i++)
            {
                if (expectedResult[i] != returnedValue[i])
                {
                    Console.WriteLine("Error: at index " + i + " the function \'PlusOne5\' returned: " + returnedValue[i] + ", but the expected result was: " + expectedResult[i] + ".");
                }
            }
        }

        static void Print(int[] digits)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                Console.Write(digits[i]);
            }
        }
        static void Main(string[] args)
        {
            RunTests();
            int[] digits = { 9, 9, 9 };
            digits = PlusOne(digits);
            Print(digits);
        }
    }
}
