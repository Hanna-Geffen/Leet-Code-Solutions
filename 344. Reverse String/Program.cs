using System;

namespace _344._Reverse_String
{
    class Program
    {
        static void ReverseString(char[] s)
        {
            char temp;
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                temp = s[i];
                s[i] = s[j];
                s[j] = temp;
                i++;
                j--;
            }
        }
        static void ReverseString2(char[] s)
        {
            ReverseString_recursion(s,0,s.Length-1);
        }

        static void ReverseString_recursion(char[] s, int start, int end)
        {
            if (start >= end) { return; }
            char temp = s[start];
            s[start] = s[end];
            s[end] = temp;
            ReverseString_recursion(s, start + 1, end - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
