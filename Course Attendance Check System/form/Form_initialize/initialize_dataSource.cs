using System;
using System.Windows.Forms;
using systemFunction;

namespace Course_Attendance_Check_System
{
    public partial class initialize_dataSource : Form
    { 
        /// <summary>
        /// initialize_dataSource的构造器
        /// </summary>
        public initialize_dataSource()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 检测数据库配置信息是否填写完全
        /// </summary>
        /// <returns></returns>
        public Boolean checkContent()
        {
            if (txt_dataSource_ip.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_dataSource_port.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_dataSource_database.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_dataSource_user.Text.ToString().Equals(""))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存数据库配置信息
        /// </summary>
        /// <returns></returns>
        public bool initDataSourceSetting()
        {
            try
            {
                systemInitImp.getSystemInit().saveDataSourceInfo(
                    txt_dataSource_ip.Text,
                    Convert.ToInt32(txt_dataSource_port.Text),
                    txt_dataSource_database.Text,
                    txt_dataSource_user.Text,
                    txt_dataSource_pwd.Text
                    );
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
