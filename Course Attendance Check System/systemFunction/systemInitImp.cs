using Course_Attendance_Check_System.formImp;
using publicClass;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using systemSetting;

namespace systemFunction
{
    class systemInitImp
    {
        private static systemInitImp systemInit = new systemInitImp();

        /// <summary>
        /// 保存服务端配置信息
        /// </summary>
        /// <param name="serverIP">服务端ip地址</param>
        /// <param name="serverPort">服务端端口</param>
        /// <param name="mysqlPath">mysql服务配置文件路径</param>
        public void saveServerInfo(string serverIP, int serverPort, string mysqlPath)
        {
            systemSetting.serverInfo.getServerInfo().setServerInfo(serverIP, serverPort, mysqlPath);
        }

        /// <summary>
        /// 保存数据库配置信息
        /// </summary>
        /// <param name="dataSourceIP">数据库主机IP</param>
        /// <param name="dataSourcePort">数据库主机端口</param>
        /// <param name="dataBaseName">数据库名称</param>
        /// <param name="dataSourceUser">数据库用户名</param>
        /// <param name="dataSourcePwd">数据库密码</param>
        public void saveDataSourceInfo(
            string dataSourceIP, int dataSourcePort,
            string dataBaseName, string dataSourceUser, string dataSourcePwd)
        {
            systemSetting.dataSourceInfo.getDataSourceInfo().setDataSourceInfo(
                dataSourceIP,dataSourcePort,dataBaseName,dataSourceUser,dataSourcePwd);
        }

        public void saveClassTimeInfo(int interval, int[] startHour, int[] startMinute)
        {
            systemSetting.classTimeInfo.getClassTimeInfo().setClassTimeInfo(interval, startHour, startMinute);
        }

        bool clearFlag;

