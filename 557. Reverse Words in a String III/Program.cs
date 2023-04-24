using System;

namespace _557._Reverse_Words_in_a_String_III
{
    class Program
    {
        // s'teL ekat
        //Input: s = "Let's take LeetCode contest"
        //Output: "s'teL ekat edoCteeL tsetnoc"
        static string ReverseWords(string s)
        {
            string reversedString = "";
            string reverseWord = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    reverseWord = s[i] + reverseWord;
                }
                if (s[i] == ' ' || i == s.Length - 1)
                {
                    reversedString += ' ' + reverseWord;
                    reverseWord = "";
                }
            }
            return reversedString.Substring(1, reversedString.Length - 1);//to remove the first space
        }

        static void Main(string[] args)
        {
            string s = "Hanna Geffen";
            string result = ReverseWords(s);
            Console.WriteLine(result);
        }
    }
}
