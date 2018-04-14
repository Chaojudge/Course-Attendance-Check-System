using Course_Attendance_Check_System.attendanceServer;
using Course_Attendance_Check_System.formImp;
using System;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.form.Form_attendance
{
    public partial class attendance_rewardAndPunish : Form
    {
        /// <summary>
        /// attendace_rewardAndPunish的构造器
        /// </summary>
        public attendance_rewardAndPunish()
        {
            this.MaximizeBox = false;
            attendanceInfo.getAttendance().setRewardAndPunish(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /// <summary>
        /// 奖励按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reward_Click(object sender, EventArgs e)
        {
            if (txt_stuId.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入学号");
            }
            else if (txt_ecore.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入额外分数");
            }
            else
            {
                attendanceServerImp.getAttendanceServer().rewardAndPunish(
                    txt_stuId.Text.ToString(),Convert.ToInt32(txt_ecore.Text.ToString()),true);
            }
        }

        /// <summary>
        /// 触发按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_punish_Click(object sender, EventArgs e)
        {
            if (txt_stuId.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入学号");
            }
            else if (txt_ecore.Text.ToString().Equals(""))
            {
                MessageBox.Show("请输入额外分数");
            }
            else
            {
                attendanceServerImp.getAttendanceServer().rewardAndPunish(
                    txt_stuId.Text.ToString(), Convert.ToInt32(txt_ecore.Text.ToString()), false);
            }
        }
    }
}
