using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _112_PathSum
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

    public class Solution_112
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            if (root.left == null && root.right == null)
            {
                return sum == root.val;
            }

            return HasPathSum(root.left, sum - root.val) ||
                   HasPathSum(root.right, sum - root.val);
        }
    }

    public class Solution
    {
        private void PathSumImpl(TreeNode root, int curSum, LinkedList<int> curPath, IList<IList<int>> results)
        {
            if (root == null)
            {
                return;
            }

            curPath.AddLast(root.val);
            if (root.left == null && root.right == null)
            {
                if (curSum == root.val)
                {
                    results.Add(curPath.ToList());
                }
            }
            else
            {
                PathSumImpl(root.left, curSum - root.val, curPath, results);
                PathSumImpl(root.right, curSum - root.val, curPath, results);
            }
            curPath.RemoveLast();
        }


        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root != null)
            {
                LinkedList<int> curPath = new LinkedList<int>();
                PathSumImpl(root, sum, curPath, result);
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sln = new Solution();

            var root = new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };

            Console.WriteLine(sln.PathSum(root, 22));
        }
    }
}
