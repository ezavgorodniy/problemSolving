using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _437_PathSum
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
        public int PathSum(TreeNode root, int sum)
        {
            int result = 0; 
            DFS(root, new LinkedList<int>(), sum, ref result);
            return result;
        }

        private void DFS(TreeNode curNode, LinkedList<int> curSums, int target, ref int result)
        {
            if (curNode == null)
            {
                return;
            }

            if (curSums.Count == 0)
            {
                curSums.AddLast(curNode.val);
            }
            else
            {
                curSums.AddLast(curSums.Last.Value + curNode.val);
            }
            result += CheckListForSums(curSums, target);

            DFS(curNode.left, curSums, target, ref result);
            DFS(curNode.right, curSums, target, ref result);
            curSums.RemoveLast();
        }

        private int CheckListForSums(LinkedList<int> curSums, int target)
        {
            int result = 0;
            var lastValue = curSums.Last.Value;
            if (curSums.Last.Value == target)
            {
                result++;
            }
            var curLeftSum = curSums.First;
            while (curLeftSum != curSums.Last)
            {
                if (lastValue - curLeftSum.Value == target)
                {
                    result++;
                }
                curLeftSum = curLeftSum.Next;
            }
            return result;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(10)
            {
                left= new TreeNode(5)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(-2)
                    },
                    right = new TreeNode(2)
                    {
                        right = new TreeNode(1)
                    }
                },
                right = new TreeNode(-3)
                {
                    right = new TreeNode(11)
                }
            };

            var sln = new Solution();
            Console.WriteLine(sln.PathSum(root, 8));
        }
    }
}
