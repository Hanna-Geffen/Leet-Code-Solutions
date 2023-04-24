using System;

namespace _28._Implement_strStr__
{
    class Program
    {
        static int StrStr(string haystack, string needle)//O(haystack*needle)
        {
            try
            {
                CheckConstraints(haystack, needle);
                if (haystack.Length < needle.Length) return -1;

                for (int i = 0; i <= haystack.Length - needle.Length; i++)//if i got here then haystack.Length >= needle.Length
                {
                    bool match = true;
                    for (int j = 0; j < needle.Length; j++)
                    {
                        if (haystack[i+j] != needle[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match) return i;
                }

                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }


        static void CheckConstraints(string haystack, string needle)
        {
            //0 <= haystack.length, needle.length <= 5 * 10^4
            //haystack and needle consist of only lower -case English characters.

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (haystack.Length > 5 * max || needle.Length > 5 * max)
            {
                throw new Exception("ERROR: 0 <= haystack.length, needle.length <= 5 * 10^4.");
            }
            for (int i = 0; i < Math.Max(haystack.Length, needle.Length); i++)
            {
                if (i < haystack.Length && ((int)haystack[i] < 97 || (int)haystack[i] > 122))
                {
                    throw new Exception("ERROR: haystack consist of only lower-case English characters.");
                }
                if (i < needle.Length && ((int)needle[i] < 97 || (int)needle[i] > 122))
                {
                    throw new Exception("ERROR: needle consist of only lower-case English characters.");
                }
            }
        }

        static void RunTests()
        {
            //test examples:
            TestFunction("hello","ll",2);

            TestFunction("aaaaa", "bba", -1);

            TestFunction("mississippi", "issip", 4);

            TestFunction("mississippi", "issipi", -1);

            TestFunction("mississippi", "ippi", 7);

            TestFunction("mississippi", "ippii", -1);

            TestFunction("mississippi", "mississippi", 0);

            TestFunction("pississippi", "mississippi", -1);

            //check constraints error:
            TestFunction("AAAAA", "bbbbb", -1);

            TestFunction("aaaaa", "BBBBB", -1);
        }

        static void TestFunction(string haystack, string needle, int expectedResult)
        {
            int returnedValue = StrStr(haystack, needle);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'StrStr3\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            string haystack = "mississippi";
            string needle = "iss";
            int result = StrStr(haystack, needle);
            Console.WriteLine(result);
  
        }
    }
}
