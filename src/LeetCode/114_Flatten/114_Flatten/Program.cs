using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _114_Flatten
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

        private void FlattenImpl(TreeNode node, TreeNode prev)
        {
            if (node == null)
            {
                return;
            }

            if (node.left == null && node.right == null && prev?.left != null)
            {
                prev.left = null;
                node.right = prev.right;
                prev.right = node;
                return;
            }

            FlattenImpl(node.left, node);
            FlattenImpl(node.right, node);
        }

        public void Flatten(TreeNode root)
        {
            FlattenImpl(root, null);
            if (root.left != null)
            {
                var prevRight = root.right;
                root.right = root.left;
                root.left = null;

                var curNode = root.right;
                while (curNode.right != null)
                {
                    curNode = curNode.right;
                }
                curNode.right = prevRight;

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var rootTreeSample = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right =  new TreeNode(4)
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(6)
                }
            };
            var root = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(5)
                    },
                    right = new TreeNode(4)
                }
            };

            var sln = new Solution();
            sln.Flatten(root);
        }
    }
}
