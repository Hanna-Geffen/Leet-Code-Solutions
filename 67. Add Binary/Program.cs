using System;

namespace _67._Add_Binary
{
    class Program
    {
        static string AddBinary(string a, string b)
        {
            try
            {
                CheckConstraints(a, b);
                string result = "";
                int i = a.Length - 1, j = b.Length - 1;
                int toAdd = 0;

                while (i >= 0 || j >= 0)
                {
                    if (i >= 0) { toAdd += Convert.ToInt32(a[i]) - '0'; }
                    if (j >= 0) { toAdd += Convert.ToInt32(b[j]) - '0'; }
                    result = toAdd % 2 + result;
                    toAdd = toAdd / 2;
                    i--;
                    j--;
                }

                if (toAdd == 1) { return toAdd + result; }
         
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "-1";
            }
        }

        static void CheckConstraints(string a, string b)
        {
            //1 <= a.length, b.length <= 10^4
            //a and b consist only of '0' or '1' characters.
            //Each string does not contain leading zeros except for the zero itself.

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (a.Length < 1 || a.Length > max || b.Length < 1 || b.Length > max)
            {
                throw new Exception("ERROR: 1 <= a.length, b.length <= 10^4.");
            }
            if ((a[0] == '0' && a.Length != 1) || (b[0] == '0' && b.Length != 1))
            {
                throw new Exception("ERROR: Each string does not contain leading zeros except for the zero itself.");
            }
            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                if (i < a.Length && a[i] != '0' && a[i] != '1')
                {
                    throw new Exception("ERROR: a consist of only lower-case English characters.");
                }
                if (i < b.Length && b[i] != '0' && b[i] != '1')
                {
                    throw new Exception("ERROR: b consist of only lower-case English characters.");
                }
            }
        }

        static void RunTests()
        {
            //test examples:
            TestFunction("11111", "101010101", "101110100");

            TestFunction("101010", "10101", "111111");

            TestFunction("111", "111", "1110");

            TestFunction("11", "1", "100");

            TestFunction("1010", "101", "1111");

            TestFunction("1110111110111", "101010", "1111000100001");

            TestFunction("1000100101010101", "110111", "1000100110001100");

            TestFunction("11011000011001101010101010", "1001010010", "11011000011001110011111100");

            TestFunction("0", "1", "1");

            //check constraints error:
            TestFunction("123456", "111", "-1");

            TestFunction("111", "245", "-1");

            TestFunction("", "111", "-1");

            TestFunction("111", "", "-1");

            TestFunction("011", "111", "-1");

            TestFunction("111", "0011", "-1");
        }

        static void TestFunction(string a, string b, string expectedResult)
        {
            string returnedValue = AddBinary(a, b);
            for (int i = 0, j = 0; i < expectedResult.Length && j < returnedValue.Length; i++, j++)
            {
                if (expectedResult[i] != returnedValue[j])
                {
                    Console.WriteLine("Error: the function \'AddBinary4\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
                    return;
                }
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            string a = "1010";
            string b = "1011";
            string result = AddBinary(a, b);
            Console.WriteLine(result);
        }
    }
}