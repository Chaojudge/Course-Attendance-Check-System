namespace Course_Attendance_Check_System
{
    partial class form_attendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_attendance));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_attendance_interval = new System.Windows.Forms.Label();
            this.label_attendance_serverPort = new System.Windows.Forms.Label();
            this.label_attendance_serverIP = new System.Windows.Forms.Label();
            this.panel_attendance = new System.Windows.Forms.Panel();
            this.notifyIcon_attendance = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_attendance_interval);
            this.groupBox1.Controls.Add(this.label_attendance_serverPort);
            this.groupBox1.Controls.Add(this.label_attendance_serverIP);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 121);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务端配置信息";
            // 
            // label_attendance_interval
            // 
            this.label_attendance_interval.AutoSize = true;
            this.label_attendance_interval.Location = new System.Drawing.Point(509, 58);
            this.label_attendance_interval.Name = "label_attendance_interval";
            this.label_attendance_interval.Size = new System.Drawing.Size(104, 16);
            this.label_attendance_interval.TabIndex = 2;
            this.label_attendance_interval.Text = "课堂教学时间";
            // 
            // label_attendance_serverPort
            // 
            this.label_attendance_serverPort.AutoSize = true;
            this.label_attendance_serverPort.Location = new System.Drawing.Point(270, 58);
            this.label_attendance_serverPort.Name = "label_attendance_serverPort";
            this.label_attendance_serverPort.Size = new System.Drawing.Size(88, 16);
            this.label_attendance_serverPort.TabIndex = 1;
            this.label_attendance_serverPort.Text = "服务端端口";
            // 
            // label_attendance_serverIP
            // 
            this.label_attendance_serverIP.AutoSize = true;
            this.label_attendance_serverIP.Location = new System.Drawing.Point(23, 58);
            this.label_attendance_serverIP.Name = "label_attendance_serverIP";
            this.label_attendance_serverIP.Size = new System.Drawing.Size(72, 16);
            this.label_attendance_serverIP.TabIndex = 0;
            this.label_attendance_serverIP.Text = "服务端IP";
            // 
            // panel_attendance
            // 
            this.panel_attendance.Location = new System.Drawing.Point(17, 140);
            this.panel_attendance.Name = "panel_attendance";
            this.panel_attendance.Size = new System.Drawing.Size(741, 475);
            this.panel_attendance.TabIndex = 2;
            // 
            // notifyIcon_attendance
            // 
            this.notifyIcon_attendance.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon_attendance.Icon")));
            this.notifyIcon_attendance.Text = "Course Attendance Check System";
            this.notifyIcon_attendance.Visible = true;
            this.notifyIcon_attendance.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nouseDoubleClick);
            // 
            // form_attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 627);
            this.Controls.Add(this.panel_attendance);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form_attendance";
            this.Text = "Course Attendance Check System";
            this.Deactivate += new System.EventHandler(this.form_attendance_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_attendance_FormClosing);
            this.Load += new System.EventHandler(this.Form_attendance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_attendance_interval;
        private System.Windows.Forms.Label label_attendance_serverPort;
        private System.Windows.Forms.Label label_attendance_serverIP;
        private System.Windows.Forms.Panel panel_attendance;
        private System.Windows.Forms.NotifyIcon notifyIcon_attendance;
    }
}