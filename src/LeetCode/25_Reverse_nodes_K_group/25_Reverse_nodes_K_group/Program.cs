using System;

namespace _25_Reverse_nodes_K_group
{
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }


    public class Solution
    {
        private bool GroupExist(ListNode head, int groupSize)
        {
            int actualGroupSize = 0;
            while (actualGroupSize < groupSize && head != null)
            {
                head = head.next;
                actualGroupSize++;
            }

            return groupSize == actualGroupSize;
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
            {
                return head;
            }

            ListNode result = head;
            bool firstGroup = true;
            var currentGroupHead = head;
            ListNode prevGroupTail = null;
            while (GroupExist(currentGroupHead, k))
            {
                var current = currentGroupHead;
                var currentNext = currentGroupHead.next;

                int itemsLeft = k;
                while (currentNext != null && itemsLeft != 1)
                {
                    var newNext = currentNext.next;
                    currentNext.next = current;

                    current = currentNext;
                    currentNext = newNext;

                    itemsLeft--;
                }

                currentGroupHead.next = currentNext;
                if (firstGroup)
                {
                    result = current;
                    firstGroup = false;
                }
                else
                {
                    prevGroupTail.next = current;
                }

                prevGroupTail = currentGroupHead;
                currentGroupHead = currentNext;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var curList = new ListNode(1)
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
                                {
                                    next = new ListNode(7)
                                }
                            }
                        }
                    }
                }
            };

            var result = (new Solution()).ReverseKGroup(curList, 1);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }
    }
}
