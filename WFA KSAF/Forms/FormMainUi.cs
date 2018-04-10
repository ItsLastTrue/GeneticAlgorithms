using CL.Extensions;
using CL.KSAF.Creators;
using CL.KSAF.Entities;
using CL.KSAF.Helpers;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA.KSAF.Delegates;
using WFA.KSAF.DrawningGraphs;
using WFA.KSAF.Generated;
using WFA.KSAF.Helpers;
using WFA.KSAF.SelectionLifeCycles;
using ZedGraph;
using ConvertExt = CL.KSAF.Extensions.ConvertExt;

namespace WFA.KSAF.Forms
{
    public partial class FormMainUi : Form
    {
        private readonly ZedGraphPainting _zedGraphPainting;

        //public void TimerJob()
        //{
        //    _formAlgorithmCode.richTextBoxClassCode.Text = PopulationCreator.Code; //FormateCodeText();

        //    if (Iteration > 30)
        //        zedGraphIterations.GraphPane.Legend.IsVisible = false;
        //}

        /// <summary>
        /// Если первый ряд исходных данных не относится к функции а представляет сортировку (Exp.: глубина каротажа).
        /// </summary>
        public List<double> DeptPoints { get; } = new List<double>();

        /// <summary>
        /// Супер класс для проведения селекции.
        /// </summary>
        public SelectionManager SelectionManager { get; private set; }

        #region Общие функции и форма                           ***********************************************************************************************************************************************
        public List<string> IncomingParameters = new List<string>();

        public readonly FormDialog FormDialog;
        private readonly FormOpenFile _formOpenFile;
        private readonly FormConvolution _formConvolution;
        private readonly FormErrors _formErrors;
        private readonly FormDesigner _formDesigner = new FormDesigner();
        private readonly FormAlgorithmCode _formAlgorithmCode;
        private readonly FormPhonotypeCollections _formPhonotypeCollections = new FormPhonotypeCollections();

        public FormMainUi()
        {
            InitializeComponent();

            _formOpenFile = new FormOpenFile(this);
            _formConvolution = new FormConvolution(this);
            _formAlgorithmCode = new FormAlgorithmCode(this);
            _formErrors = new FormErrors(this);
            FormDialog = new FormDialog(this);

            _zedGraphPainting = new ZedGraphPainting(ZedGraphResult, richTextBoxIncoming)
            {
                IsDeptActive = checkBoxHaveDept.Checked,
            };
        }

        private void FormMainUi_Load(object sender, EventArgs e)
        {
            ZedGraphResult.GraphPane.Title.IsVisible = false;
            zedGraphIterations.GraphPane.Title.IsVisible = false;
        }

        /// <summary>
        /// Позволяет работать с формой из других потоков.
        /// </summary>
        /// <param name="a"></param>
        public void DoActionThreadSafe(Action a)
        {
            if (InvokeRequired)
            {
                SafeActionDelegate d = DoActionThreadSafe;
                Invoke(d, a);
                return;
            }

            Invoke(a);
        }

        private static void DelLine(TextBoxBase rtb, int index) =>
            rtb.Text = rtb.Text.Remove(rtb.GetFirstCharIndexFromLine(index) - 1, rtb.Lines[index].Length + 1);

        private void checkBoxHaveDept_CheckedChanged(object sender, EventArgs e) =>
            _zedGraphPainting.IsDeptActive = checkBoxHaveDept.Checked;
        #endregion
        #region Графы и рисование                               ***********************************************************************************************************************************************
        private bool ZedGraphResult_MouseMoveEvent(ZedGraphControl sender, MouseEventArgs e) =>
            default(bool);

        private bool ZedGraphResult_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e) =>
            _zedGraphPainting.MouseDownEvent(e);

        private void ZedGraphResult_MouseMove(object sender, MouseEventArgs e) =>
            _zedGraphPainting.MouseMove(e);

