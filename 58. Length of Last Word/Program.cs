using System;

namespace _58._Length_of_Last_Word
{
    class Program
    {
        static int LengthOfLastWord(string s)
        {
            try
            {
                CheckConstraints(s);
                int length = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if ( s[i] != ' ') //its a letter
                    {
                        if (i > 0 && s[i - 1] == ' ')//it's the first letter after the last space == the last word for now.
                        {
                            length = 0;
                        }
                        length++;
                    }
                }

                return length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(string s)
        {
            //1 <= s.length <= 10^4
            //s consists of only English letters and spaces ' '.
            //65-90 uppercase
            //97-122 lowercase
            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (s.Length < 1 || s.Length > max)
            {
                throw new Exception("ERROR: 1 <= s.length <= 10^4.");
            }
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] != 32 && ((int)s[i] < 65 || (int)s[i] > 122 || ((int)s[i] > 90 && (int)s[i] < 97)))
                {
                    throw new Exception("ERROR: s consists of only English letters and spaces ' '.");
                }
            }
        }

        static void RunTests()
        {
            //test examples:
            TestFunction("Hello world",5);

            TestFunction(" ", 0);

            TestFunction(" abhf", 4);

            TestFunction("ass ", 3);

            TestFunction("sss      gggg    ll ", 2);

            //check constraints error:
            TestFunction("7", -1);
            TestFunction("`", -1);
            TestFunction("[", -1);
            TestFunction("(", -1);
            TestFunction("@", -1);
            TestFunction("!", -1);

            TestFunction("", -1);
        }

        static void TestFunction(string s, int expectedResult)
        {
            int returnedValue = LengthOfLastWord4(s);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'LengthOfLastWord4\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            string s = "day";
            int result = LengthOfLastWord(s);
            Console.WriteLine(result);
        }
    }
}
