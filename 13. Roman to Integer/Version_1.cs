using System;

namespace _13._Roman_to_Integer
{
    class Version_1
    {
        enum myRoman { I = 1, V = 5, X = 10, L = 50, C = 100, D = 500, M = 1000, IV = 4, IX = 9, XL = 40, XC = 90, CD = 400, CM = 900 }
        //int myNum = (int) Months.April;

        static int RomanToInt(string s)
        {
            myRoman number = myRoman.I;
            int result = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    Enum.TryParse(string.Concat(s[i], s[i + 1]), out number);

                    if (number == myRoman.IV || number == myRoman.IX || number == myRoman.XL || number == myRoman.XC || number == myRoman.CD || number == myRoman.CM)
                    {
                        result += (int)number;
                        ++i;
                        continue;
                    }
                }
                //if(i==s.Length-1)
                Enum.TryParse(s[i].ToString(), out number);
                result += (int)number;
            }

            return result;
        }

        static void TestFunction()
        {
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("I"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("V"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("X"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("L"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("C"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("D"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("M"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("IV"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("IX"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("XL"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("XC"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("CD"));
            Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt("CM"));
        }
        static void Main1(string[] args)
        {
            try
            {
                string Continue = "";
                do
                {
                    //TestFunction();
                    Console.WriteLine("Enter a Roman number:");
                    string s = Console.ReadLine();
                    Console.WriteLine("Your roman number is equal to {0} in Int.", RomanToInt(s));
                    Continue = Console.ReadLine();
                }
                while (Continue == "");
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong: " + e.Message);
            }
        }
    }
}
