using System;
using System.Collections;

namespace _20._Valid_Parentheses
{
    // https://leetcode.com/problems/valid-parentheses/
    // Description:
    // Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    // An input string is valid if:
    // 1. Open brackets must be closed by the same type of brackets.
    // 2. Open brackets must be closed in the correct order.
    // 3. Every close bracket has a corresponding open bracket of the same type.
       
    // Constraints:
    // 1 <= s.length <= 104
    // s consists of parentheses only '()[]{}'.

    class Class5
    {
        static bool IsValid(string s)
        {
            Stack ExpectedParentheses = new Stack(s.Length / 2);

            for (int i = 0; i < s.Length; i++)
            {
                if (IsOpeningParentheses(s[i]))
                {
                    ExpectedParentheses.Push(GetClosingParentheses(s[i]));
                }
                else
                {
                    if (ExpectedParentheses.Count == 0 || (char)ExpectedParentheses.Peek() != s[i])
                    {
                        return false;
                    }
                    ExpectedParentheses.Pop();
                }
            }
            return (ExpectedParentheses.Count == 0);
        }

        private static char GetClosingParentheses(char c)
        {
            switch (c)
            {
                case '(':
                    return ')';
                case '{':
                    return '}';
                case '[':
                    return ']';
                default:
                    throw new FormatException();
            }
        }

        private static bool IsOpeningParentheses(char c)
        {
            return (c == '(' || c == '{' || c == '[');
        }

        static void Main5(string[] args)
        {
            try
            {
                string Continue = "";
                do
                {
                    Console.WriteLine("Enter a string to check:");
                    string x = Console.ReadLine();
                    Console.WriteLine("The check result is: " + IsValid(x));
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

