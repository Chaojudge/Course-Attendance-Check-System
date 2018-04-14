using Course_Attendance_Check_System.formImp;
using System;
using System.Windows.Forms;

namespace Course_Attendance_Check_System
{
    public partial class initialize_statement : Form
    {
        /// <summary>
        /// initialize_statement的构造器
        /// </summary>
        public initialize_statement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// “接受”复选框勾选状态改变时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_accept_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_accept.Checked == false)
            {
                formInfo.getFormInfo().getForm_initialize().acceptService(false);
            }
            else if (cb_accept.Checked == true)
            {
                formInfo.getFormInfo().getForm_initialize().acceptService(true);
            }
        }

        /// <summary>
        /// 初始化“接受”复选框的勾选状态为未勾选
        /// </summary>
        public void checkReset()
        {
            cb_accept.Checked = false;
        }
    }
}
