namespace Course_Attendance_Check_System.form.Form_attendance
{
    partial class attendance_startCheck
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
            this.dgv_showAttendance = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_endClass = new System.Windows.Forms.Button();
            this.btn_manualSign = new System.Windows.Forms.Button();
            this.button_randomCall = new System.Windows.Forms.Button();
            this.btn_rewardAndPunish = new System.Windows.Forms.Button();
            this.label_allStudentCount = new System.Windows.Forms.Label();
            this.label_absentCount = new System.Windows.Forms.Label();
            this.label_attendantCount = new System.Windows.Forms.Label();
            this.txt_receive = new System.Windows.Forms.TextBox();
            this.txt_attendantCount = new System.Windows.Forms.TextBox();
            this.txt_absentCount = new System.Windows.Forms.TextBox();
            this.txt_allStudentCount = new System.Windows.Forms.TextBox();
            this.timer_showAttendance = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showAttendance)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_showAttendance
            // 
            this.dgv_showAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_showAttendance.Location = new System.Drawing.Point(12, 19);
            this.dgv_showAttendance.Name = "dgv_showAttendance";
            this.dgv_showAttendance.RowTemplate.Height = 23;
            this.dgv_showAttendance.Size = new System.Drawing.Size(526, 259);
            this.dgv_showAttendance.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "本次课堂道勤表";
            // 
            // btn_endClass
            // 
            this.btn_endClass.Location = new System.Drawing.Point(410, 308);
            this.btn_endClass.Name = "btn_endClass";
            this.btn_endClass.Size = new System.Drawing.Size(128, 41);
            this.btn_endClass.TabIndex = 2;
            this.btn_endClass.Text = "下课结束";
            this.btn_endClass.UseVisualStyleBackColor = true;
            this.btn_endClass.Click += new System.EventHandler(this.btn_endClass_Click);
            // 
            // btn_manualSign
            // 
            this.btn_manualSign.Location = new System.Drawing.Point(146, 308);
            this.btn_manualSign.Name = "btn_manualSign";
            this.btn_manualSign.Size = new System.Drawing.Size(130, 41);
            this.btn_manualSign.TabIndex = 3;
            this.btn_manualSign.Text = "手动签到";
            this.btn_manualSign.UseVisualStyleBackColor = true;
            this.btn_manualSign.Click += new System.EventHandler(this.btn_manualSign_Click);
            // 
            // button_randomCall
            // 
            this.button_randomCall.Location = new System.Drawing.Point(12, 308);
            this.button_randomCall.Name = "button_randomCall";
            this.button_randomCall.Size = new System.Drawing.Size(132, 41);
            this.button_randomCall.TabIndex = 4;
            this.button_randomCall.Text = "随机点名";
            this.button_randomCall.UseVisualStyleBackColor = true;
            this.button_randomCall.Click += new System.EventHandler(this.button_randomCall_Click);
            // 
            // btn_rewardAndPunish
            // 
            this.btn_rewardAndPunish.Location = new System.Drawing.Point(279, 308);
            this.btn_rewardAndPunish.Name = "btn_rewardAndPunish";
            this.btn_rewardAndPunish.Size = new System.Drawing.Size(128, 41);
            this.btn_rewardAndPunish.TabIndex = 5;
            this.btn_rewardAndPunish.Text = "奖惩处理";
            this.btn_rewardAndPunish.UseVisualStyleBackColor = true;
            this.btn_rewardAndPunish.Click += new System.EventHandler(this.btn_rewardAndPunish_Click);
            // 
            // label_allStudentCount
            // 
            this.label_allStudentCount.AutoSize = true;
            this.label_allStudentCount.Location = new System.Drawing.Point(413, 287);
            this.label_allStudentCount.Name = "label_allStudentCount";
            this.label_allStudentCount.Size = new System.Drawing.Size(125, 12);
            this.label_allStudentCount.TabIndex = 7;
            this.label_allStudentCount.Text = "总人数：          人";
            // 
            // label_absentCount
            // 
            this.label_absentCount.AutoSize = true;
            this.label_absentCount.Location = new System.Drawing.Point(221, 287);
            this.label_absentCount.Name = "label_absentCount";
            this.label_absentCount.Size = new System.Drawing.Size(137, 12);
            this.label_absentCount.TabIndex = 8;
            this.label_absentCount.Text = "缺勤人数：          人";
            // 
            // label_attendantCount
            // 
            this.label_attendantCount.AutoSize = true;
            this.label_attendantCount.Location = new System.Drawing.Point(14, 287);
            this.label_attendantCount.Name = "label_attendantCount";
            this.label_attendantCount.Size = new System.Drawing.Size(137, 12);
            this.label_attendantCount.TabIndex = 9;
            this.label_attendantCount.Text = "道勤人数：          人";
            // 
            // txt_receive
            // 
            this.txt_receive.Location = new System.Drawing.Point(12, 196);
            this.txt_receive.Multiline = true;
            this.txt_receive.Name = "txt_receive";
            this.txt_receive.ReadOnly = true;
            this.txt_receive.Size = new System.Drawing.Size(526, 82);
            this.txt_receive.TabIndex = 10;
            this.txt_receive.Visible = false;
            // 
            // txt_attendantCount
            // 
            this.txt_attendantCount.Location = new System.Drawing.Point(72, 281);
            this.txt_attendantCount.Name = "txt_attendantCount";
            this.txt_attendantCount.ReadOnly = true;
            this.txt_attendantCount.Size = new System.Drawing.Size(63, 21);
            this.txt_attendantCount.TabIndex = 11;
            // 
            // txt_absentCount
            // 
            this.txt_absentCount.Location = new System.Drawing.Point(278, 281);
            this.txt_absentCount.Name = "txt_absentCount";
            this.txt_absentCount.ReadOnly = true;
            this.txt_absentCount.Size = new System.Drawing.Size(63, 21);
            this.txt_absentCount.TabIndex = 12;
            // 
            // txt_allStudentCount
            // 
            this.txt_allStudentCount.Location = new System.Drawing.Point(458, 281);
            this.txt_allStudentCount.Name = "txt_allStudentCount";
            this.txt_allStudentCount.ReadOnly = true;
            this.txt_allStudentCount.Size = new System.Drawing.Size(63, 21);
            this.txt_allStudentCount.TabIndex = 13;
            // 
            // timer_showAttendance
            // 
            this.timer_showAttendance.Interval = 1000;
            this.timer_showAttendance.Tick += new System.EventHandler(this.timer_showAttendance_Tick);
            // 
            // attendance_startCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(550, 356);
            this.Controls.Add(this.txt_allStudentCount);
            this.Controls.Add(this.txt_absentCount);
            this.Controls.Add(this.txt_attendantCount);
            this.Controls.Add(this.txt_receive);
            this.Controls.Add(this.label_attendantCount);
            this.Controls.Add(this.label_absentCount);
            this.Controls.Add(this.label_allStudentCount);
            this.Controls.Add(this.btn_rewardAndPunish);
            this.Controls.Add(this.button_randomCall);
            this.Controls.Add(this.btn_manualSign);
            this.Controls.Add(this.btn_endClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_showAttendance);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "attendance_startCheck";
            this.Text = "attendance_startCheck";
            this.Load += new System.EventHandler(this.attendance_startCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showAttendance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_showAttendance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_endClass;
        private System.Windows.Forms.Button btn_manualSign;
        private System.Windows.Forms.Button button_randomCall;
        private System.Windows.Forms.Button btn_rewardAndPunish;
        private System.Windows.Forms.Label label_allStudentCount;
        private System.Windows.Forms.Label label_absentCount;
        private System.Windows.Forms.Label label_attendantCount;
        private System.Windows.Forms.TextBox txt_receive;
        private System.Windows.Forms.TextBox txt_attendantCount;
        private System.Windows.Forms.TextBox txt_absentCount;
        private System.Windows.Forms.TextBox txt_allStudentCount;
        private System.Windows.Forms.Timer timer_showAttendance;
    }
}