using System;
using System.Drawing;
using System.Windows.Forms;

namespace WFA.KSAF.Forms
{
    public sealed class FormDialog : Form
    {
        private readonly FormMainUi _formMainUi;

        public Label LabelCurrentDeviation;
        public TextBox TextboxBestPhenotype;
        public Label LabelElapsedTime;
        public Label LabelElaps;
        public Label LabelStatusText;
        private Button _buttonEnd;
        private Button _buttonContinue;
        private Button _buttonPause;

        public FormDialog(FormMainUi formMainUi)
        {
            InitializeComponent();
            _formMainUi = formMainUi;
        }

        private void FormMainUi_FormClosing(object sender, FormClosingEventArgs e)
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
            FormClosing += FormMainUi_FormClosing;

            LabelStatusText = new Label
            {
                Name = "label2",
                Text = "sadda",
                Location = new Point(10, 10),
                AutoSize = true
            };
            Controls.Add(LabelStatusText);

            LabelCurrentDeviation = new Label
            {
                Name = "label1",
                Text = "sadda",
                Location = new Point(10, 30),
                AutoSize = true
            };
            Controls.Add(LabelCurrentDeviation);

            TextboxBestPhenotype = new TextBox
            {
                Name = "textbox1",
                Text = "sadda",
                Width = 250,
                Height = 100,
                Multiline = true,
                Location = new Point(10, 50)
            };
            Controls.Add(TextboxBestPhenotype);

            _buttonEnd = new Button
            {
                Name = "button1",
                Text = "Остановить",
                Width = 81,
                Height = 23,
                Location = new Point(180, 160)
            };
            Controls.Add(_buttonEnd);
            _buttonEnd.Click += ButtonEndClick;

            _buttonContinue = new Button
            {
                Name = "button2",
                Text = "Продолжить",
                Width = 80,
                Height = 23,
                Location = new Point(10, 160)
            };
            Controls.Add(_buttonContinue);
            _buttonContinue.Click += ButtonContinueClick;

            _buttonPause = new Button
            {
                Name = "button3",
                Text = "Пауза",
                Width = 80,
                Height = 23,
                Location = new Point(95, 160)
            };
            Controls.Add(_buttonPause);
            _buttonPause.Click += ButtonPauseClick;

            LabelElapsedTime = new Label
            {
                Name = "label1",
                Text = "Затрачено времени:",
                Location = new Point(10, 187),
                AutoSize = true
            };
            Controls.Add(LabelElapsedTime);

            LabelElaps = new Label
            {
                Name = "labelElaps",
                Text = "",
                Location = new Point(119, 187),
                AutoSize = true
            };
            Controls.Add(LabelElaps);
        }

        private void ButtonContinueClick(object sender, EventArgs e)
        {
            //_mainForm.IsSelectionContinues = true;
            _formMainUi.ContinueIterationsLoop();
        }

        private void ButtonEndClick(object sender, EventArgs e) =>
            _formMainUi.HaveSolution();

        private void ButtonPauseClick(object sender, EventArgs e)
        {
            _formMainUi.PauseIterationsLoop();
            Visible = false;
        }
    }
}