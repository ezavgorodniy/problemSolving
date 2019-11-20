using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _103_ZigZag
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

        private void ZigzagLevelOrderImpl(TreeNode curNode, int curLevel, IList<IList<int>> result)
        {
            if (curNode == null)
            {
                return;
            }

            if (result.Count <= curLevel)
            {
                result[curLevel] = new List<int>();
                result[curLevel].Add(curNode.val);
            }
            else
            {
                if (curLevel % 2 == 0)
                {
                    result[curLevel].Insert(0, curNode.val);
                }
                else
                {
                    result[curLevel].Add(curNode.val);
                }
            }

            ZigzagLevelOrderImpl(curNode.left, curLevel + 1, result);
            ZigzagLevelOrderImpl(curNode.right, curLevel + 1, result);
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var result = new List<IList<int>>();
            ZigzagLevelOrderImpl(root, 0, result);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            var sln = new Solution();
            var result = sln.ZigzagLevelOrder(root);
            foreach (var row in result)
            {
                foreach (var cell in row)
                {
                    Console.Write("{0} ", cell);
                }
                Console.WriteLine();
            }
        }
    }
}
