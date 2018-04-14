using Course_Attendance_Check_System.attendanceServer;
using Course_Attendance_Check_System.formImp;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.form.Form_attendance
{
    public partial class attendance_startCheck : Form
    {
        /// <summary>
        /// attendance_startCheck的构造器
        /// </summary>
        public attendance_startCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当attendance_startCheck加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attendance_startCheck_Load(object sender, EventArgs e)
        {
            timer_showAttendance.Enabled = true;
        }

        /// <summary>
        /// 接收客户端发来的消息
        /// </summary>
        /// <param name="receiveMsg"></param>
        public void showServerReceive(string receiveMsg)
        {
            controlImp.getControlImp().appendTextBox(this, txt_receive, receiveMsg);
        }

        /// <summary>
        /// 考勤名单、总人数、道勤人数以及缺勤人数显示
        /// </summary>
        /// <param name="table">考勤名单</param>
        /// <param name="attendantCount">道勤人数</param>
        /// <param name="absentCount">缺勤人数</param>
        /// <param name="allStudentCount">总人数</param>
        public void showAttendance(DataTable table,int attendantCount,int absentCount,int allStudentCount)
        {
            controlImp.getControlImp().setDataGridViewSource(this, dgv_showAttendance, table);
            controlImp.getControlImp().setTextBoxText(this, txt_attendantCount,""+ attendantCount);
            controlImp.getControlImp().setTextBoxText(this, txt_absentCount, "" + absentCount);
            controlImp.getControlImp().setTextBoxText(this, txt_allStudentCount, "" + allStudentCount);
        }

        /// <summary>
        /// timer触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_showAttendance_Tick(object sender, EventArgs e)
        {
            if (attendanceServerImp.getAttendanceServer().checkCurrentTime())
            {
                attendanceServerImp.getAttendanceServer().startAttendanceSelect();
            }
            else
            {
                attendanceServerImp.getAttendanceServer().endClass();
                timer_showAttendance.Enabled = false;
            }
        }

        /// <summary>
        /// 下课结束按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_endClass_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否提前下课结束", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                attendanceServerImp.getAttendanceServer().endClass();
                formInfo.getFormInfo().getForm_attendance().setCloseFlag(false);
            }
        }


        private void btn_selectAbsentList_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 奖惩处理按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_rewardAndPunish_Click(object sender, EventArgs e)
        {
            new attendance_rewardAndPunish().Show();
        }

        /// <summary>
        /// 随机点名按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_randomCall_Click(object sender, EventArgs e)
        {
            new Thread(attendanceServerImp.getAttendanceServer().randomCallStudent).Start();
        }

        /// <summary>
        /// 手动签到按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_manualSign_Click(object sender, EventArgs e)
        {
            new attendance_manualSign().Show();
        }
    }
}
