using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA.KSAF
{
    public partial class FormPhonotypeCollections : Form
    {
        public FormPhonotypeCollections()
        {
            InitializeComponent();
        }
        private void FormPhonotypeCollections_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
