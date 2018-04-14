namespace Course_Attendance_Check_System.form.Form_attendance
{
    partial class attendance_manualSign
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(attendance_manualSign));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_stuId = new System.Windows.Forms.TextBox();
            this.txt_score = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_manualSign = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "本次课堂分数";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "学生学号";
            // 
            // txt_stuId
            // 
            this.txt_stuId.Location = new System.Drawing.Point(78, 90);
            this.txt_stuId.Name = "txt_stuId";
            this.txt_stuId.Size = new System.Drawing.Size(210, 26);
            this.txt_stuId.TabIndex = 2;
            // 
            // txt_score
            // 
            this.txt_score.Location = new System.Drawing.Point(395, 90);
            this.txt_score.Name = "txt_score";
            this.txt_score.Size = new System.Drawing.Size(72, 26);
            this.txt_score.TabIndex = 3;
            this.txt_score.Text = "90";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(470, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "分";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(1, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(496, 64);
            this.label4.TabIndex = 5;
            this.label4.Text = "提示：\r\n     手动签到时，需要确定学生学生证信息，签到后尽可能做到课室\r\n内前面的座位，以便观察，在上课过程中，教师可以通过点人头数来\r\n确定人数，如果人数" +
    "有误可以让各个班长来处理";
            // 
            // btn_manualSign
            // 
            this.btn_manualSign.Location = new System.Drawing.Point(385, 123);
            this.btn_manualSign.Name = "btn_manualSign";
            this.btn_manualSign.Size = new System.Drawing.Size(99, 28);
            this.btn_manualSign.TabIndex = 6;
            this.btn_manualSign.Text = "签到";
            this.btn_manualSign.UseVisualStyleBackColor = true;
            this.btn_manualSign.Click += new System.EventHandler(this.btn_manualSign_Click);
            // 
            // attendance_manualSign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 162);
            this.Controls.Add(this.btn_manualSign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_score);
            this.Controls.Add(this.txt_stuId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "attendance_manualSign";
            this.Text = "手动签到";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_stuId;
        private System.Windows.Forms.TextBox txt_score;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_manualSign;
    }
}