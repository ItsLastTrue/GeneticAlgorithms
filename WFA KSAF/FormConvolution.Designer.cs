namespace WFA.KSAF
{
    partial class FormConvolution
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOperFunc = new System.Windows.Forms.TextBox();
            this.textBoxIncFunc = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxOpRange = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOutRange = new System.Windows.Forms.TextBox();
            this.textBoxIncRange = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBoxConvolution = new System.Windows.Forms.RichTextBox();
            this.richTextBoxOperator = new System.Windows.Forms.RichTextBox();
            this.richTextBoxIncoming = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(322, 514);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 176;
            this.textBox1.Text = "25";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(167, 516);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(127, 23);
            this.button7.TabIndex = 175;
            this.button7.Text = "Random";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(400, 464);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(186, 23);
            this.button6.TabIndex = 174;
            this.button6.Text = "Цифровой фильтр";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(400, 435);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(186, 23);
            this.button5.TabIndex = 173;
            this.button5.Text = "Рекурсивный фильтр";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 172;
            this.label8.Text = "Операторы";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(319, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 171;
            this.label7.Text = "Исходящая";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 170;
            this.label6.Text = "Входящая";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(178, 464);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 169;
            this.button4.Text = "Оператор";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 521);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 168;
            this.label4.Text = "Х-до";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 167;
            this.label3.Text = "Х-от";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 166;
            this.label5.Text = "Шаг";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(212, 493);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(30, 20);
            this.textBox4.TabIndex = 165;
            this.textBox4.Text = "0,1";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(40, 516);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(63, 20);
            this.textBox3.TabIndex = 164;
            this.textBox3.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(40, 493);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(63, 20);
            this.textBox5.TabIndex = 163;
            this.textBox5.Text = "25";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 162;
            // 
            // textBoxOperFunc
            // 
            this.textBoxOperFunc.Location = new System.Drawing.Point(178, 438);
            this.textBoxOperFunc.Name = "textBoxOperFunc";
            this.textBoxOperFunc.Size = new System.Drawing.Size(100, 20);
            this.textBoxOperFunc.TabIndex = 161;
            this.textBoxOperFunc.Text = "EXP(-0.2*x)";
            // 
            // textBoxIncFunc
            // 
            this.textBoxIncFunc.Location = new System.Drawing.Point(12, 438);
            this.textBoxIncFunc.Name = "textBoxIncFunc";
            this.textBoxIncFunc.Size = new System.Drawing.Size(144, 20);
            this.textBoxIncFunc.TabIndex = 160;
            this.textBoxIncFunc.Text = "Pow(x,2.39)-Cos(x)*195.50";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 464);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 159;
            this.button3.Text = "Входящая";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(462, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 23);
            this.button2.TabIndex = 158;
            this.button2.Text = "Обратная задача";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(459, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 157;
            this.label1.Text = "Длина оператора";
            // 
            // textBoxOpRange
            // 
            this.textBoxOpRange.Enabled = false;
            this.textBoxOpRange.Location = new System.Drawing.Point(462, 77);
            this.textBoxOpRange.Name = "textBoxOpRange";
            this.textBoxOpRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxOpRange.TabIndex = 156;
            this.textBoxOpRange.Text = "3";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(459, 100);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(127, 13);
            this.label15.TabIndex = 155;
            this.label15.Text = "Окресности исходящей";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(459, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 13);
            this.label14.TabIndex = 154;
            this.label14.Text = "Окресности входящей";
            // 
            // textBoxOutRange
            // 
            this.textBoxOutRange.Enabled = false;
            this.textBoxOutRange.Location = new System.Drawing.Point(462, 116);
            this.textBoxOutRange.Name = "textBoxOutRange";
            this.textBoxOutRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxOutRange.TabIndex = 153;
            this.textBoxOutRange.Text = "6";
            // 
            // textBoxIncRange
            // 
            this.textBoxIncRange.Enabled = false;
            this.textBoxIncRange.Location = new System.Drawing.Point(462, 38);
            this.textBoxIncRange.Name = "textBoxIncRange";
            this.textBoxIncRange.Size = new System.Drawing.Size(100, 20);
            this.textBoxIncRange.TabIndex = 152;
            this.textBoxIncRange.Text = "4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 151;
            this.button1.Text = "Прямая задача";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxConvolution
            // 
            this.richTextBoxConvolution.Location = new System.Drawing.Point(312, 22);
            this.richTextBoxConvolution.Name = "richTextBoxConvolution";
            this.richTextBoxConvolution.Size = new System.Drawing.Size(144, 192);
            this.richTextBoxConvolution.TabIndex = 150;
            this.richTextBoxConvolution.Text = "5 -2\n4 5\n3 6\n2 2\n1 1\n0 -2";
            // 
            // richTextBoxOperator
            // 
            this.richTextBoxOperator.Location = new System.Drawing.Point(12, 235);
            this.richTextBoxOperator.Name = "richTextBoxOperator";
            this.richTextBoxOperator.Size = new System.Drawing.Size(681, 186);
            this.richTextBoxOperator.TabIndex = 149;
            this.richTextBoxOperator.Text = "0.25 0.25 0.25 0.25";
            // 
            // richTextBoxIncoming
            // 
            this.richTextBoxIncoming.Location = new System.Drawing.Point(12, 22);
            this.richTextBoxIncoming.Name = "richTextBoxIncoming";
            this.richTextBoxIncoming.Size = new System.Drawing.Size(144, 192);
            this.richTextBoxIncoming.TabIndex = 148;
            this.richTextBoxIncoming.Text = "3 -1\n2 3\n1 1\n0 2";
            // 
            // FormConvolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 555);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxOperFunc);
            this.Controls.Add(this.textBoxIncFunc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOpRange);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxOutRange);
            this.Controls.Add(this.textBoxIncRange);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBoxConvolution);
            this.Controls.Add(this.richTextBoxOperator);
            this.Controls.Add(this.richTextBoxIncoming);
            this.Name = "FormConvolution";
            this.Text = "FormConvolution";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormConvolution_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOperFunc;
        private System.Windows.Forms.TextBox textBoxIncFunc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxOpRange;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxOutRange;
        private System.Windows.Forms.TextBox textBoxIncRange;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.RichTextBox richTextBoxConvolution;
        private System.Windows.Forms.RichTextBox richTextBoxOperator;
        public System.Windows.Forms.RichTextBox richTextBoxIncoming;
    }
}