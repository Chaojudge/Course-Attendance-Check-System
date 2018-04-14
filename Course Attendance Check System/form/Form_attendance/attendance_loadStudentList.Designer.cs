namespace Course_Attendance_Check_System.form.Form_attendance
{
    partial class attendance_loadStudentList
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
            this.btn_selectStudentCSV = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_studentListPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_outputAttendancePath = new System.Windows.Forms.TextBox();
            this.btn_loadStudentList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lab_loadStudentList_studentCount = new System.Windows.Forms.Label();
            this.dgv_showAllStudent = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showAllStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_selectStudentCSV
            // 
            this.btn_selectStudentCSV.Location = new System.Drawing.Point(474, 3);
            this.btn_selectStudentCSV.Name = "btn_selectStudentCSV";
            this.btn_selectStudentCSV.Size = new System.Drawing.Size(75, 23);
            this.btn_selectStudentCSV.TabIndex = 0;
            this.btn_selectStudentCSV.Text = "名单选择";
            this.btn_selectStudentCSV.UseVisualStyleBackColor = true;
            this.btn_selectStudentCSV.Click += new System.EventHandler(this.btn_selectStudentCSV_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "学生名单文件路径";
            // 
            // txt_studentListPath
            // 
            this.txt_studentListPath.Location = new System.Drawing.Point(111, 3);
            this.txt_studentListPath.Name = "txt_studentListPath";
            this.txt_studentListPath.ReadOnly = true;
            this.txt_studentListPath.Size = new System.Drawing.Size(357, 21);
            this.txt_studentListPath.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "本次课堂考勤情况导出路径";
            // 
            // txt_outputAttendancePath
            // 
            this.txt_outputAttendancePath.Location = new System.Drawing.Point(158, 34);
            this.txt_outputAttendancePath.Name = "txt_outputAttendancePath";
            this.txt_outputAttendancePath.ReadOnly = true;
            this.txt_outputAttendancePath.Size = new System.Drawing.Size(310, 21);
            this.txt_outputAttendancePath.TabIndex = 4;
            // 
            // btn_loadStudentList
            // 
            this.btn_loadStudentList.Location = new System.Drawing.Point(474, 32);
            this.btn_loadStudentList.Name = "btn_loadStudentList";
            this.btn_loadStudentList.Size = new System.Drawing.Size(75, 23);
            this.btn_loadStudentList.TabIndex = 5;
            this.btn_loadStudentList.Text = "名单导入";
            this.btn_loadStudentList.UseVisualStyleBackColor = true;
            this.btn_loadStudentList.Click += new System.EventHandler(this.btn_loadStudentList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lab_loadStudentList_studentCount);
            this.groupBox1.Controls.Add(this.dgv_showAllStudent);
            this.groupBox1.Location = new System.Drawing.Point(5, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 281);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "学生名单浏览";
            // 
            // lab_loadStudentList_studentCount
            // 
            this.lab_loadStudentList_studentCount.AutoSize = true;
            this.lab_loadStudentList_studentCount.Location = new System.Drawing.Point(419, 262);
            this.lab_loadStudentList_studentCount.Name = "lab_loadStudentList_studentCount";
            this.lab_loadStudentList_studentCount.Size = new System.Drawing.Size(65, 12);
            this.lab_loadStudentList_studentCount.TabIndex = 1;
            this.lab_loadStudentList_studentCount.Text = "学生总数：";
            // 
            // dgv_showAllStudent
            // 
            this.dgv_showAllStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_showAllStudent.Location = new System.Drawing.Point(6, 20);
            this.dgv_showAllStudent.Name = "dgv_showAllStudent";
            this.dgv_showAllStudent.RowTemplate.Height = 23;
            this.dgv_showAllStudent.Size = new System.Drawing.Size(532, 235);
            this.dgv_showAllStudent.TabIndex = 0;
            // 
            // attendance_loadStudentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(550, 357);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_loadStudentList);
            this.Controls.Add(this.txt_outputAttendancePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_studentListPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_selectStudentCSV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "attendance_loadStudentList";
            this.Text = "Form_loadStudentList";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_showAllStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_selectStudentCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_studentListPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_outputAttendancePath;
        private System.Windows.Forms.Button btn_loadStudentList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_showAllStudent;
        private System.Windows.Forms.Label lab_loadStudentList_studentCount;
    }
}