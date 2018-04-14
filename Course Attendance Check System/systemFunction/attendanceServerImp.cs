using Course_Attendance_Check_System.formImp;
using publicClass;
using System;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using systemSetting;

namespace Course_Attendance_Check_System.attendanceServer
{
    class attendanceServerImp
    {
        private static attendanceServerImp attendanceServer = new attendanceServerImp();
        public static attendanceServerImp getAttendanceServer()
        {
            return attendanceServer;
        }

        /// <summary>
        /// 初始化下课时间
        /// </summary>
        public void setEndTime()
        {
            int interval = classTimeInfo.getClassTimeInfo().getInterval();
            int[] startHour = classTimeInfo.getClassTimeInfo().getStartHour();
            int[] startMinute = classTimeInfo.getClassTimeInfo().getStartMinute();
            int[] endHour = new int[classTimeInfo.getClassTimeInfo().getStartHour().Length];
            int[] endMinute = new int[classTimeInfo.getClassTimeInfo().getStartMinute().Length];

            for (int i = 0; i < classTimeInfo.getClassTimeInfo().getStartHour().Length; i++)
            {
                if (startMinute[i] + interval <= 59)
                {
                    endHour[i] = startHour[i];
                    endMinute[i] = startMinute[i] + interval;
                }
                else
                {
                    endHour[i] = startHour[i] + 1;
                    endMinute[i] = startMinute[i] + interval - 60;
                }
            }

            classTimeInfo.getClassTimeInfo().setEndTimeInfo(endHour, endMinute);
        }

        /// <summary>
        /// 设置启动服务端的系统时间
        /// </summary>
        private void setCurrentTime()
        {
            DateTime time = DateTime.Now;
            int startServerHour = time.Hour;
            int startServerMinute = time.Minute;
            int startServerInterval = 0;
            int[] startHour = classTimeInfo.getClassTimeInfo().getStartHour();
            int[] startMinute = classTimeInfo.getClassTimeInfo().getStartMinute();
            int[] endHour = classTimeInfo.getClassTimeInfo().getEndHour();
            int[] endMinute = classTimeInfo.getClassTimeInfo().getEndMinute();

            for (int i = 0; i < classTimeInfo.getClassTimeInfo().getStartHour().Length; i++)
            {
                if (startServerHour == startHour[i] && startServerHour == endHour[i])
                {
                    if (startMinute[i] <= startServerMinute && startServerMinute < endMinute[i])
                    {
                        startServerInterval = endMinute[i] - startServerMinute;
                    }
                }
                else if (startServerHour == startHour[i] && startServerHour < endHour[i])
                {
                    if (startMinute[i] <= startServerMinute && startServerMinute <= 59)
                    {
                        startServerInterval = endMinute[i] + 59 - startServerMinute;
                    }
                }
                else if (startHour[i] < startServerHour && startServerHour == endHour[i])
                {
                    if (startServerMinute < endMinute[i])
                    {
                        startServerInterval = endMinute[i] - startServerMinute;
                    }
                }
            }
            attendanceServerInfo.getAttendanceServerInfo().setStartServerTime(
                startServerHour, startServerMinute, startServerInterval);
            attendanceInfo.getAttendance().getStartCheck().showServerReceive("本次课堂时间" + startServerInterval);
        }

