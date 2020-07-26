namespace PF2Easy
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxSSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxSType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSAlign = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSFamily = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownSLevel = new System.Windows.Forms.NumericUpDown();
            this.comboBoxSLevel = new System.Windows.Forms.ComboBox();
            this.textBoxSCreat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewCreatures = new System.Windows.Forms.DataGridView();
            this.textBoxBudget = new System.Windows.Forms.TextBox();
            this.labelBudget = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelParty = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox_Encounter = new System.Windows.Forms.ListBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panelFlow = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreatures)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1045, 587);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1045, 565);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panelFlow);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxValue);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDown3);
            this.splitContainer2.Panel1.Controls.Add(this.numericUpDown2);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewCreatures);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxBudget);
            this.splitContainer2.Panel1.Controls.Add(this.labelBudget);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            this.splitContainer2.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer2.Panel1.Controls.Add(this.labelParty);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBox_Encounter);
            this.splitContainer2.Size = new System.Drawing.Size(381, 565);
            this.splitContainer2.SplitterDistance = 483;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(3, 48);
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown3.TabIndex = 29;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(91, 48);
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(73, 20);
            this.numericUpDown2.TabIndex = 28;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.buttonSearch);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textBoxSSize);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxSType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxSAlign);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBoxSFamily);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.numericUpDownSLevel);
            this.panel2.Controls.Add(this.comboBoxSLevel);
            this.panel2.Controls.Add(this.textBoxSCreat);
            this.panel2.Location = new System.Drawing.Point(1, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 120);
            this.panel2.TabIndex = 27;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(104, 95);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 44;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(208, 95);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 43;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(310, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Size";
            // 
            // textBoxSSize
            // 
            this.textBoxSSize.Location = new System.Drawing.Point(289, 61);
            this.textBoxSSize.Name = "textBoxSSize";
            this.textBoxSSize.Size = new System.Drawing.Size(76, 20);
            this.textBoxSSize.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(225, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Type";
            // 
            // textBoxSType
            // 
            this.textBoxSType.Location = new System.Drawing.Point(207, 22);
            this.textBoxSType.Name = "textBoxSType";
            this.textBoxSType.Size = new System.Drawing.Size(76, 20);
            this.textBoxSType.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Alignment";
            // 
            // textBoxSAlign
            // 
            this.textBoxSAlign.Location = new System.Drawing.Point(289, 22);
            this.textBoxSAlign.Name = "textBoxSAlign";
            this.textBoxSAlign.Size = new System.Drawing.Size(76, 20);
            this.textBoxSAlign.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Creature";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Family";
            // 
            // textBoxSFamily
            // 
            this.textBoxSFamily.Location = new System.Drawing.Point(125, 21);
            this.textBoxSFamily.Name = "textBoxSFamily";
            this.textBoxSFamily.Size = new System.Drawing.Size(76, 20);
            this.textBoxSFamily.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Level";
            // 
            // numericUpDownSLevel
            // 
            this.numericUpDownSLevel.Location = new System.Drawing.Point(62, 21);
            this.numericUpDownSLevel.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDownSLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownSLevel.Name = "numericUpDownSLevel";
            this.numericUpDownSLevel.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownSLevel.TabIndex = 32;
            // 
            // comboBoxSLevel
            // 
            this.comboBoxSLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSLevel.FormattingEnabled = true;
            this.comboBoxSLevel.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "<=",
            ">=",
            "~"});
            this.comboBoxSLevel.Location = new System.Drawing.Point(5, 20);
            this.comboBoxSLevel.Name = "comboBoxSLevel";
            this.comboBoxSLevel.Size = new System.Drawing.Size(51, 21);
            this.comboBoxSLevel.TabIndex = 31;
            // 
            // textBoxSCreat
            // 
            this.textBoxSCreat.Location = new System.Drawing.Point(5, 61);
            this.textBoxSCreat.Name = "textBoxSCreat";
            this.textBoxSCreat.Size = new System.Drawing.Size(278, 20);
            this.textBoxSCreat.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Search Parameters";
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(4, 152);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 25;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Party Size";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridViewCreatures
            // 
            this.dataGridViewCreatures.AllowUserToAddRows = false;
            this.dataGridViewCreatures.AllowUserToDeleteRows = false;
            this.dataGridViewCreatures.AllowUserToOrderColumns = true;
            this.dataGridViewCreatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCreatures.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridViewCreatures.Location = new System.Drawing.Point(8, 74);
            this.dataGridViewCreatures.MultiSelect = false;
            this.dataGridViewCreatures.Name = "dataGridViewCreatures";
            this.dataGridViewCreatures.ReadOnly = true;
            this.dataGridViewCreatures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCreatures.Size = new System.Drawing.Size(370, 222);
            this.dataGridViewCreatures.TabIndex = 21;
            this.dataGridViewCreatures.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCreatures_CellDoubleClick);
            this.dataGridViewCreatures.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCreatures_ColumnHeaderMouseClick);
            this.dataGridViewCreatures.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCreatures_RowEnter);
            // 
            // textBoxBudget
            // 
            this.textBoxBudget.Location = new System.Drawing.Point(327, 32);
            this.textBoxBudget.Name = "textBoxBudget";
            this.textBoxBudget.ReadOnly = true;
            this.textBoxBudget.Size = new System.Drawing.Size(51, 20);
            this.textBoxBudget.TabIndex = 20;
            this.textBoxBudget.Text = "0";
            // 
            // labelBudget
            // 
            this.labelBudget.AutoSize = true;
            this.labelBudget.Location = new System.Drawing.Point(324, 56);
            this.labelBudget.Name = "labelBudget";
            this.labelBudget.Size = new System.Drawing.Size(58, 13);
            this.labelBudget.TabIndex = 19;
            this.labelBudget.Text = "XP Budget";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Desired Difficlty";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Trivial",
            "Low",
            "Moderate",
            "Severe",
            "Extreme",
            "Custom"});
            this.comboBox1.Location = new System.Drawing.Point(176, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(89, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelParty
            // 
            this.labelParty.AutoSize = true;
            this.labelParty.Location = new System.Drawing.Point(89, 32);
            this.labelParty.Name = "labelParty";
            this.labelParty.Size = new System.Drawing.Size(76, 13);
            this.labelParty.TabIndex = 16;
            this.labelParty.Text = "Average Level";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(381, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // listBox_Encounter
            // 
            this.listBox_Encounter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Encounter.FormattingEnabled = true;
            this.listBox_Encounter.Location = new System.Drawing.Point(0, 0);
            this.listBox_Encounter.Margin = new System.Windows.Forms.Padding(2000);
            this.listBox_Encounter.Name = "listBox_Encounter";
            this.listBox_Encounter.Size = new System.Drawing.Size(381, 78);
            this.listBox_Encounter.TabIndex = 24;
            this.listBox_Encounter.SelectedIndexChanged += new System.EventHandler(this.listBox_Encounter_SelectedIndexChanged_1);
            this.listBox_Encounter.DoubleClick += new System.EventHandler(this.listBox_Encounter_DoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(660, 565);
            this.webBrowser1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 565);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1045, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(292, 152);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 31;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(271, 32);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.ReadOnly = true;
            this.textBoxValue.Size = new System.Drawing.Size(51, 20);
            this.textBoxValue.TabIndex = 32;
            this.textBoxValue.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(271, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "XP Value";
            // 
            // panelFlow
            // 
            this.panelFlow.Controls.Add(this.buttonReset);
            this.panelFlow.Controls.Add(this.buttonRemove);
            this.panelFlow.Controls.Add(this.panel2);
            this.panelFlow.Controls.Add(this.button1);
            this.panelFlow.Controls.Add(this.label3);
            this.panelFlow.Location = new System.Drawing.Point(8, 302);
            this.panelFlow.Name = "panelFlow";
            this.panelFlow.Size = new System.Drawing.Size(370, 178);
            this.panelFlow.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 587);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "PF2EZ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCreatures)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelFlow.ResumeLayout(false);
            this.panelFlow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridViewCreatures;
        private System.Windows.Forms.TextBox textBoxBudget;
        private System.Windows.Forms.Label labelBudget;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelParty;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ListBox listBox_Encounter;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSCreat;
        private System.Windows.Forms.NumericUpDown numericUpDownSLevel;
        private System.Windows.Forms.ComboBox comboBoxSLevel;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSFamily;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxSType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSAlign;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Panel panelFlow;
    }
}

