using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _61_RotateList
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
        private ListNode FindKthElement(ListNode head, int k)
        {
            ListNode current = head;
            while (k != 0)
            {
                current = current.next;
                k--;
            }

            return current;
        }


        private void FindRotationParameters(ListNode head, int k, out ListNode tail, out ListNode rotationGear)
        {
            int index = 0;
            ListNode current = head;
            while (current.next != null)
            {
                current = current.next;
                index++;
            }

            tail = current;
            int length = index + 1;
            if (k % length == 0)
            {
                rotationGear = null;
            }
            else
            {
                rotationGear = FindKthElement(head, (length - k % length) % length - 1);
            }
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null || head.next == null || k == 0)
            {
                return head;
            }

            ListNode tail, rotationGear;
            FindRotationParameters(head, k, out tail, out rotationGear);

            if (rotationGear != null)
            {
                tail.next = head;
                head = rotationGear.next;
                rotationGear.next = null;
            }
            return head;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();
            while (true)
            {


                var lst = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(5)
                            }
                        }
                    }
                };
                var newRotation = sln.RotateRight(lst, int.Parse(Console.ReadLine()));

                while (newRotation != null)
                {
                    Console.WriteLine(newRotation.val);
                    newRotation = newRotation.next;
                }
                Console.WriteLine();
            }
        }
    }
}
