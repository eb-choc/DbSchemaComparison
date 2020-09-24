namespace DbSchemaComparison
{
    partial class newConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newConnectionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.com_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_host = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_conn_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型：";
            // 
            // com_type
            // 
            this.com_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_type.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_type.FormattingEnabled = true;
            this.com_type.Items.AddRange(new object[] {
            "MySql",
            "MsSqlServer"});
            this.com_type.Location = new System.Drawing.Point(357, 161);
            this.com_type.Name = "com_type";
            this.com_type.Size = new System.Drawing.Size(271, 32);
            this.com_type.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "HOST：";
            // 
            // txt_host
            // 
            this.txt_host.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_host.Location = new System.Drawing.Point(357, 218);
            this.txt_host.Name = "txt_host";
            this.txt_host.Size = new System.Drawing.Size(271, 35);
            this.txt_host.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "PORT：";
            // 
            // txt_port
            // 
            this.txt_port.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_port.Location = new System.Drawing.Point(357, 279);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(271, 35);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "3306";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "连接名称：";
            // 
            // txt_conn_name
            // 
            this.txt_conn_name.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_conn_name.Location = new System.Drawing.Point(357, 101);
            this.txt_conn_name.Name = "txt_conn_name";
            this.txt_conn_name.Size = new System.Drawing.Size(271, 35);
            this.txt_conn_name.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "账号：";
            // 
            // txt_user
            // 
            this.txt_user.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_user.Location = new System.Drawing.Point(357, 342);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(271, 35);
            this.txt_user.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(261, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "密码：";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_pwd.Location = new System.Drawing.Point(357, 402);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(271, 35);
            this.txt_pwd.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "保存(&S)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_conn_name);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_host);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.com_type);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新建数据库连接";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox com_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_host;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_conn_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button button1;
    }
}