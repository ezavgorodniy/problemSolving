using System;

namespace MinDepth
{

    public class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftSubTreeDepth = 1 + MinDepth(root.left);
            var rightSubTreeDepth = 1 + MinDepth(root.right);

            return Math.Min(leftSubTreeDepth, rightSubTreeDepth);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(2)
                }
            };

            Console.WriteLine(new Solution().MinDepth(rootNode));
        }
    }
}
