using Course_Attendance_Check_System.attendanceServer;
using Course_Attendance_Check_System.formImp;
using System;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.form.Form_attendance
{
    public partial class attendance_manualSign : Form
    {
        /// <summary>
        /// attendance_manualSign的构造器
        /// </summary>
        public attendance_manualSign()
        {
            this.MaximizeBox = false;
            attendanceInfo.getAttendance().setManualSign(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        /// <summary>
        /// 签到按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_manualSign_Click(object sender, EventArgs e)
        {
            attendanceServerImp.getAttendanceServer().manualSign(
                txt_stuId.Text.ToString(), Convert.ToInt32(txt_score.Text.ToString()));
        }
    }
}
