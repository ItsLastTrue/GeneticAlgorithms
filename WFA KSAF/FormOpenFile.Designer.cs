namespace WFA.KSAF
{
    partial class FormOpenFile
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
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.ZedGraphView = new ZedGraph.ZedGraphControl();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.выбратьАргументФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выбратьЗначенияФункцииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перенестиНаГлавнуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RichTextBoxLasContent = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(244, 259);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(568, 34);
            this.progressBar1.TabIndex = 26;
            this.progressBar1.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(595, 9);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(127, 17);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.Text = "Аргументы функции";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // ZedGraphView
            // 
            this.ZedGraphView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ZedGraphView.Location = new System.Drawing.Point(762, 9);
            this.ZedGraphView.Name = "ZedGraphView";
            this.ZedGraphView.ScrollGrace = 0D;
            this.ZedGraphView.ScrollMaxX = 0D;
            this.ZedGraphView.ScrollMaxY = 0D;
            this.ZedGraphView.ScrollMaxY2 = 0D;
            this.ZedGraphView.ScrollMinX = 0D;
            this.ZedGraphView.ScrollMinY = 0D;
            this.ZedGraphView.ScrollMinY2 = 0D;
            this.ZedGraphView.Size = new System.Drawing.Size(371, 642);
            this.ZedGraphView.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(138, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Открыть корректирующую";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "Открыть LAS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(484, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Обработка данных";
            this.label1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(458, 9);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(93, 17);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "Весь контент";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(310, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(433, 611);
            this.dataGridView1.TabIndex = 16;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьАргументФункцииToolStripMenuItem,
            this.выбратьЗначенияФункцииToolStripMenuItem,
            this.перенестиНаГлавнуюToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(228, 70);
            // 
            // выбратьАргументФункцииToolStripMenuItem
            // 
            this.выбратьАргументФункцииToolStripMenuItem.Name = "выбратьАргументФункцииToolStripMenuItem";
            this.выбратьАргументФункцииToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.выбратьАргументФункцииToolStripMenuItem.Text = "Выбрать аргумент функции";
            // 
            // выбратьЗначенияФункцииToolStripMenuItem
            // 
            this.выбратьЗначенияФункцииToolStripMenuItem.Name = "выбратьЗначенияФункцииToolStripMenuItem";
            this.выбратьЗначенияФункцииToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.выбратьЗначенияФункцииToolStripMenuItem.Text = "Выбрать значения функции";
            // 
            // перенестиНаГлавнуюToolStripMenuItem
            // 
            this.перенестиНаГлавнуюToolStripMenuItem.Name = "перенестиНаГлавнуюToolStripMenuItem";
            this.перенестиНаГлавнуюToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.перенестиНаГлавнуюToolStripMenuItem.Text = "Перенести на главную";
            // 
            // RichTextBoxLasContent
            // 
            this.RichTextBoxLasContent.Location = new System.Drawing.Point(310, 41);
            this.RichTextBoxLasContent.Name = "RichTextBoxLasContent";
            this.RichTextBoxLasContent.Size = new System.Drawing.Size(433, 611);
            this.RichTextBoxLasContent.TabIndex = 19;
            this.RichTextBoxLasContent.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(310, 9);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(124, 17);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Данные с датчиков";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.HorizontalScrollbar = true;
            this.checkedListBox1.Location = new System.Drawing.Point(8, 243);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(281, 409);
            this.checkedListBox1.TabIndex = 15;
            this.checkedListBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkedListBox1_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(8, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(281, 199);
            this.listBox1.TabIndex = 14;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Location = new System.Drawing.Point(310, 41);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.Size = new System.Drawing.Size(433, 611);
            this.dataGridView2.TabIndex = 23;
            // 
            // FormOpenFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 661);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.ZedGraphView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RichTextBoxLasContent);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FormOpenFile";
            this.Text = "FormOpenFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOpenFile_FormClosing);
            this.Load += new System.EventHandler(this.FormOpenFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButton3;
        public ZedGraph.ZedGraphControl ZedGraphView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выбратьАргументФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выбратьЗначенияФункцииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перенестиНаГлавнуюToolStripMenuItem;
        private System.Windows.Forms.RichTextBox RichTextBoxLasContent;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}