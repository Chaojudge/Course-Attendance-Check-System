namespace Course_Attendance_Check_System.form.Form_attendance
{
    partial class attendance_rewardAndPunish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(attendance_rewardAndPunish));
            this.label4 = new System.Windows.Forms.Label();
            this.btn_punish = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ecore = new System.Windows.Forms.TextBox();
            this.txt_stuId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_reward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(2, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(496, 64);
            this.label4.TabIndex = 6;
            this.label4.Text = "提示：\r\n     奖惩处理可以根据学生表现来进行奖励和处罚，例如：学生上\r\n课回答问题而获得奖励，学生在课堂中捣乱、玩手机、携带2步手机、\r\n讲话、睡觉等情况而" +
    "进行处罚，在使用功能是应该确认学生身份\r\n";
            // 
            // btn_punish
            // 
            this.btn_punish.Location = new System.Drawing.Point(385, 115);
            this.btn_punish.Name = "btn_punish";
            this.btn_punish.Size = new System.Drawing.Size(99, 28);
            this.btn_punish.TabIndex = 12;
            this.btn_punish.Text = "处罚";
            this.btn_punish.UseVisualStyleBackColor = true;
            this.btn_punish.Click += new System.EventHandler(this.btn_punish_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(469, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "分";
            // 
            // txt_ecore
            // 
            this.txt_ecore.Location = new System.Drawing.Point(376, 82);
            this.txt_ecore.Name = "txt_ecore";
            this.txt_ecore.Size = new System.Drawing.Size(94, 26);
            this.txt_ecore.TabIndex = 10;
            // 
            // txt_stuId
            // 
            this.txt_stuId.Location = new System.Drawing.Point(77, 82);
            this.txt_stuId.Name = "txt_stuId";
            this.txt_stuId.Size = new System.Drawing.Size(210, 26);
            this.txt_stuId.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "学生学号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "额外分数";
            // 
            // btn_reward
            // 
            this.btn_reward.Location = new System.Drawing.Point(270, 115);
            this.btn_reward.Name = "btn_reward";
            this.btn_reward.Size = new System.Drawing.Size(99, 28);
            this.btn_reward.TabIndex = 12;
            this.btn_reward.Text = "奖励";
            this.btn_reward.UseVisualStyleBackColor = true;
            this.btn_reward.Click += new System.EventHandler(this.btn_reward_Click);
            // 
            // attendance_rewardAndPunish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 162);
            this.Controls.Add(this.btn_reward);
            this.Controls.Add(this.btn_punish);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ecore);
            this.Controls.Add(this.txt_stuId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "attendance_rewardAndPunish";
            this.Text = "奖惩处理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_punish;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ecore;
        private System.Windows.Forms.TextBox txt_stuId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reward;
    }
}