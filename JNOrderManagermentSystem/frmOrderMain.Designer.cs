namespace JNOrderManagermentSystem
{
    partial class frmOrderMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrderMain));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.stockInDateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.stockOutDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.newButton = new System.Windows.Forms.Button();
            this.moveDownButton1 = new System.Windows.Forms.Button();
            this.delScheduleButton = new System.Windows.Forms.Button();
            this.moveUpButton2 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.pbStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.customer_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dinghuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_no = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Product_name = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shuliang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_salse = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.jine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yujijiaohuoshijian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jianhuoshijian2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dingdanguanliyuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kaipiao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.shifoujiaohuo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fukuanriqi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beizhu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Input_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.order_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xinzeng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(955, 547);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(949, 541);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(943, 497);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(935, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customer_name,
            this.dinghuoshijian,
            this.order_no,
            this.Product_no,
            this.Product_name,
            this.shuliang,
            this.Product_salse,
            this.jine,
            this.yujijiaohuoshijian,
            this.jianhuoshijian2,
            this.dingdanguanliyuan,
            this.kaipiao,
            this.shifoujiaohuo,
            this.fukuanriqi,
            this.beizhu,
            this.Input_Date,
            this.order_id,
            this.xinzeng,
            this.Message});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(929, 331);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.打印ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 70);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 打印ToolStripMenuItem
            // 
            this.打印ToolStripMenuItem.Name = "打印ToolStripMenuItem";
            this.打印ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.打印ToolStripMenuItem.Text = "打印";
            this.打印ToolStripMenuItem.Click += new System.EventHandler(this.打印ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.filterButton);
            this.groupBox2.Controls.Add(this.stockInDateTimePicker1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.stockOutDateTimePicker);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(929, 92);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 15);
            this.label1.TabIndex = 90;
            this.label1.Text = "*如果查找所有请填写\"所有\"";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(15, 65);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 20);
            this.label24.TabIndex = 89;
            this.label24.Text = "查找内容";
            // 
            // textBox8
            // 
            this.textBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(109, 63);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(356, 26);
            this.textBox8.TabIndex = 8;
            this.textBox8.Enter += new System.EventHandler(this.textBox8_Enter);
            // 
            // filterButton
            // 
            this.filterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterButton.Location = new System.Drawing.Point(825, 26);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(101, 41);
            this.filterButton.TabIndex = 78;
            this.filterButton.Text = "查找";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // stockInDateTimePicker1
            // 
            this.stockInDateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stockInDateTimePicker1.Location = new System.Drawing.Point(356, 22);
            this.stockInDateTimePicker1.Name = "stockInDateTimePicker1";
            this.stockInDateTimePicker1.Size = new System.Drawing.Size(109, 26);
            this.stockInDateTimePicker1.TabIndex = 5;
            this.stockInDateTimePicker1.Value = new System.DateTime(2017, 12, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(263, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 76;
            this.label4.Text = "结束时间";
            // 
            // stockOutDateTimePicker
            // 
            this.stockOutDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockOutDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stockOutDateTimePicker.Location = new System.Drawing.Point(109, 22);
            this.stockOutDateTimePicker.Name = "stockOutDateTimePicker";
            this.stockOutDateTimePicker.Size = new System.Drawing.Size(114, 26);
            this.stockOutDateTimePicker.TabIndex = 4;
            this.stockOutDateTimePicker.Value = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "开始时间";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.newButton);
            this.groupBox3.Controls.Add(this.moveDownButton1);
            this.groupBox3.Controls.Add(this.delScheduleButton);
            this.groupBox3.Controls.Add(this.moveUpButton2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(3, 426);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(929, 41);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(6, 9);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(35, 25);
            this.newButton.TabIndex = 38;
            this.newButton.Text = "+";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // moveDownButton1
            // 
            this.moveDownButton1.Location = new System.Drawing.Point(129, 9);
            this.moveDownButton1.Name = "moveDownButton1";
            this.moveDownButton1.Size = new System.Drawing.Size(35, 25);
            this.moveDownButton1.TabIndex = 41;
            this.moveDownButton1.Text = "▽";
            this.moveDownButton1.UseVisualStyleBackColor = true;
            // 
            // delScheduleButton
            // 
            this.delScheduleButton.Location = new System.Drawing.Point(47, 9);
            this.delScheduleButton.Name = "delScheduleButton";
            this.delScheduleButton.Size = new System.Drawing.Size(35, 25);
            this.delScheduleButton.TabIndex = 39;
            this.delScheduleButton.Text = "-";
            this.delScheduleButton.UseVisualStyleBackColor = true;
            this.delScheduleButton.Click += new System.EventHandler(this.delScheduleButton_Click);
            // 
            // moveUpButton2
            // 
            this.moveUpButton2.Location = new System.Drawing.Point(88, 9);
            this.moveUpButton2.Name = "moveUpButton2";
            this.moveUpButton2.Size = new System.Drawing.Size(35, 25);
            this.moveUpButton2.TabIndex = 40;
            this.moveUpButton2.Text = "△";
            this.moveUpButton2.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "actn020.gif");
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbStatus,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 513);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(943, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // pbStatus
            // 
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // customer_name
            // 
            this.customer_name.DataPropertyName = "customer_name";
            this.customer_name.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.customer_name.HeaderText = "客户";
            this.customer_name.Name = "customer_name";
            this.customer_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.customer_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dinghuoshijian
            // 
            this.dinghuoshijian.DataPropertyName = "dinghuoshijian";
            this.dinghuoshijian.HeaderText = "订货时间";
            this.dinghuoshijian.Name = "dinghuoshijian";
            // 
            // order_no
            // 
            this.order_no.DataPropertyName = "order_no";
            this.order_no.HeaderText = "订单号";
            this.order_no.Name = "order_no";
            // 
            // Product_no
            // 
            this.Product_no.DataPropertyName = "Product_no";
            this.Product_no.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Product_no.HeaderText = "产品型号";
            this.Product_no.Name = "Product_no";
            this.Product_no.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Product_name
            // 
            this.Product_name.DataPropertyName = "Product_name";
            this.Product_name.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Product_name.HeaderText = "名称";
            this.Product_name.Name = "Product_name";
            this.Product_name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // shuliang
            // 
            this.shuliang.DataPropertyName = "shuliang";
            this.shuliang.HeaderText = "数量";
            this.shuliang.Name = "shuliang";
            // 
            // Product_salse
            // 
            this.Product_salse.DataPropertyName = "Product_salse";
            this.Product_salse.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Product_salse.HeaderText = "单价";
            this.Product_salse.Name = "Product_salse";
            this.Product_salse.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_salse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // jine
            // 
            this.jine.DataPropertyName = "jine";
            this.jine.HeaderText = "金额";
            this.jine.Name = "jine";
            // 
            // yujijiaohuoshijian
            // 
            this.yujijiaohuoshijian.DataPropertyName = "yujijiaohuoshijian";
            this.yujijiaohuoshijian.HeaderText = "预计交货时间";
            this.yujijiaohuoshijian.Name = "yujijiaohuoshijian";
            // 
            // jianhuoshijian2
            // 
            this.jianhuoshijian2.DataPropertyName = "jianhuoshijian2";
            this.jianhuoshijian2.HeaderText = "交货时间2";
            this.jianhuoshijian2.Name = "jianhuoshijian2";
            // 
            // dingdanguanliyuan
            // 
            this.dingdanguanliyuan.DataPropertyName = "dingdanguanliyuan";
            this.dingdanguanliyuan.HeaderText = "订单管理员";
            this.dingdanguanliyuan.Name = "dingdanguanliyuan";
            // 
            // kaipiao
            // 
            this.kaipiao.DataPropertyName = "kaipiao";
            this.kaipiao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kaipiao.HeaderText = "开票";
            this.kaipiao.Items.AddRange(new object[] {
            "是",
            "否"});
            this.kaipiao.Name = "kaipiao";
            this.kaipiao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.kaipiao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // shifoujiaohuo
            // 
            this.shifoujiaohuo.DataPropertyName = "shifoujiaohuo";
            this.shifoujiaohuo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.shifoujiaohuo.HeaderText = "是否交货";
            this.shifoujiaohuo.Items.AddRange(new object[] {
            "是",
            "否"});
            this.shifoujiaohuo.Name = "shifoujiaohuo";
            this.shifoujiaohuo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.shifoujiaohuo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fukuanriqi
            // 
            this.fukuanriqi.DataPropertyName = "fukuanriqi";
            this.fukuanriqi.HeaderText = "付款日期";
            this.fukuanriqi.Name = "fukuanriqi";
            // 
            // beizhu
            // 
            this.beizhu.DataPropertyName = "beizhu";
            this.beizhu.HeaderText = "备注";
            this.beizhu.Name = "beizhu";
            // 
            // Input_Date
            // 
            this.Input_Date.DataPropertyName = "Input_Date";
            this.Input_Date.HeaderText = "录入时间";
            this.Input_Date.Name = "Input_Date";
            // 
            // order_id
            // 
            this.order_id.DataPropertyName = "order_id";
            this.order_id.HeaderText = "order_id";
            this.order_id.Name = "order_id";
            this.order_id.Visible = false;
            // 
            // xinzeng
            // 
            this.xinzeng.DataPropertyName = "xinzeng";
            this.xinzeng.HeaderText = "xinzeng";
            this.xinzeng.Name = "xinzeng";
            this.xinzeng.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xinzeng.Visible = false;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            // 
            // frmOrderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 547);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmOrderMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "订单中心";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.DateTimePicker stockInDateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker stockOutDateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar pbStatus;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button moveDownButton1;
        private System.Windows.Forms.Button delScheduleButton;
        private System.Windows.Forms.Button moveUpButton2;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem 打印ToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewComboBoxColumn customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dinghuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_no;
        private System.Windows.Forms.DataGridViewComboBoxColumn Product_no;
        private System.Windows.Forms.DataGridViewComboBoxColumn Product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn shuliang;
        private System.Windows.Forms.DataGridViewComboBoxColumn Product_salse;
        private System.Windows.Forms.DataGridViewTextBoxColumn jine;
        private System.Windows.Forms.DataGridViewTextBoxColumn yujijiaohuoshijian;
        private System.Windows.Forms.DataGridViewTextBoxColumn jianhuoshijian2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dingdanguanliyuan;
        private System.Windows.Forms.DataGridViewComboBoxColumn kaipiao;
        private System.Windows.Forms.DataGridViewComboBoxColumn shifoujiaohuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fukuanriqi;
        private System.Windows.Forms.DataGridViewTextBoxColumn beizhu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Input_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn order_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn xinzeng;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}