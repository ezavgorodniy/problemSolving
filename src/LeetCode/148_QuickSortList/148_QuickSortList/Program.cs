using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _148_QuickSortList
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
        private int Size(ListNode head)
        {
            int cnt = 0;
            while (head != null)
            {
                head = head.next;
                cnt++;
            }
            return cnt;
        }

        public ListNode SortList(ListNode head)
        {
            int blockSize = 1;
            int n = Size(head);
            var virtualHead = new ListNode(0);
            ListNode B = null;
            virtualHead.next = head;
            while (blockSize < n)
            {
                var iter = 0;
                var last = virtualHead;
                var it = virtualHead.next;
                while (iter < n)
                {
                    var a = Math.Min(n - iter, blockSize);
                    var b = Math.Min(n - iter - a, blockSize);

                    var A = it;
                    if (b != 0)
                    {
                        var i = 0;
                        for (i = 0; i < a - 1; ++i) it = it.next;
                        B = it.next;
                        it.next = null;
                        it = B;

                        for (i = 0; i < b - 1; ++i) it = it.next;
                        var tmp = it.next;
                        it.next = null;
                        it = tmp;
                    }

                    while (A != null || B != null)
                    {
                        if (B == null || (A != null && A.val <= B.val))
                        {
                            last.next = A;
                            last = last.next;
                            A = A.next;
                        }
                        else
                        {
                            last.next = B;
                            last = last.next;
                            B = B.next;
                        }
                    }
                    last.next = null;
                    iter += a + b;
                }
                blockSize <<= 1;
            }
            return virtualHead.next;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
