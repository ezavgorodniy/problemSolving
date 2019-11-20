using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _430_Flatten
{
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node()
        {
        }

        public Node(int _val, Node _prev, Node _next, Node _child)
        {
            val = _val;
            prev = _prev;
            next = _next;
            child = _child;
        }
    }

    public class Solution
    {
        private class FlattenResult
        {
            public Node Head { get; set; }
            public Node Tail { get; set; }
        }

        private FlattenResult GetFlatten(Node head)
        {
            var curNode = head;
            while (curNode.next != null)
            {
                var nextCurNode = curNode.next;

                if (curNode.child != null)
                {
                    var flattenCurNode = GetFlatten(curNode.child);

                    flattenCurNode.Tail.next = curNode.next;
                    curNode.next.prev = flattenCurNode.Tail;

                    curNode.child.prev = curNode;
                    curNode.next = curNode.child;

                    curNode.child = null;
                }

                curNode = nextCurNode;
            }

            if (curNode.child != null)
            {
                var tail = curNode;
                GetFlatten(tail.child);
                tail.next = tail.child;
                tail.child.prev = tail;
                tail.child = null;
            }

            return new FlattenResult
            {
                Head = head,
                Tail = curNode
            };
        }

        public Node Flatten(Node head)
        {
            GetFlatten(head);
            return head;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new Node {val =1};
            var node2 = new Node {val =2};
            var node3 = new Node {val =3};
            var node4 = new Node {val =4};
            var node5 = new Node {val =5};
            var node6 = new Node {val =6};
            var node7 = new Node {val =7};
            var node8 = new Node {val =8};
            var node9 = new Node {val =9};
            var node10 = new Node {val =10};
            var node11 = new Node {val =11};
            var node12 = new Node {val =12 };

            node1.next = node2;

            node2.prev = node1;
            node2.next = node3;

            node3.prev = node2;
            node3.next = node4;

            node4.prev = node3;
            node4.next = node5;

            node5.prev = node4;
            node5.next = node6;

            node6.prev = node5;

            node6.child = node7;

            node7.next = node8;

            node8.prev = node7;
            node8.next = node9;

            node9.prev = node8;
            node9.next = node10;

            node10.prev = node9;

            node10.child = node11;
            node11.next = node12;
            node12.prev = node11;


            var sln = new Solution();
            sln.Flatten(node1);
        }
    }
}
