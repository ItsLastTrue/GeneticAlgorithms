namespace WFA.KSAF
{
    partial class FormAlgorithmCode
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
            this.richTextBoxClassCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxClassCode
            // 
            this.richTextBoxClassCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxClassCode.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxClassCode.Name = "richTextBoxClassCode";
            this.richTextBoxClassCode.Size = new System.Drawing.Size(1093, 692);
            this.richTextBoxClassCode.TabIndex = 42;
            this.richTextBoxClassCode.Text = "";
            // 
            // FormAlgorithmCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 692);
            this.Controls.Add(this.richTextBoxClassCode);
            this.Name = "FormAlgorithmCode";
            this.Text = "FormAlgorithmCode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAlgorithmCode_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBoxClassCode;
    }
}