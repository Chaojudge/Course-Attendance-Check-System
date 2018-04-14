namespace Course_Attendance_Check_System
{
    partial class initialize_server
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
            this.btn_select_mysqlPath = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_mysqlPath = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel_server = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_IPAddress_three = new System.Windows.Forms.TextBox();
            this.txt_IPAddress_two = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_IPAddress_one = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_server.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_select_mysqlPath
            // 
            this.btn_select_mysqlPath.Location = new System.Drawing.Point(345, 170);
            this.btn_select_mysqlPath.Name = "btn_select_mysqlPath";
            this.btn_select_mysqlPath.Size = new System.Drawing.Size(69, 23);
            this.btn_select_mysqlPath.TabIndex = 31;
            this.btn_select_mysqlPath.Text = "选择";
            this.btn_select_mysqlPath.UseVisualStyleBackColor = true;
            this.btn_select_mysqlPath.Click += new System.EventHandler(this.btn_select_mysqlPath_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 235);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(551, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "_________________________________________________________________________________" +
    "__________";
            // 
            // txt_mysqlPath
            // 
            this.txt_mysqlPath.Location = new System.Drawing.Point(100, 172);
            this.txt_mysqlPath.Name = "txt_mysqlPath";
            this.txt_mysqlPath.Size = new System.Drawing.Size(239, 21);
            this.txt_mysqlPath.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 10F);
            this.label14.Location = new System.Drawing.Point(17, 174);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 14);
            this.label14.TabIndex = 27;
            this.label14.Text = "Mysql根目录";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10F);
            this.label13.Location = new System.Drawing.Point(345, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 14);
            this.label13.TabIndex = 26;
            this.label13.Text = "必须是无被占用的端口";
            // 
            // panel_server
            // 
            this.panel_server.Controls.Add(this.btn_select_mysqlPath);
            this.panel_server.Controls.Add(this.label16);
            this.panel_server.Controls.Add(this.label15);
            this.panel_server.Controls.Add(this.txt_mysqlPath);
            this.panel_server.Controls.Add(this.label14);
            this.panel_server.Controls.Add(this.label13);
            this.panel_server.Controls.Add(this.label12);
            this.panel_server.Controls.Add(this.label11);
            this.panel_server.Controls.Add(this.txt_IPAddress_three);
            this.panel_server.Controls.Add(this.txt_IPAddress_two);
            this.panel_server.Controls.Add(this.label10);
            this.panel_server.Controls.Add(this.txt_Port);
            this.panel_server.Controls.Add(this.label8);
            this.panel_server.Controls.Add(this.txt_IPAddress_one);
            this.panel_server.Controls.Add(this.label7);
            this.panel_server.Controls.Add(this.label9);
            this.panel_server.Controls.Add(this.label2);
            this.panel_server.Controls.Add(this.label1);
            this.panel_server.Location = new System.Drawing.Point(12, 11);
            this.panel_server.Name = "panel_server";
            this.panel_server.Size = new System.Drawing.Size(579, 334);
            this.panel_server.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 10F);
            this.label16.Location = new System.Drawing.Point(17, 256);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(546, 42);
            this.label16.TabIndex = 30;
            this.label16.Text = "     在选择Mysql根目录以前，需要安装Mysql服务，安装过程可以查看安装说明书，其\r\n中安装后Mysql服务根目录没有启动、关闭、查询服务的批处理文件，" +
    "该系统服务端会根\r\n据用户指定的Mysql服务根目录来生成Mysql服务的启动、关闭以及查询的批处理文件\r\n";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10F);
            this.label12.Location = new System.Drawing.Point(250, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 25;
            this.label12.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10F);
            this.label11.Location = new System.Drawing.Point(166, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 24;
            this.label11.Text = ".";
            // 
            // txt_IPAddress_three
            // 
            this.txt_IPAddress_three.Location = new System.Drawing.Point(267, 75);
            this.txt_IPAddress_three.Name = "txt_IPAddress_three";
            this.txt_IPAddress_three.Size = new System.Drawing.Size(64, 21);
            this.txt_IPAddress_three.TabIndex = 23;
            this.txt_IPAddress_three.Text = "0";
            // 
            // txt_IPAddress_two
            // 
            this.txt_IPAddress_two.Location = new System.Drawing.Point(183, 75);
            this.txt_IPAddress_two.Name = "txt_IPAddress_two";
            this.txt_IPAddress_two.Size = new System.Drawing.Size(64, 21);
            this.txt_IPAddress_two.TabIndex = 22;
            this.txt_IPAddress_two.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10F);
            this.label10.Location = new System.Drawing.Point(333, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 14);
            this.label10.TabIndex = 21;
            this.label10.Text = ".1，最后一位必须为1";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(100, 124);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(239, 21);
            this.txt_Port.TabIndex = 20;
            this.txt_Port.Text = "8966";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10F);
            this.label8.Location = new System.Drawing.Point(17, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 19;
            this.label8.Text = "服务端端口";
            // 
            // txt_IPAddress_one
            // 
            this.txt_IPAddress_one.Location = new System.Drawing.Point(100, 75);
            this.txt_IPAddress_one.Name = "txt_IPAddress_one";
            this.txt_IPAddress_one.Size = new System.Drawing.Size(64, 21);
            this.txt_IPAddress_one.TabIndex = 18;
            this.txt_IPAddress_one.Text = "127";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.Location = new System.Drawing.Point(17, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 17;
            this.label7.Text = "服务端主机";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(551, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "_________________________________________________________________________________" +
    "__________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(551, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "_________________________________________________________________________________" +
    "__________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "系统服务端配置";
            // 
            // initialize_server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(602, 356);
            this.Controls.Add(this.panel_server);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "initialize_server";
            this.Text = "initialize_server";
            this.panel_server.ResumeLayout(false);
            this.panel_server.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_select_mysqlPath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_mysqlPath;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel_server;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_IPAddress_three;
        private System.Windows.Forms.TextBox txt_IPAddress_two;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_IPAddress_one;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}