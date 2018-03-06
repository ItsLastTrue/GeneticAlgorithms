using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.Linq;
using System.CodeDom.Compiler;
using System.Globalization;
using System.Reflection;
using CL.Extensions;
using WFA.KSAF.Forms;
using WFA.KSAF.Creators;
using WFA.KSAF.Generated;
using WFA.KSAF.Helpers;
using ConvertExt = WFA.KSAF.Extensions.ConvertExt;

namespace WFA.KSAF
{
    public partial class Form1 : Form
    {
        #region Общие функции и форма                           ***********************************************************************************************************************************************
        public CreatePopulation PopulationCreator;
        
        private readonly FormOpenFile FormOpenFile;
        private readonly FormConvolution FormConvolution;
        private readonly FormErrors FormErrors;
        private readonly DialogForm DialogBog;
        private readonly Designer FormDesigner = new Designer();
        private readonly FormAlgorithmCode FormAlgorithmCode = new FormAlgorithmCode();
        private readonly FormPhonotypeCollections FormPhonotypeCollections = new FormPhonotypeCollections();

        /// <summary>
        /// Набор исходных точек и значений в них.
        /// </summary>
        public double[,] Arguments;
        /// <summary>
        /// Количество переменных x,y,z,...
        /// </summary>
        public int ArgumentsRows;

        /// <summary>
        /// Количество точек {[1,3],[3,3],...}.
        /// </summary>
        public int ArgumentsCount;

        /// <summary>
        /// Равен нулю если первый столбец в исх точках уже содержит данные ИЛИ равен 1 если 1 столбец - глубина (а второй уже функция).
        /// </summary>
        private int _deptincrement;

        public Form1()
        {
            InitializeComponent();

            FormOpenFile = new FormOpenFile(this);
            FormConvolution = new FormConvolution(this);
            FormErrors = new FormErrors(this);
            DialogBog = new DialogForm(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ZedGraphResult.GraphPane.Title.IsVisible = false;
            zedGraphIterations.GraphPane.Title.IsVisible = false;
        }

        public void ClearNullStr(RichTextBox rtb)
        {
            while (rtb.Lines[rtb.Lines.Length - 1].Replace(" ", "") == "") DelLine(rtb, rtb.Lines.Length - 1);
        }

        private void DelLine(RichTextBox rtb, int index) =>
            rtb.Text = rtb.Text.Remove(rtb.GetFirstCharIndexFromLine(index) - 1, rtb.Lines[index].Length + 1);

        private void checkBoxHaveDept_CheckedChanged(object sender, EventArgs e) =>
            _deptincrement = checkBoxHaveDept.Checked ? 1 : 0;

        #endregion
        #region Графы и рисование                               ***********************************************************************************************************************************************
        public Color GetRandColor()
        {
            Color[] _colors =
            {
                Color.Black,
                Color.Blue,
                Color.Brown,
                Color.Gray,
                Color.Green,
                Color.Indigo,
                Color.Orange,
                Color.Red,
                Color.Aqua,
                Color.Gold,
                Color.DarkViolet,
                Color.DeepPink,
                Color.YellowGreen
            };
            return _colors[rnd.Next(_colors.Length)];
        }
        public void DrawGraph(ZedGraphControl NameZedGraphControl, string GraphName, PointPairList _list, Color GraphColor)
        {
            // Получим панель для рисования
            GraphPane pane = NameZedGraphControl.GraphPane;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            //pane.CurveList.Clear();
            PointPairList ListNew = new PointPairList(_list);
            // Создадим кривую с названием GraphName, 
            // которая будет рисоваться цветом (GraphColor),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve = pane.AddCurve(GraphName, ListNew, GraphColor, SymbolType.None);
            pane.XAxis.MajorGrid.IsZeroLine = true;
            pane.YAxis.MajorGrid.IsZeroLine = false;
            if (checkBoxHaveDept.Checked)
            {
                pane.XAxis.Title.Text = "KPD";
                pane.YAxis.Title.Text = "DEPT";
            }
            else
            {
                pane.XAxis.Title.Text = "F(x)";
                pane.YAxis.Title.Text = "x";
            }

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            NameZedGraphControl.AxisChange();
            // Обновляем график
            NameZedGraphControl.Invalidate();
        }
        bool begunPainting;
        private bool ZedGraphResult_MouseMoveEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            return default(bool);
        }
        PointPairList PPDrawting = new PointPairList();

