using CL.KSAF.Entities;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using WFA.KSAF.Forms;

namespace WFA.KSAF
{
    public partial class FormErrors : Form
    {
        private readonly FormMainUi _mainForm;

        public FormErrors(FormMainUi mainform)
        {
            InitializeComponent();
            _mainForm = mainform;
        }

        private SelectionStatus Status => _mainForm.SelectionManager.Status;

        private void FormErrors_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void FormErrors_VisibleChanged(object sender, EventArgs e)
        {
            if (Status is null) return;
            if (Status.Log.CompileErrors.Count == 0)
            {
                richTextBox1.Text = @"Ошибок нет";
                return;
            }

            listBox1.Items.Clear();
            foreach (var onestr in Status.Log.CompileErrors)
            {
                Debug.Assert(onestr.Iteration != null, "onestr.Iteration != null");
                listBox1.Items.Add(onestr.Iteration);
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (var err in Status.Log.CompileErrors)
            {
                if (err.Iteration == Convert.ToInt32(listBox1.SelectedItem))
                    richTextBox1.Text = err.Code + "\r\n\r\n" + err.ErrorText;
            }
        }

        private void FormErrors_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
