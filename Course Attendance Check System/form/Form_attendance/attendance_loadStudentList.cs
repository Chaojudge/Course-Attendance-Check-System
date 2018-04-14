//using Course_Attendance_Check_System.server;
using Course_Attendance_Check_System.attendanceServer;
using Course_Attendance_Check_System.formImp;
using Course_Attendance_Check_System.systemFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using systemSetting;

namespace Course_Attendance_Check_System.form.Form_attendance
{
    public partial class attendance_loadStudentList : Form
    {
        /// <summary>
        /// attendance_loadStudentList的构造器
        /// </summary>
        public attendance_loadStudentList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击选择学生名单.csv文件按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_selectStudentCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog select_studentList = new OpenFileDialog();
            select_studentList.Filter = "学生名单文件|*.csv";
            select_studentList.InitialDirectory = "./";
            if (select_studentList.ShowDialog() == DialogResult.OK)
            {
                txt_studentListPath.Text = select_studentList.FileName;
                FileInfo studentList = new FileInfo(select_studentList.FileName);
                txt_outputAttendancePath.Text = studentList.FullName.Replace(@"\" + studentList.Name, "");
            }
        }

        /// <summary>
        /// 点击“导入”按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loadStudentList_Click(object sender, EventArgs e)
        {
            if (btn_loadStudentList.Text.ToString().Equals("名单导入"))
            {
                if (MessageBox.Show("是否开启计时模式", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // serverImp
                    loadStudentListImp.getLoadStudentListImp().saveLoadStudentListInfo(
                        txt_studentListPath.Text, txt_outputAttendancePath.Text, true);
                }
                else
                {
                    loadStudentListImp.getLoadStudentListImp().saveLoadStudentListInfo(
                        txt_studentListPath.Text, txt_outputAttendancePath.Text, false);
                }
                new Thread(new ThreadStart(loadStudentListImp.getLoadStudentListImp().loadStudent)).Start();
            }
            else if(btn_loadStudentList.Text.ToString().Equals("开始考勤"))
            {
                attendanceServerImp.getAttendanceServer().setEndTime();
                if (attendanceServerImp.getAttendanceServer().checkCurrentTime())
                {
                    attendanceServerImp.getAttendanceServer().startAttendanceServer();
                    formInfo.getFormInfo().getForm_attendance().setCloseFlag(false);
                }
                else
                {
                    MessageBox.Show("当前时间不处于上课时间段，无法开始考勤");
                }
            }
        }

        /// <summary>
        /// 预览导入的学生名单
        /// </summary>
        /// <param name="table"></param>
        public void showStudentList(DataTable table)
        {
            controlImp.getControlImp().setDataGridViewSource(this, dgv_showAllStudent, table);
        }

        /// <summary>
        /// 计算并输出学生总数
        /// </summary>
        /// <param name="allStudentCount"></param>
        public void showAllStudentCount(int allStudentCount)
        {
            controlImp.getControlImp().setLabelText(this, lab_loadStudentList_studentCount,"学生总数：" + allStudentCount);
        }

        /// <summary>
        /// 设置“导入”按钮文本为“开始考勤”
        /// </summary>
        public void setLoadBtnToStartCheck()
        {
            controlImp.getControlImp().setBtnText(this,btn_loadStudentList, "开始考勤");
        } 

        
    }
}
