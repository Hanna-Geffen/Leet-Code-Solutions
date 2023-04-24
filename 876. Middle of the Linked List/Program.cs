using System;

namespace _876._Middle_of_the_Linked_List
{
    class Program
    {
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

        //Input: head = [1,2,3,4,5,6]
        //Output: [4,5,6]

        static ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        static void Main(string[] args)
        {
            ListNode l = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ListNode result = MiddleNode(l);
            while (result != null)
            {
                Console.WriteLine(result.val + "--->");
                result = result.next;
            }
        }
    }
}
