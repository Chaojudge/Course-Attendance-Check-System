using System.Windows.Forms;

namespace Course_Attendance_Check_System
{
    public partial class initialize_finish : Form
    {
        /// <summary>
        /// initialize_finish的构造器
        /// </summary>
        public initialize_finish()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置系统初始化的结果
        /// </summary>
        /// <param name="value"></param>
        public void setResult(string value)
        {
            lab_result.Text = value;
        }
    }
}
