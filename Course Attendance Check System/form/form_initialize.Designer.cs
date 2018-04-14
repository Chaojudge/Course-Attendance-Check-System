namespace Course_Attendance_Check_System
{
    partial class form_initialize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_initialize));
            this.panel_initialize = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_initialize
            // 
            this.panel_initialize.BackColor = System.Drawing.SystemColors.Control;
            this.panel_initialize.Location = new System.Drawing.Point(10, 10);
            this.panel_initialize.Name = "panel_initialize";
            this.panel_initialize.Size = new System.Drawing.Size(579, 338);
            this.panel_initialize.TabIndex = 10;
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_back.Location = new System.Drawing.Point(351, 354);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 23);
            this.btn_back.TabIndex = 9;
            this.btn_back.Text = "上一步";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Visible = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(432, 354);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 8;
            this.btn_next.Text = "下一步";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(514, 353);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // form_initialize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 386);
            this.Controls.Add(this.panel_initialize);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_initialize";
            this.Text = "Course Attendance Check System Initialize";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_initialize_FormClosing);
            this.Load += new System.EventHandler(this.Form_initialize_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_initialize;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_cancel;
    }
}