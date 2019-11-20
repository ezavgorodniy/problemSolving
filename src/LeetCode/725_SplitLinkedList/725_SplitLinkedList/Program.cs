using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _725_SplitLinkedList
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
        private int GetSize(ListNode root)
        {
            int size = 0;
            while (root != null)
            {
                root = root.next;
                size++;
            }
            return size;
        }

        private ListNode GetNext(ListNode current, int k)
        {
            var prevCurrent = current;
            while (k != 0)
            {
                prevCurrent = current;
                current = current.next;
                k--;
            }
            prevCurrent.next = null;
            return current;
        }

        public ListNode[] SplitListToParts(ListNode root, int k)
        {
            var result = new ListNode[k];
            var listSize = GetSize(root);


            var bucketSize = listSize / k;
            var biggerBucketAmount = listSize % k;
            var currentNode = root;
            for (int i = 0; i < biggerBucketAmount; i++)
            {
                result[i] = currentNode;
                currentNode = GetNext(currentNode, bucketSize + 1);
            }

            for (int i = biggerBucketAmount; i < k; i++)
            {
                result[i] = currentNode;
                currentNode = GetNext(currentNode, bucketSize);
            }

            return result;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            //next = new ListNode(5)
                            //{
                            //    next = new ListNode(6)
                            //    {
                            //        next = new ListNode(7)
                            //    }
                            //}
                        }
                    }
                }
            };

            var sln = new Solution();
            var parts = sln.SplitListToParts(root, 5);
        }
    }
}
