using System;
using System.Runtime.InteropServices;

namespace SwapNodes
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
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var first = head;
            var second = head.next;
            var third = head.next.next;
            second.next = first;
            first.next = third;
            head = second;
            do
            {
                var prevSecond = first;
                first = third;
                if (first == null)
                {
                    break;
                }

                second = first.next;
                if (second == null)
                {
                    break;
                }

                third = first.next.next;
                second.next = first;
                prevSecond.next = second;
                first.next = third;
            } while (third != null);
            return head;
        }
    }

    class Program
    {
        private static void ConsoleOutListNode(ListNode a)
        {
            while (a != null)
            {
                Console.Write("{0} ", a.val);
                a = a.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var solution = new Solution();

            var example = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                            {
                                next = new ListNode(6)
                            }
                        }
                    }
                }
            };

            var solvedExample = solution.SwapPairs(example);
            ConsoleOutListNode(solvedExample);
        }
    }
}
