using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicatesFromSortedList
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            if (head.next == null)
            {
                return head;
            }

            while (head.next != null && head.next.val == head.val)
            {
                var headValuesToDelete = head.val;
                while (head != null && head.val == headValuesToDelete)
                {
                    head = head.next;
                }

                if (head == null)
                {
                    return null;
                }
            }


            if (head == null)
            {
                return null;
            }

            var prev = head;
            var cur = head.next;
            while (cur.next != null)
            {
                var curVal = cur.val;
                if (cur.next.val == curVal)
                {
                    while (cur != null && cur.val == curVal)
                    {
                        cur = cur.next;
                    }

                    prev.next = cur;
                    if (cur == null)
                    {
                        break;
                    }
                }
                else
                {
                    prev = cur;
                    cur = cur.next;
                }
            }

            return head;
        }


        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }
            if (head == null)
            {
                return head;
            }

            var prev = head;
            var cur = head.next;
            while (cur != null)
            {
                if (cur.val == val)
                {
                    prev.next = cur.next;
                }
                else
                {
                    prev = cur;
                }
                cur = cur.next;
            }

            return head;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var list = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(1)
                    }
                }
            };

            var solution  =new Solution();
            solution.RemoveElements(list, 2);
        }
    }
}
