using Course_Attendance_Check_System.formImp;
using System;
using System.Windows.Forms;
using systemSetting;

namespace Course_Attendance_Check_System
{
    public partial class form_attendance : Form
    {
        /// <summary>
        /// form_attendance的构造器
        /// </summary>
        public form_attendance()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            formInfo.getFormInfo().setForm_attendance(this);
            InitializeComponent();
        }

        /// <summary>
        /// form_attendance加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_attendance_Load(object sender, EventArgs e)
        {
            this.notifyIcon_attendance.Visible = true;
            label_attendance_serverIP.Text = "服务端IP   " + serverInfo.getServerInfo().getServerIP();
            label_attendance_serverPort.Text = "服务端端口   " + serverInfo.getServerInfo().getServerPort();
            label_attendance_interval.Text = "课堂教学时间   " + classTimeInfo.getClassTimeInfo().getInterval() + "分钟";
            this.panel_attendance.Controls.Add(attendanceInfo.getAttendance().getLoadStudentList());
            this.panel_attendance.Controls.Add(attendanceInfo.getAttendance().getStartCheck());
            this.panel_attendance.Controls.Add(attendanceInfo.getAttendance().getEndCheck());
            attendanceInfo.getAttendance().getLoadStudentList().Show();
        }

        bool closeFlag = true;
        
        /// <summary>
        /// 设置课堂考勤主窗体是否可关闭属性
        /// </summary>
        /// <param name="closeFlag"></param>
        public void setCloseFlag(bool closeFlag)
        {
            this.closeFlag = closeFlag;
        }

        /// <summary>
        /// 当课堂考勤主窗体正在关闭时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_attendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeFlag)
            {
                if (MessageBox.Show("是否退出系统", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    notifyIcon_attendance.Visible = false;
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("正在考勤中，请下课结束后再退出");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 开始考勤
        /// </summary>
        public void startCheck()   
        {
            controlImp.getControlImp().exchangePage(
                attendanceInfo.getAttendance().getLoadStudentList(),
                attendanceInfo.getAttendance().getStartCheck());
        }

        /// <summary>
        /// 结束考勤
        /// </summary>
        public void endCheck()
        {
            controlImp.getControlImp().exchangePage(
                attendanceInfo.getAttendance().getStartCheck(),
                attendanceInfo.getAttendance().getEndCheck());
        }

        /// <summary>
        /// 当课堂考勤窗体最小化时触发托盘最小化应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_attendance_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// 当该系统托盘图标被点击时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_attendance_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        /// <summary>
        /// 当窗体标题栏被双击时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        /// <summary>
        /// 设置课堂时间文本框
        /// </summary>
        public void setCurrentInterval()
        {
            this.BeginInvoke((EventHandler)delegate {
                label_attendance_interval.Text = "课堂教学时间   " +  
                attendanceServerInfo.getAttendanceServerInfo().getStartServerInterval() + "分钟";
            });
        }
    }
}
