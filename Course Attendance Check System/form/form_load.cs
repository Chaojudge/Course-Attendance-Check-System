using System;
using System.Windows.Forms;
using System.Threading;
using systemFunction;
using Course_Attendance_Check_System.formImp;

namespace Course_Attendance_Check_System
{
    public partial class form_load : Form
    {
        /// <summary>
        /// form_load的构造器
        /// </summary>
        public form_load()
        {
            formInfo.getFormInfo().setForm_load(this);
            this.Form_loadSkin = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            // DiamondBlue.ssk|Longhorn.ssk|Midsummer|mp10|MSN|RealOne|SteelBlack|vista1|Warm|Wave
            this.Form_loadSkin.SkinFile = @".\Longhorn.ssk";
            this.MaximizeBox = false;
            this.MinimizeBox = false;          
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /// <summary>
        /// 系统加载窗体加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_load_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(systemLoadImp.getSystemLoadImp().loadSystem)).Start();
        }

        /// <summary>
        /// 系统加载失败时触发的事件
        /// </summary>
        public void loadFailed()
        {
            this.BeginInvoke((EventHandler)delegate 
            {
                new form_initialize().Show();
                this.Hide();
            });
        }

        /// <summary>
        /// 系统加载成功时触发的事件
        /// </summary>
        public void loadSuccess()
        {
            this.BeginInvoke((EventHandler)delegate
            {
                new form_attendance().Show();
                this.Hide();
            });
        }

        /// <summary>
        /// 系统加载时，设置进度条进度的方法
        /// </summary>
        /// <param name="value">当前值</param>
        /// <param name="max">最大值</param>
        /// <param name="result">加载内容</param>
        public void loadProgress(int value,int max,string result)
        {
            controlImp.getControlImp().setProgress(this, pro_load, value, max, result);
        }

    }
}
