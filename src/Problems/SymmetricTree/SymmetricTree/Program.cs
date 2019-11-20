using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricTree
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

        public bool IsSymmetric(TreeNode currentLeftRoot, TreeNode currentRightRoot)
        {
            // both of them are null
            if (currentLeftRoot == null && currentRightRoot == null)
            {
                return true;
            }

            // only one of the is null 
            if (currentLeftRoot == null || currentRightRoot == null)
            {
                return false;
            }

            // values are not equal
            if (currentLeftRoot.val != currentRightRoot.val)
            {
                return false;
            }

            return IsSymmetric(currentLeftRoot.left, currentRightRoot.right) &&
                   IsSymmetric(currentLeftRoot.right, currentRightRoot.left);
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root.left == null && root.right == null)
            {
                return true;
            }
            if (root.left != null || root.right != null)
            {
                return false;
            }

            return IsSymmetric(root.left, root.right);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var treeNode = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(3)
                }
            };

            Console.WriteLine(solution.IsSymmetric(treeNode));
        }
    }
}
