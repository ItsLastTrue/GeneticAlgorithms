using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WFA.KSAF
{
    public class CurveInformation
    {
        //string MNEM;
        //string Unit;
        //string CURVEDESCRIPTION;
        //int TabNum;
    }

    public class LasParametrs
    {
        public string Body;
        public int DescriptionCount;
        public List<CurveInformation> Names = new List<CurveInformation>();
        public List<string> CurveNames = new List<string>();
        public double WellCategory;
        public double WellDiameter;
        public string Null;
        public List<double[]> Dept = new List<double[]>();
    }

    internal class DialogForm : Form
    {
        private readonly Form1 _mainForm;

        public Label Label1;
        public TextBox Textbox1;
        public Label LabelTime;
        public Label LabelElaps;
        public Label Label2;
        private Button _button1;
        private Button _button2;
        private Button _button3;

        public DialogForm(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Visible = false;
        }

        private void InitializeComponent()
        {
            Name = "myForm";
            Text = "Новая форма";
            CenterToScreen();
            Width = 285;
            Height = 240;
            FormClosing += Form1_FormClosing;

            Label2 = new Label
            {
                Name = "label2",
                Text = "sadda",
                Location = new Point(10, 10),
                AutoSize = true
            };
            Controls.Add(Label2);

            Label1 = new Label
            {
                Name = "label1",
                Text = "sadda",
                Location = new Point(10, 30),
                AutoSize = true
            };
            Controls.Add(Label1);

            Textbox1 = new TextBox
            {
                Name = "textbox1",
                Text = "sadda",
                Width = 250,
                Height = 100,
                Multiline = true,
                Location = new Point(10, 50)
            };
            Controls.Add(Textbox1);

            _button1 = new Button
            {
                Name = "button1",
                Text = "Остановить",
                Width = 81,
                Height = 23,
                Location = new Point(180, 160)
            };
            Controls.Add(_button1);
            _button1.Click += Button1_Click;

            _button2 = new Button
            {
                Name = "button2",
                Text = "Продолжить",
                Width = 80,
                Height = 23,
                Location = new Point(10, 160)
            };
            Controls.Add(_button2);
            _button2.Click += Button2_Click;

            _button3 = new Button
            {
                Name = "button3",
                Text = "Пауза",
                Width = 80,
                Height = 23,
                Location = new Point(95, 160)
            };
            Controls.Add(_button3);
            _button3.Click += Button3_Click;

            LabelTime = new Label
            {
                Name = "label1",
                Text = "Затрачено времени:",
                Location = new Point(10, 187),
                AutoSize = true
            };
            Controls.Add(LabelTime);

            LabelElaps = new Label
            {
                Name = "labelElaps",
                Text = "",
                Location = new Point(119, 187),
                AutoSize = true
            };
            Controls.Add(LabelElaps);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _mainForm.IsSelectionContinues = true;
            _mainForm.RuletIterationsLoop();
        }

        private void Button1_Click(object sender, EventArgs e) =>
            _mainForm.HaveSolution();
     
        private void Button3_Click(object sender, EventArgs e) =>
            Visible = false;
    }
}
