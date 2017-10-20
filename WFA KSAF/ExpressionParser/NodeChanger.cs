using System.Diagnostics;

namespace WFA.KSAF.ExpressionParser
{
    internal class NodeChanger
    {
        [DebuggerNonUserCode]
        internal NodeChanger(TreeNode firstNode)
        {
            FirstNode = firstNode;
        }

        /// <summary>
        /// Первый встреченный узел, если уровень не пуст.
        /// </summary>
        public readonly TreeNode FirstNode;

        /// <summary>
        /// Второй узлов если на данном уровне их несколько.
        /// </summary>
        public TreeNode SecondNode => FirstNodeParent.Child[1];

        /// <summary>
        /// Узел который будет уничтожен по результатам сокращения (родитель firsNode).
        /// </summary>
        public TreeNode FirstNodeParent => FirstNode.ParentNode;

        /// <summary>
        /// Узел который должен получить нового ребенка взамен того что будет сокращен.
        /// </summary>
        public TreeNode FirstNodeGrandParent => FirstNodeParent.ParentNode;
        
        /// <summary>
        /// Результат сокращения узлов.
        /// </summary>
        public TreeNode CalculatedNode;

        /// <summary>
        /// Найденная в глубине древа констаната (если второй узел это оператор).
        /// </summary>
        public TreeNode FindedConst;

        /// <summary>
        /// Новый родитель у которого будет заменена константа на вновь вычисленную
        /// </summary>
        public TreeNode FindedConstParent => FindedConst.ParentNode;

        public void SwapRefs(TreeNode source, TreeNode desination)
        {
            source.Position = desination.Position;
            source.ParentNode = desination.ParentNode;
            desination.ReplaceBy(source);
        }
    }
}
