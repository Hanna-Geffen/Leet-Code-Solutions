using System;

namespace _13._Roman_to_Integer
{
    // https://leetcode.com/problems/roman-to-integer/
    // Description:
    // Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.
    // Symbol        Value
    // I             1
    // V             5
    // X             10
    // L             50
    // C             100
    // D             500
    // M             1000
    // For example, 2 is written as II in Roman numeral, just two ones added together.
    // 12 is written as XII, which is simply X + II.
    // The number 27 is written as XXVII, which is XX + V + II.
    // Roman numerals are usually written largest to smallest from left to right.
    // However, the numeral for four is not IIII.
    // Instead, the number four is written as IV.
    // Because the one is before the five we subtract it making four.
    // The same principle applies to the number nine, which is written as IX.
    // There are six instances where subtraction is used:
    // I can be placed before V (5) and X(10) to make 4 and 9. 
    // X can be placed before L(50) and C(100) to make 40 and 90. 
    // C can be placed before D(500) and M(1000) to make 400 and 900.
    // Given a roman numeral, convert it to an integer.

    //Constraints:
    //1 <= prices.length <= 105
    //0 <= prices[i] <= 104

    class Program
    {
        enum myRoman { I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000, IV = 4, IX = 9, XL = 40, XC = 90, CD = 400, CM = 900 }
        //int myNum = (int) Months.April;

        static int RomanToInt(string s)
        {
            myRoman number = myRoman.I;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1 && Enum.TryParse(string.Concat(s[i], s[i + 1]), out number))
                {
                    result += (int)number;
                    ++i;
                }
                else
                {
                    Enum.TryParse(s[i].ToString(), out number);
                    result += (int)number;
                }
            }

            return result;
        }

        /*        private static bool IsValid(string s)
                {
                    if (s.Length < 1 || s.Length > 15)
                    {
                        Console.WriteLine("The Length of the Roman number must be: 1 <= s.length <= 15.");
                        return false;
                    }
                    myRoman number;
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!Enum.TryParse(s[i].ToString(), out number))
                        {
                            Console.WriteLine("A Roman number contains only the characters 'I', 'V', 'X', 'L', 'C', 'D', 'M'.");
                            return false;
                        }
                    }
                    return true;
                }*/

        static void TestFunction(string s, int expectedResult)
        {
            int returnedValue = RomanToInt(s);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'RomanToInt\' returned: " + returnedValue + ", but the expected result for the string \"" + s + "\" was: " + expectedResult + ".");
            }
        }
        static void RunTests()
        {
            TestFunction("I", 1);
            TestFunction("V", 5);
            TestFunction("X", 10);
            TestFunction("L", 50);
            TestFunction("C", 100);
            TestFunction("D", 500);
            TestFunction("M", 1000);
            TestFunction("IV", 4);
            TestFunction("IX", 9);
            TestFunction("XL", 40);
            TestFunction("XC", 90);
            TestFunction("CD", 400);
            TestFunction("CM", 900);
            TestFunction("XVI", 16);
            TestFunction("I", 1);
            TestFunction("MCMXCVII", 1997);
            TestFunction("RUE", 0);
            TestFunction("uuu", 0);
            TestFunction(")))", 0);
        }

        private static string Input_String(string Valid_Characters, string message)
        {
            bool OK = true;
            string s = "";
            do
            {
                OK = true;
                Console.WriteLine(message);
                s = Console.ReadLine();

                for (int i = 0; i < s.Length; i++)
                {
                    if (Valid_Characters.IndexOf(s[i]) == -1)
                    {
                        Console.WriteLine("The string must include only these characters: \'{0}\'.\n", Valid_Characters);
                        OK = false;
                    }
                }
            } while (!OK);
            return s;
        }

        private static string Input_String_In_Range(int min, int max, string name, string message)
        {
            bool OK = true;
            string s = "";
            do
            {
                OK = true;
                s = Input_String("IVXLCDM0", message);

                if (s.Length < min || s.Length > max)
                {
                    Console.WriteLine("The {0} must be: {1} <= s.{0} <= {2}.\n", name, min, max);
                    OK = false;
                }
            } while (!OK);
            return s;
        }
        static string Init_String()
        {
            return Input_String_In_Range(1, 15, "length", "Enter a Roman number or 0 to exit:");
        }
        static void Main(string[] args)
        {
            RunTests();

            string s;
            int result;
            do
            {
                s = Init_String();
                if (s == "0")
                {
                    break;
                }
                result = RomanToInt(s);
                Console.WriteLine("Your roman number is equal to {0} in Int.\n", result);
            }
            while (true);
            Console.WriteLine("Good Bye.");
        }
    }
}
