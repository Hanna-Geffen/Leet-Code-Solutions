using System;

namespace _21._Merge_Two_Sorted_Lists
{
    // https://leetcode.com/problems/merge-two-sorted-lists/
    // Description:
    // You are given the heads of two sorted linked lists list1 and list2.
    // Merge the two lists in a one sorted list. The list should be made by splicing together the nodes of the first two lists.
    // Return the head of the merged linked list.

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

            public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                CheckConstraints(l1, l2);
                ListNode head = new ListNode();
                ListNode tail = head;
                while (l1 != null && l2 != null)
                {
                    if (l1.val <= l2.val)
                    {
                        tail.next = new ListNode(l1.val);
                        l1 = l1.next;
                    }
                    else
                    {
                        tail.next = new ListNode(l2.val);
                        l2 = l2.next;
                    }
                    tail = tail.next;
                }
                while (l1 != null)
                {
                    tail.next = new ListNode(l1.val);
                    l1 = l1.next;
                    tail = tail.next;
                }
                while (l2 != null)
                {
                    tail.next = new ListNode(l2.val);
                    l2 = l2.next;
                    tail = tail.next;
                }
                return head.next;
            }

            private static void CheckConstraints(ListNode l1, ListNode l2)
            {
                /*       The number of nodes in both lists is in the range[0, 50].
                       -100 <= Node.val <= 100
                       Both l1 and l2 are sorted in non-decreasing order.*/
                int CountNumOfNodesL1 = 0;
                int CountNumOfNodesL2 = 0;

                for (ListNode i1 = l1, i2 = l2; i1 != null && i2 != null; i1 = i1.next, i2 = i2.next)
                {
                    if ((i1.next != null && i1.val > i1.next.val) || (i2.next != null && i2.val > i2.next.val))
                    {
                        Console.WriteLine("ERROR: The lists should be sorted in non-decreasing order.");
                    }
                    if (i1.val < -100 || i1.val > 100 || i2.val < -100 || i2.val > 100)
                    {
                        Console.WriteLine("ERROR: -100 <= Node.val <= 100");
                    }
                    CountNumOfNodesL1++;
                    CountNumOfNodesL2++;
                }
                if (CountNumOfNodesL1 > 50 || CountNumOfNodesL2 > 50)
                {
                    Console.WriteLine("ERROR: The number of nodes in the lists should be in the range[0, 50]");

                }
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
            ListNode l1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            ListNode expectedResult = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))));
            TestFunction(l1, l2, expectedResult);//l1=[1,2,4] l2=[1,3,4] expectedResult=[1,1,2,3,4,4]

            TestFunction(null, null, null); //l1=[] l2=[] expectedResult=[]
            TestFunction(null, new ListNode(), new ListNode());//l1=[] l2=[0] expectedResult=[0]


            l1 = new ListNode(1, new ListNode(3, new ListNode(7, new ListNode(8, new ListNode(10)))));
            l2 = new ListNode(2, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(9)))));
            expectedResult = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5, new ListNode(6, new ListNode(7, new ListNode(8, new ListNode(9, new ListNode(10))))))))));
            TestFunction(l1, l2, expectedResult);//l1=[1,3,7,8,10] l2=[2,4,5,6,9] expectedResult=[1,2,3,4,5,6,7,8,9,10]
        }

        static void TestFunction(ListNode l1, ListNode l2, ListNode expectedResult)
        {
            ListNode returnedValue = ListNode.MergeTwoLists(l1, l2);

            if (expectedResult == null && returnedValue != null)
            {
                Console.WriteLine("Error: the function \'MergeTwoLists\' returned:");
                Print(returnedValue);
                Console.WriteLine("But the expected result was:");
                Print(expectedResult);
            }
            for (ListNode i = expectedResult; i != null; i = i.next)
            {
                //quand returned value=null ca bug.
                if (i.val != returnedValue.val)
                {
                    Console.WriteLine("Error: the function \'MergeTwoLists\' returned:");
                    Print(returnedValue);
                    Console.WriteLine("But the expected result was:");
                    Print(expectedResult);
                }
                returnedValue = returnedValue.next;
            }
        }

        static void Main(string[] args)
        {
            RunTests();
            ListNode l1 = new ListNode(1, new ListNode(3, new ListNode(5, new ListNode(7, new ListNode(9, new ListNode(11))))));
            ListNode l2 = new ListNode(2, new ListNode(4, new ListNode(6, new ListNode(8, new ListNode(10, new ListNode(12))))));
            ListNode result = ListNode.MergeTwoLists(l1, l2);
            Print(result);
        }
    }
}
