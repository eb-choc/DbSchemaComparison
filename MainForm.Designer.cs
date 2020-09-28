namespace DbSchemaComparison
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.连接CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建数据库连接NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新数据库连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.processBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lbl_status_proces = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chk_view1 = new System.Windows.Forms.CheckBox();
            this.chk_index1 = new System.Windows.Forms.CheckBox();
            this.chk_field1 = new System.Windows.Forms.CheckBox();
            this.lbl_port1 = new System.Windows.Forms.Label();
            this.lbl_host1 = new System.Windows.Forms.Label();
            this.lbl_type1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_port2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_host2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_type2 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重置表ID值ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接CToolStripMenuItem,
            this.工具TToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1610, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 连接CToolStripMenuItem
            // 
            this.连接CToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建数据库连接NToolStripMenuItem,
            this.数据库连接管理ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.刷新数据库连接ToolStripMenuItem});
            this.连接CToolStripMenuItem.Name = "连接CToolStripMenuItem";
            this.连接CToolStripMenuItem.Size = new System.Drawing.Size(114, 38);
            this.连接CToolStripMenuItem.Text = "连接(&C)";
            // 
            // 新建数据库连接NToolStripMenuItem
            // 
            this.新建数据库连接NToolStripMenuItem.Name = "新建数据库连接NToolStripMenuItem";
            this.新建数据库连接NToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.新建数据库连接NToolStripMenuItem.Text = "新建数据库连接(&N)";
            this.新建数据库连接NToolStripMenuItem.Click += new System.EventHandler(this.新建数据库连接NToolStripMenuItem_Click);
            // 
            // 数据库连接管理ToolStripMenuItem
            // 
            this.数据库连接管理ToolStripMenuItem.Name = "数据库连接管理ToolStripMenuItem";
            this.数据库连接管理ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.数据库连接管理ToolStripMenuItem.Text = "数据库连接管理";
            this.数据库连接管理ToolStripMenuItem.Click += new System.EventHandler(this.数据库连接管理ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(356, 6);
            // 
            // 刷新数据库连接ToolStripMenuItem
            // 
            this.刷新数据库连接ToolStripMenuItem.Name = "刷新数据库连接ToolStripMenuItem";
            this.刷新数据库连接ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.刷新数据库连接ToolStripMenuItem.Text = "刷新数据库连接";
            this.刷新数据库连接ToolStripMenuItem.Click += new System.EventHandler(this.刷新数据库连接ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.processBar1,
            this.lbl_status_proces});
            this.statusStrip1.Location = new System.Drawing.Point(0, 925);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1610, 41);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(230, 31);
            this.toolStripStatusLabel1.Text = "数据库结构比较工具";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(225, 31);
            this.toolStripStatusLabel2.Text = "CopyRight @ T&&A";
            // 
            // processBar1
            // 
            this.processBar1.Name = "processBar1";
            this.processBar1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.processBar1.Size = new System.Drawing.Size(200, 29);
            this.processBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // lbl_status_proces
            // 
            this.lbl_status_proces.Name = "lbl_status_proces";
            this.lbl_status_proces.Size = new System.Drawing.Size(49, 31);
            this.lbl_status_proces.Text = "0%";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 150;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1610, 883);
            this.splitContainer1.SplitterDistance = 791;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.chk_view1);
            this.groupBox1.Controls.Add(this.chk_index1);
            this.groupBox1.Controls.Add(this.chk_field1);
            this.groupBox1.Controls.Add(this.lbl_port1);
            this.groupBox1.Controls.Add(this.lbl_host1);
            this.groupBox1.Controls.Add(this.lbl_type1);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 883);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "源数据库";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(97, 681);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chk_view1
            // 
            this.chk_view1.AutoSize = true;
            this.chk_view1.Enabled = false;
            this.chk_view1.Location = new System.Drawing.Point(97, 501);
            this.chk_view1.Name = "chk_view1";
            this.chk_view1.Size = new System.Drawing.Size(138, 28);
            this.chk_view1.TabIndex = 5;
            this.chk_view1.Text = "比较视图";
            this.chk_view1.UseVisualStyleBackColor = true;
            // 
            // chk_index1
            // 
            this.chk_index1.AutoSize = true;
            this.chk_index1.Enabled = false;
            this.chk_index1.Location = new System.Drawing.Point(97, 452);
            this.chk_index1.Name = "chk_index1";
            this.chk_index1.Size = new System.Drawing.Size(138, 28);
            this.chk_index1.TabIndex = 5;
            this.chk_index1.Text = "比较索引";
            this.chk_index1.UseVisualStyleBackColor = true;
            // 
            // chk_field1
            // 
            this.chk_field1.AutoSize = true;
            this.chk_field1.Checked = true;
            this.chk_field1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_field1.Enabled = false;
            this.chk_field1.Location = new System.Drawing.Point(97, 399);
            this.chk_field1.Name = "chk_field1";
            this.chk_field1.Size = new System.Drawing.Size(138, 28);
            this.chk_field1.TabIndex = 5;
            this.chk_field1.Text = "比较字段";
            this.chk_field1.UseVisualStyleBackColor = true;
            // 
            // lbl_port1
            // 
            this.lbl_port1.AutoSize = true;
            this.lbl_port1.Location = new System.Drawing.Point(185, 305);
            this.lbl_port1.Name = "lbl_port1";
            this.lbl_port1.Size = new System.Drawing.Size(0, 24);
            this.lbl_port1.TabIndex = 4;
            // 
            // lbl_host1
            // 
            this.lbl_host1.AutoSize = true;
            this.lbl_host1.Location = new System.Drawing.Point(185, 245);
            this.lbl_host1.Name = "lbl_host1";
            this.lbl_host1.Size = new System.Drawing.Size(0, 24);
            this.lbl_host1.TabIndex = 3;
            // 
            // lbl_type1
            // 
            this.lbl_type1.AutoSize = true;
            this.lbl_type1.Location = new System.Drawing.Point(185, 191);
            this.lbl_type1.Name = "lbl_type1";
            this.lbl_type1.Size = new System.Drawing.Size(0, 24);
            this.lbl_type1.TabIndex = 2;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(185, 141);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(383, 32);
            this.comboBox3.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(185, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(383, 32);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Host:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "数据库：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据源：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lbl_port2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lbl_host2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbl_type2);
            this.groupBox2.Controls.Add(this.comboBox4);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(815, 883);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标数据库";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "数据库：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "数据源：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Type:";
            // 
            // lbl_port2
            // 
            this.lbl_port2.AutoSize = true;
            this.lbl_port2.Location = new System.Drawing.Point(199, 305);
            this.lbl_port2.Name = "lbl_port2";
            this.lbl_port2.Size = new System.Drawing.Size(0, 24);
            this.lbl_port2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Host:";
            // 
            // lbl_host2
            // 
            this.lbl_host2.AutoSize = true;
            this.lbl_host2.Location = new System.Drawing.Point(199, 245);
            this.lbl_host2.Name = "lbl_host2";
            this.lbl_host2.Size = new System.Drawing.Size(0, 24);
            this.lbl_host2.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Port:";
            // 
            // lbl_type2
            // 
            this.lbl_type2.AutoSize = true;
            this.lbl_type2.Location = new System.Drawing.Point(199, 191);
            this.lbl_type2.Name = "lbl_type2";
            this.lbl_type2.Size = new System.Drawing.Size(0, 24);
            this.lbl_type2.TabIndex = 2;
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(199, 139);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(383, 32);
            this.comboBox4.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(199, 91);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(383, 32);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // 工具TToolStripMenuItem
            // 
            this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重置表ID值ToolStripMenuItem});
            this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
            this.工具TToolStripMenuItem.Size = new System.Drawing.Size(112, 38);
            this.工具TToolStripMenuItem.Text = "工具(&T)";
            // 
            // 重置表ID值ToolStripMenuItem
            // 
            this.重置表ID值ToolStripMenuItem.Name = "重置表ID值ToolStripMenuItem";
            this.重置表ID值ToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.重置表ID值ToolStripMenuItem.Text = "重置表ID值";
            this.重置表ID值ToolStripMenuItem.Click += new System.EventHandler(this.重置表ID值ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1610, 966);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DbSchemaComparison";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 连接CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建数据库连接NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 刷新数据库连接ToolStripMenuItem;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripProgressBar processBar1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_port1;
        public System.Windows.Forms.Label lbl_host1;
        public System.Windows.Forms.Label lbl_type1;
        public System.Windows.Forms.CheckBox chk_view1;
        public System.Windows.Forms.CheckBox chk_index1;
        public System.Windows.Forms.CheckBox chk_field1;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lbl_port2;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lbl_host2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lbl_type2;
        public System.Windows.Forms.ComboBox comboBox2;
        public System.Windows.Forms.ComboBox comboBox3;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.ToolStripStatusLabel lbl_status_proces;
        private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重置表ID值ToolStripMenuItem;
    }
}

