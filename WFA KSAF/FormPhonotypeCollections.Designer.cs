namespace WFA.KSAF
{
    partial class FormPhonotypeCollections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextPhenotypes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextPhenotypes
            // 
            this.richTextPhenotypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextPhenotypes.Location = new System.Drawing.Point(0, 0);
            this.richTextPhenotypes.Name = "richTextPhenotypes";
            this.richTextPhenotypes.Size = new System.Drawing.Size(996, 685);
            this.richTextPhenotypes.TabIndex = 55;
            this.richTextPhenotypes.Text = "";
            // 
            // FormPhonotypeCollections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 685);
            this.Controls.Add(this.richTextPhenotypes);
            this.Name = "FormPhonotypeCollections";
            this.Text = "FormPhonotypeCollections";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPhonotypeCollections_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextPhenotypes;
    }
}