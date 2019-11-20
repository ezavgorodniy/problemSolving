using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222_CompleteTreeNodes
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
    public class Solution
    {
        private int GetHeight(TreeNode root, Func<TreeNode, TreeNode> movingStrategy)
        {
            var result = 0;
            while (root != null)
            {
                root = movingStrategy(root);
                result++;
            }

            return result;
        }

        private int GetLeftHeight(TreeNode root)
        {
            return GetHeight(root, node => node.left);
        }

        private int GetRightHeight(TreeNode root)
        {
            return GetHeight(root, node => node.right);
        }

        private void GetLeafsCount(TreeNode root, ref int result)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                result++;
            }

            GetLeafsCount(root.left, ref result);
            GetLeafsCount(root.right, ref result);
        }

        public int CountNodes(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftHeight = GetLeftHeight(root);
            var rightHeihgt = GetRightHeight(root);
            if (leftHeight == rightHeihgt)
            {
                return (1 << leftHeight) - 1;
            }
            else if (leftHeight < rightHeihgt)
            {
                var result = (1 << leftHeight) - 1;
                GetLeafsCount(root.right, ref result);
                return result;
            }
            else
            {
                var result = (1 << rightHeihgt) - 1;
                GetLeafsCount(root.left, ref result);
                return result;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(2),
                    right = new TreeNode(2)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(2),
                }
            };

            var sln = new Solution();
            Console.WriteLine(sln.CountNodes(tree));
        }
    }
}