        /// <summary>
        /// 设置服务端的密钥
        /// </summary>
        private void saveServerKey()
        {
            string[] randomStr = {
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l",
                "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x",
                "y", "z",
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",
                "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X",
                "Y", "Z",
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"};
            string mainKey = "jfsnci7owkal2ot7g1scs3rng4suck32";
            string randomKey = "";
            Random rand = new Random();
            for (int j = 0; j < 32; j++)
            {
                randomKey += randomStr[rand.Next(0, randomStr.Length)];
            }
            attendanceServerInfo.getAttendanceServerInfo().setServerKey(mainKey, randomKey);
        }

        /// <summary>
        /// 检测当前系统时间
        /// </summary>
        /// <returns></returns>
        public bool checkCurrentTime()
        {
            DateTime time = DateTime.Now;
            int startServerHour = time.Hour;
            int startServerMinute = time.Minute;
            int[] startHour = classTimeInfo.getClassTimeInfo().getStartHour();
            int[] startMinute = classTimeInfo.getClassTimeInfo().getStartMinute();
            int[] endHour = classTimeInfo.getClassTimeInfo().getEndHour();
            int[] endMinute = classTimeInfo.getClassTimeInfo().getEndMinute();

            for (int i = 0; i < startHour.Length; i++)
            {
                if (startServerHour == startHour[i] && startServerHour == endHour[i])
                {
                    if (startMinute[i] <= startServerMinute && startServerMinute < endMinute[i])
                    {
                        return true;
                    }
                }
                else if (startServerHour == startHour[i] && startServerHour < endHour[i])
                {
                    if (startMinute[i] <= startServerMinute && startServerMinute <= 59)
                    {
                        return true;
                    }
                }
                else if (startHour[i] < startServerHour && startServerHour == endHour[i])
                {
                    if (startServerMinute < endMinute[i])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 启动考勤服务端线程
        /// </summary>
        public void startAttendanceServer()
        {
            new Thread(new ThreadStart(attendanceServerThread)).Start();
        }

        /// <summary>
        /// 服务端线程
        /// </summary>
        private void attendanceServerThread()
        {
            setCurrentTime();
            saveServerKey();
            Socket serverSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(
                IPAddress.Parse(serverInfo.getServerInfo().getServerIP()),
                serverInfo.getServerInfo().getServerPort()
                ));
            formInfo.getFormInfo().getForm_attendance().setCurrentInterval();
            try
            {
                serverSocket.Listen(3000);          // 最大监听客户端数量
                formInfo.getFormInfo().getForm_attendance().startCheck();
                attendanceInfo.getAttendance().getStartCheck().showServerReceive("服务端启动成功");
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务端启动失败：" + ex.ToString());
            }
            if (serverSocket.IsBound)
            {
                while (true)
                {
                    Socket client = serverSocket.Accept();
                    attendanceInfo.getAttendance().getStartCheck().showServerReceive("发现客户端 ：" + client.RemoteEndPoint);
                    attendanceServerSocket attendanceSocket = new attendanceServerSocket(client);
                    new Thread(new ThreadStart(attendanceSocket.receiveMsg)).Start();
                    attendanceServerManager.getManager().addStudentClient(attendanceSocket);
                }
            }
        }

        /// <summary>
        /// 实时学生道勤情况查询
        /// </summary>
        public void startAttendanceSelect()
        {
            DataTable table = null;
            int absentCount = 0;
            int attendantCount = 0;
            int allStudentCount = 0;
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                table = mysqlImp.getMysql().showTable(@"
                    select 
                    stuId               as  '学号'    ,
                    stuClassName        as  '班级'    ,
                    stuName             as  '姓名'    ,
                    score               as  '签到成绩',
                    ecore               as  '额外成绩',
                    allcore             as  '总成绩'  ,
                    signTime            as  '签到时间'
                    from    timeattendance
                    where if_sign = true
                    ");
                absentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from timeattendance where if_sign = false;").Rows[0]["count(*)"].ToString());
                attendantCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from timeattendance where if_sign = true;").Rows[0]["count(*)"].ToString());
                allStudentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from timeattendance;").Rows[0]["count(*)"].ToString());
            }
            else
            {
                table = mysqlImp.getMysql().showTable(@"
                    select 
                    stuId               as  '学号'    ,
                    stuClassName        as  '班级'    ,
                    stuName             as  '姓名'    ,
                    score               as  '签到成绩',
                    ecore               as  '额外成绩',
                    allcore             as  '总成绩'  ,
                    signTime            as  '签到时间'
                    from    signattendance
                    where   if_sign = true
                    ");
                absentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from signattendance where if_sign = false;").Rows[0]["count(*)"].ToString());
                attendantCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from signattendance where if_sign = true;").Rows[0]["count(*)"].ToString());
                allStudentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable(
                    "select count(*) from signattendance;").Rows[0]["count(*)"].ToString());
            }
            attendanceInfo.getAttendance().getStartCheck().showAttendance(table, attendantCount, absentCount, allStudentCount);
        }

        /// <summary>
        /// 下课结束
        /// </summary>
        public void endClass()
        {
            attendanceServerManager.getManager().endClass();
            formInfo.getFormInfo().getForm_attendance().endCheck();
            showEndClassInfo();
        }

        /// <summary>
        /// 显示下课结算信息
        /// </summary>
        private void showEndClassInfo()
        {
            int attendantCount, absentCount, allStudentCount, attendancePercent = 0;
            float classCoreAvg = 0;
            DataTable classCoreAver = new DataTable();
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                attendantCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from timeattendance where if_sign = true").Rows[0]["count(*)"].ToString());
                absentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from timeattendance where if_sign = false").Rows[0]["count(*)"].ToString());
                allStudentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from timeattendance").Rows[0]["count(*)"].ToString());
                attendancePercent = (int)(((float)attendantCount / (float)allStudentCount) * (float)100);
                classCoreAver = mysqlImp.getMysql()
                    .showTable("select AVG(allcore) as 'classCoreAver' from timeattendance where if_sign= true;");
                if (classCoreAver.Rows[0]["classCoreAver"] == System.DBNull.Value)
                {
                    classCoreAvg = 0;
                }
                else
                {
                    classCoreAvg = Convert.ToSingle(classCoreAver.Rows[0]["classCoreAver"].ToString());
                }
            }
            else
            {
                attendantCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from signattendance where if_sign = true").Rows[0]["count(*)"].ToString());
                absentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from signattendance where if_sign = false").Rows[0]["count(*)"].ToString());
                allStudentCount = Convert.ToInt32(mysqlImp.getMysql()
                    .showTable("select count(*) from signattendance").Rows[0]["count(*)"].ToString());
                attendancePercent = (int)(((float)attendantCount / (float)allStudentCount) * (float)100);
                classCoreAver = mysqlImp.getMysql()
                    .showTable("select AVG(allcore) as 'classCoreAver' from signattendance where if_sign= true;");
                if (classCoreAver.Rows[0]["classCoreAver"] == System.DBNull.Value)
                {
                    classCoreAvg = 0;
                }
                else
                {
                    classCoreAvg = Convert.ToSingle(classCoreAver.Rows[0]["classCoreAver"].ToString());
                }
            }
            string outputPath = loadStudentListInfo.getLoadStudent().getOutputAttendancePath();
            attendanceInfo.getAttendance().getEndCheck().setEndCheck(
                attendantCount, absentCount, 
                allStudentCount, attendancePercent, 
                classCoreAvg, outputPath);
        }

        /// <summary>
        /// 手动签到
        /// </summary>
        /// <param name="stuId">学号</param>
        /// <param name="score">签到分数</param>
        public void manualSign(string stuId,int score)
        {
            if (attendanceServerManager.getManager().checkStudentExist(stuId))
            {
                if (attendanceServerManager.getManager().checkStudentSign(stuId))
                {
                    controlImp.getControlImp().showDialog(
                    formInfo.getFormInfo().getForm_attendance(),
                    "该学号已经签到过了");
                }
                else
                {
                    if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                    {
                        mysqlImp.getMysql().update(
                            "update timeattendance set score=" + score
                            + ",if_sign=true,signDate=CURDATE(),signTime=CURTIME() where stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update timeattendance set allcore = score + ecore where stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update timeattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update timeattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                    }
                    else
                    {
                        mysqlImp.getMysql().update(
                            "update signattendance set score=" + score
                            + ",if_sign=true,signDate=CURDATE(),signTime=CURTIME() where stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update signattendance set allcore = score + ecore where stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update signattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                        mysqlImp.getMysql().update("update signattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                    }
                    controlImp.getControlImp().showDialog(
                        attendanceInfo.getAttendance().getManualSign(),
                        "签到成功");
                    attendanceInfo.getAttendance().getManualSign().Hide();
                }
            }
            else
            {
                controlImp.getControlImp().showDialog(
                    formInfo.getFormInfo().getForm_attendance(),
                    "该学号不存在");
            }
        }

        /// <summary>
        /// 奖惩处理
        /// </summary>
        /// <param name="stuId">学号</param>
        /// <param name="ecore">额外分数</param>
        /// <param name="type">处理类型</param>
        public void rewardAndPunish(string stuId, int ecore,bool type)
        {
            // type = true为奖励，false为处罚
            if (attendanceServerManager.getManager().checkStudentExist(stuId))
            {
                if (attendanceServerManager.getManager().checkStudentSign(stuId))
                {
                    if (type)
                    {
                        if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                        {
                            mysqlImp.getMysql().update(
                                "update timeattendance set ecore=ecore+" + ecore
                                +" where stuId='"+stuId+"'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = score + ecore where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                        }
                        else
                        {
                            mysqlImp.getMysql().update(
                                "update signattendance set ecore=ecore+" + ecore
                                + " where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = score + ecore where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                        }
                        controlImp.getControlImp().showDialog(
                            attendanceInfo.getAttendance().getRewardAndPunish(),
                            "奖励成功");
                    }
                    else
                    {
                        if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                        {
                            mysqlImp.getMysql().update(
                                "update timeattendance set ecore=ecore-" + ecore
                                + " where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = score + ecore where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update timeattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");

                        }
                        else
                        {
                            mysqlImp.getMysql().update(
                                "update signattendance set ecore=ecore-" + ecore
                                + " where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = score + ecore where stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                            mysqlImp.getMysql().update("update signattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                        }
                        controlImp.getControlImp().showDialog(
                            attendanceInfo.getAttendance().getRewardAndPunish(),
                            "惩罚成功");
                    }
                    attendanceInfo.getAttendance().getRewardAndPunish().Hide();
                }
                else
                {
                    controlImp.getControlImp().showDialog(
                    attendanceInfo.getAttendance().getRewardAndPunish(),
                    "该学号尚未签到");
                }
            }
            else
            {
                controlImp.getControlImp().showDialog(
                    attendanceInfo.getAttendance().getRewardAndPunish(),
                    "该学号不存在");
            }
        }

        /// <summary>
        /// 随机点名
        /// </summary>
        public void randomCallStudent()
        {
            DataTable table = new DataTable();
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                table = mysqlImp.getMysql().showTable(
                "select stuId,stuClassName,stuName from timeattendance where if_sign=true order by rand() LIMIT 1;");
            }
            else
            {
                table = mysqlImp.getMysql().showTable(
                "select stuId,stuClassName,stuName from signattendance where if_sign=true order by rand() LIMIT 1;");
            }
            if (table.Rows.Count > 0)
            {
                string stuId = table.Rows[0]["stuId"].ToString();
                string stuClassName = table.Rows[0]["stuClassName"].ToString();
                string stuName = table.Rows[0]["stuName"].ToString();
                attendanceServerManager.getManager().randomCall(stuId);
                controlImp.getControlImp().showDialog(formInfo.getFormInfo().getForm_attendance(),
                    "学号为：" + stuId
                    + "\r\n班级为：" + stuClassName
                    + "\r\n姓名为：" + stuName);
            }
            else
            {
                controlImp.getControlImp().showDialog(formInfo.getFormInfo().getForm_attendance(),
                    "还没有学生签到，请稍后再随机点名");
            }
        }

        /// <summary>
        /// 查询缺勤学生
        /// </summary>
        public void selectAbsence()
        {

        }

        /// <summary>
        /// 输出道勤名单文件
        /// </summary>
        public void outputAttendantFile()
        {
            DataTable attendanceDetailTable = new DataTable();
            DataTable attendanceTable = new DataTable();
            DataTable absenceTable = new DataTable();
            DateTime time = DateTime.Now;
            string attendanceDate = time.Year + "年" 
                + time.Month + "月" 
                + time.Day + "日"
                + time.Hour + "时"
                + time.Minute + "分";
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                attendanceDetailTable = mysqlImp.getMysql()
                    .showTable("select stuId,stuClassName,stuName,score,ecore,allcore from timeattendance");
                absenceTable = mysqlImp.getMysql()
                    .showTable("select stuId,stuClassName,stuName from timeattendance where if_sign = false;");
            }
            else
            {
                attendanceDetailTable = mysqlImp.getMysql()
                    .showTable("select stuId,stuClassName,stuName,score,ecore,allcore from signattendance");
                absenceTable = mysqlImp.getMysql()
                    .showTable("select stuId,stuClassName,stuName from signattendance where if_sign = false;");
            }
            string[] attendanceDetailContent = new string[attendanceDetailTable.Rows.Count + 2];
            string[] attendanceContent = new string[attendanceDetailTable.Rows.Count + 2];
            string[] absentContent = new string[absenceTable.Rows.Count + 2];

            attendanceDetailContent[0] = "//时间,"+ attendanceDate + ",课程名称,#请填写#,道勤人数," + (attendanceDetailTable.Rows.Count - absenceTable.Rows.Count) + "人";
            attendanceDetailContent[1] = "//学号,班级,姓名,签到成绩,额外成绩,本次课堂成绩";
            attendanceContent[0] = "//时间," + attendanceDate + ",课程名称,#请填写#,道勤人数," + (attendanceDetailTable.Rows.Count - absenceTable.Rows.Count) + "人";
            attendanceContent[1] = "//学号,班级,姓名,本次课堂成绩";
            absentContent[0] = "//时间," + attendanceDate + ",课程名称,#请填写#,缺勤人数," + absenceTable.Rows.Count + "人";
            absentContent[1] = "//学号,班级,姓名";
            int i = 2;
            for (; i < attendanceDetailTable.Rows.Count + 2; i++)
            {
                attendanceDetailContent[i] =
                    attendanceDetailTable.Rows[i - 2]["stuId"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["stuClassName"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["stuName"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["score"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["ecore"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["allcore"].ToString() + ",";
                attendanceContent[i] = 
                    attendanceDetailTable.Rows[i - 2]["stuId"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["stuClassName"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["stuName"].ToString() + ","
                    + attendanceDetailTable.Rows[i - 2]["allcore"].ToString() + ",";
            }
            for (i = 2; i < absenceTable.Rows.Count + 2; i++)
            {
                absentContent[i] =
                    absenceTable.Rows[i - 2]["stuId"].ToString() + ","
                    + absenceTable.Rows[i - 2]["stuClassName"].ToString() + ","
                    + absenceTable.Rows[i - 2]["stuName"].ToString();
            }
            System.IO.File.WriteAllLines(
                loadStudentListInfo.getLoadStudent().getOutputAttendancePath() + @"\"+ attendanceDate + "的课堂道勤表-详细.csv",
                attendanceDetailContent, Encoding.UTF8);
            System.IO.File.WriteAllLines(
                loadStudentListInfo.getLoadStudent().getOutputAttendancePath() + @"\" + attendanceDate + "的课堂道勤表.csv",
                attendanceContent, Encoding.UTF8);
            System.IO.File.WriteAllLines(
                loadStudentListInfo.getLoadStudent().getOutputAttendancePath() + @"\" + attendanceDate + "的课堂缺勤表.csv",
                absentContent, Encoding.UTF8);
            controlImp.getControlImp().showDialog(attendanceInfo.getAttendance().getEndCheck(), "输出成功");
        }
    }
}
