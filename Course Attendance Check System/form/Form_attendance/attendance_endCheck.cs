using Course_Attendance_Check_System.attendanceServer;
using Course_Attendance_Check_System.formImp;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.form.Form_attendance
{
    public partial class attendance_endCheck : Form
    {
        /// <summary>
        /// attendance_encCheck构造器
        /// </summary>
        public attendance_endCheck()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化下课显示信息
        /// </summary>
        /// <param name="attendantCount">道勤人数</param>
        /// <param name="absentCount">缺勤人数</param>
        /// <param name="allStudentCount">学生总数</param>
        /// <param name="attendancePercent">道勤率</param>
        /// <param name="classCoreAvg">平均本次课堂成绩</param>
        /// <param name="outputPath">本次考勤情况文件输出路径</param>
        public void setEndCheck(int attendantCount, 
            int absentCount, 
            int allStudentCount, 
            int attendancePercent, 
            float classCoreAvg,
            string outputPath)
        {
            this.BeginInvoke((EventHandler)delegate 
            {
                label_attendantCount.Text = "道勤人数：" + attendantCount + "人";
                label_absentCount.Text = "缺勤人数：" + absentCount + "人";
                label_allStudentCount.Text = "总人数：" + allStudentCount + "人";
                label_attendancePercent.Text = "道勤率：" + attendancePercent + "%";
                label_classCoreAver.Text = "平均道勤分数" + classCoreAvg + "";
                txt_outputPath.Text = outputPath;
            });
        }

        /// <summary>
        /// 输出按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_outputCSV_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(attendanceServerImp.getAttendanceServer().outputAttendantFile)).Start();
            formInfo.getFormInfo().getForm_attendance().setCloseFlag(true);
        }

        /// <summary>
        /// attendance_endCheck页面窗体加载时触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attendance_endCheck_Load(object sender, EventArgs e)
        {
            formInfo.getFormInfo().getForm_attendance().setCloseFlag(false);
        }
    }
}