        private bool ZedGraphResult_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e) =>
            _zedGraphPainting.MouseUpEvent();

        private void radioButton2_CheckedChanged(object sender, EventArgs e) =>
            _zedGraphPainting.DrawtingMode = radioButton2.Checked;

        private void radioButton1_CheckedChanged(object sender, EventArgs e) =>
            _zedGraphPainting.DrawtingMode = radioButton2.Checked;
        #endregion
        #region Прогрузка данных                                ***********************************************************************************************************************************************
        private Arguments PointsReader()
        {
            //Равен 0 если первый столбец в исх точках уже содержит данные ИЛИ равен 1 если первый столбец - глубина и мы его используем только для рисования.
            var deptIncrement = checkBoxHaveDept.Checked ? 1 : 0;
            ClearNullStr(richTextBoxIncoming);
            var argumentsRows = richTextBoxIncoming.Lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length - 1 - deptIncrement;
            var argumentsCount = richTextBoxIncoming.Lines.Length;

            var args = new List<List<double>>();

            foreach (string line in richTextBoxIncoming.Lines)
            {
                var split = line.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToList();
                var dbls = split.Skip(deptIncrement).Select(ConvertExt.ToDbl).ToList();
                args.Add(dbls);

                if (checkBoxHaveDept.Checked)
                    DeptPoints.Add(split.First().ToDbl());
            }

            return new Arguments(argumentsRows, argumentsCount, args);
        }
        #endregion
        #region Генератор функций                               ***********************************************************************************************************************************************
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            richTextBoxIncoming.Text = "";
            var list = new PointPairList();

            double start = ConvertExt.ToDbl(textBox2.Text);
            double finish = ConvertExt.ToDbl(textBox3.Text);
            double step = ConvertExt.ToDbl(textBox4.Text);
            double[,] temp2 = Evaluator(TextBoxIdeal.Text, start, finish, step);
            for (var i = 0; i < temp2.GetLength(1); i++)
            {
                list.Add(temp2[1, i], temp2[0, i]);
                // ReSharper disable LocalizableElement
                richTextBoxIncoming.Text += temp2[0, i] + "\t" + temp2[1, i] + "\r\n";
                // ReSharper restore LocalizableElement
            }
            ZedGraphHlp.DrawGraph(ZedGraphResult, "Сгенерированная", list, Color.Green, false);
        }

        public double[,] Evaluator(string expression, double start, double finish, double step)
        {
            var n = 0;
            string code = string.Empty;
            code += "using System;";
            code += "namespace CSEvaluator";
            code += "{ public class Evaluate";
            code += "  { public double GetResult(int number){ return(" + expression.Replace("x", "EvaluatorXY[0,number]") + "); }";

            code += "       private void Reader()";
            code += "       {";

            for (double i = start; i >= finish; i = i - step)
            {
                n++;
                code += "               EvaluatorXY[0," + (n - 1) + "] = " + Math.Round(i, 4).ToString(CultureInfo.InvariantCulture) + ";";
            }
            code += "       }";

            code += "       private double Pow(double arg, double leaf)";
            code += "       {";
            code += "           if (arg > 0) return Math.Pow(arg, leaf);";
            code += "           double result = 0;";
            code += "           int floatlenght = 0;";
            code += "           double tmp = arg;";
            code += "           while ((int)tmp % 10 == 0  && tmp!=0)";
            code += "           {";
            code += "               tmp *= 10;";
            code += "               floatlenght++;";
            code += "           }";
            code += "           bool negatArg = false;";

            code += "           if ((leaf ) % 2 != 0 )";
            code += "           {";
            code += "               arg = arg * -1;";
            code += "              negatArg = true;";
            code += "           }";
            code += "           result = Math.Pow(arg, leaf);";
            code += "           if (negatArg == true) result = result * -1;";
            code += "           return result;";
            code += "       }";
            code += "       private double Cos(double arg) { return Math.Cos(arg); }";
            code += "       private double Sin(double arg) { return Math.Sin(arg); }";
            code += "       private double Tan(double arg) { return Math.Tan(arg); }";
            code += "       private double EXP(double arg) { return Math.Exp(arg); }";
            code += "       private double Log(double leaf, double arg) { return Math.Log(arg, leaf); }";

            code += "       double[,] EvaluatorXY = new double[2," + n + "];";

            code += "       public void GetEvaluatorXY()";
            code += "       {";
            code += "       Reader();";
            code += "           for (int i = 0;i<=" + (n - 1) + ";i++)";
            code += "               EvaluatorXY[1,i] = Math.Round(GetResult(i),4);";
            code += "       }";
            code += "       public double[,] GetResultEvaluatorXY()";
            code += "       {";
            code += "           GetEvaluatorXY();";
            code += "           return EvaluatorXY;";
            code += "       }";
            code += "  }";
            code += "}";

            var ccParams = new CompilerParameters
            {
                //CompilerOptions = "/t:library",
                GenerateInMemory = true,
                IncludeDebugInformation = true,
                GenerateExecutable = false,
                OutputAssembly = "Evaluate.dll",
                CompilerOptions = "/optimize",
                TempFiles = new TempFileCollection(".", false)
            };
            ccParams.ReferencedAssemblies.Add("system.dll");
            CodeDomProvider compileProvider = CodeDomProvider.CreateProvider("CSharp");

            var results = compileProvider.CompileAssemblyFromSource(ccParams, code);
            var assembly = results.CompiledAssembly;
            var evaluator = assembly.CreateInstance("CSEvaluator.Evaluate");

            ContractHlp.Assert(evaluator != null, "Erorr 16420203. Не удалось собрать компилятор.");

            var result = (double[,])evaluator.GetType().InvokeMember("GetResultEvaluatorXY", BindingFlags.InvokeMethod, null, evaluator, new object[] { }, null, null, null);

            return result;
        }
        #endregion
        #region ToolStripMenu                                   ***********************************************************************************************************************************************
        private void открытьФайлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _formDesigner.Show();
            _formOpenFile.Owner = this;
            _formOpenFile.ShowDialog();
        }

        private void кодАлгоритмаToolStripMenuItem_Click(object sender, EventArgs e) =>
            _formAlgorithmCode.Show();

        private void toolStripMenuItem1_Click(object sender, EventArgs e) =>
            _formConvolution.Show();

        private void конструкторАлгоритмаToolStripMenuItem_Click(object sender, EventArgs e) =>
            _formDesigner.Show();

        private void коллекцияФенотиповToolStripMenuItem_Click(object sender, EventArgs e) =>
            _formPhonotypeCollections.Show();

        private void ошибкиToolStripMenuItem_Click(object sender, EventArgs e) =>
            _formErrors.Show();

        private void тестированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void потокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formTreads = new Threads();
            formTreads.Show();
        }

        private void общиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _formTests = new FormTests();
            _formTests.Show();
        }

        #endregion
        #region Доп функционал                                  ***********************************************************************************************************************************************
        public void ClearNullStr(RichTextBox rtb)
        {
            while (rtb.Lines[rtb.Lines.Length - 1].Replace(" ", "") == "")
                DelLine(rtb, rtb.Lines.Length - 1);
        }

        private void buttonStopEndScreen_Click(object sender, EventArgs e)
        {
            FormDialog.Visible = true;
            FormDialog.TopMost = true;
            FormDialog.TopMost = false;
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            textBoxPopulationSize.Enabled = true;
            progressBar1.Value = 0;
            ZedGraphResult.GraphPane.CurveList.Clear();
            ZedGraphResult.GraphPane.GraphObjList.Clear();
            ZedGraphResult.Invalidate();
            zedGraphIterations.GraphPane.CurveList.Clear();
            zedGraphIterations.GraphPane.GraphObjList.Clear();
            zedGraphIterations.Invalidate();
            richTextBoxIncoming.Text = "";
            richTextBoxResolve.Text = "";
            SelectionManager = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _formConvolution.richTextBoxIncoming.Text = richTextBoxIncoming.Text;
            _formConvolution.richTextBoxConvolution.Text = richTextBoxResolve.Text;
        }

        private void buttonTrim_Click(object sender, EventArgs e)
        {
            textBox2.Text = Math.Round(ZedGraphResult.GraphPane.YAxis.Scale.Max, 1).ToString(CultureInfo.InvariantCulture);
            textBox3.Text = Math.Round(ZedGraphResult.GraphPane.YAxis.Scale.Min, 1).ToString(CultureInfo.InvariantCulture);
            richTextBoxIncoming.Text = "";
            foreach (string parameter in IncomingParameters)
            {
                string[] parts = parameter.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var dept = ConvertExt.ToDbl(parts[0]);
                if (dept <= ConvertExt.ToDbl(textBox2.Text) & dept >= ConvertExt.ToDbl(textBox3.Text))
                {
                    richTextBoxIncoming.Text += (dept - ConvertExt.ToDbl(textBox3.Text)).IsLessThanEpsilon() == false
                        ? parameter + "\r\n"
                        : parameter;
                }
            }
        }

        public void richTextBoxIncoming_DoubleClick(object sender, EventArgs e)
        {
            ClearNullStr(richTextBoxIncoming);
            int fxIndex = richTextBoxIncoming.Lines[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            var list = new PointPairList();

            try
            {
                ZedGraphResult.GraphPane.CurveList["Исходная"].Color = Color.Green;
            }
            catch
            {
                ZedGraphHlp.DrawGraph(ZedGraphResult, "Исходная", list, Color.Red, checkBoxHaveDept.Checked);
            }
            ZedGraphResult.GraphPane.CurveList["Исходная"].Clear();

            foreach (string line in richTextBoxIncoming.Lines)
            {
                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                ZedGraphResult.GraphPane.CurveList["Исходная"].AddPoint(ConvertExt.ToDbl(parts[fxIndex - 1]), ConvertExt.ToDbl(parts[0]));
            }

            ZedGraphResult.AxisChange();
            ZedGraphResult.Invalidate();
        }

        [SuppressMessage("ReSharper", "All")]
        private void buttonUseTestClass_Click(object sender, EventArgs e)
        {
            var classTest = new Estimator();
            richTextBoxIncoming.Text = "";
            richTextBoxResolve.Text = "";

            double bestFunc = Math.Pow(10, 300);

            var better = classTest.DeviationCollections(new[]
            {
                754.23171986103057,
                142.85790967464447
            }, 30);
            //double[] readLeafs = ClassTest.Out_Constants[bestIndex];
            //richTextBoxResolve.Text += "Отклонение: " + BestFunc + "\rГенотип #" + bestIndex + "\rИтераций Н-М: " + ClassTest.Out_NM_Restarts[bestIndex];
            try
            {
                //for (int i = 0; i < readLeafs.Length; i++)
                //    richTextBoxResolve.Text += "\rЛист " + i + ": " + Math.Round(readLeafs[i], 3);
            }
            catch
            {
                //ignore
            }
        }
        #endregion
        #region Запуск селекции                                 ***********************************************************************************************************************************************
        private void buttonStartAlgorithm_Click(object sender, EventArgs e)
        {
            int popsize = Convert.ToInt32(textBoxPopulationSize.Text);
            var selectionConfig = new SelectionConfig
            {
                MaxNelrodMidIterations = 300,
                MutationChance = Convert.ToInt32(textBoxMutationChance.Text),
                GrowSpeed = Convert.ToInt32(textBox1GrowSpeed.Text),
                MaxConstantsCount = Convert.ToInt16(textBoxLeafsCount.Text),
                MaxAlgorithmIterations = Convert.ToInt16(textBoxIterationsCount.Text),
                TargetDeviation = ConvertExt.ToDbl(textBoxDesp.Text),
            };

            var args = PointsReader();
            SelectionManager = new SelectionManager(popsize, args, checkBoxConvolution.Checked, selectionConfig, new GraphPointsCycle(this));

            textBoxPopulationSize.Enabled = false;
            textBoxPopulationSize.Text = SelectionManager.PopulationSize.ToString();

            ContinueIterationsLoop();
        }

        public void PauseIterationsLoop() =>
            SelectionManager.PauseLoop();

        public void ContinueIterationsLoop()
        {
            if (SelectionManager.Status.IsContinuous) return;

            switch (checkBoxInThisThread.Checked)
            {
                case true:
                    SelectionManager.ContinueLoop(true, true);
                    break;

                default:
                    Task.Run(() => SelectionManager.ContinueLoop(true, true));
                    break;
            }
            //Refresh();
        }

        public void HaveSolution() =>
            SelectionManager.EndAlgorithm();

        private void textBoxIterationsCount_TextChanged(object sender, EventArgs e) =>
            StartHelper(() => SelectionManager.SelectionConfig.MaxAlgorithmIterations = Convert.ToInt16(textBoxIterationsCount.Text));

        private void textBoxMutationChance_TextChanged(object sender, EventArgs e) =>
            StartHelper(() => SelectionManager.SelectionConfig.MutationChance = Convert.ToInt32(textBoxMutationChance.Text));

        private void richTextBoxIncoming_TextChanged(object sender, EventArgs e) =>
            buttonStartAlgorithm.Enabled = richTextBoxIncoming.Text != "";

        private static void StartHelper(Action a)
        {
            try { a.Invoke(); }
            catch
            {
                // ignored
            }
        }
        #endregion
        #region Корзина                                         ***********************************************************************************************************************************************
        ///// <summary>
        ///// Позволяет обновлять текст в тектовых контролах из сторонних процессов.
        ///// </summary>
        //public void SetTextThreadSafe(object textControl, string text)
        //{
        //    // InvokeRequired required compares the thread ID of the  
        //    // calling thread to the thread ID of the creating thread.  
        //    // If these threads are different, it returns true.
        //    if (richTextBoxResolve.InvokeRequired)
        //    {
        //        TextReturningVoidDelegate d =  SetTextThreadSafe;
        //        Invoke(d, textControl, text);
        //        return;
        //    }

        //    switch (textControl)
        //    {
        //        case Form f:
        //            f.Text = text;
        //            break;

        //        case TextBoxBase tb:
        //            tb.Text = text;
        //            break;

        //        case Control lb:
        //            lb.Text = text;
        //            break;

        //        case ToolStripMenuItem tsmi:
        //            tsmi.Text = text;
        //            break;

        //        default:
        //            throw new Exception($"Тип '{textControl.GetType()}' для используемого контрола " +
        //                                $"не поддерживается в методе '{nameof(SetTextThreadSafe)}' (error 10251004)");
        //    }
        //}
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int i = 0;
        //    while (i < 50)
        //    {
        //        var expr = "0+3-Pow(3-Pow(Arg[0,n],1)+Pow(Arg[0,n],Pow(3-Pow(Arg[0,n],1)+Pow(Arg[0,n],Arg[0,n]),1)),1)";//////////////// 0 + 3.101875 - Pow(3.101875 - Pow(Arg[0, n], 0.99875) + Pow(Arg[0, n], Pow(3.101875 - Pow(Arg[0, n], 0.99875) + Pow(Arg[0, n], Arg[0, n]), 0.99875)), 0.99875)
        //        var sda = -0.123415425;
        //        var round = Math.Round(sda, 3);
        //        var str = round.ToString();
        //        try
        //        {
        //            var s = "1";
        //            var no = "0";
        //            var sb = Convert.ToBoolean(s);
        //            var noB = Convert.ToBoolean(no);
        //        }
        //        catch
        //        {

        //        }
        //        Compiler math = new Compiler(expr);//
        //        math.Parse();
        //        List<Parser.ExpressionNodes.TreeNode> _ParsedResTree = math.ParsedTree();
        //        //var _Parsedid = _ParsedResTree[0].GetLastID();
        //        //var _ParsedReRes = math.ReparseTree();
        //        math.Simplification();
        //        List<Parser.ExpressionNodes.TreeNode> _SimplResTree = math.ParsedTree();
        //        //var _Simplid = _ParsedResTree[0].GetLastID();
        //        var _SimplReRes = math.ReparseTree();
        //        math.ChangeConstantsToLeaf();
        //        var _SimplReResLeafs = math.ReparseTree();
        //        i++;
        //    }
        //}
        //    var sa = GetMounthsRange("01.01.2000", "01.01.2021");
        //        foreach(var s in sa)
        //        {
        //            ReadFromSql("INSERT INTO [AMX].[Mounths] ([Date],[Position])VALUES('"+Convert.ToDateTime(s[0]).ToString("yyyy-MM-dd") + "','First')");
        //            ReadFromSql("INSERT INTO [AMX].[Mounths] ([Date],[Position])VALUES('" + Convert.ToDateTime(s[1]).ToString("yyyy-MM-dd") + "','Last')");
        //        }
        //public List<string[]> ReadFromSql(string executeCommand)
        //    {
        //        List<string[]> strList = new List<string[]>();
        //        using (SqlConnection myConnection = new SqlConnection(@"Data Source=gls-vsb-sqlrip1\spbase;Initial Catalog=OAPiA;User Id=master; Password=Kick.tolyan"))
        //        {
        //            myConnection.Open();
        //            SqlCommand myCommand = new SqlCommand(executeCommand, myConnection);
        //            SqlDataReader reader = myCommand.ExecuteReader();
        //            myCommand.Dispose();
        //            while (reader.Read())
        //            {
        //                string[] strToadd = new string[reader.FieldCount];
        //                for (int i = 0; i < reader.FieldCount; i++) strToadd[i] = reader[i].ToString();
        //                strList.Add(strToadd);
        //            }
        //            reader.Dispose();
        //        }
        //        return strList;
        //    }
        //    public List<string[]> GetMounthsRange(string startDay, string endDay)
        //    {
        //        try
        //        {
        //            List<string[]> months = new List<string[]>();
        //            DateTime start = Convert.ToDateTime(startDay);
        //            DateTime end = Convert.ToDateTime(endDay);
        //            if (start.ToString("MM.yyyy") != end.ToString("MM.yyyy"))
        //            {
        //                while (start.ToString("MM.yyyy") != end.ToString("MM.yyyy"))
        //                {
        //                    months.Add(new string[] { start.ToString("dd.MM.yyyy"),
        //                    (Convert.ToDateTime("01." + start.AddMonths(1).ToString("MM.yyyy"))).AddDays(-1).ToString("dd.MM.yyyy")
        //                });
        //                    start = Convert.ToDateTime("01." + start.AddMonths(1).ToString("MM.yyyy"));
        //                }
        //                months.Add(new string[] { start.ToString("dd.MM.yyyy"),
        //                    (Convert.ToDateTime("01." + start.AddMonths(1).ToString("MM.yyyy"))).AddDays(-1).ToString("dd.MM.yyyy")
        //                });
        //            }
        //            else
        //                months.Add(new string[] { start.ToString("dd.MM.yyyy"), end.ToString("dd.MM.yyyy") });
        //            return months;
        //        }
        //        catch
        //        {    //            
        //            return new List<string[]>() { new string[] { "01.01.2015", "02.01.2015" } };
        //        };
        //    }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < 100; i++)
        //        richTextBoxIncoming.Text += rnd.Next(0, 2);
        //}
        #endregion
    }
}