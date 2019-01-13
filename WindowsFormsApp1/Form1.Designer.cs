namespace WindowsFormsApp1
{
    partial class Form1
    {
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.мнемокод = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mEMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.instructionBTN = new System.Windows.Forms.Button();
            this.FlagS = new System.Windows.Forms.CheckBox();
            this.FlagZ = new System.Windows.Forms.CheckBox();
            this.FlagP = new System.Windows.Forms.CheckBox();
            this.FlagAC = new System.Windows.Forms.CheckBox();
            this.FlagC = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нToolStripMenuItem = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.ассемблерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клавиатураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестоваяформаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skipcmd = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.TimerPeriod = new System.Windows.Forms.NumericUpDown();
            this.CmdMOdebtn = new System.Windows.Forms.RadioButton();
            this.AutomaticModebtn = new System.Windows.Forms.RadioButton();
            this.GuiRegPC = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegSP = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegL = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegH = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegE = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegD = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegC = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegB = new WindowsFormsApp1.HexNumericUpDown();
            this.GuiRegA = new WindowsFormsApp1.HexNumericUpDown();
            this.MemAddrBeg = new WindowsFormsApp1.HexNumericUpDown();
            this.form1BindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEMBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skipcmd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemAddrBeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "адрес памяти";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addr,
            this.data,
            this.мнемокод});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(174, 521);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // addr
            // 
            this.addr.HeaderText = "addr";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            this.addr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.addr.Width = 40;
            // 
            // data
            // 
            this.data.HeaderText = "data";
            this.data.Name = "data";
            this.data.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.data.Width = 40;
            // 
            // мнемокод
            // 
            this.мнемокод.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.мнемокод.HeaderText = "мнемокод";
            this.мнемокод.Name = "мнемокод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(202, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(266, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(389, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "D";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "E";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "H";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "L";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(410, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "PC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(327, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "SP";
            // 
            // instructionBTN
            // 
            this.instructionBTN.Location = new System.Drawing.Point(367, 127);
            this.instructionBTN.Name = "instructionBTN";
            this.instructionBTN.Size = new System.Drawing.Size(75, 23);
            this.instructionBTN.TabIndex = 22;
            this.instructionBTN.Text = "Пуск";
            this.instructionBTN.UseVisualStyleBackColor = true;
            this.instructionBTN.Click += new System.EventHandler(this.instructionBTN_Click);
            // 
            // FlagS
            // 
            this.FlagS.AutoSize = true;
            this.FlagS.Location = new System.Drawing.Point(228, 33);
            this.FlagS.Name = "FlagS";
            this.FlagS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FlagS.Size = new System.Drawing.Size(33, 17);
            this.FlagS.TabIndex = 23;
            this.FlagS.Text = "S";
            this.FlagS.UseVisualStyleBackColor = true;
            this.FlagS.CheckedChanged += new System.EventHandler(this.FlagS_CheckedChanged);
            // 
            // FlagZ
            // 
            this.FlagZ.AutoSize = true;
            this.FlagZ.Location = new System.Drawing.Point(267, 33);
            this.FlagZ.Name = "FlagZ";
            this.FlagZ.Size = new System.Drawing.Size(33, 17);
            this.FlagZ.TabIndex = 24;
            this.FlagZ.Text = "Z";
            this.FlagZ.UseVisualStyleBackColor = true;
            this.FlagZ.CheckedChanged += new System.EventHandler(this.FlagZ_CheckedChanged);
            // 
            // FlagP
            // 
            this.FlagP.AutoSize = true;
            this.FlagP.Location = new System.Drawing.Point(352, 33);
            this.FlagP.Name = "FlagP";
            this.FlagP.Size = new System.Drawing.Size(33, 17);
            this.FlagP.TabIndex = 25;
            this.FlagP.Text = "P";
            this.FlagP.UseVisualStyleBackColor = true;
            this.FlagP.CheckedChanged += new System.EventHandler(this.FlagP_CheckedChanged);
            // 
            // FlagAC
            // 
            this.FlagAC.AutoSize = true;
            this.FlagAC.Location = new System.Drawing.Point(306, 33);
            this.FlagAC.Name = "FlagAC";
            this.FlagAC.Size = new System.Drawing.Size(40, 17);
            this.FlagAC.TabIndex = 26;
            this.FlagAC.Text = "AC";
            this.FlagAC.UseVisualStyleBackColor = true;
            this.FlagAC.CheckedChanged += new System.EventHandler(this.FlagAC_CheckedChanged);
            // 
            // FlagC
            // 
            this.FlagC.AutoSize = true;
            this.FlagC.Location = new System.Drawing.Point(391, 33);
            this.FlagC.Name = "FlagC";
            this.FlagC.Size = new System.Drawing.Size(33, 17);
            this.FlagC.TabIndex = 27;
            this.FlagC.Text = "C";
            this.FlagC.UseVisualStyleBackColor = true;
            this.FlagC.CheckedChanged += new System.EventHandler(this.FlagC_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Флаги";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.правкаToolStripMenuItem,
            this.ассемблерToolStripMenuItem,
            this.клавиатураToolStripMenuItem,
            this.тестоваяформаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нToolStripMenuItem,
            this.toolStripTextBox1,
            this.toolStripComboBox1});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.правкаToolStripMenuItem.Text = "Файл";
            // 
            // нToolStripMenuItem
            // 
            this.нToolStripMenuItem.Name = "нToolStripMenuItem";
            this.нToolStripMenuItem.Size = new System.Drawing.Size(180, 23);
            this.нToolStripMenuItem.Text = "н";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(240, 22);
            this.toolStripTextBox1.Text = "Выход";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            // 
            // ассемблерToolStripMenuItem
            // 
            this.ассемблерToolStripMenuItem.Name = "ассемблерToolStripMenuItem";
            this.ассемблерToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.ассемблерToolStripMenuItem.Text = "Ассемблер";
            this.ассемблерToolStripMenuItem.Click += new System.EventHandler(this.ассемблерToolStripMenuItem_Click);
            // 
            // клавиатураToolStripMenuItem
            // 
            this.клавиатураToolStripMenuItem.Name = "клавиатураToolStripMenuItem";
            this.клавиатураToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.клавиатураToolStripMenuItem.Text = "Средства стенда";
            this.клавиатураToolStripMenuItem.Click += new System.EventHandler(this.клавиатураToolStripMenuItem_Click);
            // 
            // тестоваяформаToolStripMenuItem
            // 
            this.тестоваяформаToolStripMenuItem.Name = "тестоваяформаToolStripMenuItem";
            this.тестоваяформаToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.тестоваяформаToolStripMenuItem.Text = "тестовая_форма";
            this.тестоваяформаToolStripMenuItem.Click += new System.EventHandler(this.тестоваяформаToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skipcmd);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.msLabel);
            this.groupBox1.Controls.Add(this.intervalLabel);
            this.groupBox1.Controls.Add(this.TimerPeriod);
            this.groupBox1.Controls.Add(this.CmdMOdebtn);
            this.groupBox1.Controls.Add(this.AutomaticModebtn);
            this.groupBox1.Location = new System.Drawing.Point(205, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 110);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режим работы";
            // 
            // skipcmd
            // 
            this.skipcmd.Location = new System.Drawing.Point(68, 68);
            this.skipcmd.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.skipcmd.Name = "skipcmd";
            this.skipcmd.Size = new System.Drawing.Size(58, 20);
            this.skipcmd.TabIndex = 6;
            this.skipcmd.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Пропуск";
            this.label12.Visible = false;
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(129, 44);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(21, 13);
            this.msLabel.TabIndex = 4;
            this.msLabel.Text = "мс";
            this.msLabel.Visible = false;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(6, 44);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(56, 13);
            this.intervalLabel.TabIndex = 3;
            this.intervalLabel.Text = "Интервал";
            this.intervalLabel.Visible = false;
            // 
            // TimerPeriod
            // 
            this.TimerPeriod.Location = new System.Drawing.Point(68, 42);
            this.TimerPeriod.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.TimerPeriod.Name = "TimerPeriod";
            this.TimerPeriod.Size = new System.Drawing.Size(58, 20);
            this.TimerPeriod.TabIndex = 2;
            this.TimerPeriod.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.TimerPeriod.Visible = false;
            this.TimerPeriod.ValueChanged += new System.EventHandler(this.TimerPeriod_ValueChanged);
            // 
            // CmdMOdebtn
            // 
            this.CmdMOdebtn.AutoSize = true;
            this.CmdMOdebtn.Checked = true;
            this.CmdMOdebtn.Location = new System.Drawing.Point(55, 19);
            this.CmdMOdebtn.Name = "CmdMOdebtn";
            this.CmdMOdebtn.Size = new System.Drawing.Size(46, 17);
            this.CmdMOdebtn.TabIndex = 1;
            this.CmdMOdebtn.TabStop = true;
            this.CmdMOdebtn.Text = "Ком";
            this.CmdMOdebtn.UseVisualStyleBackColor = true;
            this.CmdMOdebtn.CheckedChanged += new System.EventHandler(this.CmdMOdebtn_CheckedChanged);
            // 
            // AutomaticModebtn
            // 
            this.AutomaticModebtn.AutoSize = true;
            this.AutomaticModebtn.Location = new System.Drawing.Point(6, 19);
            this.AutomaticModebtn.Name = "AutomaticModebtn";
            this.AutomaticModebtn.Size = new System.Drawing.Size(43, 17);
            this.AutomaticModebtn.TabIndex = 0;
            this.AutomaticModebtn.Text = "Авт";
            this.AutomaticModebtn.UseVisualStyleBackColor = true;
            this.AutomaticModebtn.CheckedChanged += new System.EventHandler(this.AutomaticModebtn_CheckedChanged);
            // 
            // GuiRegPC
            // 
            this.GuiRegPC.Hexadecimal = true;
            this.GuiRegPC.Location = new System.Drawing.Point(437, 88);
            this.GuiRegPC.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.GuiRegPC.Name = "GuiRegPC";
            this.GuiRegPC.Size = new System.Drawing.Size(50, 20);
            this.GuiRegPC.TabIndex = 21;
            this.GuiRegPC.Value = ((long)(0));
            this.GuiRegPC.ValueChanged += new System.EventHandler(this.GuiRegPC_ValueChanged);
            // 
            // GuiRegSP
            // 
            this.GuiRegSP.Hexadecimal = true;
            this.GuiRegSP.Location = new System.Drawing.Point(354, 88);
            this.GuiRegSP.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.GuiRegSP.Name = "GuiRegSP";
            this.GuiRegSP.Size = new System.Drawing.Size(50, 20);
            this.GuiRegSP.TabIndex = 20;
            this.GuiRegSP.Value = ((long)(0));
            this.GuiRegSP.ValueChanged += new System.EventHandler(this.GuiRegSP_ValueChanged);
            // 
            // GuiRegL
            // 
            this.GuiRegL.Hexadecimal = true;
            this.GuiRegL.HexLength = 2;
            this.GuiRegL.Location = new System.Drawing.Point(284, 88);
            this.GuiRegL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegL.Name = "GuiRegL";
            this.GuiRegL.Size = new System.Drawing.Size(37, 20);
            this.GuiRegL.TabIndex = 19;
            this.GuiRegL.Value = ((long)(0));
            this.GuiRegL.ValueChanged += new System.EventHandler(this.GuiRegL_ValueChanged);
            // 
            // GuiRegH
            // 
            this.GuiRegH.Hexadecimal = true;
            this.GuiRegH.HexLength = 2;
            this.GuiRegH.Location = new System.Drawing.Point(223, 88);
            this.GuiRegH.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegH.Name = "GuiRegH";
            this.GuiRegH.Size = new System.Drawing.Size(37, 20);
            this.GuiRegH.TabIndex = 18;
            this.GuiRegH.Value = ((long)(0));
            this.GuiRegH.ValueChanged += new System.EventHandler(this.GuiRegH_ValueChanged);
            // 
            // GuiRegE
            // 
            this.GuiRegE.Hexadecimal = true;
            this.GuiRegE.HexLength = 2;
            this.GuiRegE.Location = new System.Drawing.Point(473, 59);
            this.GuiRegE.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegE.Name = "GuiRegE";
            this.GuiRegE.Size = new System.Drawing.Size(37, 20);
            this.GuiRegE.TabIndex = 17;
            this.GuiRegE.Value = ((long)(0));
            this.GuiRegE.ValueChanged += new System.EventHandler(this.GuiRegE_ValueChanged);
            // 
            // GuiRegD
            // 
            this.GuiRegD.Hexadecimal = true;
            this.GuiRegD.HexLength = 2;
            this.GuiRegD.Location = new System.Drawing.Point(410, 59);
            this.GuiRegD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegD.Name = "GuiRegD";
            this.GuiRegD.Size = new System.Drawing.Size(37, 20);
            this.GuiRegD.TabIndex = 16;
            this.GuiRegD.Value = ((long)(0));
            this.GuiRegD.ValueChanged += new System.EventHandler(this.GuiRegD_ValueChanged);
            // 
            // GuiRegC
            // 
            this.GuiRegC.Hexadecimal = true;
            this.GuiRegC.HexLength = 2;
            this.GuiRegC.Location = new System.Drawing.Point(346, 59);
            this.GuiRegC.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegC.Name = "GuiRegC";
            this.GuiRegC.Size = new System.Drawing.Size(37, 20);
            this.GuiRegC.TabIndex = 15;
            this.GuiRegC.Value = ((long)(0));
            this.GuiRegC.ValueChanged += new System.EventHandler(this.GuiRegC_ValueChanged);
            // 
            // GuiRegB
            // 
            this.GuiRegB.Hexadecimal = true;
            this.GuiRegB.HexLength = 2;
            this.GuiRegB.Location = new System.Drawing.Point(284, 59);
            this.GuiRegB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegB.Name = "GuiRegB";
            this.GuiRegB.Size = new System.Drawing.Size(37, 20);
            this.GuiRegB.TabIndex = 14;
            this.GuiRegB.Value = ((long)(0));
            this.GuiRegB.ValueChanged += new System.EventHandler(this.GuiRegB_ValueChanged);
            // 
            // GuiRegA
            // 
            this.GuiRegA.Hexadecimal = true;
            this.GuiRegA.HexLength = 2;
            this.GuiRegA.Location = new System.Drawing.Point(223, 59);
            this.GuiRegA.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.GuiRegA.Name = "GuiRegA";
            this.GuiRegA.Size = new System.Drawing.Size(37, 20);
            this.GuiRegA.TabIndex = 12;
            this.GuiRegA.Value = ((long)(0));
            this.GuiRegA.ValueChanged += new System.EventHandler(this.GuiRegA_ValueChanged);
            // 
            // MemAddrBeg
            // 
            this.MemAddrBeg.DecimalPlaces = 4;
            this.MemAddrBeg.Hexadecimal = true;
            this.MemAddrBeg.Location = new System.Drawing.Point(91, 30);
            this.MemAddrBeg.Maximum = new decimal(new int[] {
            65280,
            0,
            0,
            0});
            this.MemAddrBeg.Name = "MemAddrBeg";
            this.MemAddrBeg.Size = new System.Drawing.Size(79, 20);
            this.MemAddrBeg.TabIndex = 0;
            this.MemAddrBeg.Value = ((long)(0));
            this.MemAddrBeg.ValueChanged += new System.EventHandler(this.MemAddrBeg_ValueChanged);
            // 
            // form1BindingSource1
            // 
            this.form1BindingSource1.DataSource = typeof(WindowsFormsApp1.Form1);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(WindowsFormsApp1.Form1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(367, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Cтоп";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 32;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 589);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FlagC);
            this.Controls.Add(this.FlagAC);
            this.Controls.Add(this.FlagP);
            this.Controls.Add(this.FlagZ);
            this.Controls.Add(this.FlagS);
            this.Controls.Add(this.instructionBTN);
            this.Controls.Add(this.GuiRegPC);
            this.Controls.Add(this.GuiRegSP);
            this.Controls.Add(this.GuiRegL);
            this.Controls.Add(this.GuiRegH);
            this.Controls.Add(this.GuiRegE);
            this.Controls.Add(this.GuiRegD);
            this.Controls.Add(this.GuiRegC);
            this.Controls.Add(this.GuiRegB);
            this.Controls.Add(this.GuiRegA);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MemAddrBeg);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mEMBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skipcmd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GuiRegA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemAddrBeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HexNumericUpDown MemAddrBeg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource form1BindingSource1;
        private System.Windows.Forms.BindingSource mEMBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private HexNumericUpDown GuiRegA;
        private HexNumericUpDown GuiRegB;
        private HexNumericUpDown GuiRegC;
        private HexNumericUpDown GuiRegD;
        private HexNumericUpDown GuiRegE;
        private HexNumericUpDown GuiRegH;
        private HexNumericUpDown GuiRegL;
        private HexNumericUpDown GuiRegSP;
        private HexNumericUpDown GuiRegPC;
        private System.Windows.Forms.Button instructionBTN;
        private System.Windows.Forms.CheckBox FlagS;
        private System.Windows.Forms.CheckBox FlagZ;
        private System.Windows.Forms.CheckBox FlagP;
        private System.Windows.Forms.CheckBox FlagAC;
        private System.Windows.Forms.CheckBox FlagC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox нToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn мнемокод;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.NumericUpDown TimerPeriod;
        private System.Windows.Forms.RadioButton CmdMOdebtn;
        private System.Windows.Forms.RadioButton AutomaticModebtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem ассемблерToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown skipcmd;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem клавиатураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестоваяформаToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
    }
}

