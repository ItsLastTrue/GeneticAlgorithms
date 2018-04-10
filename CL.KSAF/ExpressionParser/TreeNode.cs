using System.Collections.Generic;
using System.Diagnostics;

namespace CL.KSAF.ExpressionParser
{
    [DebuggerDisplay("{" + nameof(ID) + "}:{" + nameof(Node) + "} is ({" + nameof(NodeType) + "})")]
    public class TreeNode
    {
        public int ID;
        public TreeNode ParentNode;
        public string Node;
        public double? Value;
        public MathType NodeType;
        public int Position;
        public List<TreeNode> Child;

        public bool IsHaveChild =>
            Child != null && Child.Count > 0;

        /// <summary>
        /// Замена узла с сохранением ссылок на него из других источников.
        /// </summary>
        /// <param name="fromNode"></param>
        public void ReplaceBy(TreeNode fromNode)
        {
            ID = fromNode.ID;
            ParentNode = fromNode.ParentNode;
            Node = fromNode.Node;
            Value = fromNode.Value;
            NodeType = fromNode.NodeType;
            Child = fromNode.Child;
            Position = fromNode.Position;
        }

        public int GetLastID(List<TreeNode> recurseTree = null)
        {
            var maxInx = 0;

            foreach (TreeNode c in Child)
            {
                if (c.ID > maxInx)
                    maxInx = c.ID;
                int childID = c.GetLastID(c.Child);
                if (childID > maxInx)
                    maxInx = childID;
            }
            return maxInx;
        }

        public TreeNode ToNewCopy() =>
            new TreeNode
            {
                ID = ID,
                Node = Node,
                Value = Value,
                NodeType = NodeType,
                Child = new List<TreeNode>(),
                Position = Position,
            };
    }
}