        double LastX, LastY;
        private bool ZedGraphResult_MouseDownEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            if (DrawtingMode)
            {
                begunPainting = true;
                ZedGraphResult.IsEnableHZoom = false;
                ZedGraphResult.IsEnableVZoom = false;
                PPDrawting.Clear();
                richTextBoxResolve.Clear();
                ZedGraphResult.GraphPane.ReverseTransform(e.Location, out LastX, out LastY);
                LastX = Math.Round(LastX, 1);
                LastY = Math.Round(LastY, 1);
                PPDrawting.Add(LastX, LastY);
                try { ZedGraphResult.GraphPane.CurveList["Произвольная"].Color = Color.HotPink; }
                catch
                {
                    DrawGraph(ZedGraphResult, "Произвольная", PPDrawting, Color.HotPink);
                }
                ZedGraphResult.GraphPane.CurveList["Произвольная"].Clear();
            }
            return default(bool);
        }
        private void ZedGraphResult_MouseMove(object sender, MouseEventArgs e)
        {
            double currentX, currentY;
            ZedGraphResult.GraphPane.ReverseTransform(e.Location, out currentX, out currentY);
            currentY = Math.Round(currentY, 1);
            currentX = Math.Round(currentX, 1);

            if (begunPainting)
            {
                // Выводим результат
                if ((int)(currentY * 10) - (int)(LastY * 10) <= -1)
                {
                    LastX = Math.Round(currentX, 1);
                    LastY = Math.Round(currentY, 1);
                    richTextBoxResolve.Text += LastY + " " + LastX + "\r\n";
                    PPDrawting.Add(LastX, LastY);
                    ZedGraphResult.GraphPane.CurveList["Произвольная"].AddPoint(LastX, LastY);
                    ZedGraphResult.Invalidate();
                }
            }
        }
        private bool ZedGraphResult_MouseUpEvent(ZedGraphControl sender, MouseEventArgs e)
        {
            begunPainting = false;
            ZedGraphResult.IsEnableHZoom = true;
            ZedGraphResult.IsEnableVZoom = true;
            return default(bool);
        }
        bool DrawtingMode;
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) DrawtingMode = true;
            else DrawtingMode = false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) DrawtingMode = true;
            else DrawtingMode = false;
        }
        #endregion
        #region Прогрузка данных                                ***********************************************************************************************************************************************
        public void Reader()
        {
            ClearNullStr(richTextBoxIncoming);

            ArgumentsRows = richTextBoxIncoming.Lines[0].Split(new [] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length - 1 - _deptincrement;
            ArgumentsCount = richTextBoxIncoming.Lines.Length;

            Arguments = new double[ArgumentsRows + 1, ArgumentsCount];
            for (var i = 0; i < richTextBoxIncoming.Lines.Length; i++)
            {
                string[] parts = richTextBoxIncoming.Lines[i].Split(new [] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (var n = 0; n <= ArgumentsRows; n++)
                {
                    Arguments[n, i] = ConvertExt.ToDbl(parts[n + _deptincrement]);
                }
            }
        }
        #endregion
        #region Генератор функций                               ***********************************************************************************************************************************************
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            richTextBoxIncoming.Text = "";
            var list = new PointPairList();

            double start = ConvertExt.ToDbl(textBox2.Text);
            double finish= ConvertExt.ToDbl(textBox3.Text);
            double step =  ConvertExt.ToDbl(textBox4.Text);
            double[,] temp2 = Evaluator(TextBoxIdeal.Text, start, finish, step);
            for (var i = 0; i < temp2.GetLength(1); i++)
            {
                list.Add(temp2[1, i], temp2[0, i]);
                richTextBoxIncoming.Text += temp2[0, i] + @"\t" + temp2[1, i] + @"\r\n";
            }
            DrawGraph(ZedGraphResult, "Сгенерированная", list, Color.Green);
        }

        public double[,] Evaluator(string expression, double start, double finish, double step)
        {
            CompilerParameters CC_Params;
            CodeDomProvider CompileProvider;
            CompileProvider = CodeDomProvider.CreateProvider("CSharp");
            CC_Params = new CompilerParameters
            {
                //CompilerOptions = "/t:library",
                GenerateInMemory = true,
                IncludeDebugInformation = true,
                GenerateExecutable = false,
                OutputAssembly = "Evaluate.dll",
                CompilerOptions = "/optimize",
                TempFiles = new TempFileCollection(".", false)
            };
            CC_Params.ReferencedAssemblies.Add("system.dll");

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

            var results = CompileProvider.CompileAssemblyFromSource(CC_Params, code);
            var assembly = results.CompiledAssembly;
            var evaluator = assembly.CreateInstance("CSEvaluator.Evaluate");
            if (evaluator is null)
                throw new Exception("Erorr 16420203. Не удалось собрать компилятор.");

            var result = (double[,])evaluator.GetType().InvokeMember("GetResultEvaluatorXY", BindingFlags.InvokeMethod, null, evaluator, new object[] { }, null, null, null);

            return result;
        }
        #endregion
        #region ToolStripMenu                                   ***********************************************************************************************************************************************
        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDesigner.Show();
            FormOpenFile.Owner = this;
            FormOpenFile.ShowDialog();
        }
        private void кодАлгоритмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlgorithmCode.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormConvolution.Show();
        }
        private void конструкторАлгоритмаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDesigner.Show();
        }
        private void коллекцияФенотиповToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPhonotypeCollections.Show();
        }
        private void ошибкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormErrors.Show();
        }
        #endregion
        #region Доп функционал                                  ***********************************************************************************************************************************************
        private void buttonStopEndScreen_Click(object sender, EventArgs e)
        {
            DialogBog.Visible = true;
            DialogBog.TopMost = true;
            DialogBog.TopMost = false;
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
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FormConvolution.richTextBoxIncoming.Text = richTextBoxIncoming.Text;
            FormConvolution.richTextBoxConvolution.Text = richTextBoxResolve.Text;
        }
        public List<string> IncomingParameters = new List<string>();
        private void buttonTrim_Click(object sender, EventArgs e)
        {
            textBox2.Text = Math.Round(ZedGraphResult.GraphPane.YAxis.Scale.Max, 1).ToString();
            textBox3.Text = Math.Round(ZedGraphResult.GraphPane.YAxis.Scale.Min, 1).ToString();
            richTextBoxIncoming.Text = "";
            for (int i = 0; i < IncomingParameters.Count; i++)
            {
                string[] parts = IncomingParameters[i].Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var dept = ConvertExt.ToDbl(parts[0]);
                if (dept <= ConvertExt.ToDbl(textBox2.Text) & dept >= ConvertExt.ToDbl(textBox3.Text))
                {
                    if (dept != ConvertExt.ToDbl(textBox3.Text)) richTextBoxIncoming.Text += IncomingParameters[i] + "\r\n";
                    else richTextBoxIncoming.Text += IncomingParameters[i];
                }
            }
        }
        public void richTextBoxIncoming_DoubleClick(object sender, EventArgs e)
        {
            ClearNullStr(richTextBoxIncoming);
            int Fx_index = richTextBoxIncoming.Lines[0].Split(new [] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PointPairList list = new PointPairList();

            try { ZedGraphResult.GraphPane.CurveList["Исходная"].Color = Color.Green; }
            catch
            {
                DrawGraph(ZedGraphResult, "Исходная", list, Color.Red);
            }
            ZedGraphResult.GraphPane.CurveList["Исходная"].Clear();

            for (int i = 0; i < richTextBoxIncoming.Lines.Length; i++)
            {
                string[] parts = richTextBoxIncoming.Lines[i].Split(new [] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                ZedGraphResult.GraphPane.CurveList["Исходная"].AddPoint(ConvertExt.ToDbl(parts[Fx_index - 1]), ConvertExt.ToDbl(parts[0]));
            }
            ZedGraphResult.AxisChange();
            ZedGraphResult.Invalidate();
        }
        private void buttonUseTestClass_Click(object sender, EventArgs e)
        {
            var ClassTest = new Estimator();
            richTextBoxIncoming.Text = "";
            richTextBoxResolve.Text = "";
            double BestFunc =  Math.Pow(10, 300);
            var bestIndex = 0;
            for (int i = 0; i < Convert.ToInt32(textBoxPopulationSize.Text); i++)
            {
                //var better = ClassTest.Out_Deviations[i];
                //if (BestFunc >= better)
                //{
                //    BestFunc = better;
                //    bestIndex = i;
                //}
            }
            //double[] readLeafs = ClassTest.Out_Constants[bestIndex];
            //richTextBoxResolve.Text += "Отклонение: " + BestFunc + "\rГенотип #" + bestIndex + "\rИтераций Н-М: " + ClassTest.Out_NM_Restarts[bestIndex];
            try
            {
                //for (int i = 0; i < readLeafs.Length; i++)
                //    richTextBoxResolve.Text += "\rЛист " + i + ": " + Math.Round(readLeafs[i], 3);
            }
            catch { }
        }
        #endregion
        #region Запуск селекции                                 ***********************************************************************************************************************************************
        private void buttonStartAlgorithm_Click(object sender, EventArgs e)
        {
            SelectionRulet();
            textBoxPopulationSize.Enabled = false;
        }
        private DateTime StartTime;
        private TimeSpan ElapsedTime;
        private int Iteration;
        private double MaxDespers;
        private double BestFunc_Diviate;

        private Random rnd = new Random();
        private void SelectionRulet()
        {
            Reader();
            int popsize = Convert.ToInt32(textBoxPopulationSize.Text);
            popsize = ParityHlp.ToEven(popsize);

            textBoxPopulationSize.Text = popsize.ToString();
            BestFunc_Diviate = Math.Pow(10, 300);
            Iteration = 0;
            IsSelectionContinues = true;
            StartTime = DateTime.Now;
            ElapsedTime = TimeSpan.Zero;

            var arrList = new List<List<double>>();

            for (var i = 0; i < 41; i++)
            {
                var line = new List<double>();
                for (var n = 0; n < 2; n++)
                    line.Add(Arguments[n, i]);
                arrList.Add(line);
            }

            PopulationCreator = new CreatePopulation(arrList, popsize, checkBoxConvolution.Checked);
            MaxDespers = ConvertExt.ToDbl(textBoxDesp.Text);
            RuletIterationsLoop();
        }

        /// <summary>
        /// Сообщает нужно ли продолжать создание новых популяций.
        /// </summary>
        public bool IsSelectionContinues { get; set; }

        private PointPairList BestPPList = new PointPairList();
        private PointPairList FrozenPPList = new PointPairList();
        private string _frozenPhenotype = "";
        
        public void RuletIterationsLoop()
        {
            PopulationCreator.MaxNelrodMidIterations = 300;
            PopulationCreator.MutationChance = Convert.ToInt32(textBoxMutationChance.Text);
            PopulationCreator.GrowSpeed = Convert.ToInt32(textBox1GrowSpeed.Text);
            PopulationCreator.MaxConstantsCount = Convert.ToInt16(textBoxLeafsCount.Text);

            var isNewGenotypeIsBetter = false;
            var f_x = string.Empty;
            
            if (BestFunc_Diviate < MaxDespers & IsSelectionContinues)
                textBoxDesp.Text = BestFunc_Diviate.ToString(CultureInfo.InvariantCulture);

            int populationSize = Convert.ToInt32(textBoxPopulationSize.Text);
            while (BestFunc_Diviate >= ConvertExt.ToDbl(textBoxDesp.Text) & IsSelectionContinues)
            {
                MaxDespers = ConvertExt.ToDbl(textBoxDesp.Text);
                StartTime = DateTime.Now;
                var iterationsPhonotypeCollections = "";
                PopulationCreator.PopulationCompiler(MaxDespers, Iteration);
                Iteration += 1;

                double iterToBreak = ConvertExt.ToDbl(textBoxIterationsCount.Text);
                var progressBar = (int)Math.Round(100 * (Iteration / iterToBreak - Math.Truncate(Iteration / iterToBreak)));
                if (progressBar == 0) progressBar = 100;
                progressBar1.Value = progressBar;

                //                                     Замораживаем старую или новая функция лучше и используем ее
                var newBestGenotype = PopulationCreator.BestGenotype;
                var newBestDeviate = PopulationCreator.Individual[newBestGenotype].SurvivalRate.Deviations;

                if (BestFunc_Diviate >= newBestDeviate)
                {
                    BestFunc_Diviate = newBestDeviate;
                    isNewGenotypeIsBetter = true;
                    f_x = "";
                }

                //------------------------------------Замораживаем старую или новая функция лучше и используем ее
                for (var i = 0; i < populationSize; i++)
                {                    
                    iterationsPhonotypeCollections += i + " - Кв. отклонение: " + PopulationCreator.Individual[i].SurvivalRate.Deviations + "\r\n";
                    string leafsJoin = string.Join("; ", PopulationCreator.Individual[i].SurvivalRate.Constants.Select(dbl => dbl.ToString(CultureInfo.InvariantCulture)).ToArray());
                    iterationsPhonotypeCollections += i + " - Постоянные: " + leafsJoin + "\r\n";
                    iterationsPhonotypeCollections += i + " - Генотип: " + PopulationCreator.Individual[i].Genotype + "\r\n";
                    iterationsPhonotypeCollections += i + " - Рестартов Н-М: " + PopulationCreator.Individual[i].SurvivalRate.NelMidRestarts + "\r\n";
                }

                FormAlgorithmCode.richTextBoxClassCode.Text = PopulationCreator.Code;//FormateCodeText();
                try
                {
                    FormPhonotypeCollections.richTextPhenotypes.Text += iterationsPhonotypeCollections;
                }
                catch
                {
                    FormPhonotypeCollections.richTextPhenotypes.Text = "";
                    FormPhonotypeCollections.richTextPhenotypes.Text += iterationsPhonotypeCollections;
                }

                BestPPList.Clear();
                var getCrazy = false;
                for (var i = 0; i < ArgumentsCount; i++)
                {
                    double outFy = PopulationCreator.GraphPoints[i];
                    double outFx = checkBoxHaveDept.Checked 
                        ? ConvertExt.ToDbl(richTextBoxIncoming.Lines[i].Split(new [] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0]) 
                        : Arguments[0, i];

                    if (Math.Abs(outFy) > Math.Abs(Arguments[1, i]) * 50.0 && Math.Abs(Arguments[1, i]) != 0)
                        getCrazy = true;

                    BestPPList.Add(outFy, outFx);
                    f_x += outFx + "\t";

                    for (var args = 1; args < ArgumentsRows; args++)
                        f_x += Arguments[args, i] + "\t";

                    if (isNewGenotypeIsBetter)
                        f_x += "F:" + Math.Round(PopulationCreator.GraphPoints[i], 3) + "\r\n";
                }

                //Функция рехнулась (используем прошлый вариант).
                if (getCrazy && FrozenPPList.Count > 0)
                    BestPPList = new PointPairList(FrozenPPList);

                DrawGraph(zedGraphIterations, Iteration.ToString(), BestPPList, GetRandColor());
                if (Iteration > 30)
                    zedGraphIterations.GraphPane.Legend.IsVisible = false;

                if (isNewGenotypeIsBetter)
                {
                    _frozenPhenotype = PopulationCreator.GetSimplify(newBestGenotype);
                    for (var i = 0; i < ArgumentsRows; i++)
                        _frozenPhenotype = _frozenPhenotype.Replace("Arg[" + i + ",n]", ((char)(97 + i)).ToString());
                    
                    FrozenPPList = new PointPairList(BestPPList);                    
                    richTextBoxResolve.Text = f_x;

                    f_x = "";
                    isNewGenotypeIsBetter = false;
                }

                DialogBog.Text = @"Итерация № " + Iteration;

                DialogBog.Label2.Text = BestFunc_Diviate < MaxDespers 
                    ? "Достигнуто преследуемое отклонение" 
                    : "Достигнуто заданное колличество итераций";

                DialogBog.Label1.Text = @"Текущее отклонение: " + BestFunc_Diviate;
                DialogBog.Textbox1.Text = _frozenPhenotype;
                var pause = false;
                ElapsedTime += DateTime.Now - StartTime;
                DialogBog.LabelElaps.Text = ElapsedTime.ToString();
                double endLoop = Iteration.ToDbl() / textBoxIterationsCount.Text.ToDbl();

                if ((endLoop / Math.Truncate(endLoop) - 1).IsLessThanEpsilon())
                    pause = true;

                if (BestFunc_Diviate < MaxDespers || pause)
                {
                    IsSelectionContinues = false;
                    buttonStopEndScreen.Visible = true;
                    DialogBog.Show();
                }
                this.Refresh();
            }
        }

        public void HaveSolution() =>
            DrawGraph(ZedGraphResult, "Результат подбора", FrozenPPList, Color.Blue);
        
        private void открытьФайлToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
                        
        }

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

        private void richTextBoxIncoming_TextChanged(object sender, EventArgs e) =>
            buttonStartAlgorithm.Enabled = richTextBoxIncoming.Text != "";
        #endregion
        #region Корзина                                         ***********************************************************************************************************************************************
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