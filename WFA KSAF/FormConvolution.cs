using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WFA.KSAF;
using WFA.KSAF.Extensions;
using ZedGraph;

namespace WFA.KSAF
{
    public partial class FormConvolution : Form
    {
        private Form1 MainForm;
        public FormConvolution(Form1 _Mainform)
        {
            InitializeComponent();
            MainForm = _Mainform;
        }
        private void FormConvolution_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private List<double[]> ListIncoming = new List<double[]>();
        private List<double[]> ListOperator = new List<double[]>();
        private List<double[]> ListConvolution = new List<double[]>();
        public void Reader(RichTextBox rtb, List<double[]> list)
        {
            if (string.Compare(rtb.Text, "") != 0)
            {
                int linesLenght = rtb.Lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
                MainForm.ClearNullStr(rtb);
                list.Clear();
                for (int i = 0; i < rtb.Lines.Length; i++)
                {
                    string[] parts = rtb.Lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    double[] xy = new double[linesLenght];
                    //if (rtb != richTextBoxOperator) for (int n = 0; n < linesLenght; n++) xy[n] = MainForm.ConvertToDouble(parts[n]);
                    //else for (int n = linesLenght; n >=0 ; n--) xy[n] = MainForm.ConvertToDouble(parts[n]);
                    for (int n = 0; n < linesLenght; n++) xy[n] = parts[n].ToDblSlow();
                    list.Add(xy);
                }
            }
            list.Reverse();
        }
        private double GetArgumentFromList(int column, int row, List<double[]> list)
        {
            double[] arg;
            try
            {
                arg = list[column];
                return arg[row];
            }
            catch { return 0.0; }
        }
        private void GetConvolution(int startIncIndex, int startOpIndex)
        {
            int OperatorsLenght = richTextBoxOperator.Lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;
            int ConvolutionLenght = OperatorsLenght + richTextBoxIncoming.Lines.Length - 1;
            double[] tempOp = new double[OperatorsLenght];
            tempOp = ListOperator[startOpIndex];
            ListConvolution.Clear();
            for (int n = 0; n < ConvolutionLenght; n++)
            {
                double[] tempConv = new double[2];
                tempConv[0] = n;
                tempConv[1] = 0;
                for (int m = 0; m <= n; m++)
                {
                    tempConv[1] += GetArgumentFromList(startIncIndex + m, 1, ListIncoming) * GetArgumentFromList(startOpIndex + 0, OperatorsLenght - n + m, ListOperator);
                }
                ListConvolution.Add(tempConv);
            }
        }
        private double[] GetOperators(int startIncIndex, int startConvIndex)
        {
            richTextBoxOperator.Clear();
            int OperatorsLenght = ListConvolution.Count - ListIncoming.Count + 1;
            double[] tempOp = new double[OperatorsLenght + 1];
            ListOperator.Add(tempOp);
            tempOp[0] = GetArgumentFromList(startIncIndex, 0, ListIncoming);
            richTextBoxOperator.Text += tempOp[0].ToString().Replace(",", ".") + " ";
            for (int n = 0; n < OperatorsLenght; n++)
            {
                for (int m = 1; m <= n; m++)
                {
                    tempOp[n + 1] += GetArgumentFromList(startIncIndex + m, 1, ListIncoming) * GetArgumentFromList(0, 1 + n - m, ListOperator);
                }
                double one = GetArgumentFromList(startConvIndex + n, 1, ListConvolution);
                double two = tempOp[n + 1];
                double three = GetArgumentFromList(startIncIndex + 0, 1, ListIncoming);

                tempOp[n + 1] = (one - two) / three;
            }
            return tempOp;
        }
        private void DrawToMain(RichTextBox rtb, string title)
        {
            int Fx_index = rtb.Lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PointPairList list = new PointPairList();
            for (int i = 0; i < rtb.Lines.Length; i++)
            {
                string[] parts = rtb.Lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                list.Add(parts[Fx_index - 1].ToDbl(), parts[0].ToDbl());
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, title, list, MainForm.GetRandColor());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Reader(richTextBoxIncoming, ListIncoming);
            Reader(richTextBoxOperator, ListOperator);

            int iterations = Math.Min(richTextBoxIncoming.Lines.Length, richTextBoxOperator.Lines.Length + Convert.ToInt16(textBoxIncRange.Text) - 1) - Convert.ToInt16(textBoxIncRange.Text) + 1;
            int findedStartDeptInc = -1;
            int findedStartDeptOp = -1;
            bool finded = false;
            foreach (double[] getInc in ListIncoming)
            {
                if (!finded)
                    foreach (double[] getOp in ListOperator)
                    {
                        if (getInc[0] == getOp[0])
                        {
                            findedStartDeptOp = ListOperator.IndexOf(getOp);
                            findedStartDeptInc = ListIncoming.IndexOf(getInc);
                            finded = true;
                        }
                    }
            }

            if (findedStartDeptOp == -1)
                MessageBox.Show("Совпадений по глубине не найдено");
            else
            {
                GetConvolution(findedStartDeptInc, findedStartDeptOp);
            }
            ListConvolution.Reverse();
            richTextBoxConvolution.Clear();
            foreach (double[] getConv in ListConvolution)
            {
                foreach (double getOne in getConv)
                {
                    double y = Math.Round(getOne, 4);
                    richTextBoxConvolution.Text += y + " ";
                }
                richTextBoxConvolution.Text += "\r\n";
            }
            MainForm.ClearNullStr(richTextBoxConvolution);
            DrawToMain(richTextBoxConvolution, "Свертка");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reader(richTextBoxIncoming, ListIncoming);
            Reader(richTextBoxConvolution, ListConvolution);
            int OperatorsCount = ListConvolution.Count - ListIncoming.Count + 1;
            OperatorsCount = 1;
            int findedStartDeptInc = -1;
            int findedStartDeptConv = -1;
            bool finded = false;
            foreach (double[] getInc in ListIncoming)
            {
                if (!finded)
                    foreach (double[] getConv in ListConvolution)
                        if (getInc[0] == getConv[0])
                        {
                            findedStartDeptConv = ListConvolution.IndexOf(getConv);
                            findedStartDeptInc = ListIncoming.IndexOf(getInc);
                            finded = true;
                        }
            }

            if (findedStartDeptConv == -1)
                MessageBox.Show("Совпадений по глубине не найдено");
            else
            {
                ListOperator.Clear();
                MainForm.zedGraphIterations.GraphPane.CurveList.Clear();
                MainForm.zedGraphIterations.GraphPane.GraphObjList.Clear();
                for (int i = 0; i < OperatorsCount; i++)
                {
                    GetOperators(findedStartDeptInc + i, findedStartDeptConv + i);
                }
                ListOperator.Reverse();
                richTextBoxOperator.Text = "";
                foreach (double[] getOp in ListOperator)
                {
                    PointPairList iterpoints = new PointPairList();
                    int x = 0;
                    foreach (double getOne in getOp)
                    {
                        double y = Math.Round(getOne, 4);
                        if (x != 0) iterpoints.Add(x, y);
                        x++;
                        richTextBoxOperator.Text += y + " ";
                    }
                    MainForm.DrawGraph(MainForm.zedGraphIterations, "", iterpoints, MainForm.GetRandColor());
                    richTextBoxOperator.Text += "\r\n";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBoxIncoming.Text = "";
            PointPairList list = new PointPairList();
            double start =  textBox5.Text.ToDbl();
            double finish = textBox3.Text.ToDbl();
            double step =   textBox4.Text.ToDbl();
            double[,] temp2 = MainForm.Evaluator(textBoxIncFunc.Text, start, finish, step);
            for (int i = 0; i < temp2.GetLength(1); i++)
            {
                list.Add(temp2[1, i], temp2[0, i]);
                richTextBoxIncoming.Text += temp2[0, i] + "\t" + temp2[1, i] + "\r\n";
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Функция для свертки", list, MainForm.GetRandColor());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PointPairList list = new PointPairList();
            double start =  textBox5.Text.ToDbl();
            double finish = textBox3.Text.ToDbl();
            richTextBoxOperator.Text = finish.ToString();
            double step =  textBox4.Text.ToDblSlow();
            double[,] temp2 = MainForm.Evaluator(textBoxIncFunc.Text, start, finish, step);
            for (int i = 0; i < temp2.GetLength(1); i++)
            {
                list.Add(temp2[1, i], temp2[0, i]);
                richTextBoxOperator.Text += temp2[0, i] + "\t" + temp2[1, i] + "\r\n";
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Оператор свертки", list, MainForm.GetRandColor());
        }

        private void FormConvolution_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm.checkBoxHaveDept.Checked = true;
            MainForm.checkBoxConvolution.Checked = true;
            MainForm.textBoxPopulationSize.Text = "15";
            MainForm.textBoxNMIteratoins.Text = "3000";
            int OperatorsLenght = richTextBoxOperator.Lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PointPairList list = new PointPairList();
            Reader(richTextBoxOperator, ListOperator);
            Reader(richTextBoxIncoming, ListIncoming);
            ListConvolution.Clear();
            MainForm.richTextBoxIncoming.Text = "";
            richTextBoxConvolution.Text = "";
            for (int i = 0; i < OperatorsLenght - 1; i++)
            {
                double[] temp = new double[2];
                temp[0] = Math.Round(GetArgumentFromList(i, 0, ListIncoming), 4);
                temp[1] = 0;
                list.Add(temp[1], temp[0]);
                ListConvolution.Add(temp);
                MainForm.richTextBoxIncoming.Text += temp[0] + "   \t" + GetArgumentFromList(i, 1, ListIncoming) + "    \t" + temp[1] + "\r\n";
                richTextBoxConvolution.Text += temp[0] + "   \t" + temp[1] + "\r\n";
            }
            for (int i = OperatorsLenght - 1; i < richTextBoxIncoming.Lines.Length; i++)
            {
                double[] tempConv = new double[2];
                tempConv[0] = Math.Round(GetArgumentFromList(i, 0, ListIncoming), 4);
                for (int m = 0; m < OperatorsLenght; m++)
                {
                    tempConv[1] += GetArgumentFromList(0, m, ListOperator) * GetArgumentFromList(i - m, 1, ListIncoming);
                }
                for (int m = 1; m <= 2; m++)
                {
                    tempConv[1] -= 0.5 * GetArgumentFromList(i - m, 1, ListConvolution);
                }
                list.Add(tempConv[1], tempConv[0]);
                ListConvolution.Add(tempConv);
                MainForm.richTextBoxIncoming.Text += tempConv[0] + "   \t" + GetArgumentFromList(i, 1, ListIncoming) + "    \t" + Math.Round(tempConv[1], 4) + "\r\n";
                richTextBoxConvolution.Text += tempConv[0] + "   \t" + Math.Round(tempConv[1], 4) + "\r\n";
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Рекурсивный фильтр", list, Color.Red);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainForm.checkBoxHaveDept.Checked = true;
            MainForm.checkBoxConvolution.Checked = true;
            MainForm.textBoxPopulationSize.Text = "15";
            MainForm.textBoxNMIteratoins.Text = "3000";
            int OperatorsLenght = richTextBoxOperator.Lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            PointPairList list = new PointPairList();
            Reader(richTextBoxOperator, ListOperator);
            Reader(richTextBoxIncoming, ListIncoming);
            ListConvolution.Clear();
            MainForm.richTextBoxIncoming.Text = "";
            richTextBoxConvolution.Text = "";
            for (int i = 0; i < OperatorsLenght - 1; i++)
            {
                double[] temp = new double[2];
                temp[0] = Math.Round(GetArgumentFromList(i, 0, ListIncoming), 4);
                temp[1] = 0;
                list.Add(temp[1], temp[0]);
                ListConvolution.Add(temp);
                MainForm.richTextBoxIncoming.Text += temp[0] + "   \t" + GetArgumentFromList(i, 1, ListIncoming) + "    \t" + temp[1] + "\r\n";
                richTextBoxConvolution.Text += temp[0] + "   \t" + temp[1] + "\r\n";
            }
            for (int i = OperatorsLenght - 1; i < richTextBoxIncoming.Lines.Length; i++)
            {
                double[] tempConv = new double[2];
                tempConv[0] = Math.Round(GetArgumentFromList(i, 0, ListIncoming), 4);
                for (int m = 0; m < OperatorsLenght; m++)
                {
                    tempConv[1] += GetArgumentFromList(0, m, ListOperator) * GetArgumentFromList(i - m, 1, ListIncoming);
                }
                //for (int m = 1; m <= 2; m++)
                //{
                //    tempConv[1] -= 0.5 * GetArgumentFromList(i - m, 1, ListConvolution);
                //}
                list.Add(tempConv[1], tempConv[0]);
                ListConvolution.Add(tempConv);
                MainForm.richTextBoxIncoming.Text += tempConv[0] + "   \t" + GetArgumentFromList(i, 1, ListIncoming) + "    \t" + Math.Round(tempConv[1], 4) + "\r\n";
                richTextBoxConvolution.Text += tempConv[0] + "   \t" + Math.Round(tempConv[1], 4) + "\r\n";
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Цифровой фильтр", list, Color.Pink);
        }
        Random rnd = new Random();
        private void button7_Click(object sender, EventArgs e)
        {
            richTextBoxIncoming.Text = "";
            PointPairList list = new PointPairList();
            double start =  textBox5.Text.ToDblSlow();
            double finish = textBox3.Text.ToDblSlow();
            double step =   textBox4.Text.ToDblSlow();
            double[,] temp2 = MainForm.Evaluator(textBoxIncFunc.Text, start, finish, step);
            for (double i = start; i > finish; i -= step)
            {
                double[] temp = new double[2];
                temp[0] = Math.Round(i, 4);
                temp[1] = rnd.Next(-Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox1.Text));
                list.Add(temp[1], temp[0]);
                richTextBoxIncoming.Text += temp[0] + "\t" + temp[1] + "\r\n";
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Функция для свертки", list, Color.Green);
        }
    }
}
