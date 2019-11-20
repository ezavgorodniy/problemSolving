using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiameterOfBinaryTree
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
        public int MaxLevel(TreeNode root, int level)
        {
            if (root == null)
            {
                return level;
            }

            return 1 + Math.Max(MaxLevel(root.left, level + 1), MaxLevel(root.right, level + 1));
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return MaxLevel(root.left, 0) + MaxLevel(root.right, 0);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root= new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };

            var sln = new Solution();
            Console.WriteLine(sln.DiameterOfBinaryTree(root));
        }
    }
}
