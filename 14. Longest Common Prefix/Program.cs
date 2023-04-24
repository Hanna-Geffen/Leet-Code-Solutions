using System;

namespace _14._Longest_Common_Prefix
{
    // https://leetcode.com/problems/longest-common-prefix/
    // Description:
    // Write a function to find the longest common prefix string amongst an array of strings.
    // If there is no common prefix, return an empty string "".
       
    // Constraints:
    // 1 <= strs.length <= 200
    // 0 <= strs[i].length <= 200
    // strs[i] consists of only lowercase English letters.

    class Program
    {
        static string LongestCommonPrefix(string[] strs)
        {
            string lcp = "";

            for (int i = 0; i < strs[0].Length; i++)
            {
                foreach (var s in strs)
                {
                    if (i >= s.Length || strs[0][i] != s[i])
                    {
                        return lcp;
                    }
                }
                lcp += strs[0][i];
            }
            return lcp;
        }


/*        private static void CheckInput(string[] strs)
        {
            if (strs.Length > 200)
            {
                throw new Exception("The Length of the strings array must be: 0 <= strs.Length <= 200.");
            }
            foreach (string s in strs)
            {
                if (s.Length > 200)
                {
                    throw new Exception("The Length of the strings in the array must be: 0 <= s.Length <= 200.");
                }
                for (int i = 0; i < s.Length; i++)
                {
                    if ((int)s[i] < 97 || (int)s[i] > 122)
                    {
                        throw new Exception("All the strings in the array must consist of only lower-case English letters.");
                    }
                }
            }
        }*/

        static void TestFunction(string[] strs, string expectedResult)
        {
            string returnedValue = LongestCommonPrefix(strs);
            if (expectedResult != returnedValue)
            {
                throw new Exception("Error: the function \'LongestCommonPrefix\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }

        static void RunTests()
        {
            string[] strs1 = { "car", "case", "cafe" };
            TestFunction(strs1, "ca");
            string[] strs2 = { "hanna", "hannounet", "haim" };
            TestFunction(strs2, "ha");
            string[] strs3 = { "flower", "flow", "flight" };
            TestFunction(strs3, "fl");
            string[] strs4 = { "dog", "racecar", "car" };
            TestFunction(strs4, "");
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
                s = Input_String("abcdefghijklmnopqrstuvwxyz", message);

                if (s.Length < min || s.Length > max)
                {
                    Console.WriteLine("The {0} must be: {1} <= s.{0} <= {2}.\n", name, min, max);
                    OK = false;
                }
            } while (!OK);
            return s;
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
                    Console.WriteLine(e.Message);
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

        static string[] Init_String_Array()
        {
            int Length = Input_Number_In_Range(0, 200, "size", "Enter a size for your string array or 0 to exit:");
            if (Length == 0)
            {
                return null;
            }
            string[] strs = new string[Length];

            Console.WriteLine("Enter strings to initialize your array.");
            for (int i = 0; i < Length; i++)
            {
                strs[i] = Input_String_In_Range(0, 200, "length", "Enter a string for strs[" + i + "]:");
            }
            return strs;
        }

        static void Main(string[] args)
        {
            RunTests();

            string[] strs1;

            do
            {
                strs1 = Init_String_Array();
                if (strs1 == null)
                {
                    break;
                }
                string result = LongestCommonPrefix(strs1);
                Console.WriteLine("The Longest Common Prefix (LCP) is : " + result + "\n");
            }
            while (true);
            Console.WriteLine("Good Bye.");
        }
    }
}
