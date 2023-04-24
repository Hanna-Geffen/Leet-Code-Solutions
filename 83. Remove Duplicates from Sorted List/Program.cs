using System;

namespace _83._Remove_Duplicates_from_Sorted_List
{
    class Program
    {

        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        static ListNode DeleteDuplicates(ListNode head)
        {
            try
            {
                CheckConstraints(head);
                if (head == null || head.next == null) { return head; }//there are no duplicates possible.

                ListNode current = head;//the first is for sure unique so we check from current.next

                while (current.next != null)
                {
                    if (current.val != current.next.val)//if found a new unique: 
                    {
                        current = current.next;
                    }
                    else//if found a duplicate: skip it.
                    {
                        current.next = current.next.next;
                    }
                }
                Print(head);
                return head;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new ListNode();
            }
        }

        private static void CheckConstraints(ListNode l)
        {
            //The number of nodes in the list is in the range[0, 300].
            //-100 <= Node.val <= 100
            //The list is guaranteed to be sorted in ascending order.

            int CountNodes = 0;

            for (ListNode i = l; i != null; i = i.next)
            {
                if (i.val < -100 || i.val > 100 )
                {
                    throw new Exception("ERROR: -100 <= Node.val <= 100.");
                } 
                if (i.next != null && i.val > i.next.val) 
                {
                    throw new Exception("ERROR: The list should be sorted in ascending order.");
                }
                CountNodes++;
            }
            if (CountNodes > 300)
            {
                throw new Exception("ERROR: The number of nodes in the list should be in the range[0, 300].");
            }
        }

        static void Print(ListNode list)
        {
            for (ListNode i = list; i != null; i = i.next)
            {
                Console.Write(i.val + "---->");
            }
            Console.Write("null\n");
        }

        static void RunTests()
        {
            ListNode l1 = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(4, new ListNode(4)))));
            ListNode expectedResult = new ListNode(1, new ListNode(2, new ListNode(4)));
            TestFunction(l1, expectedResult);//l1=[1,1,2,4,4]  expectedResult=[1,2,4]

            ListNode l2 = new ListNode(1, new ListNode(3,new ListNode(3,new ListNode(3, new ListNode(4,new ListNode(4,new ListNode(4,new ListNode(5))))))));
            expectedResult = new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(5))));
            TestFunction(l2, expectedResult);//l2=[1,3,3,3,4,4,4,5] expectedResult=[1,3,4,5]


            TestFunction(null, null); //l1=[] expectedResult=[]
            TestFunction(new ListNode(), new ListNode());//l1=[0] expectedResult=[0]

            //check constraints:
            TestFunction(new ListNode(3, new ListNode(1)), new ListNode());//unsorted
            TestFunction(new ListNode(101, new ListNode(3)), new ListNode());//val
            TestFunction(new ListNode(-101, new ListNode(-1)), new ListNode());//val
        }

        static void TestFunction(ListNode l1, ListNode expectedResult)
        {
            ListNode returnedValue = DeleteDuplicates(l1);

            if ((returnedValue == null && expectedResult != null) || (returnedValue != null && expectedResult == null))
            {
                Console.WriteLine("Error: the returned value doesn't match the expected value.");
                return;
            }
            ListNode i = expectedResult, j= returnedValue;
            while (i != null && j != null)
            {
                if (i.val != j.val)
                {
                    Console.WriteLine("Error: the function \'DeleteDuplicates\' returned:");
                    Print(returnedValue);
                    Console.WriteLine("But the expected result was:");
                    Print(expectedResult);
                    return;
                }
                i = i.next;
                j = j.next;
            }
            if (i != null || j != null)
            {
                Console.WriteLine("Error: the returned value doesn't match the expected value.");
            }
        }


        static void Main(string[] args)
        {
            RunTests();
            ListNode l1 = new ListNode(1, new ListNode(1, new ListNode(5, new ListNode(5, new ListNode(9, new ListNode(9))))));
            ListNode result = DeleteDuplicates(l1);
            Print(result);
        }
    }
}
