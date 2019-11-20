using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _116_NextRightPointer
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }
        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Solution
    {
        private void ConnectImpl(Node root, int level, List<Node> currentLeftest)
        {
            if (root == null)
            {
                return;
            }

            if (currentLeftest.Count <= level)
            {
                currentLeftest.Add(root);
                root.next = null;
            }
            else
            {
                root.next = currentLeftest[level];
                currentLeftest[level] = root;
            }

            ConnectImpl(root.right, level + 1, currentLeftest);
            ConnectImpl(root.left, level + 1, currentLeftest);
        }

        public Node Connect(Node root)
        {
            ConnectImpl(root, 0, new List<Node>());
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new Node(1)
            {
                left = new Node(2)
                {
                    left = new Node(4),
                    right =new Node(5)
                },
                right = new Node(3)
                {
                    left = new Node(6),
                    right = new Node(7)
                }
            };

            var sln = new Solution();
            sln.Connect(tree);
        }
    }
}
