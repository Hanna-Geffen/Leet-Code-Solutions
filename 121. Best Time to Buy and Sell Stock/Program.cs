using System;

namespace _121._Best_Time_to_Buy_and_Sell_Stock
{
    class Program
    {
        // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        // Description:
        // You are given an array prices where prices[i] is the price of a given stock on the ith day.        
        // You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
        // Return the maximum profit you can achieve from this transaction.If you cannot achieve any profit, return 0.
           
        // Constraints:
        // 1 <= prices.length <= 105
        // 0 <= prices[i] <= 104
        
        static int MaxProfit(int[] prices)
        {
            try
            {
                CheckConstraints(prices);
                int maxProfit = 0;
                int buyPrice = prices[0];

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] < buyPrice)
                    {
                        buyPrice = prices[i];
                    }
                    else if (prices[i] - buyPrice > maxProfit)
                    {
                        maxProfit = prices[i] - buyPrice;
                    }
                }

                return maxProfit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }

        static void CheckConstraints(int[] prices)
        {
            //1 <= prices.length <= 10^5.
            //0 <= prices[i] <= 10^4.

            int max = Convert.ToInt32(Math.Pow(10, 4));

            if (prices.Length < 1 || prices.Length > max * 10)
            {
                throw new Exception("ERROR: 1 <= prices.length <= 10^5.");
            }
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < 0 || prices[i] > max)
                {
                    throw new Exception("ERROR: 0 <= prices[i] <= 10^4.");
                }
            }
        }

        static void RunTests()
        {
            //test examples:
            int[] prices = { 7, 1, 5, 3, 6, 4 };
            TestFunction(prices, 5);

            int[] prices1 = { 7, 6, 4, 3, 1 };
            TestFunction(prices1, 0);

            int max = Convert.ToInt32(Math.Pow(10, 4));

            //check constraints error:
            int[] prices3 = new int[0];//Length too low
            TestFunction(prices3, -1);

            int[] prices4 = new int[(10 * max) + 1];//Length too high
            TestFunction(prices4, -1);

            int[] prices5 = { -1, 7, 8 };//price[i] too low
            TestFunction(prices5, -1);

            int[] prices6 = { max + 1, 5, 1 };//price[i] too high
            TestFunction(prices6, -1);
        }

        static void TestFunction(int[] prices, int expectedResult)
        {
            int returnedValue = MaxProfit(prices);
            if (expectedResult != returnedValue)
            {
                Console.WriteLine("Error: the function \'MaxProfit\' returned: " + returnedValue + ", but the expected result was: " + expectedResult + ".");
            }
        }


        static void Main(string[] args)
        {
            RunTests();
            int[] prices = new int[] { 7, 1, 5, 3, 6, 4 };
            //int[] prices = new int[] { 7, 6, 4, 3, 1 };
            int profit = MaxProfit(prices);
            Console.WriteLine(profit);

        }
    }
}
