using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _449_SerializerTree
{
    /**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
    public class Codec
    {

        private const char NodesSplitter = ',';
        private const string LeafIndicator = "X";

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var sb = new StringBuilder();
            buildString(root, sb);
            return sb.ToString();
        }


        private void buildString(TreeNode node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append(LeafIndicator)
                    .Append(NodesSplitter);
            }
            else
            {
                sb.Append(node.val)
                    .Append(NodesSplitter);
                buildString(node.left, sb);
                buildString(node.right, sb);
            }
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            var nodes = new LinkedList<string>(data.Trim(NodesSplitter).Split(NodesSplitter));
            return buildTree(nodes);
        }

        private TreeNode buildTree(LinkedList<String> nodes)
        {
            var val = nodes.First();
            nodes.RemoveFirst();
            if (val == LeafIndicator)
            {
                return null;
            }

            return new TreeNode(int.Parse(val))
            {
                left = buildTree(nodes),
                right = buildTree(nodes)
            };
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));





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

    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            var codec = new Codec();
            var deserialize = codec.deserialize(codec.serialize(root));
        }
    }
}
