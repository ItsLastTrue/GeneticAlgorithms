using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using WFA.KSAF;
using ZedGraph;

namespace WFA.KSAF
{
    public partial class FormOpenFile : Form
    {
        private Form1 MainForm;
        StreamReader InStream;
        private int RowsCount;
        private Regex mRegLine = new Regex(@"[-+][0-9]+(?:\.[0-9]*)?");
        List<PointPairList> CollectionsPointPairList = new List<PointPairList>();
        List<string> CollectionsPointPairListNames = new List<string>();
        int LasFileCounts = 0;

        public FormOpenFile(Form1 _Mainform)
        {
            InitializeComponent();
            MainForm = _Mainform;
            dataGridView2.Columns.Add("DEPT", "DEPT");
            dataGridView2.Columns.Add("Аргумент", "Аргумент");
            dataGridView2.Columns.Add("Значение", "Значение");
        }
        public LasParametrs[] LasFileCollections = new LasParametrs[10];
        private void IdentificationLasFile(string FilePath, LasParametrs Filename)
        {

            dataGridView1.Columns.Clear();
            RowsCount = 0;
            //InStream = new StreamReader(FilePath, Encoding.GetEncoding(1251));
            string readText = File.ReadAllText(FilePath, Encoding.GetEncoding(1251));
            string[] lines = Regex.Split(readText, "\r\n");
            bool startReadDescription = false;
            bool startReadLog = false;
            string tempSeriesString;
            int descriptionCount = 0;
            string lasString;
            double[] tempIcoming;
            label1.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            double step = 100.0 / (lines.Length - 1);
            double progress = 0;
            for (int linesCount = 0; linesCount < lines.Length - 1; linesCount++)
            {
                progress += step;
                if (progress > 1)
                {
                    progress--;
                    progressBar1.Value++;
                }
                //this.Refresh();
                lasString = lines[linesCount];
                Filename.Body += lasString + Environment.NewLine;

                if (lasString.Contains("NULL."))
                {
                    Filename.Null = mRegLine.Match(lasString).ToString();
                }

                if (lasString.Replace(" ", "") == "#MNEM.UNITAPICODECURVEDESCRIPTION")
                {
                    Filename.Body += linesCount + Environment.NewLine;
                    linesCount++;
                    lasString = lines[linesCount];
                    Filename.Body += lasString + Environment.NewLine;
                    startReadDescription = true;
                    linesCount++;
                    lasString = lines[linesCount];
                    //dataGridView1.Columns.Add("DEPT.M", "DEPT.M");
                }

                if ((startReadDescription == true && lasString.Contains("~")) | descriptionCount > 40)
                    startReadDescription = false;


                if (lasString.Replace(" ", "").Contains("~ASCII"))
                {
                    startReadLog = true;
                    linesCount++;
                    lasString = lines[linesCount];
                }

                if (startReadDescription)
                {
                    descriptionCount++;
                    if (descriptionCount != 1) CollectionsPointPairList.Add(new PointPairList());
                    char[] seps = { ':' };
                    string[] parts = lasString.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                    tempSeriesString = listBox1.Items[(listBox1.Items.Count - 1)].ToString() + "_" + parts[1];
                    checkedListBox1.Items.Add(tempSeriesString);
                    dataGridView1.Columns.Add(tempSeriesString, tempSeriesString);
                    Filename.CurveNames.Add(tempSeriesString);
                    CollectionsPointPairListNames.Add(tempSeriesString);
                }

                if (startReadLog == true)
                {
                    tempIcoming = new double[descriptionCount];
                    char[] seps = { ' ', '\t' };
                    lasString.Remove(0, 1);
                    string[] parts = lasString.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                    dataGridView1.Rows.Add();
                    for (int i = 0; i < descriptionCount; i++)
                    {
                        if (parts[i] != Filename.Null)
                            tempIcoming[i] = MainForm.ConvertToDouble(parts[i]);
                        else
                            tempIcoming[i] = double.NaN;
                        dataGridView1[i, RowsCount].Value = tempIcoming[i];
                        if (i > 0) CollectionsPointPairList[i - 1].Add(tempIcoming[i], tempIcoming[0]);
                    }
                    RowsCount++;
                    Filename.Dept.Add(tempIcoming);
                    Filename.DescriptionCount = descriptionCount;
                }
            }
            label1.Visible = false;
            progressBar1.Visible = false;
            tempIcoming = new double[descriptionCount];
            for (int i = 0; i < Filename.Dept.Count; i++)
            {
                tempIcoming = Filename.Dept[i];
            }
            RichTextBoxLasContent.Text = Filename.Body;
            PointPairList temp = new PointPairList();
            //for (int j = 1; j < descriptionCount; j++)
            //{
            //    temp.Clear();
            //    for (int jj = 0; jj < dataGridView1.RowCount; j++)
            //    {
            //        temp.Add(Convert.ToDouble(dataGridView1[12, j].Value), Convert.ToDouble(dataGridView1[0, j].Value));
            //    }
            //}
            Random rnd = new Random();
            for (int i = 1; i < descriptionCount; i++) DrawGraph(ZedGraphView, CollectionsPointPairListNames[i - 1], CollectionsPointPairList[i - 1], _colors[rnd.Next(_colors.Length)]);
            VisibleCurves();
        }

