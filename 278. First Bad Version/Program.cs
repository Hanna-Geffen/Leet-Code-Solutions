using System;

namespace _278._First_Bad_Version
{
    class Program
    {
        public int FirstBadVersion(int n)//O(logN)
        {
            int left = 1, right = n, mid = 0;

            while (left <= right)
            {
                mid = left + (right - left) / 2;
                bool isBad = IsBadVersion(mid);
                if (isBad && IsBadVersion(mid - 1) == false) { return mid; }
                if (isBad)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private bool IsBadVersion(int n)
        {
            //implemented by LeetCode- no need to implement.
            return n > 13;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
