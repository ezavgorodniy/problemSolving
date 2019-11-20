using System;

namespace _23_MergeLists
{
 
     public class ListNode
    {
 
             public int val;
      public ListNode next;
      public ListNode(int x) { val = x; }
  }


    class Program
    {

        public static ListNode MergeKLists(ListNode[] lists)
        {
            ListNode resultHead = null;
            ListNode resultTail = null;

            int indexMin;
            do
            {
                indexMin = -1;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (lists[i] == null)
                    {
                        continue;
                    }
                    if (indexMin == -1)
                    {
                        indexMin = i;
                    }
                    if (lists[i].val < lists[indexMin].val)
                    {
                        indexMin = i;
                    }
                }

                if (indexMin == -1)
                {
                    break;
                }
                if (resultHead == null)
                {
                    resultHead = lists[indexMin];
                    resultTail = lists[indexMin];
                }
                else
                {
                    resultTail.next = lists[indexMin];
                    resultTail = resultTail.next;
                }
                lists[indexMin] = lists[indexMin].next;
            }
            while (indexMin != -1);


            return resultHead;

        }

        static void Main(string[] args)
        {
            MergeKLists(new[]
            {
                new ListNode(1)
                {
                    next = new ListNode(4)
                    {
                        next = new ListNode(5)
                        {
                            next = null
                        }
                    }
                },
                new ListNode(1)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = null
                        }
                    }
                },
                new ListNode(2)
                {
                    next = new ListNode(6)
                    {
                        next = null
                    }
                }
            });
            Console.WriteLine("Hello World!");
        }
    }
}
