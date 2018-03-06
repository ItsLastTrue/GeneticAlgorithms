using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WFA.KSAF
{
    public partial class FormErrors : Form
    {
        private readonly Form1 _mainForm;
        public FormErrors(Form1 mainform)
        {
            InitializeComponent();
            _mainForm = mainform;
        }

        private void FormErrors_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormErrors_VisibleChanged(object sender, EventArgs e)
        {
            if (_mainForm.PopulationCreator is null) return;
            if (_mainForm.PopulationCreator.Log.CompileErrors.Count == 0) return;

            listBox1.Items.Clear();
            foreach (var onestr in _mainForm.PopulationCreator.Log.CompileErrors)
            {
                Debug.Assert(onestr.Iteration != null, "onestr.Iteration != null");
                listBox1.Items.Add(onestr.Iteration);
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var err in _mainForm.PopulationCreator.Log.CompileErrors)
            {
                if (err.Iteration == Convert.ToInt32(listBox1.SelectedItem))
                    richTextBox1.Text = err.Code + "\r\n\r\n" + err.ErrorText;
            }
        }

        private void FormErrors_Load(object sender, EventArgs e)
        {

        }
    }
}
