namespace Course_Attendance_Check_System
{
    partial class initialize_finish
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
            this.panel_process = new System.Windows.Forms.Panel();
            this.lab_result = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_process.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_process
            // 
            this.panel_process.Controls.Add(this.lab_result);
            this.panel_process.Controls.Add(this.label9);
            this.panel_process.Controls.Add(this.label2);
            this.panel_process.Controls.Add(this.label1);
            this.panel_process.Location = new System.Drawing.Point(12, 11);
            this.panel_process.Name = "panel_process";
            this.panel_process.Size = new System.Drawing.Size(579, 334);
            this.panel_process.TabIndex = 11;
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Font = new System.Drawing.Font("宋体", 10F);
            this.lab_result.Location = new System.Drawing.Point(63, 76);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(161, 154);
            this.lab_result.TabIndex = 9;
            this.lab_result.Text = "已经完成以下系统配置：\r\n\r\n\r\n     1.服务端配置\r\n\r\n\r\n     2.数据库配置\r\n\r\n\r\n     3.课堂时间配置\r\n\r\n";
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
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置完成";
            // 
            // initialize_finish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(602, 357);
            this.Controls.Add(this.panel_process);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "initialize_finish";
            this.Text = "initialize_finish";
            this.panel_process.ResumeLayout(false);
            this.panel_process.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_process;
        private System.Windows.Forms.Label lab_result;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}