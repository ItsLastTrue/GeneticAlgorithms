using System.Diagnostics;

namespace CL.KSAF.ExpressionParser
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

        private TreeNode _secondNode;
        /// <summary>
        /// Второй узел если на данном уровне их несколько.
        /// </summary>
        public TreeNode SecondNode => _secondNode ?? (_secondNode = FirstNodeParent.Child[1]);

        private TreeNode _firstNodeParent;
        /// <summary>
        /// Узел который будет уничтожен по результатам сокращения (родитель firsNode).
        /// </summary>
        public TreeNode FirstNodeParent => _firstNodeParent ?? (_firstNodeParent = FirstNode.ParentNode);


        private TreeNode _firstNodeGrandParent;
        /// <summary>
        /// Узел который должен получить нового ребенка взамен того что будет сокращен.
        /// </summary>
        public TreeNode FirstNodeGrandParent => _firstNodeGrandParent ?? (_firstNodeGrandParent = FirstNodeParent.ParentNode);
        
        /// <summary>
        /// Результат сокращения узлов.
        /// </summary>
        public TreeNode CalculatedNode;

        /// <summary>
        /// Найденная в глубине древа констаната (если второй узел это оператор).
        /// </summary>
        public TreeNode FindedConst;

        private TreeNode _findedConstParent;
        /// <summary>
        /// Новый родитель у которого будет заменена константа на вновь вычисленную
        /// </summary>
        public TreeNode FindedConstParent => _findedConstParent ?? (_findedConstParent = FindedConst.ParentNode);

        public void SwapRefs(TreeNode source, TreeNode desination)
        {
            //Считываем позицию узла который будем подменять.
            source.Position = desination.Position;
            //Считываем родителя нода, который будем заменять.
            source.ParentNode = desination.ParentNode;

            //Заменяем у родителя старого ребенка на нового.
            desination.ParentNode.Child[desination.Position] = source;
            //[через раз работает хуетя]Подменяем узел новым узлом (ссылки из вне на данный старый узел 
            //сохраняются, но значения в нем из нового узла).
            //desination.ReplaceBy(source);
        }
    }
}
