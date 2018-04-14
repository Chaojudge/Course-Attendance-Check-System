using Sunisoft.IrisSkin;

namespace Course_Attendance_Check_System
{
    partial class form_load
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_load));
            this.pro_load = new System.Windows.Forms.ProgressBar();
            this.Form_loadSkin = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // pro_load
            // 
            this.pro_load.Location = new System.Drawing.Point(13, 13);
            this.pro_load.Name = "pro_load";
            this.pro_load.Size = new System.Drawing.Size(505, 23);
            this.pro_load.TabIndex = 3;
            // 
            // Form_loadSkin
            // 
            this.Form_loadSkin.@__DrawButtonFocusRectangle = true;
            this.Form_loadSkin.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.Form_loadSkin.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.Form_loadSkin.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Form_loadSkin.SerialNumber = "";
            this.Form_loadSkin.SkinFile = null;
            // 
            // form_load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(530, 62);
            this.Controls.Add(this.pro_load);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "form_load";
            this.Text = "Course Attendance Check System Load";
            this.Load += new System.EventHandler(this.form_load_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pro_load;
        private SkinEngine Form_loadSkin;
    }
}

