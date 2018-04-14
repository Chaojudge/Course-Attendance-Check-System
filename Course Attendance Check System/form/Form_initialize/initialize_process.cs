using System;
using System.Threading;
using System.Windows.Forms;

namespace Course_Attendance_Check_System
{
    public partial class initialize_process : Form
    {
        /// <summary>
        /// initialize_process的构造器
        /// </summary>
        public initialize_process()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 声明委托
        /// </summary>
        /// <param name="result">加载进度的信息</param>
        private delegate void setLabel(string result);

        /// <summary>
        /// 设置加载进度以及进度信息
        /// </summary>
        /// <param name="value">进度值</param>
        /// <param name="interval">间隔值</param>
        /// <param name="max">最大值</param>
        /// <param name="result">进度信息</param>
        public void initSettingProgress(int value,int interval,int max,string result)
        {
            initLabelThread(result);
            Thread initProgressThread = new Thread((ThreadStart)delegate
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    pro_initSetting.Maximum = max;
                    pro_initSetting.Value = value - interval;
                    for (int i = value - interval; i < value; i++)
                    {
                        Thread.Sleep(12);
                        pro_initSetting.Value++;
                        //Console.WriteLine(pro_initSetting.Value + "\r\n");
                    }
                });
            });
            initProgressThread.Start();
        }

        /// <summary>
        /// 启动系统加载线程
        /// </summary>
        /// <param name="result">进度信息</param>
        private void initLabelThread(string result)
        {
            Thread initlabelthread = new Thread((ThreadStart)delegate 
            {
                this.BeginInvoke((EventHandler)delegate
                {
                    if (this.InvokeRequired)
                    {
                        setLabel setlab = new setLabel(initLabelThread);
                        this.Invoke(setlab, new object[] { result });
                    }
                    else
                    {
                        txt_initResult.AppendText(result + "\r\n");
                    }
                });  
            });
            //initlabelthread.IsBackground = true;
            initlabelthread.Start();
        }
    }
}
