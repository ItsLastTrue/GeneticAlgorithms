using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using WFA.KSAF.Extensions;

namespace WFA.KSAF.ExpressionParser
{
    public class TreeParser
    {
        public string Expression;
        public List<TreeNode> MathTree;
        public Dictionary<string, double> Constants;
        private List<TreeNode> _toEstimateTree;

        public TreeParser(string expression, IReadOnlyList<double> constants = null)
        {
            Expression = expression;

            if (constants != null)
                Constants = constants.Select((dbl, i) => new { Key = $"Leaf[{i}]", dbl }).ToDictionary(e => e.Key, e => e.dbl);
        }

        public int TreeCapasity(List<TreeNode> tree, int startIndex = 0)
        {
            startIndex += tree.Count;
            tree.ForEach(e => startIndex += TreeCapasity(e.Child, startIndex));
            return startIndex;
        }
        #region Парсинг                                 ********************************************************************************************************************************
        private bool _isMoreThatOneArgFunc;
        private TreeNode _parentNode;

        /// <summary>
        /// Преобразует текстовую строку в синтаксическое древо.
        /// </summary>
        public void Parse()
        {
            var toParse = Preparation(Expression);
            _mainIDCounter = 0;
            _parentNode = HomeNode;
            MathTree = new List<TreeNode> { _parentNode };
            RecurceParse(toParse);
        }

        public void RecurceParse(string recurceExpression)
        {
            //Первым делом ищем оператиры низкого приоритета '+','-' помеченные символом '|'.
            var toSearch = '|';

            if (_isMoreThatOneArgFunc)
            {
                _isMoreThatOneArgFunc = false;
                toSearch = ' ';// ищем разделитель для запятой " ," (в условии - чтобы не замедлять поиск ситуативным циклом поиска многопараметр функции)
            }
            RESTART:
            var cutExpr = string.Empty;
            var bktOpen = 0; //открытая скобка

            for (int i = recurceExpression.Length - 1; i >= 0; i--)
            {
                char curr = recurceExpression[i];

                if (curr.CompareTo(')') == 0) bktOpen += 1;
                if (curr.CompareTo('(') == 0 && bktOpen > 0) bktOpen -= 1;

                cutExpr = curr + cutExpr; //пишем

                if ((curr.CompareTo(toSearch) == 0 && bktOpen == 0) || (i == 0 && bktOpen == 0 && toSearch == '~'))
                {
                    var cutLenght = cutExpr.Length;
                    BuildTree(ref cutExpr);
                    TreeNode saveParNode = _parentNode;
                    if (!string.IsNullOrEmpty(cutExpr))
                    {
                        if (IsSimple(cutExpr))
                        {
                            BuildTree(ref cutExpr);
                            recurceExpression = recurceExpression.Remove(i, cutLenght);
                            goto RESTART;
                        }
                        else
                        {
                            RecurceParse(cutExpr);
                            recurceExpression = recurceExpression.Remove(i, cutLenght);
                            _parentNode = saveParNode;
                            goto RESTART;
                        }
                    }
                }
                if (i == 0 && toSearch == ' ') // в случае когда нет оператора в конце, выход из режима многопарам. функции
                {
                    toSearch = '|';
                    goto RESTART;
                }
                if (i == 0 && toSearch == '|') // в случае когда нет оператора в конце
                {
                    toSearch = '~';
                    goto RESTART;
                }
            }
            _nullNodeIndexSave = _mainIDCounter - 1;
        }

