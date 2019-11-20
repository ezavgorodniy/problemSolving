using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelOrderTraversal
{
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
    public class Solution
    {
        private void FillLevels(IList<IList<int>> list, TreeNode currentNode, int currentLevel)
        {
            if (currentNode == null)
            {
                return;
            }

            while (currentLevel >= list.Count)
            {
                list.Add(new List<int>());
            }

            var newLevel = currentLevel + 1;
            FillLevels(list, currentNode.left, newLevel);
            FillLevels(list, currentNode.right, newLevel);

            list[currentLevel].Add(currentNode.val);

        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var result = new List<IList<int>>();
            FillLevels(result, root, 0);
            result.Reverse();
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
            var result = new Solution().LevelOrderBottom(root);
            foreach (var level in result)
            {
                Console.Write("[");
                foreach (var node in level)
                {
                    Console.Write($"{node}, ");

                }
                Console.WriteLine("]");
            }
        }
    }
}
