using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _863_AllNodesDistanceK
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

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class Solution
    {

        private void NodesKDistance(TreeNode target, int K, List<int> ans)
        {
            if (target == null)
            {
                return;
            }
            if (K == 0)
            {
                ans.Add(target.val);
                return;
            }
            NodesKDistance(target.left, K - 1, ans);
            NodesKDistance(target.right, K - 1, ans);
        }

        private bool FindNode(TreeNode root, TreeNode target, int k, List<int> ans)
        {
            if (root == null)
            {
                return false;
            }
            if (root == target)
            {
                NodesKDistance(target, k, ans);
                return true;
            }
            bool ifleft = FindNode(root.left, target, k, ans);
            bool ifright = FindNode(root.right, target, k, ans);
            if (ifleft)
            {
                --k; // decrese the distance now as parent will be at 1 distance now from the target.
                if (k < 0)
                {
                    return true; //if the ancestor is more than k distance away from the parent
                }
                if (k == 0)
                {
                    ans.Add(root.val);
                    return true;
                }
                NodesKDistance(root.right, k - 1, ans); //search in right subtree for nodes at a distance k
                return true;
            }
            if (ifright)
            {
                --k;
                if (k < 0)
                {
                    return true; //if the ancestor is more than k distance away from the parent
                }
                if (k == 0)
                {
                    ans.Add(root.val);
                    return true;
                }
                NodesKDistance(root.left, k - 1, ans); //search in left subtree for nodes at a distance k
                return true;
            }
            return false;
        }

        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            List<int> ans = new List<int>();
            FindNode(root, target, K, ans);
            return ans;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //var tree = new TreeNode(3)
            //{
            //    left = new TreeNode(5)
            //    {
            //        left =  new TreeNode(6),
            //        right =  new TreeNode(2)
            //        {
            //            left = new TreeNode(7),
            //            right = new TreeNode(4)
            //        }
            //    },
            //    right = new TreeNode(1)
            //    {
            //        left = new TreeNode(0),
            //        right = new TreeNode(8)
            //    }
            //};

            //foreach (var res in (new Solution()).DistanceK(tree, tree.left, 2))
            //{
            //    Console.WriteLine(res);
            //}

            var tree = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(2)
                }
            };

            foreach (var res in (new Solution()).DistanceK(tree, tree.left.right, 1))
            {
                Console.WriteLine(res);
            }
        }
    }
}
