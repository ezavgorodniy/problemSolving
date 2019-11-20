using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeLinkedList
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
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
            {
                return true;
            }

            var size = 0;
            var iterator = head;
            while (iterator != null)
            {
                iterator = iterator.next;
                size++;
            }

            iterator = head;
            var stopIndex = size / 2 + size % 2;
            while (stopIndex != 0)
            {
                iterator = iterator.next;
                stopIndex--;
            }

            var prevIterator = iterator;
            iterator = iterator.next;
            prevIterator.next = null;
            while (iterator != null)
            {
                var nextIterator = iterator.next;
                iterator.next = prevIterator;
                prevIterator = iterator;
                iterator = nextIterator;
            }

            var firstListIterator = head;
            var secondListIterator = prevIterator;
            while (firstListIterator != null && secondListIterator != null)
            {
                if (firstListIterator.val != secondListIterator.val)
                {
                    return false;
                }

                firstListIterator = firstListIterator.next;
                secondListIterator = secondListIterator.next;
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new ListNode(1);
            var solution = new Solution();
            Console.WriteLine(solution.IsPalindrome(list));
        }
    }
}