        public void setClearFlag(bool clearFlag)
        {
            this.clearFlag = clearFlag;
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        public void initializeSystem()
        {
            initializeInfo.getInitialize().getInitialize_process().initSettingProgress(10,10,270,
                "正在创建系统配置文件config.ini...");
            createCofigINI();
            initializeInfo.getInitialize().getInitialize_process().initSettingProgress(20, 10, 270,
                "创建系统配置文件config.ini完成");
            initializeInfo.getInitialize().getInitialize_process().initSettingProgress(30, 10, 270,
                "正在创建MySQL服务批处理文件...");
            createMysqlBat();
            initializeInfo.getInitialize().getInitialize_process().initSettingProgress(70, 10, 270,
                "创建MySQL服务批处理文件完成");
            initializeInfo.getInitialize().getInitialize_process().initSettingProgress(80, 10, 270,
                "正在检测MySQL服务运行状态...");
            if (queryMysqlService())
            {
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(90, 10, 270,
                "MySQL服务正在运行中");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(100, 10, 270,
                "正在尝试连接数据库源...");
                if (connectMysql())
                {
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(110, 10, 270,
                    "连接数据库源完成");
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(120, 10, 270,
                    "正在初始化数据表...");
                    initTable();
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(265, 10, 270,
                    "初始化表格完成");
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(270, 5, 270,
                    "系统初始化完成");
                    formInfo.getFormInfo().getForm_initialize().initSuccess();
                }
                else
                {
                    formInfo.getFormInfo().getForm_initialize()
                        .initFailed("连接数据库源失败：\r\n请检查数据库源配置信息是否填写正确");
                }
            }
            else
            {
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(85, 5, 270, 
                    "MySQL服务未启动");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(90, 5, 270,
                    "正在启动MySQL服务...");
                startMysqlService();
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(95, 5, 270,
                    "正在检测MySQL服务运行情况");
                if (queryMysqlService())
                {
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(100, 5, 270,
                        "MySQL服务运行成功");
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(105, 5, 270,
                        "正在尝试连接数据库源...");
                    if (connectMysql())
                    {
                        initializeInfo.getInitialize().getInitialize_process().initSettingProgress(110, 5, 270,
                            "连接数据库源完成");
                        initializeInfo.getInitialize().getInitialize_process().initSettingProgress(120, 10, 270,
                            "正在初始化数据表...");
                        initTable();
                        initializeInfo.getInitialize().getInitialize_process().initSettingProgress(265, 10, 270,
                            "初始化表格完成");
                        initializeInfo.getInitialize().getInitialize_process().initSettingProgress(270, 5, 270,
                            "系统初始化完成");
                        formInfo.getFormInfo().getForm_initialize().initSuccess();
                    }
                    else
                    {
                        // connect mysql failed
                        // show err msg
                        formInfo.getFormInfo().getForm_initialize()
                            .initFailed("连接数据库源失败：\r\n请检查数据库源配置信息是否填写正确");
                    }
                }
                else
                {
                    formInfo.getFormInfo().getForm_initialize()
                        .initFailed("启动MySQL服务失败：\r\n MySQL服务是否安装完整");
                }
            }
        }

        /// <summary>
        /// 在文件根目录下创建config.ini系统配置文件，并写入配置信息
        /// </summary>
        private void createCofigINI()
        {
            try
            {
                string startHourStr = "";
                string startMinuteStr = "";
                int i;
                for (i = 0; i < classTimeInfo.getClassTimeInfo().getStartHour().Length - 1; i++)
                {
                    startHourStr += classTimeInfo.getClassTimeInfo().getStartHour()[i].ToString() + ",";
                    startMinuteStr += classTimeInfo.getClassTimeInfo().getStartMinute()[i].ToString() + ",";
                }
                startHourStr += classTimeInfo.getClassTimeInfo().getStartHour()[i].ToString();
                startMinuteStr += classTimeInfo.getClassTimeInfo().getStartMinute()[i].ToString();

                string configINIStr = ""
                    + "[server]" + ";"
                    + "ip=" + serverInfo.getServerInfo().getServerIP() + ";"
                    + "port=" + serverInfo.getServerInfo().getServerPort() + ";"
                    + "mysqlpath=" + serverInfo.getServerInfo().getMysqlPath() + ";"
                    + ";"
                    + "[mysql]" + ";"
                    + "ip=" + dataSourceInfo.getDataSourceInfo().getDataSourceIP() + ";"
                    + "port=" + dataSourceInfo.getDataSourceInfo().getDataSourcePort() + ";"
                    + "database=" + dataSourceInfo.getDataSourceInfo().getDataBaseName() + ";"
                    + "user=" + dataSourceInfo.getDataSourceInfo().getDataSourceUser() + ";"
                    + "pwd=" + dataSourceInfo.getDataSourceInfo().getDataSourcePwd() + ";"
                    + ";"
                    + "[classTime]" + ";"
                    + "interval=" + classTimeInfo.getClassTimeInfo().getInterval() + ";"
                    + "startHour=" + startHourStr + ";"
                    + "startMinute=" + startMinuteStr + ";" ;

                string[] configINIContent = configINIStr.Split(';');
                System.IO.File.WriteAllLines("./config.ini", configINIContent, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("config.ini文件创建出错：" + ex.ToString()); ;
            }
        }

        /// <summary>
        /// 在mysql服务配置文件目录中创建mysql服务操作批处理文件
        /// </summary>
        private void createMysqlBat()
        {
            try
            {
                string[] startMysql = {
                "@echo off",
                @"set path=%path%;.\bin\;",
                "sc query|find \"MySQL\" && goto EXIST || goto NOTEXIST",
                ":EXIST",
                "net stop mysql",
                "sc delete mysql",
                "goto RESULT",
                "",
                ":NOTEXIST",
                "echo mysql server not exist",
                "goto RESULT"
                ,"",
                ":RESULT",
                "mysqld -install",
                "net start mysql"};

                string[] stopMysql = {
                "@echo off",
                "net stop mysql",
                "sc delete mysql"};

                string[] queryMysql = {
                "@echo off",
                "sc query mysql"};

                System.IO.File.WriteAllLines(serverInfo.getServerInfo().getMysqlPath()
                    + @"\startMysql.bat", startMysql, Encoding.ASCII);
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(40, 10, 270,
                    "-------->MySQL服务启动批处理文件创建完成");
                System.IO.File.WriteAllLines(serverInfo.getServerInfo().getMysqlPath()
                    + @"\queryMysql.bat", queryMysql, Encoding.ASCII);
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(50, 10, 270,
                    "-------->MySQL服务查询状态批处理文件创建完成");
                System.IO.File.WriteAllLines(serverInfo.getServerInfo().getMysqlPath()
                    + @"\stopMysql.bat", stopMysql, Encoding.ASCII);
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(60, 10, 270,
                    "-------->MySQL服务关闭批处理文件创建完成");
                serverInfo.getServerInfo().setMysqlBatFile("startMysql.bat","queryMysql.bat","stopMysql.bat");
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建MySQL服务批处理文件失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 启动mysql服务
        /// </summary>
        private void startMysqlService()
        {
            try
            {
                string errMsg = string.Empty;
                execBat(serverInfo.getServerInfo().getStartMysqlBatFile(), ref errMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("启动MySQL服务失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 执行批处理文件
        /// </summary>
        /// <param name="batFile">批处理文件对象</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        private string execBat(FileInfo batFile,ref string errMsg)
        {
            string output = string.Empty;
            try
            {
                using (Process pro = new Process())
                {
                    FileInfo file = batFile;
                    pro.StartInfo.WorkingDirectory = file.Directory.FullName;
                    pro.StartInfo.FileName = batFile.FullName;
                    pro.StartInfo.CreateNoWindow = true;
                    pro.StartInfo.RedirectStandardOutput = true;
                    pro.StartInfo.RedirectStandardError = true;
                    pro.StartInfo.UseShellExecute = false;
                    pro.Start();
                    pro.WaitForExit();
                    output = pro.StandardOutput.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("运行" + batFile.Name + "失败:" + ex.ToString());
                output = null;
            }
            return output;
        }

        private bool queryMysqlService()
        {
            string errMsg = string.Empty;
            string output = execBat(serverInfo.getServerInfo().getQueryMysqlBatFile(), ref errMsg);
            if (output.IndexOf("RUNNING") > -1)
            {
                return true;
            }
            return false;
        }

        private bool connectMysql()
        {
            try
            {
                mysqlImp.getMysql().connect();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接数据库源失败：" + ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 初始化数据表
        /// </summary>
        private void initTable()
        {
            try
            {
                operateTable("timeattendance", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "stuTele              varchar(255)                ,"
                    + "stuMac               varchar(255)                ,"
                    + "score                float                       ,"
                    + "ecore                float                       ,"
                    + "allcore              float                       ,"
                    + "signDate             date                        ,"
                    + "signTime             time                        ,"
                    + "keepTime             int                         ,"
                    + "if_sign              bit                         "
                    + ");");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(135, 15, 270,
                    "-------->初始化timeattendance表完成");

                operateTable("signattendance", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "stuTele              varchar(255)                ,"
                    + "stuMac               varchar(255)                ,"
                    + "score                float                       ,"
                    + "ecore                float                       ,"
                    + "allcore              float                       ,"
                    + "signDate             date                        ,"
                    + "signTime             time                        ,"
                    + "if_sign              bit                         "
                    + ");");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(150, 15, 270,
                    "-------->初始化signattendance表完成");

                operateTable("temporarycore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "core                 float                       "
                    + ")");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(165, 15, 270,
                    "-------->初始化temporarycore表完成");

                operateTable("allclasscore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "core                 float                       "
                    + ")");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(180, 15, 270,
                    "-------->初始化allclasscore表完成");

                operateTable("examcore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "core                 float                       "
                    + ")");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(195, 15, 270,
                    "-------->初始化examcore表完成");

                operateTable("allhomecore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "core                 float                       "
                    + ")");

                operateTable("allcore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "allcore              float(1)                     "
                    + ")");

                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(210, 15, 270,
                    "-------->初始化allhomecore和allcore表完成");

                operateTable("coursecore", "("
                    + "stuId                varchar(255)     primary key ,"
                    + "stuClassName         varchar(255)                ,"
                    + "stuName              varchar(255)                ,"
                    + "allClassCore         float                       ,"
                    + "allHomeCore          float                       ,"
                    + "examCore             float                       ,"
                    + "courseCore           float                       ,"
                    + "if_pass              bit                         "
                    + ")");
                initializeInfo.getInitialize().getInitialize_process().initSettingProgress(225, 15, 270,
                    "-------->初始化coursecore表完成");

                if (clearFlag)
                {
                    operateTable("timehistory", "("
                       + "id                   int             auto_increment  primary key  ,"
                       + "stuId                varchar(255)                                  ,"
                       + "stuClassName         varchar(255)                                 ,"
                       + "stuName              varchar(255)                                 ,"
                       + "stuTele              varchar(255)                                 ,"
                       + "stuMac               varchar(255)                                 ,"
                       + "score                float                                        ,"
                       + "ecore                float                                        ,"
                       + "allcore              float                                        ,"
                       + "signDate             date                                         ,"
                       + "signTime             time                                         ,"
                       + "keepTime             int                                          ,"
                       + "if_sign              bit                                          "
                       + ");");
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(240, 15, 270,
                    "-------->初始化timehistory表完成");

                    operateTable("signhistory", "("
                       + "id                   int             auto_increment  primary key  ,"
                       + "stuId                varchar(255)                                 ,"
                       + "stuClassName         varchar(255)                                 ,"
                       + "stuName              varchar(255)                                 ,"
                       + "stuTele              varchar(255)                                 ,"
                       + "stuMac               varchar(255)                                 ,"
                       + "score                float                                        ,"
                       + "ecore                float                                        ,"
                       + "allcore              float                                        ,"
                       + "signDate             date                                         ,"
                       + "signTime             time                                         ,"
                       + "if_sign              bit                                          "
                       + ");");
                    initializeInfo.getInitialize().getInitialize_process().initSettingProgress(255, 15, 270,
                    "-------->初始化signhistory表完成");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("初始化表格失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 判断数据表是否存在，不存在则创建数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="content"></param>
        private void operateTable(string tableName,string content)
        {
            if (mysqlImp.getMysql().query("select * from " + tableName) != null)
            {
                mysqlImp.getMysql().update("truncate table " + tableName);
            }
            else
            {
                mysqlImp.getMysql().update("create table " + tableName + content);
            }
        }

        /// <summary>
        /// 获取systemInitImp实例化对象
        /// </summary>
        /// <returns>返回systemInitImp实例化对象</returns>
        public static systemInitImp getSystemInit()
        {
            return systemInit;
        }
    }
}
