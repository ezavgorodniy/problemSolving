using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124_BinaryTreeMaximumPathSum
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
    public class Solution
    {
        public int MaxPathSum(TreeNode root, int curSum)
        {
            if (root == null)
            {
                return Math.Max(curSum, 0);
            }

            int maxLeftSum = MaxPathSum(root.left, 0);
            if (curSum >= 0)
            {
                maxLeftSum += curSum;
            }

            int maxRightSum = MaxPathSum(root.right, 0);
            if (curSum >= 0)
            {
                maxRightSum += curSum;
            }

            int result = Math.Max(maxLeftSum, maxRightSum);
            return Math.Max(result, root.val + maxLeftSum + maxRightSum);
        }

        public void FindMaximumElement(TreeNode root, ref int max)
        {
            if (root == null)
            {
                return;
            }

            if (root.val > max)
            {
                max = root.val;
            }

            FindMaximumElement(root.left, ref max);
            FindMaximumElement(root.right, ref max);
        }




        public int MaxPathSum(TreeNode root)
        {
            int maxElement = int.MinValue;
            FindMaximumElement(root, ref maxElement);
            if (maxElement < 0)
            {
                return maxElement;
            }
            else
            {
                return MaxPathSum(root, 0);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeNode(1)
            {
                left = new TreeNode(-2)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(-1)
                    },
                    right = new TreeNode(3)
                },
                right = new TreeNode(-3)
                {
                    left = new TreeNode(-2)
                }
            };

            var sln = new Solution();
            Console.WriteLine(sln.MaxPathSum(tree));
        }
    }
}
