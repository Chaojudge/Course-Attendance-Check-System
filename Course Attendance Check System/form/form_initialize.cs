using System;
using System.Windows.Forms;
using Course_Attendance_Check_System.formImp;
using systemFunction;
using System.Threading;

namespace Course_Attendance_Check_System
{
    public partial class form_initialize : Form
    {

        bool closeFlag = true;          //是否可关闭

        /// <summary>
        /// form_initialize构造器
        /// </summary>
        public form_initialize()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            formInfo.getFormInfo().setForm_initialize(this);
            InitializeComponent();
        }

        /// <summary>
        /// form_initialize窗体加载时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_initialize_Load(object sender, EventArgs e)
        {
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_welcome());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_statement());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitalize_server());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_dataSource());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_classTime());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_process());
            this.panel_initialize.Controls.Add(initializeInfo.getInitialize().getInitialize_finish());
            initializeInfo.getInitialize().getInitialize_welcome().Show();
            controlImp.getControlImp().setBtnVisible(this, btn_back, false);
        }

        /// <summary>
        /// 点击“下一步”按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_back_Click(object sender, EventArgs e)
        {
            if (initializeInfo.getInitialize().getInitialize_statement().Visible == true)
            {
                initializeInfo.getInitialize().getInitialize_statement().checkReset();
                controlImp.getControlImp().setBtnVisible(this, btn_back, false);
                controlImp.getControlImp().setBtnEnabled(this, btn_next, true);
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_statement(),
                    initializeInfo.getInitialize().getInitialize_welcome());
            }
            else if (initializeInfo.getInitialize().getInitalize_server().Visible == true)
            {
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitalize_server(),
                    initializeInfo.getInitialize().getInitialize_statement());
            }
            else if (initializeInfo.getInitialize().getInitialize_dataSource().Visible == true)
            {
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_dataSource(),
                    initializeInfo.getInitialize().getInitalize_server());
            }
            else if (initializeInfo.getInitialize().getInitialize_classTime().Visible == true)
            {
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_classTime(),
                    initializeInfo.getInitialize().getInitialize_dataSource());
            }
        }

        /// <summary>
        /// 点击“上一步”按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_next_Click(object sender, EventArgs e)
        {
            if (initializeInfo.getInitialize().getInitialize_welcome().Visible == true)
            {
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_welcome(),
                    initializeInfo.getInitialize().getInitialize_statement());
                controlImp.getControlImp().setBtnVisible(this, btn_back, true);
                controlImp.getControlImp().setBtnEnabled(this, btn_next, false);
                initializeInfo.getInitialize().getInitialize_statement().checkReset();
            }
            else if (initializeInfo.getInitialize().getInitialize_statement().Visible == true)
            {
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_statement(),
                    initializeInfo.getInitialize().getInitalize_server());
            }
            else if (initializeInfo.getInitialize().getInitalize_server().Visible == true)
            {
                if (initializeInfo.getInitialize().getInitalize_server().checkContent())
                {
                    initializeInfo.getInitialize().getInitalize_server().initServerSetting();
                    controlImp.getControlImp().exchangePage(
                        initializeInfo.getInitialize().getInitalize_server(),
                        initializeInfo.getInitialize().getInitialize_dataSource());
                }
                else
                {
                    controlImp.getControlImp().showDialog(this, "服务端配置信息填写不完整");
                }
            }
            else if (initializeInfo.getInitialize().getInitialize_dataSource().Visible == true)
            {
                if (initializeInfo.getInitialize().getInitialize_dataSource().checkContent())
                {
                    initializeInfo.getInitialize().getInitialize_dataSource().initDataSourceSetting();
                    controlImp.getControlImp().exchangePage(
                        initializeInfo.getInitialize().getInitialize_dataSource(),
                        initializeInfo.getInitialize().getInitialize_classTime());
                }
                else
                {
                    controlImp.getControlImp().showDialog(this, "数据库源配置信息填写不完整");
                }
            }
            else if (initializeInfo.getInitialize().getInitialize_classTime().Visible == true)
            {
                if (initializeInfo.getInitialize().getInitialize_classTime().checkContent())
                {
                    initializeInfo.getInitialize().getInitialize_classTime().initClassTimeSetting();

                    // 设置是否清除历史记录
                    if (MessageBox.Show("是否清除历史记录", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (MessageBox.Show("清除历史记录将无法恢复，是否继续", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            closeFlag = false;
                            systemInitImp.getSystemInit().setClearFlag(true);
                            controlImp.getControlImp().setBtnVisible(this, btn_back, false);
                            // set btn_next's enabled is false
                            controlImp.getControlImp().setBtnEnabled(this, btn_next, false);
                            controlImp.getControlImp().exchangePage(
                                initializeInfo.getInitialize().getInitialize_classTime(),
                                initializeInfo.getInitialize().getInitialize_process());
                            new Thread(new ThreadStart(systemInitImp.getSystemInit().initializeSystem)).Start();
                        }
                    }
                    else
                    {
                        systemInitImp.getSystemInit().setClearFlag(false);
                        closeFlag = false;
                        controlImp.getControlImp().setBtnVisible(this, btn_back, false);
                        // set btn_next's enabled is false
                        controlImp.getControlImp().setBtnEnabled(this, btn_next, false);
                        controlImp.getControlImp().exchangePage(
                            initializeInfo.getInitialize().getInitialize_classTime(),
                            initializeInfo.getInitialize().getInitialize_process());
                        new Thread(new ThreadStart(systemInitImp.getSystemInit().initializeSystem)).Start();
                    }
                }
                else
                {
                    controlImp.getControlImp().showDialog(this, "课堂时间配置信息填写不完整");
                }
            }
            else if (initializeInfo.getInitialize().getInitialize_process().Visible == true)
            {
                closeFlag = true;
                controlImp.getControlImp().setBtnText(this, btn_next, "完成");
                controlImp.getControlImp().exchangePage(
                    initializeInfo.getInitialize().getInitialize_process(),
                    initializeInfo.getInitialize().getInitialize_finish());
            }
            else if (initializeInfo.getInitialize().getInitialize_finish().Visible == true)
            {
                //Environment.Exit(0);
                new form_attendance().Show();
                this.Hide();
            }
        }

        /// <summary>
        /// 点击“取消”按钮触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (closeFlag == true)
            {
                if (MessageBox.Show("是否关闭初始化向导", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
            }
            else
            { 
                MessageBox.Show("正在初始化系统配置中，请稍后退出...");
            }
        }

        /// <summary>
        /// 当窗体正要关闭时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_initialize_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeFlag)
            {
                if (MessageBox.Show("是否关闭初始化向导", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                MessageBox.Show("正在初始化系统配置中，请稍后退出...");
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 当在服务条款页面勾选“接受”时触发的事件
        /// </summary>
        /// <param name="type"></param>
        public void acceptService(bool type)
        {
            btn_next.Enabled = type;
        }

        /// <summary>
        /// 系统初始化成功
        /// </summary>
        public void initSuccess()
        {
            controlImp.getControlImp().setBtnEnabled(this, btn_next, true);
        }

        /// <summary>
        /// 系统初始化失败
        /// </summary>
        /// <param name="result"></param>
        public void initFailed(string result)
        {
            initializeInfo.getInitialize().getInitialize_finish().setResult(result);
        }
    }
}
