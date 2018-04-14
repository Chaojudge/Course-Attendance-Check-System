using System;
using System.Windows.Forms;
using systemFunction;

namespace Course_Attendance_Check_System
{
    public partial class initialize_server : Form
    {
        /// <summary>
        /// initialize_server的构造器
        /// </summary>
        public initialize_server()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存服务端配置信息
        /// </summary>
        public void initServerSetting()
        {
            
            systemInitImp.getSystemInit().saveServerInfo(
                txt_IPAddress_one.Text + "." + txt_IPAddress_two.Text + "." + txt_IPAddress_three.Text + ".1",
                Convert.ToInt32(txt_Port.Text),
                txt_mysqlPath.Text.Replace(@"\my.ini","")
                );
                
        }

        /// <summary>
        /// 当点击mysql服务配置文件选择按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_select_mysqlPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog select_mysql = new OpenFileDialog();
            select_mysql.Filter = "Mysql服务配置文件|my.ini";
            select_mysql.InitialDirectory = "./";
            if (select_mysql.ShowDialog() == DialogResult.OK)
            {
                txt_mysqlPath.Text = select_mysql.FileName;
            }
        }

        /// <summary>
        /// 检测服务端配置信息内容输入是否完全
        /// </summary>
        /// <returns></returns>
        public Boolean checkContent()
        {
            if (txt_IPAddress_one.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_IPAddress_two.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_IPAddress_three.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_Port.Text.ToString().Equals(""))
            {
                return false;
            }
            else if (txt_mysqlPath.Text.ToString().Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
