using publicClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using systemSetting;
using Course_Attendance_Check_System.formImp;

namespace systemFunction
{
    public class systemLoadImp
    {
        private static systemLoadImp systemLoad = new systemLoadImp();

        /// <summary>
        /// 获取实例化的systemLoadImp对象
        /// </summary>
        /// <returns>返回实例化的systemLoadImp对象</returns>
        public static systemLoadImp getSystemLoadImp()
        {
            return systemLoad;
        }

        /// <summary>
        /// 检测./config.ini文件是否存在
        /// </summary>
        /// <returns>返回为布尔值</returns>
        private bool checkConfigINI()
        {
            FileInfo configINI = new FileInfo("./config.ini");
            if (configINI.Exists)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 检测并读取./config.ini中配置信息
        /// </summary>
        /// <returns>返回值为布尔值</returns>
        private bool readConfigINI()
        {
            try
            {
                Dictionary<string, string> serverSetting =
                    iniReader.getINI().read("./config.ini", "server");

                Dictionary<string, string> dataSourceSetting =
                    iniReader.getINI().read("./config.ini", "mysql");

                Dictionary<string, string> classTimeSetting =
                    iniReader.getINI().read("./config.ini", "classTime");

                if (serverSetting != null &&
                    dataSourceSetting != null &&
                    classTimeSetting != null)
                {

                    serverInfo.getServerInfo().setServerInfo(
                        serverSetting["ip"],
                        Convert.ToInt32(serverSetting["port"]),
                        serverSetting["mysqlpath"]);
                    serverInfo.getServerInfo().setMysqlBatFile(
                        "startMysql.bat", "queryMysql.bat", "stopMysql.bat");

                    dataSourceInfo.getDataSourceInfo().setDataSourceInfo(
                        dataSourceSetting["ip"],
                        Convert.ToInt32(dataSourceSetting["port"]),
                        dataSourceSetting["database"],
                        dataSourceSetting["user"],
                        dataSourceSetting["pwd"]);

                    string[] startHourStrs = classTimeSetting["startHour"].Split(',');
                    string[] startMinuteStrs = classTimeSetting["startMinute"].Split(',');
                    int[] startHour = new int[startHourStrs.Length];
                    int[] startMinute = new int[startMinuteStrs.Length];
                    for (int i = 0; i < startHourStrs.Length; i++)
                    {
                        startHour[i] = Convert.ToInt32(startHourStrs[i]);
                        startMinute[i] = Convert.ToInt32(startMinuteStrs[i]);
                    }
                    classTimeInfo.getClassTimeInfo().setClassTimeInfo(
                        Convert.ToInt32(classTimeSetting["interval"]),
                        startHour,
                        startMinute);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("config.ini文件读取错误：" + ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 检测mysql服务操作批处理文件是否存在
        /// </summary>
        /// <returns>返回布尔值</returns>
        private bool checkMysqlBat()
        {
            if (serverInfo.getServerInfo().getStartMysqlBatFile().Exists &&
                serverInfo.getServerInfo().getQueryMysqlBatFile().Exists &&
                serverInfo.getServerInfo().getStopMysqlBatFile().Exists)
            {
                return true;
            }
            return false;
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
                Console.WriteLine("运行启动MySQL服务批处理文件失败：" + ex.ToString());
            }
        }

        /// <summary>
        /// 查询mysql服务状态，如果运行成功则返回True,否则返回False
        /// </summary>
        /// <returns>返回布尔值</returns>
        private bool queryMysqlService()
        {
            string errMsg = string.Empty;
            string output = execBat(
                serverInfo
                .getServerInfo()
                .getQueryMysqlBatFile(), ref errMsg);
            if (output != null)
            {
                if (output.IndexOf("RUNNING") > -1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///运行批处理文件并返回执行结果与错误信息
        /// </summary>
        /// <param name="batFile">批处理文件对象</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        private string execBat(FileInfo batFile, ref String errMsg)
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

        /// <summary>
        /// 连接mysql，连接成功返回True，否则返回False
        /// </summary>
        /// <returns>返回布尔值</returns>
        private bool connMysql()
        {
            try
            {
                mysqlImp.getMysql().connect();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("mysql连接错误：" + ex.ToString());
            }
            return false;
        }

        /// <summary>
        /// 检测数据库中是否存在相应的数据表，都存在则返回True，部分不存在则返回False
        /// </summary>
        /// <returns>返回布尔值</returns>
        private bool checkTable()
        {
            if (mysqlImp.getMysql().query("select * from timeattendance") != null &&
                mysqlImp.getMysql().query("select * from signattendance") != null &&
                mysqlImp.getMysql().query("select * from timehistory") != null &&
                mysqlImp.getMysql().query("select * from signhistory") != null &&
                mysqlImp.getMysql().query("select * from temporarycore") != null &&
                mysqlImp.getMysql().query("select * from examcore") != null &&
                mysqlImp.getMysql().query("select * from coursecore") != null &&
                mysqlImp.getMysql().query("select * from allhomecore") != null &&
                mysqlImp.getMysql().query("select * from allcore") != null &&
                mysqlImp.getMysql().query("select * from allclasscore") != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 系统加载方法
        /// </summary>
        public void loadSystem()
        {
            formInfo.getFormInfo().getForm_load().loadProgress(10,160,"正在开始检测config.ini文件是否存在...");
            if (checkConfigINI())
            {
                formInfo.getFormInfo().getForm_load().loadProgress(20, 160, "config.ini文件存在");
                formInfo.getFormInfo().getForm_load().loadProgress(30, 160, "正在读取config.ini文件...");
                if (readConfigINI())
                {
                    formInfo.getFormInfo().getForm_load().loadProgress(40, 160, "读取config.ini文件成功");
                    formInfo.getFormInfo().getForm_load().loadProgress(50, 160, "正在检查MySQL服务批处理文件是否存在...");
                    if (checkMysqlBat())
                    {
                        formInfo.getFormInfo().getForm_load().loadProgress(60, 160, "MySQL服务批处理文件存在");
                        formInfo.getFormInfo().getForm_load().loadProgress(70, 160, "正在检查MySQL服务运行状态");
                        if (queryMysqlService())
                        {
                            formInfo.getFormInfo().getForm_load().loadProgress(80, 160, "MySQL服务正在运行");
                            formInfo.getFormInfo().getForm_load().loadProgress(90, 160, "正在尝试连接数据库源...");
                            if (connMysql())
                            {
                                formInfo.getFormInfo().getForm_load().loadProgress(110, 160, "连接数据库源成功");
                                formInfo.getFormInfo().getForm_load().loadProgress(130, 160, "正在检查数据库表是否完整...");
                                if (checkTable())
                                {
                                    formInfo.getFormInfo().getForm_load().loadProgress(150, 160, "数据库表完整");
                                    formInfo.getFormInfo().getForm_load().loadProgress(160, 160, "正在启动系统，请稍后...");
                                    formInfo.getFormInfo().getForm_load().loadSuccess();
                                    // formInfo.getFormInfo().getForm_load().loadFailed();
                                }
                                else
                                {
                                    // table is not exist
                                    formInfo.getFormInfo().getForm_load().loadFailed();
                                }
                            }
                            else
                            {
                                // attempt to connect mysql failed
                                formInfo.getFormInfo().getForm_load().loadFailed();
                            }
                        }
                        else
                        {
                            formInfo.getFormInfo().getForm_load().loadProgress(80, 160, "MySQL服务没有运行");
                            formInfo.getFormInfo().getForm_load().loadProgress(90, 160, "正在启动MySQL服务...");
                            startMysqlService();
                            formInfo.getFormInfo().getForm_load().loadProgress(100, 160, "正在检查MySQL服务运行是否正常...");
                            if (queryMysqlService())
                            {
                                formInfo.getFormInfo().getForm_load().loadProgress(110, 160, "MySQL服务运行正常");
                                // 12.attempt to connnect mysql
                                formInfo.getFormInfo().getForm_load().loadProgress(120, 160, "正在尝试连接数据库源...");
                                if (connMysql())
                                {
                                    formInfo.getFormInfo().getForm_load().loadProgress(130, 160, "连接数据库源成功");
                                    formInfo.getFormInfo().getForm_load().loadProgress(140, 160, "正在检查数据库表是否完整...");
                                    if (checkTable())
                                    {
                                        formInfo.getFormInfo().getForm_load().loadProgress(150, 160, "数据库表完整");
                                        formInfo.getFormInfo().getForm_load().loadProgress(160, 160, "正在启动系统，请稍后...");
                                        // formInfo.getFormInfo().getForm_load().loadSuccess();
                                        formInfo.getFormInfo().getForm_load().loadFailed();
                                    }
                                    else
                                    {
                                        // table is not exist
                                        formInfo.getFormInfo().getForm_load().loadFailed();
                                    }
                                }
                                else
                                {
                                    // attempt to connect mysql failed
                                    formInfo.getFormInfo().getForm_load().loadFailed();
                                }
                            }
                            else
                            {
                                // check service state is not RUNNING
                                controlImp.getControlImp().showDialog(
                                    formInfo.getFormInfo().getForm_load(), 
                                    "Mysql服务启动失败，请检测Mysql服务是否安装完整");
                            }
                        }
                    }
                    else
                    {
                        // mysql service bat is not exist
                        formInfo.getFormInfo().getForm_load().loadFailed();
                    }
                }
                else
                {
                    // read config.ini failed
                    formInfo.getFormInfo().getForm_load().loadFailed();
                }
            }
            else
            {
                // config.ini is not exist
                formInfo.getFormInfo().getForm_load().loadFailed();
            }
        }
    }
}