        private void BuildTree(ref string word)
        {
            MathType wordType = MathTypeHlp.GetNodeType(word);

            switch (wordType)
            {
                case MathType.Constant:
                    AddNode(wordType, word, ReadConst(word));
                    word = string.Empty;
                    break;

                case MathType.Argument:
                    AddNode(wordType, word);
                    word = string.Empty;
                    break;

                case MathType.EasyFunction:
                case MathType.MultiFunction:
                    if (wordType is MathType.MultiFunction)
                        _isMoreThatOneArgFunc = true;

                    _parentNode = AddNode(wordType, word.Substring(0, 3));
                    word = word.Remove(0, 4);
                    word = word.Remove(word.Length - 1, 1);
                    break;

                case MathType.HightPrtOperator:
                case MathType.LowPrtOperator:
                case MathType.Comma:
                    _parentNode = AddNode(wordType, word[1].ToString());
                    word = word.Remove(0, 2);
                    break;

                case MathType.Home:
                    throw new ArgumentOutOfRangeException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private double ReadConst(string word)
        {
            if (Constants == null)
                return word.ToDbl();

            if (Constants.TryGetValue(word, out var d))
                return d;

            return word.ToDbl();
        }
        private static bool IsSimple(string s) =>
            new[] { '~', '|', ',', '(', ')' }.Any(s.Contains) == false;

        private TreeNode AddNode(MathType wordType, string word = null, double? value = null)
        {
            var target = _parentNode;
            var position = 0;
            if (target.IsHaveChild)
                position = 1;
            var n = new TreeNode
            {
                ID = _mainIDCounter++,
                Node = word,
                Value = value,
                NodeType = wordType,
                Position = position,
                Child = new List<TreeNode>(),
                ParentNode = _parentNode
            };
            target.Child.Add(n);
            return n;
        }
        #endregion
        #region Подготовка                              ********************************************************************************************************************************        
        private int _mainIDCounter;
        private int _nullNodeIndexSave;

        private static string Preparation(string s)
        {
            s = s.Replace(",n]", "sml");

            s = new[] { '+', '-' }.Aggregate(s, (current, o) => current.Replace(o.ToString(), "|" + o));

            //, "Pow", "Log", "Sin", "Cos", "Tan", "Exp"
            s = new[] { "*", "/" }.Aggregate(s, (current, o) => current.Replace(o, '~' + o));

            s = new[] { ',' }.Aggregate(s, (current, o) => current.Replace(o.ToString(), " " + o));

            s = s.Replace("*|-", "*-").Replace("/|-", "/-").Replace("(|-", "(-").Replace(",|-", ",-").Replace("E|+", "E+").Replace("E|-", "E-");
            return s;
        }

        private static TreeNode HomeNode =>
            new TreeNode
            {
                ID = -1,
                Node = "END",
                NodeType = MathType.Home,
                Child = new List<TreeNode>(),
            };
        #endregion
        #region Вывод                                   ********************************************************************************************************************************
        private string _joinedTree;

        private string _reparsedTree;

        public string JoinTreeAsString()
        {
            _joinedTree = string.Empty;
            JoinTreeAsStringRecurce(MathTree);
            return _joinedTree;
        }

        private void JoinTreeAsStringRecurce(IEnumerable<TreeNode> recurseTree)
        {
            foreach (TreeNode s in recurseTree)
            {
                _joinedTree += s.Node;
                if (s.Child.Count >= 0)
                    JoinTreeAsStringRecurce(s.Child);
            }
        }

        public string ReparseTree()
        {
            List<TreeNode> treeToParse = MathTree[0].Child;
            _reparsedTree = "R-1]";
            return RecurseReParse(treeToParse).Replace("--", "+").Replace("sml", ",n]");
        }

        private string RecurseReParse(IReadOnlyList<TreeNode> recurseTree)
        {
            for (var i = 0; i < recurseTree.Count; i++)
            {
                TreeNode thisNode = recurseTree[i];
                switch (recurseTree[i].Child.Count)
                {
                    case 0:
                        switch (i)
                        {
                            case 0:
                                _reparsedTree = _reparsedTree.Replace("R" + thisNode.ParentNode.ID + "]", thisNode.Node);
                                break;
                            case 1:
                                _reparsedTree = _reparsedTree.Replace("L" + thisNode.ParentNode.ID + "]", thisNode.Node);
                                break;
                        }
                        break;
                    case 1:
                        switch (i)
                        {
                            case 0:
                                _reparsedTree = _reparsedTree.Replace("R" + thisNode.ParentNode.ID + "]", thisNode.Node + "(R" + thisNode.ID + "])");
                                break;
                            case 1:
                                _reparsedTree = _reparsedTree.Replace("L" + thisNode.ParentNode.ID + "]", thisNode.Node + "(R" + thisNode.ID + "])");
                                break;
                        }
                        break;
                    case 2:
                        switch (i)
                        {
                            case 0:
                                _reparsedTree = _reparsedTree.Replace("R" + thisNode.ParentNode.ID + "]", "L" + thisNode.ID + "]" + thisNode.Node + "R" + thisNode.ID + "]");
                                break;
                            case 1:
                                _reparsedTree = _reparsedTree.Replace("L" + thisNode.ParentNode.ID + "]", "L" + thisNode.ID + "]" + thisNode.Node + "R" + thisNode.ID + "]");
                                break;
                        }
                        break;
                }
            }

            foreach (TreeNode t in recurseTree)
                if (t.IsHaveChild)
                    RecurseReParse(t.Child);

            return _reparsedTree;
        }
        #endregion
        #region Кодирование констант                    ********************************************************************************************************************************
        private IntCounter _leafCounter;
        private Dictionary<int, string> _dicOfLeafs;

        public double[] ChangeConstantsToLeaf()
        {
            _leafCounter = (-1).ToIntCounter();
            _dicOfLeafs = new Dictionary<int, string>();
            RecurceChangeToLeaf(MathTree[0].Child);
            var outCons = _dicOfLeafs.Select(dbl => dbl.Value.ToDbl()).ToArray();
            return outCons;
        }

        private void RecurceChangeToLeaf(IEnumerable<TreeNode> treeToFind)
        {
            //конвертим все константы в Leaf[x]
            foreach (var node in treeToFind)
            {
                if (node.NodeType is MathType.Constant && node.ID != _nullNodeIndexSave && !node.Node.Contains("Leaf"))
                    if (_dicOfLeafs.ContainsValue(node.Node))
                        node.Node = "Leaf[" + _dicOfLeafs.FirstOrDefault(x => x.Value == node.Node).Key + "]";
                    else
                    {
                        _dicOfLeafs.Add(_leafCounter.Inc(), node.Node);
                        node.Node = "Leaf[" + _leafCounter.ToInt() + "]";
                    }
                if (node.IsHaveChild)
                    RecurceChangeToLeaf(node.Child);
            }
        }

        //private void SetConstants(IReadOnlyList<double> constants, List<TreeNode> treeNodes = null)
        //{
        //    if (treeNodes == null)
        //        treeNodes = MathTree;
        //
        //    foreach (TreeNode node in treeNodes)
        //    {
        //        if (node.NodeType is MathType.Constant)
        //        {
        //            int indx = Convert.ToInt32(Regex.Match(node.Node, "[0-9]+").Value);
        //            node.Value = constants.ElementAt(indx);
        //        }
        //        SetConstants(constants, node.Child);
        //    }
        //}
        #endregion
        #region Упрощение                               ********************************************************************************************************************************

        private int _simplRestarts;
        private List<int> _childsCount = new List<int>();
        /// <summary>
        /// Упрощает древовидную структура вычисляя узлы содержащие только константы.
        /// </summary>
        /// <returns>
        /// True если упрощение произошло (необходимо повторить обход древа).
        /// </returns>
        public void Simplification()
        {
            List<TreeNode> treeToInd = _toEstimateTree?[0].Child ?? MathTree[0].Child;

            while (SimplificationRecurse(treeToInd))
            {
                _simplRestarts++;
                //SimplificationRecurse(treeToInd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recurseTree"></param>
        /// <returns>
        /// True если упрощение произошло (требуется перезапуск упрощения с верхнего узла).
        /// </returns>
        private bool SimplificationRecurse(IReadOnlyList<TreeNode> recurseTree)
        {
            int nodesCount = recurseTree.Count;

            //достигли дна
            if (nodesCount == 0)
                return false;

            var changer = new NodeChanger(firstNode: recurseTree[0]);

            ////не трогаем последний узел "0-"
            //if (firstNode.ID == _nullNodeIndexSave)
            //    return false;

            //Узел является константой
            switch (nodesCount)
            {
                case 1:
                    if (IsConst(changer.FirstNode) == false)
                        return SimplificationRecurse(changer.FirstNode.Child);

                    changer.CalculatedNode = GetCalculatedNode(changer.FirstNodeParent, changer.FirstNode);

                    //В этом случае мы просто стираем нижний узел oldParentNode на тот что мы получили.
                    changer.SwapRefs(changer.CalculatedNode, changer.FirstNodeParent);
                    return true;

                case 2:
                    if (IsConst(changer.FirstNode) == false)
                        return SimplificationRecurse(changer.FirstNode.Child) || SimplificationRecurse(changer.SecondNode.Child);

                    //changer.SecondNode = recurseTree[1];

                    //не трогаем последний узел "0-"
                    if (changer.SecondNode.ID == _nullNodeIndexSave)
                        return false;

                    //значит второй тоже константа - вычисляем их по операции Parent
                    if (IsConst(changer.SecondNode))
                    {
                        changer.CalculatedNode = GetCalculatedNode(changer.FirstNodeParent, changer.FirstNode, changer.SecondNode);

                        if (changer.FirstNodeParent.NodeType is MathType.Comma)
                        {
                            changer.SwapRefs(changer.CalculatedNode, changer.FirstNodeGrandParent);

                            //changer.CalculatedNode.Position = changer.FirstNodeGrandParent.Position;
                            //changer.CalculatedNode.ParentNode = changer.FirstNodeGrandParent.ParentNode;
                            //changer.FirstNodeGrandParent.ReplaceBy(changer.CalculatedNode);
                            ////oldGrandParentNode.ParentNode.Child[firstNode.ParentNode.ParentNode.Position].ReplaceBy(newNode);
                            //oldGrandParentNode.ParentNode.Child[oldGrandParentNode.Position] = calc;
                        }
                        else
                        {
                            changer.SwapRefs(changer.CalculatedNode, changer.FirstNodeParent);
                            //changer.CalculatedNode.Position = changer.FirstNodeParent.Position;
                            //changer.CalculatedNode.ParentNode = changer.FirstNodeParent.ParentNode;
                            //changer.FirstNodeParent.ReplaceBy(changer.CalculatedNode);
                            //oldParentNode = calc;
                            //oldParentNode.ParentNode.Child[firstNode.ParentNode.Position].ReplaceBy(calc);
                        }
                        return true;
                    }
                    //значит второй узел это оператор спускаемся ниже и ищем константу
                    else if (changer.SecondNode.IsHaveChild)
                    {
                        //ну приехали блин, дальше операторы другого типа - не можем упрощать.
                        if (changer.SecondNode.NodeType != changer.FirstNodeParent.NodeType)
                            return SimplificationRecurse(changer.SecondNode.Child);

                        changer.FindedConst = GetConstantNode(changer.SecondNode.Child, changer.FirstNodeParent.NodeType);

                        //ну приехали блин, кругом одни аргументы, ни единой константочки - упрощать нечего.
                        if (changer.FindedConst == null)
                            return SimplificationRecurse(changer.SecondNode.Child);

                        changer.CalculatedNode = GetCalculatedNode(changer.FirstNodeParent, changer.FirstNode, changer.FindedConst); //вычисляем новый узел

                        //Заменяем найденную где-то вглубине древа узел константу findedConst на ту что мы 
                        //получили по рещультатам сокращения.
                        changer.SwapRefs(changer.CalculatedNode, changer.FindedConst);
                        //changer.CalculatedNode.ParentNode = changer.FindedConstParent;
                        //changer.CalculatedNode.Position = changer.FindedConst.Position;
                        //changer.FindedConst.ReplaceBy(changer.CalculatedNode);

                        //Поднимаем древо удаляя два использованых узла: firstNode as аргумент и oldParentNode as мат операция. 
                        //Они включаются в константу (где-то в глубине древа) и эта линия исчезает как в тетрисе, поднимая secondNode на одну ступень вверх.
                        //Позиция secondNode приравнивается к позиции вырезанного oldParentNode
                        changer.SwapRefs(changer.FirstNodeParent, changer.SecondNode);
                        //changer.SecondNode.ParentNode = changer.FirstNodeParent.ParentNode;
                        //changer.SecondNode.Position = changer.FirstNodeParent.Position;
                        //changer.FirstNodeParent.ReplaceBy(changer.SecondNode);

                        //swap.FirstNodeGrandParent.Child[swap.FirstNodeParent.Position] = secondNode;
                        //oldGrandParentNode.Child[oldParentNode.Position].ReplaceBy(secondNode); //вырезаем узел над нами
                        //newParentNode.Child[findedConst.Position].ReplaceBy(newNode); //подменяем узел у родителя найденного узла
                        return true;
                    }
                    else
                    {
                        //ну приехали блин - узел это грязный аргумент, да и к тому же без значения, ну как его упростишь?
                        return false;
                    }

                default:
                    throw new Exception("Error 14331910. Структура синтаксического древа не предусматривает наличие трех и более узлов.");
            }
        }

        public TreeNode GetConstantNode(List<TreeNode> treeToFind, MathType sameTypeToFind)
        {
            foreach (TreeNode node in treeToFind)
                if (IsConst(node) && node.ID != _nullNodeIndexSave)
                    return node;

            //чтобы приоритет был у верхних листьев
            foreach (TreeNode node in treeToFind)
                if (node.IsHaveChild && node.NodeType == sameTypeToFind)
                    return GetConstantNode(node.Child, sameTypeToFind);

            return null;
        }

        [DebuggerNonUserCode]
        private bool IsConst(TreeNode node) =>
            node.NodeType is MathType.Constant || _toEstimateTree != null && node.NodeType is MathType.Argument;

        private TreeNode GetCalculatedNode(TreeNode operation, TreeNode firstArgument, TreeNode extraArgument = null)
        {
            MathType nodeType = operation.NodeType;
            if (nodeType is MathType.Comma)
                return GetCalculatedNode(operation.ParentNode, firstArgument, extraArgument);

            string oper = operation.Node;
            if (extraArgument != null)
                oper = SwapOperExeption(operation, extraArgument);

            double firstArg = firstArgument?.Value ?? throw new Exception("Error 11401910. Значение для узла не установлено");
            double val = GetCalculatedValue(oper, firstArg, extraArgument?.Value ?? 0.0);
            var newNode = new TreeNode
            {
                ID = _mainIDCounter++,
                Node = val.ToString(CultureInfo.InvariantCulture),
                Value = val,
                NodeType = MathType.Constant,
                Child = new List<TreeNode>(),
                Position = -1,
                ParentNode = null,
            };
            return newNode;
        }

        private static string SwapOperExeption(TreeNode operNode, TreeNode secondArgumentNode)
        {
            if (secondArgumentNode.Position == 1)
                return operNode.Node;

            TreeNode operSecondNode = secondArgumentNode.ParentNode;
            switch (operNode.NodeType)
            {
                case MathType.HightPrtOperator:
                    switch (operSecondNode.Node)
                    {
                        case "/":
                            return operNode.Node == "/" ? "*" : "/";

                        case "*":
                            break;

                        default:
                            throw new Exception("Error 13341910. Оператор не был добавлен в метод обработки мат исключений.");
                    }
                    break;

                case MathType.LowPrtOperator:
                    switch (operSecondNode.Node)
                    {
                        case "-":
                            return operNode.Node == "+" ? "-" : "+";

                        case "+":
                            break;

                        default:
                            throw new Exception("Error 13351910. Оператор не был добавлен в метод обработки мат исключений.");
                    }
                    break;
            }

            return operNode.Node;
        }

        private static double GetCalculatedValue(string oper, double firstArgument, double extraArgument)
        {
            switch (oper[0])
            {
                case '+':
                    return extraArgument + firstArgument;
                case '-':
                    return extraArgument - firstArgument;
                case '/':
                    return extraArgument / firstArgument;
                case '*':
                    return extraArgument * firstArgument;
            }
            switch (oper.Substring(0, 3))
            {
                case "Sin":
                    return Math.Sin(firstArgument);
                case "Cos":
                    return Math.Cos(firstArgument);
                case "Tan":
                    return Math.Tan(firstArgument);
                case "Exp":
                    return Math.Exp(firstArgument);
                case "Pow":
                    return Math.Pow(extraArgument, firstArgument);
                case "Log":
                    return Math.Log(extraArgument, firstArgument);
            }
            throw new Exception($"Error 10201810. Не удалось определить мат оператор '{oper}'.");
        }
        #endregion
        #region Вычисление                              ********************************************************************************************************************************
        public double Estimate(IReadOnlyList<IReadOnlyList<double>> argumentList, IReadOnlyList<double> constants)
        {
            //SetConstants(constants);
            Simplification();
            var deviate = 0.0;
            foreach (IReadOnlyList<double> arguments in argumentList)
            {
                RecurseCopy(arguments);
                Simplification();
                if (_toEstimateTree[0].Child[0].Value == null)
                    throw new Exception("Error 13291910. Не удалось вычислить значение.");

                deviate += Math.Abs(arguments.Last() - (double)_toEstimateTree[0].Child[0].Value);
            }
            _toEstimateTree = null;
            return deviate;
        }

        private void RecurseCopy(IReadOnlyList<double> arguments, TreeNode mainTreeNode = null, TreeNode parentDestinationNode = null)
        {
            TreeNode newNode;
            if (parentDestinationNode == null || mainTreeNode == null)
            {
                mainTreeNode = MathTree[0];

                newNode = mainTreeNode.ToNewCopy();
                _toEstimateTree = new List<TreeNode> { newNode };
            }
            else
            {
                newNode = mainTreeNode.ToNewCopy();
                parentDestinationNode.Child.Add(newNode);
                newNode.ParentNode = parentDestinationNode;
            }

            if (newNode.NodeType is MathType.Argument)
            {
                int indx = Convert.ToInt32(Regex.Match(newNode.Node, "[0-9]+").Value);
                newNode.Value = arguments.ElementAt(indx);
            }

            mainTreeNode.Child.ForEach(e => RecurseCopy(arguments, e, newNode));
        }

        //private void CopyTree(IReadOnlyList<double> arguments, List<TreeNode> treeNodes = null)
        //{
        //    if (treeNodes == null)
        //    {
        //        _toEstimateTree = new List<TreeNode> { MathTree[0].ToNewCopy() };
        //        RecurseCopy()
        //    }
        //        treeNodes = _toEstimateTree = new List<TreeNode>();

        //    foreach (TreeNode node in treeNodes)
        //    {
        //        if (node.NodeType is MathType.Argument)
        //        {
        //            int indx = Convert.ToInt32(Regex.Match(node.Node, "[0-9]+").Value);
        //            node.Node = node.Node.Replace("", arguments.ElementAt(indx).ToString(CultureInfo.InvariantCulture));
        //        }
        //        ReplaceArguments(node.Child, arguments);
        //    }
        //}

        //private void ReplaceArguments(List<TreeNode> treeNodes, IReadOnlyList<double> arguments)
        //{
        //    foreach (TreeNode node in treeNodes)
        //    {
        //        if (node.NodeType is MathType.Argument)
        //        {
        //            int indx = Convert.ToInt32(Regex.Match(node.Node, "[0-9]+").Value);
        //            node.Node = node.Node.Replace("", arguments.ElementAt(indx).ToString(CultureInfo.InvariantCulture));
        //        }
        //        ReplaceArguments(node.Child, arguments);
        //    }
        //}
        #endregion
    }
}