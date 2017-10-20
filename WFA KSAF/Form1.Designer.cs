using WFA.KSAF.Forms;

namespace WFA.KSAF
{
    partial class Form1
    {
        //my
        private FormTests _formTests;

        //^^^^^

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxLeafsCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxConvolution = new System.Windows.Forms.CheckBox();
            this.textBox1GrowSpeed = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxResolve = new System.Windows.Forms.RichTextBox();
            this.checkBoxHaveDept = new System.Windows.Forms.CheckBox();
            this.textBoxNMIteratoins = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIterationsCount = new System.Windows.Forms.TextBox();
            this.buttonStopEndScreen = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonTrim = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxIdeal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonStartAlgorithm = new System.Windows.Forms.Button();
            this.textBoxMutationChance = new System.Windows.Forms.TextBox();
            this.zedGraphIterations = new ZedGraph.ZedGraphControl();
            this.ZedGraphResult = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.конструкторАлгоритмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кодАлгоритмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коллекцияФенотиповToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ошибкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.потокиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.общиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxDesp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxPopulationSize = new System.Windows.Forms.TextBox();
            this.richTextBoxIncoming = new System.Windows.Forms.RichTextBox();
            this.buttonUseTestClass = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLeafsCount
            // 
            this.textBoxLeafsCount.Location = new System.Drawing.Point(384, 371);
            this.textBoxLeafsCount.Name = "textBoxLeafsCount";
            this.textBoxLeafsCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxLeafsCount.TabIndex = 119;
            this.textBoxLeafsCount.Text = "6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(384, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "Колличество констант";
            // 
            // checkBoxConvolution
            // 
            this.checkBoxConvolution.AutoSize = true;
            this.checkBoxConvolution.Location = new System.Drawing.Point(511, 34);
            this.checkBoxConvolution.Name = "checkBoxConvolution";
            this.checkBoxConvolution.Size = new System.Drawing.Size(68, 17);
            this.checkBoxConvolution.TabIndex = 118;
            this.checkBoxConvolution.Text = "Свертка";
            this.checkBoxConvolution.UseVisualStyleBackColor = true;
            // 
            // textBox1GrowSpeed
            // 
            this.textBox1GrowSpeed.Location = new System.Drawing.Point(385, 335);
            this.textBox1GrowSpeed.Name = "textBox1GrowSpeed";
            this.textBox1GrowSpeed.Size = new System.Drawing.Size(100, 20);
            this.textBox1GrowSpeed.TabIndex = 86;
            this.textBox1GrowSpeed.Text = "7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(385, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(180, 13);
            this.label11.TabIndex = 117;
            this.label11.Text = "Скорость роста генотипа (10 Max)";
            // 
            // richTextBoxResolve
            // 
            this.richTextBoxResolve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxResolve.Location = new System.Drawing.Point(889, 358);
            this.richTextBoxResolve.Name = "richTextBoxResolve";
            this.richTextBoxResolve.Size = new System.Drawing.Size(229, 315);
            this.richTextBoxResolve.TabIndex = 115;
            this.richTextBoxResolve.Text = "";
            // 
            // checkBoxHaveDept
            // 
            this.checkBoxHaveDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxHaveDept.AutoSize = true;
            this.checkBoxHaveDept.Location = new System.Drawing.Point(893, 3);
            this.checkBoxHaveDept.Name = "checkBoxHaveDept";
            this.checkBoxHaveDept.Size = new System.Drawing.Size(125, 17);
            this.checkBoxHaveDept.TabIndex = 114;
            this.checkBoxHaveDept.Text = "Строить по глубине";
            this.checkBoxHaveDept.UseVisualStyleBackColor = true;
            // 
            // textBoxNMIteratoins
            // 
            this.textBoxNMIteratoins.Location = new System.Drawing.Point(382, 434);
            this.textBoxNMIteratoins.Name = "textBoxNMIteratoins";
            this.textBoxNMIteratoins.Size = new System.Drawing.Size(100, 20);
            this.textBoxNMIteratoins.TabIndex = 113;
            this.textBoxNMIteratoins.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Максимум итераций, шт";
            // 
            // textBoxIterationsCount
            // 
            this.textBoxIterationsCount.Location = new System.Drawing.Point(385, 296);
            this.textBoxIterationsCount.Name = "textBoxIterationsCount";
            this.textBoxIterationsCount.Size = new System.Drawing.Size(100, 20);
            this.textBoxIterationsCount.TabIndex = 111;
            this.textBoxIterationsCount.Text = "10";
            // 
            // buttonStopEndScreen
            // 
            this.buttonStopEndScreen.Location = new System.Drawing.Point(502, 140);
            this.buttonStopEndScreen.Name = "buttonStopEndScreen";
            this.buttonStopEndScreen.Size = new System.Drawing.Size(75, 23);
            this.buttonStopEndScreen.TabIndex = 110;
            this.buttonStopEndScreen.Text = "Ответ";
            this.buttonStopEndScreen.UseVisualStyleBackColor = true;
            this.buttonStopEndScreen.Visible = false;
            this.buttonStopEndScreen.Click += new System.EventHandler(this.buttonStopEndScreen_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(382, 411);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 17);
            this.checkBox1.TabIndex = 109;
            this.checkBox1.Text = "Итерации Нелдора-Мида";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Location = new System.Drawing.Point(474, 644);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 108;
            this.button3.Text = "Свертка";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonTrim
            // 
            this.buttonTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTrim.Location = new System.Drawing.Point(303, 650);
            this.buttonTrim.Name = "buttonTrim";
            this.buttonTrim.Size = new System.Drawing.Size(75, 23);
            this.buttonTrim.TabIndex = 107;
            this.buttonTrim.Text = "Обрезать";
            this.buttonTrim.UseVisualStyleBackColor = true;
            this.buttonTrim.Click += new System.EventHandler(this.buttonTrim_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(379, 105);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(200, 23);
            this.progressBar1.TabIndex = 106;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(362, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 104;
            this.radioButton2.Text = "Рисование";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(362, 82);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 17);
            this.radioButton1.TabIndex = 103;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Масштабирование";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(385, 472);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 102;
            this.label8.Text = "Генератор функций от x";
            // 
            // TextBoxIdeal
            // 
            this.TextBoxIdeal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TextBoxIdeal.Location = new System.Drawing.Point(385, 488);
            this.TextBoxIdeal.Name = "TextBoxIdeal";
            this.TextBoxIdeal.Size = new System.Drawing.Size(194, 20);
            this.TextBoxIdeal.TabIndex = 101;
            this.TextBoxIdeal.Text = "Pow(x,3)+Pow(x,2)-280*x+1600";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 521);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 100;
            this.label5.Text = "Шаг";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Х-до";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 98;
            this.label3.Text = "Х-от";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearAll.Location = new System.Drawing.Point(486, 567);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(91, 23);
            this.buttonClearAll.TabIndex = 97;
            this.buttonClearAll.Text = "Очистить";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "Колличество ошибок:";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Location = new System.Drawing.Point(547, 518);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(30, 20);
            this.textBox4.TabIndex = 96;
            this.textBox4.Text = "1";
            // 
            // buttonStartAlgorithm
            // 
            this.buttonStartAlgorithm.Enabled = false;
            this.buttonStartAlgorithm.Location = new System.Drawing.Point(379, 30);
            this.buttonStartAlgorithm.Name = "buttonStartAlgorithm";
            this.buttonStartAlgorithm.Size = new System.Drawing.Size(126, 23);
            this.buttonStartAlgorithm.TabIndex = 83;
            this.buttonStartAlgorithm.Text = "Подобрать функцию";
            this.buttonStartAlgorithm.UseVisualStyleBackColor = true;
            this.buttonStartAlgorithm.Click += new System.EventHandler(this.buttonStartAlgorithm_Click);
            // 
            // textBoxMutationChance
            // 
            this.textBoxMutationChance.Location = new System.Drawing.Point(385, 218);
            this.textBoxMutationChance.Name = "textBoxMutationChance";
            this.textBoxMutationChance.Size = new System.Drawing.Size(100, 20);
            this.textBoxMutationChance.TabIndex = 82;
            this.textBoxMutationChance.Text = "10";
            // 
            // zedGraphIterations
            // 
            this.zedGraphIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphIterations.Location = new System.Drawing.Point(583, 22);
            this.zedGraphIterations.Name = "zedGraphIterations";
            this.zedGraphIterations.ScrollGrace = 0D;
            this.zedGraphIterations.ScrollMaxX = 0D;
            this.zedGraphIterations.ScrollMaxY = 0D;
            this.zedGraphIterations.ScrollMaxY2 = 0D;
            this.zedGraphIterations.ScrollMinX = 0D;
            this.zedGraphIterations.ScrollMinY = 0D;
            this.zedGraphIterations.ScrollMinY2 = 0D;
            this.zedGraphIterations.Size = new System.Drawing.Size(300, 651);
            this.zedGraphIterations.TabIndex = 80;
            // 
            // ZedGraphResult
            // 
            this.ZedGraphResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ZedGraphResult.Location = new System.Drawing.Point(7, 22);
            this.ZedGraphResult.Name = "ZedGraphResult";
            this.ZedGraphResult.ScrollGrace = 0D;
            this.ZedGraphResult.ScrollMaxX = 0D;
            this.ZedGraphResult.ScrollMaxY = 0D;
            this.ZedGraphResult.ScrollMaxY2 = 0D;
            this.ZedGraphResult.ScrollMinX = 0D;
            this.ZedGraphResult.ScrollMinY = 0D;
            this.ZedGraphResult.ScrollMinY2 = 0D;
            this.ZedGraphResult.Size = new System.Drawing.Size(371, 651);
            this.ZedGraphResult.TabIndex = 81;
            this.ZedGraphResult.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.ZedGraphResult_MouseDownEvent);
            this.ZedGraphResult.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.ZedGraphResult_MouseUpEvent);
            this.ZedGraphResult.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.ZedGraphResult_MouseMoveEvent);
            this.ZedGraphResult.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ZedGraphResult_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem,
            this.конструкторАлгоритмаToolStripMenuItem,
            this.кодАлгоритмаToolStripMenuItem,
            this.коллекцияФенотиповToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ошибкиToolStripMenuItem,
            this.тестированиеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 84;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьФайлToolStripMenuItem1});
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.открытьФайлToolStripMenuItem.Text = "Открыть";
            // 
            // открытьФайлToolStripMenuItem1
            // 
            this.открытьФайлToolStripMenuItem1.Name = "открытьФайлToolStripMenuItem1";
            this.открытьФайлToolStripMenuItem1.Size = new System.Drawing.Size(173, 22);
            this.открытьФайлToolStripMenuItem1.Text = "Открыть Las файл";
            // 
            // конструкторАлгоритмаToolStripMenuItem
            // 
            this.конструкторАлгоритмаToolStripMenuItem.Name = "конструкторАлгоритмаToolStripMenuItem";
            this.конструкторАлгоритмаToolStripMenuItem.Size = new System.Drawing.Size(151, 20);
            this.конструкторАлгоритмаToolStripMenuItem.Text = "Конструктор алгоритма";
            this.конструкторАлгоритмаToolStripMenuItem.Click += new System.EventHandler(this.конструкторАлгоритмаToolStripMenuItem_Click);
            // 
            // кодАлгоритмаToolStripMenuItem
            // 
            this.кодАлгоритмаToolStripMenuItem.Name = "кодАлгоритмаToolStripMenuItem";
            this.кодАлгоритмаToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.кодАлгоритмаToolStripMenuItem.Text = "Код алгоритма";
            this.кодАлгоритмаToolStripMenuItem.Click += new System.EventHandler(this.кодАлгоритмаToolStripMenuItem_Click);
            // 
            // коллекцияФенотиповToolStripMenuItem
            // 
            this.коллекцияФенотиповToolStripMenuItem.Name = "коллекцияФенотиповToolStripMenuItem";
            this.коллекцияФенотиповToolStripMenuItem.Size = new System.Drawing.Size(143, 20);
            this.коллекцияФенотиповToolStripMenuItem.Text = "Коллекция фенотипов";
            this.коллекцияФенотиповToolStripMenuItem.Click += new System.EventHandler(this.коллекцияФенотиповToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 20);
            this.toolStripMenuItem1.Text = "Свертка";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ошибкиToolStripMenuItem
            // 
            this.ошибкиToolStripMenuItem.Name = "ошибкиToolStripMenuItem";
            this.ошибкиToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.ошибкиToolStripMenuItem.Text = "Ошибки";
            this.ошибкиToolStripMenuItem.Click += new System.EventHandler(this.ошибкиToolStripMenuItem_Click);
            // 
            // тестированиеToolStripMenuItem
            // 
            this.тестированиеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.потокиToolStripMenuItem,
            this.общиеToolStripMenuItem});
            this.тестированиеToolStripMenuItem.Name = "тестированиеToolStripMenuItem";
            this.тестированиеToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.тестированиеToolStripMenuItem.Text = "Тестирование";
            this.тестированиеToolStripMenuItem.Click += new System.EventHandler(this.тестированиеToolStripMenuItem_Click);
            // 
            // потокиToolStripMenuItem
            // 
            this.потокиToolStripMenuItem.Name = "потокиToolStripMenuItem";
            this.потокиToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.потокиToolStripMenuItem.Text = "Потоки";
            this.потокиToolStripMenuItem.Click += new System.EventHandler(this.потокиToolStripMenuItem_Click);
            // 
            // общиеToolStripMenuItem
            // 
            this.общиеToolStripMenuItem.Name = "общиеToolStripMenuItem";
            this.общиеToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.общиеToolStripMenuItem.Text = "Общие";
            this.общиеToolStripMenuItem.Click += new System.EventHandler(this.общиеToolStripMenuItem_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(892, 342);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 116;
            this.label9.Text = "Полученные данные:";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox3.Location = new System.Drawing.Point(409, 541);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(63, 20);
            this.textBox3.TabIndex = 95;
            this.textBox3.Tag = "0";
            this.textBox3.Text = "-20";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox2.Location = new System.Drawing.Point(409, 518);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 20);
            this.textBox2.TabIndex = 94;
            this.textBox2.Tag = "25";
            this.textBox2.Text = "20";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 523);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 93;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonGenerate.Location = new System.Drawing.Point(384, 567);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(82, 23);
            this.buttonGenerate.TabIndex = 92;
            this.buttonGenerate.Text = "Вывести";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // textBoxDesp
            // 
            this.textBoxDesp.Location = new System.Drawing.Point(385, 166);
            this.textBoxDesp.Name = "textBoxDesp";
            this.textBoxDesp.Size = new System.Drawing.Size(100, 20);
            this.textBoxDesp.TabIndex = 91;
            this.textBoxDesp.Tag = "";
            this.textBoxDesp.Text = "1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(385, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 27);
            this.label6.TabIndex = 90;
            this.label6.Tag = "grdgrdgdr";
            this.label6.Text = "Макс. допустимое кв. отклонение";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(385, 202);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 89;
            this.label10.Text = "Шанс мутации, %";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(385, 241);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 88;
            this.label12.Text = "Размер популяции, шт";
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Location = new System.Drawing.Point(385, 257);
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxPopulationSize.TabIndex = 87;
            this.textBoxPopulationSize.Text = "200";
            // 
            // richTextBoxIncoming
            // 
            this.richTextBoxIncoming.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxIncoming.Location = new System.Drawing.Point(889, 22);
            this.richTextBoxIncoming.Name = "richTextBoxIncoming";
            this.richTextBoxIncoming.Size = new System.Drawing.Size(230, 315);
            this.richTextBoxIncoming.TabIndex = 85;
            this.richTextBoxIncoming.Text = "";
            this.richTextBoxIncoming.TextChanged += new System.EventHandler(this.richTextBoxIncoming_TextChanged);
            this.richTextBoxIncoming.DoubleClick += new System.EventHandler(this.richTextBoxIncoming_DoubleClick);
            // 
            // buttonUseTestClass
            // 
            this.buttonUseTestClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUseTestClass.Location = new System.Drawing.Point(385, 644);
            this.buttonUseTestClass.Name = "buttonUseTestClass";
            this.buttonUseTestClass.Size = new System.Drawing.Size(83, 23);
            this.buttonUseTestClass.TabIndex = 105;
            this.buttonUseTestClass.Text = "UseTestClass";
            this.buttonUseTestClass.UseVisualStyleBackColor = false;
            this.buttonUseTestClass.Click += new System.EventHandler(this.buttonUseTestClass_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 676);
            this.Controls.Add(this.textBoxLeafsCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBoxConvolution);
            this.Controls.Add(this.textBox1GrowSpeed);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.richTextBoxResolve);
            this.Controls.Add(this.checkBoxHaveDept);
            this.Controls.Add(this.textBoxNMIteratoins);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIterationsCount);
            this.Controls.Add(this.buttonStopEndScreen);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonTrim);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TextBoxIdeal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.buttonStartAlgorithm);
            this.Controls.Add(this.textBoxMutationChance);
            this.Controls.Add(this.zedGraphIterations);
            this.Controls.Add(this.ZedGraphResult);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.textBoxDesp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Controls.Add(this.richTextBoxIncoming);
            this.Controls.Add(this.buttonUseTestClass);
            this.Name = "Form1";
            this.Text = "К.С.А.Ф. v7.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxLeafsCount;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.CheckBox checkBoxConvolution;
        public System.Windows.Forms.TextBox textBox1GrowSpeed;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.RichTextBox richTextBoxResolve;
        public System.Windows.Forms.CheckBox checkBoxHaveDept;
        public System.Windows.Forms.TextBox textBoxNMIteratoins;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIterationsCount;
        public System.Windows.Forms.Button buttonStopEndScreen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonTrim;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxIdeal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button buttonStartAlgorithm;
        public System.Windows.Forms.TextBox textBoxMutationChance;
        public ZedGraph.ZedGraphControl zedGraphIterations;
        public ZedGraph.ZedGraphControl ZedGraphResult;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem конструкторАлгоритмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кодАлгоритмаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem коллекцияФенотиповToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxDesp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBoxPopulationSize;
        public System.Windows.Forms.RichTextBox richTextBoxIncoming;
        private System.Windows.Forms.Button buttonUseTestClass;
        private System.Windows.Forms.ToolStripMenuItem тестированиеToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ошибкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem потокиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem общиеToolStripMenuItem;
    }
}

