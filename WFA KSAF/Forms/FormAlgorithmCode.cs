using System;
using System.Linq;
using System.Windows.Forms;

namespace WFA.KSAF.Forms
{
    public partial class FormAlgorithmCode : Form
    {
        private readonly FormMainUi _formMainUi;

        public FormAlgorithmCode(FormMainUi formMainUi)
        {
            _formMainUi = formMainUi;
            InitializeComponent();
        }

        private void FormAlgorithmCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void FormAlgorithmCode_VisibleChanged(object sender, EventArgs e) =>
            richTextBoxClassCode.Text = _formMainUi.SelectionManager.Status.CodeList
                .Aggregate(string.Empty, (all, next) => all + "\r\n--------------------------------\r\n" + next);
    }
}
