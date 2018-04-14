namespace Course_Attendance_Check_System.form.Form_attendance
{
    partial class attendance_endCheck
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_classCoreAver = new System.Windows.Forms.Label();
            this.label_attendancePercent = new System.Windows.Forms.Label();
            this.label_allStudentCount = new System.Windows.Forms.Label();
            this.label_absentCount = new System.Windows.Forms.Label();
            this.label_attendantCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_outputCSV = new System.Windows.Forms.Button();
            this.txt_outputPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_classCoreAver);
            this.groupBox1.Controls.Add(this.label_attendancePercent);
            this.groupBox1.Controls.Add(this.label_allStudentCount);
            this.groupBox1.Controls.Add(this.label_absentCount);
            this.groupBox1.Controls.Add(this.label_attendantCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本次课堂考勤结算";
            // 
            // label_classCoreAver
            // 
            this.label_classCoreAver.AutoSize = true;
            this.label_classCoreAver.Location = new System.Drawing.Point(210, 74);
            this.label_classCoreAver.Name = "label_classCoreAver";
            this.label_classCoreAver.Size = new System.Drawing.Size(131, 12);
            this.label_classCoreAver.TabIndex = 4;
            this.label_classCoreAver.Text = "本次课堂平均分数：000";
            // 
            // label_attendancePercent
            // 
            this.label_attendancePercent.AutoSize = true;
            this.label_attendancePercent.Location = new System.Drawing.Point(35, 74);
            this.label_attendancePercent.Name = "label_attendancePercent";
            this.label_attendancePercent.Size = new System.Drawing.Size(77, 12);
            this.label_attendancePercent.TabIndex = 3;
            this.label_attendancePercent.Text = "道勤率：000%";
            // 
            // label_allStudentCount
            // 
            this.label_allStudentCount.AutoSize = true;
            this.label_allStudentCount.Location = new System.Drawing.Point(400, 32);
            this.label_allStudentCount.Name = "label_allStudentCount";
            this.label_allStudentCount.Size = new System.Drawing.Size(83, 12);
            this.label_allStudentCount.TabIndex = 2;
            this.label_allStudentCount.Text = "总人数：000人";
            // 
            // label_absentCount
            // 
            this.label_absentCount.AutoSize = true;
            this.label_absentCount.Location = new System.Drawing.Point(210, 32);
            this.label_absentCount.Name = "label_absentCount";
            this.label_absentCount.Size = new System.Drawing.Size(95, 12);
            this.label_absentCount.TabIndex = 1;
            this.label_absentCount.Text = "缺勤人数：000人";
            // 
            // label_attendantCount
            // 
            this.label_attendantCount.AutoSize = true;
            this.label_attendantCount.Location = new System.Drawing.Point(35, 32);
            this.label_attendantCount.Name = "label_attendantCount";
            this.label_attendantCount.Size = new System.Drawing.Size(95, 12);
            this.label_attendantCount.TabIndex = 0;
            this.label_attendantCount.Text = "道勤人数：000人";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_outputCSV);
            this.groupBox2.Controls.Add(this.txt_outputPath);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(526, 81);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本次课堂道勤情况CSV输出";
            // 
            // btn_outputCSV
            // 
            this.btn_outputCSV.Location = new System.Drawing.Point(445, 34);
            this.btn_outputCSV.Name = "btn_outputCSV";
            this.btn_outputCSV.Size = new System.Drawing.Size(75, 23);
            this.btn_outputCSV.TabIndex = 6;
            this.btn_outputCSV.Text = "输出文件";
            this.btn_outputCSV.UseVisualStyleBackColor = true;
            this.btn_outputCSV.Click += new System.EventHandler(this.btn_outputCSV_Click);
            // 
            // txt_outputPath
            // 
            this.txt_outputPath.Location = new System.Drawing.Point(82, 36);
            this.txt_outputPath.Name = "txt_outputPath";
            this.txt_outputPath.ReadOnly = true;
            this.txt_outputPath.Size = new System.Drawing.Size(359, 21);
            this.txt_outputPath.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "输出路径：";
            // 
            // attendance_endCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(550, 356);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "attendance_endCheck";
            this.Text = "attendance_endCheck";
            this.Load += new System.EventHandler(this.attendance_endCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_classCoreAver;
        private System.Windows.Forms.Label label_attendancePercent;
        private System.Windows.Forms.Label label_allStudentCount;
        private System.Windows.Forms.Label label_absentCount;
        private System.Windows.Forms.Label label_attendantCount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_outputCSV;
        private System.Windows.Forms.TextBox txt_outputPath;
        private System.Windows.Forms.Label label6;
    }
}