        Color[] _colors = new Color[] {Color.Black,
            Color.Blue,
            Color.Brown,
            Color.Gray,
            Color.Green,
            Color.Indigo,
            Color.Orange,
            Color.Red,
            Color.YellowGreen};
        private void OpenKorrection(string FilePath)
        {
            PointPairList tempPointPair = new PointPairList(CollectionsPointPairList[checkedListBox1.SelectedIndex]);
            CollectionsPointPairList.Add(new PointPairList());
            dataGridView1.Columns.Add("Корр." + checkedListBox1.SelectedItem.ToString(), "Корр." + checkedListBox1.SelectedItem.ToString());
            InStream = new StreamReader(FilePath, Encoding.GetEncoding(866));
            string lasString;
            lasString = InStream.ReadLine();

            checkedListBox1.Items.Add("Корр_" + checkedListBox1.SelectedItem.ToString());
            Random rnd = new Random();
            for (int i = 0; i < tempPointPair.Count; i++)
            {
                string[] parts = lasString.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (tempPointPair[i].Y > MainForm.ConvertToDouble(parts[0]))
                {
                    CollectionsPointPairList[CollectionsPointPairList.Count - 1].Add(tempPointPair[i].X, tempPointPair[i].Y);
                    dataGridView1[dataGridView1.ColumnCount - 1, i].Value = tempPointPair[i].X;
                }
                else
                {
                    CollectionsPointPairList[CollectionsPointPairList.Count - 1].Add(MainForm.ConvertToDouble(parts[1]), MainForm.ConvertToDouble(parts[0]));
                    dataGridView1[dataGridView1.ColumnCount - 1, i].Value = MainForm.ConvertToDouble(parts[1]);
                    try
                    {
                        lasString = InStream.ReadLine();
                    }
                    catch
                    {
                        while (i < tempPointPair.Count)
                        {
                            CollectionsPointPairList[CollectionsPointPairList.Count - 1].Add(tempPointPair[i].X, tempPointPair[i].Y);
                            dataGridView1[dataGridView1.ColumnCount - 1, i].Value = tempPointPair[i].X;
                        }
                    }
                }
            }
            DrawGraph(ZedGraphView, "Корр." + checkedListBox1.SelectedItem.ToString(), CollectionsPointPairList[CollectionsPointPairList.Count - 1], Color.Violet);

            //while (checkedListBox1.SelectedItem.ToString()!=CollectionsPointPairListNames[i]) i++;
            //DrawGraph(ZedGraphView, CollectionsPointPairListNames[i], CollectionsPointPairList[i], _colors[rnd.Next(_colors.Length)]);
            ////daw
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
            pane.XAxis.Title.Text = "Param";
            pane.YAxis.Title.Text = "DEPT";
            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика,
            // которая умещается в интервалы по осям, установленные по умолчанию
            // Обновляем график
            NameZedGraphControl.AxisChange();
            NameZedGraphControl.Invalidate();
        }
        private void FormOpenFile_Load(object sender, EventArgs e)
        {
            label1.Parent = progressBar1;
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.Visible = true;
                dataGridView2.Visible = false;
                RichTextBoxLasContent.Visible = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = false;
                RichTextBoxLasContent.Visible = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                RichTextBoxLasContent.Visible = false;
            }
        }
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RowsCount = 0;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("DEPT.M", "DEPT.M");
            int index = this.listBox1.IndexFromPoint(e.Location);
            RichTextBoxLasContent.Text = "";
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                for (int j = 1; j < LasFileCollections[index].DescriptionCount; j++)
                {
                    dataGridView1.Columns.Add(LasFileCollections[index].CurveNames[j - 1], LasFileCollections[index].CurveNames[j - 1]);
                }
                RichTextBoxLasContent.Text = LasFileCollections[index].Body;
                double[] tempIcoming = new double[LasFileCollections[index].DescriptionCount];
                for (int i = 0; i < LasFileCollections[index].Dept.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    tempIcoming = LasFileCollections[index].Dept[i];
                    for (int j = 0; j < LasFileCollections[index].DescriptionCount; j++)
                    {
                        dataGridView1[j, RowsCount].Value = tempIcoming[j];
                    }
                    RowsCount++;
                }
            }
        }
        private void GetCurveToManeOld(int y)
        {
            MainForm.richTextBoxIncoming.Text = "";
            PointPairList list = new PointPairList();
            list.Clear();
            string enter = "\r\n";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (i == 0) MainForm.textBox2.Text = dataGridView1[0, i].Value.ToString();

                if (i == dataGridView1.Rows.Count - 1)
                {
                    MainForm.textBox3.Text = dataGridView1[0, i].Value.ToString();
                    enter = "";
                }
                MainForm.IncomingParameters.Add(dataGridView1[0, i].Value + " " + dataGridView1[y, i].Value);
                MainForm.richTextBoxIncoming.Text += dataGridView1[0, i].Value + " " + dataGridView1[y, i].Value + enter;
                list.Add(MainForm.ConvertToDouble(dataGridView1[y, i].Value), MainForm.ConvertToDouble(dataGridView1[0, i].Value));
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Из Las файла", list, Color.Blue);
        }
        private void GetCurveToMane()
        {
            //MainForm.checkBoxFormat.Checked = true;
            MainForm.richTextBoxIncoming.Text = "";
            PointPairList list = new PointPairList();
            list.Clear();
            string enter = "\r\n";
            label1.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0;
            double progress = 0;
            double step = 100.0 / (dataGridView2.Rows.Count - 1);
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                progress += step;
                if (progress > 1)
                {
                    progress--;
                    progressBar1.Value++;
                }
                if (i == 0) MainForm.textBox2.Text = dataGridView1[0, i].Value.ToString();

                if (i == dataGridView1.Rows.Count - 1)
                {
                    MainForm.textBox3.Text = dataGridView1[0, i].Value.ToString();
                    enter = "";
                }
                MainForm.IncomingParameters.Add(dataGridView2[0, i].Value + " " + dataGridView2[1, i].Value + " " + dataGridView2[2, i].Value);
                MainForm.richTextBoxIncoming.Text += dataGridView2[0, i].Value + " " + dataGridView2[1, i].Value + " " + dataGridView2[2, i].Value + enter;
                list.Add(MainForm.ConvertToDouble(dataGridView2[2, i].Value), MainForm.ConvertToDouble(dataGridView2[0, i].Value));
            }
            MainForm.DrawGraph(MainForm.ZedGraphResult, "Из Las файла", list, Color.Blue);
            label1.Visible = false;
            progressBar1.Visible = false;
            this.Close();
        }

        private void GetFunctionParameters(int y, bool IfArgument)
        {
            int modificator = 2;
            if (IfArgument) modificator--;
            for (int i = 0; i < dataGridView2.RowCount; i++) dataGridView2[modificator, i].Value = double.NaN;
            if (dataGridView2.RowCount < 10)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, i].Value = dataGridView1[0, i].Value;
                    dataGridView2[modificator, i].Value = dataGridView1[y, i].Value;
                }
            }
            else
            {
                label1.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                double progress = 0;
                double step = 100.0 / (dataGridView2.Rows.Count - 1);
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    progress += step;
                    if (progress > 1)
                    {
                        progress--;
                        progressBar1.Value++;
                    }
                    bool dataNotEof = true;
                    int j = 0;
                    if (MainForm.ConvertToDouble(dataGridView2[0, i].Value) != MainForm.ConvertToDouble(dataGridView1[0, j].Value)) j = 0;
                    while (dataNotEof && (MainForm.ConvertToDouble(dataGridView2[0, i].Value) != MainForm.ConvertToDouble(dataGridView1[0, j].Value)))
                    {
                        j++;
                        if (j == dataGridView1.Rows.Count) dataNotEof = false;
                    }
                    if (dataNotEof) dataGridView2[modificator, i].Value = dataGridView1[y, j].Value;
                    else dataGridView2[modificator, i].Value = double.NaN;
                }
            }
            radioButton3.Checked = true;
            label1.Visible = false;
            progressBar1.Visible = false;
        }


        private void выбратьАргументФункцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Focused)
            {
                int descCount = 0;
                for (int index = 0; index < listBox1.Items.Count - 1; index++) descCount += LasFileCollections[index].DescriptionCount;
                GetFunctionParameters(checkedListBox1.SelectedIndex - descCount, true);
            }
            else GetFunctionParameters(dataGridView1.CurrentCell.ColumnIndex, true);
        }
        private void выбратьЗначенияФункцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.Focused)
            {
                int descCount = 0;
                for (int index = 0; index < listBox1.Items.Count - 1; index++) descCount += LasFileCollections[index].DescriptionCount;
                GetFunctionParameters(checkedListBox1.SelectedIndex - descCount, false);
            }
            else GetFunctionParameters(dataGridView1.CurrentCell.ColumnIndex, true);
        }
        private void перенестиНаГлавнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCurveToMane();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                LasFileCollections[LasFileCounts] = new LasParametrs();
                IdentificationLasFile(openFileDialog1.FileName, LasFileCollections[LasFileCounts]);
                LasFileCounts++;
            }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = 50;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(openFileDialog1.FileName));
                OpenKorrection(openFileDialog1.FileName);
            }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
                dataGridView1.Columns[i].Width = 50;
            checkedListBox1.SetItemChecked(checkedListBox1.Items.Count - 1, true);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void VisibleCurves()
        {
            Random rnd = new Random();
            for (int i = 0; i < ZedGraphView.GraphPane.CurveList.Count; i++)
            {
                ZedGraphView.GraphPane.CurveList[i].Label.IsVisible = false;
                ZedGraphView.GraphPane.CurveList[i].IsVisible = false;
            }

            foreach (int indexChecked in checkedListBox1.CheckedIndices)
            {
                ZedGraphView.GraphPane.CurveList[indexChecked].Label.IsVisible = true;
                ZedGraphView.GraphPane.CurveList[indexChecked].IsVisible = true;
            }
            ZedGraphView.GraphPane.AxisChange();
            ZedGraphView.Invalidate();
        }
        private void checkedListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            VisibleCurves();
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormOpenFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
