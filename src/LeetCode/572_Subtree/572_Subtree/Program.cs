using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _572_Subtree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }

    public class Solution
    {
        private TreeNode FindTreeNode(TreeNode s, TreeNode t)
        {
            if (s == null)
            {
                return null;
            }

            var nodes = new Queue<TreeNode>();
            nodes.Enqueue(s);

            while (nodes.Count != 0)
            {
                var node = nodes.Dequeue();
                if (node == t)
                {
                    return node;
                }

                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                }
            }
            return null;
        }

        private bool IsSameSubTree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return s == null && t == null;
            }

            if (s.val != t.val)
            {
                return false;
            }

            return IsSameSubTree(s.left, t.left) && IsSameSubTree(s.right, t.right);
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            var subTreeRoot = FindTreeNode(s, t);
            if (subTreeRoot == null)
            {
                return false;
            }

            return IsSameSubTree(subTreeRoot, t);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new TreeNode(3)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(2)
                },
                right= new TreeNode(5)
            };
            var t = new TreeNode(4)
            {
                left = new TreeNode(1),
                right = new TreeNode(2)
            };

            var sln = new Solution();
            Console.WriteLine(sln.IsSubtree(s, t));
        }
    }
}
