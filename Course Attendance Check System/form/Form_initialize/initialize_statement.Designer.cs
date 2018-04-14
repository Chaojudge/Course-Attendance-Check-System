namespace Course_Attendance_Check_System
{
    partial class initialize_statement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(initialize_statement));
            this.panel_statement = new System.Windows.Forms.Panel();
            this.cb_accept = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_statement.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_statement
            // 
            this.panel_statement.Controls.Add(this.cb_accept);
            this.panel_statement.Controls.Add(this.label3);
            this.panel_statement.Controls.Add(this.label9);
            this.panel_statement.Controls.Add(this.label2);
            this.panel_statement.Controls.Add(this.label1);
            this.panel_statement.Location = new System.Drawing.Point(13, 12);
            this.panel_statement.Name = "panel_statement";
            this.panel_statement.Size = new System.Drawing.Size(579, 334);
            this.panel_statement.TabIndex = 7;
            // 
            // cb_accept
            // 
            this.cb_accept.AutoSize = true;
            this.cb_accept.Location = new System.Drawing.Point(501, 290);
            this.cb_accept.Name = "cb_accept";
            this.cb_accept.Size = new System.Drawing.Size(48, 16);
            this.cb_accept.TabIndex = 10;
            this.cb_accept.Text = "接受";
            this.cb_accept.UseVisualStyleBackColor = true;
            this.cb_accept.CheckedChanged += new System.EventHandler(this.cb_accept_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(539, 224);
            this.label3.TabIndex = 9;
            this.label3.Text = resources.GetString("label3.Text");
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
            this.label1.Size = new System.Drawing.Size(220, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务条款以及系统说明";
            // 
            // initialize_statement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(604, 359);
            this.Controls.Add(this.panel_statement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "initialize_statement";
            this.Text = "initialize_statement";
            this.panel_statement.ResumeLayout(false);
            this.panel_statement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_statement;
        private System.Windows.Forms.CheckBox cb_accept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}