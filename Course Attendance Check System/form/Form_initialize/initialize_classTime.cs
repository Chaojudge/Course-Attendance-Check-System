using System;
using System.Windows.Forms;
using systemFunction;

namespace Course_Attendance_Check_System
{
    public partial class initialize_classTime : Form
    {
        /// <summary>
        /// initialize_classTime的构造器
        /// </summary>
        public initialize_classTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 检测课堂时间配置信息是否填写完全
        /// </summary>
        /// <returns></returns>
        public Boolean checkContent()
        {
            if (txt_interval.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_one.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_one.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_two.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_two.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_three.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_three.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_four.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_four.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_five.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_five.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_six.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_six.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_seven.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_seven.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_eight.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_eight.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_nine.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_nine.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_ten.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_ten.Text.ToString().Equals("")) { return false; }
            else if (txt_startHour_eleven.Text.ToString().Equals("")) { return false; }
            else if (txt_startMinute_eleven.Text.ToString().Equals("")) { return false; }
            return true;
        }

        /// <summary>
        /// 保存课堂时间配置信息
        /// </summary>
        public void initClassTimeSetting()
        {
            int[] startHour     =   new int[11];
            int[] startMinute   =   new int[11];
            int interval        =   Convert.ToInt32(txt_interval.Text.ToString());
            startHour[0]        =   Convert.ToInt32(txt_startHour_one.Text.ToString());
            startHour[1]        =   Convert.ToInt32(txt_startHour_two.Text.ToString());
            startHour[2]        =   Convert.ToInt32(txt_startHour_three.Text.ToString());
            startHour[3]        =   Convert.ToInt32(txt_startHour_four.Text.ToString());
            startHour[4]        =   Convert.ToInt32(txt_startHour_five.Text.ToString());
            startHour[5]        =   Convert.ToInt32(txt_startHour_six.Text.ToString());
            startHour[6]        =   Convert.ToInt32(txt_startHour_seven.Text.ToString());
            startHour[7]        =   Convert.ToInt32(txt_startHour_eight.Text.ToString());
            startHour[8]        =   Convert.ToInt32(txt_startHour_nine.Text.ToString());
            startHour[9]        =   Convert.ToInt32(txt_startHour_ten.Text.ToString());
            startHour[10]       =   Convert.ToInt32(txt_startHour_eleven.Text.ToString());

            startMinute[0]      =   Convert.ToInt32(txt_startMinute_one.Text.ToString());
            startMinute[1]      =   Convert.ToInt32(txt_startMinute_two.Text.ToString());
            startMinute[2]      =   Convert.ToInt32(txt_startMinute_three.Text.ToString());
            startMinute[3]      =   Convert.ToInt32(txt_startMinute_four.Text.ToString());
            startMinute[4]      =   Convert.ToInt32(txt_startMinute_five.Text.ToString());
            startMinute[5]      =   Convert.ToInt32(txt_startMinute_six.Text.ToString());
            startMinute[6]      =   Convert.ToInt32(txt_startMinute_seven.Text.ToString());
            startMinute[7]      =   Convert.ToInt32(txt_startMinute_eight.Text.ToString());
            startMinute[8]      =   Convert.ToInt32(txt_startMinute_nine.Text.ToString());
            startMinute[9]      =   Convert.ToInt32(txt_startMinute_ten.Text.ToString());
            startMinute[10]     =   Convert.ToInt32(txt_startMinute_eleven.Text.ToString());

            systemInitImp.getSystemInit().saveClassTimeInfo(interval,startHour,startMinute);
        }
    }
}
