using Course_Attendance_Check_System.formImp;
using Newtonsoft.Json.Linq;
using publicClass;
using System;
using System.Collections.Generic;
using System.Data;
using systemSetting;

namespace Course_Attendance_Check_System.attendanceServer
{
    class attendanceServerManager
    {
        private static attendanceServerManager manager = new attendanceServerManager();
        public static attendanceServerManager getManager()
        {
            return manager;
        }

        Dictionary<attendanceServerSocket, string> studentClientList =
            new Dictionary<attendanceServerSocket, string>();

        /// <summary>
        /// 添加学生手机客户端对象
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        public void addStudentClient(attendanceServerSocket studentClient)
        {
            studentClientList.Add(studentClient, "");
            connRsp(studentClient);
        }

        /// <summary>
        /// 更新学生手机客户端对象
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        /// <param name="stuId">学号</param>
        public void updateStudentClient(attendanceServerSocket studentClient,string stuId)
        {
            studentClientList[studentClient] = stuId;
        }

        /// <summary>
        /// 查出学生手机客户端对象
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        public void removeStudentClient(attendanceServerSocket studentClient)
        {
            studentClientList.Remove(studentClient);
        }

        /// <summary>
        /// 连接回复
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        public void connRsp(attendanceServerSocket studentClient)
        {
            JObject connRsp = new JObject();
            connRsp.Add("type", "connRsp");
            connRsp.Add("randomKey", attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
            connRsp.Add("attendanceType", loadStudentListInfo.getLoadStudent().getAttendanceType().ToString());
            attendanceInfo.getAttendance().getStartCheck().showServerReceive("发送数据给客户端：" + connRsp.ToString());
            studentClient.sendMsg(connRsp.ToString());
        }

        /// <summary>
        /// 学生手机客户端消息管理
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        /// <param name="messageStr">客户端发送给服务端的消息</param>
        public void messageManager(attendanceServerSocket studentClient, string messageStr)
        {
            JObject reqMessage = JObject.Parse(messageStr);
            switch (reqMessage["type"].ToString())
            {
                case "signReq":
                    {
                        string stuId = aesImp.getAesImp().decrypt(
                            reqMessage["stuId"].ToString(), 
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                        string stuTele = aesImp.getAesImp().decrypt(
                            reqMessage["stuTele"].ToString(),
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                        string stuMac = aesImp.getAesImp().decrypt(
                            reqMessage["stuMac"].ToString(),
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                        signStudent(studentClient, stuId, stuTele, stuMac);
                    }
                    break;
                case "timeReq":
                    {
                        // keepTime save and calculate classCore
                        string stuId = aesImp.getAesImp().decrypt(
                            reqMessage["stuId"].ToString(),
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                        int keepTime = Convert.ToInt32(aesImp.getAesImp().decrypt(
                            reqMessage["keepTime"].ToString(),
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                        timeReq(studentClient,stuId, keepTime);
                    }
                    break;
                default:break;
            }
        }

        /// <summary>
        /// 下课结束
        /// </summary>
        public void endClass()
        {
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                foreach (attendanceServerSocket studentClient in studentClientList.Keys)
                {
                    JObject endClass = new JObject();
                    endClass.Add("type", "endClass");
                    studentClient.sendMsg(endClass.ToString());
                }
            }
        }

        /// <summary>
        /// 学生签到
        /// </summary>
        /// <param name="studentClient">学生手机客户端对象</param>
        /// <param name="stuId">学生学号</param>
        /// <param name="stuTele">学生手机号码</param>
        /// <param name="stuMac">学生手机MAC地址</param>
        private void signStudent(attendanceServerSocket studentClient, string stuId, string stuTele, string stuMac)
        {
            JObject signRsp = new JObject();
            signRsp.Add("type", "signRsp");
            if (checkStudentExist(stuId))
            {
                if (checkStudentSign(stuId))
                {
                    // 检测该学号已经签到过了
                    if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                    {
                        // 检测考勤模式处于计时模式
                        if (checkStudentTeleInfo(stuId, stuTele, stuMac))
                        {
                            // 回复计时
                            returnTime(stuId,signRsp);
                            signRsp.Add("returnType", "2");
                        }
                        else
                        {
                            // 回复计时失败，原因：该学号的手机号码和手机MAC信息与签到时的信息不一致
                            signRsp.Add("result", aesImp.getAesImp().encrypt(
                                "该学号的手机号码和手机MAC信息与签到时的信息不一致",
                                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                            signRsp.Add("returnType", "0");
                        }
                    }
                    else
                    {
                        // 检测考勤模式处于签到模式，签到失败：该学号已经签到过了
                        signRsp.Add("result", aesImp.getAesImp().encrypt(
                            "该学号已经签到过了",
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                        signRsp.Add("returnType", "0");
                    }
                }
                else
                {
                    // 检测该学号没有签到
                    if (checkStudentTele(stuTele))
                    {
                        // 检测该手机号码已经被使用
                        signRsp.Add("result",aesImp.getAesImp().encrypt(
                            "该手机号码已经被使用",
                            attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                        signRsp.Add("returnType", "0");
                    }
                    else
                    {
                        // 该手机号码没被使用
                        if (checkStudentMac(stuMac))
                        {
                            // 检测该手机设备已经被使用
                            signRsp.Add("result", aesImp.getAesImp().encrypt(
                                "该手机设备已经被使用",
                                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                            signRsp.Add("returnType", "0");
                        }
                        else
                        {
                            // 检测该手机设备没有被使用
                            // 学生签到
                            sign(stuId,stuTele,stuMac);
                            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                            {
                                signRsp.Add("result", aesImp.getAesImp().encrypt(
                                    "签到成功,请认真上课",
                                    attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                            }
                            else
                            {
                                signRsp.Add("result", aesImp.getAesImp().encrypt(
                                    "签到成功，计时过程请关闭屏幕并认真上课",
                                    attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                            }
                            signRsp.Add("interval",aesImp.getAesImp().encrypt(
                                attendanceServerInfo.getAttendanceServerInfo().getStartServerInterval().ToString()
                                ,attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
                            signRsp.Add("returnType", "1");
                            updateStudentClient(studentClient,stuId);
                            if (!loadStudentListInfo.getLoadStudent().getAttendanceType())
                            {
                                mysqlImp.getMysql().update("update signattendance set allcore = score + ecore where stuId='" + stuId + "'");
                                mysqlImp.getMysql().update("update signattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
                                mysqlImp.getMysql().update("update signattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
                            }
                        }
                    }
                }
            }
            else
            {
                signRsp.Add("result", aesImp.getAesImp().encrypt(
                    "学号不存在，请重新输入学号",
                    attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            }
            studentClient.sendMsg(signRsp.ToString());
            attendanceInfo.getAttendance().getStartCheck().showServerReceive(signRsp.ToString());
        }

        /// <summary>
        /// 检测学生是否存在
        /// </summary>
        /// <param name="stuId">学生学号</param>
        /// <returns>布尔值</returns>
        public bool checkStudentExist(string stuId)
        {
            // 检测学号是否存在
            try
            {
                DataTable table = null;
                if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                {
                    table = mysqlImp.getMysql().showTable(
                        "select stuId from timeattendance where stuId = '"
                        + stuId + "'");
                    if (table != null && table.Rows[0]["stuId"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
                else
                {
                    table = mysqlImp.getMysql().showTable(
                        "select stuId from signattendance where stuId = '"
                        + stuId + "'");
                    if (table != null && table.Rows[0]["stuId"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
            }
            catch (Exception){ }
            return false;
        }

        /// <summary>
        /// 检测学生是否签到
        /// </summary>
        /// <param name="stuId">学生学号</param>
        /// <returns>布尔值</returns>
        public bool checkStudentSign(string stuId)
        {
            try
            {
                // 检测学号是否签到,已经签到过了返回true，未签到返回false
                DataTable dataTable = null;
                if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                {
                    dataTable = mysqlImp.getMysql().showTable(
                        "select stuId from timeattendance where stuId = '"
                        + stuId + "' and if_sign=true");
                    if (dataTable != null && dataTable.Rows[0]["stuId"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
                else
                {
                    dataTable = mysqlImp.getMysql().showTable(
                        "select stuId from signattendance where stuId = '"
                        + stuId + "' and if_sign=true");
                    if (dataTable != null && dataTable.Rows[0]["stuId"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
            }
            catch (Exception){ }
            return false;
        }

        /// <summary>
        /// 检测学生手机号码是否存在
        /// </summary>
        /// <param name="stuTele">学生手机号码</param>
        /// <returns>布尔值</returns>
        private bool checkStudentTele(string stuTele)
        {
            // 检测学生手机号码是否存在
            try
            {
                DataTable table = null;
                stuTele = aesImp.getAesImp().encrypt(stuTele, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                {
                    table = mysqlImp.getMysql().showTable(
                        "select stuTele from timeattendance where stuTele = '"
                        + stuTele + "'");
                    if (table != null && table.Rows[0]["stuTele"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
                else
                {
                    table = mysqlImp.getMysql().showTable(
                        "select stuTele from signattendance where stuTele = '"
                        + stuTele + "'");
                    if (table != null && table.Rows[0]["stuTele"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
            }
            catch (Exception) { }
            return false;
        }

        /// <summary>
        /// 检测学生手机MAC是否存在
        /// </summary>
        /// <param name="stuMac">学生手机MAC</param>
        /// <returns>布尔值</returns>
        private bool checkStudentMac(string stuMac)
        {
            try
            {
                stuMac = aesImp.getAesImp().encrypt(stuMac, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                {
                    if (mysqlImp.getMysql().showTable(
                        "select stuMac from timeattendance where stuMac='"
                        + stuMac + "'").Rows[0]["stuMac"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
                else
                {
                    if (mysqlImp.getMysql().showTable(
                        "select stuMac from signattendance where stuMac='"
                        + stuMac + "'").Rows[0]["stuMac"] != System.DBNull.Value)
                    {
                        return true;
                    }
                }
            }
            catch (Exception) { }
            return false;
        }

        /// <summary>
        /// 检测学生手机号码、手机MAC与学生学号是否匹配
        /// </summary>
        /// <param name="stuId">学生学号</param>
        /// <param name="stuTele">学生手机号码</param>
        /// <param name="stuMac">学生手机MAC</param>
        /// <returns></returns>
        private bool checkStudentTeleInfo(string stuId, string stuTele, string stuMac)
        {
            try
            {
                DataTable table = null;
                stuTele = aesImp.getAesImp().encrypt(stuTele, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                stuMac = aesImp.getAesImp().encrypt(stuMac, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
                // 学号与手机号码、手机MAC信息是否一致
                table = mysqlImp.getMysql().showTable(
                    "select stuId from timeattendance where stuId='" + stuId
                    + "' and stuTele='" + stuTele
                    + "' and stuMac='" + stuMac
                    + "';");
                if (table != null && table.Rows[0]["stuId"] != System.DBNull.Value)
                {
                    return true;
                }
            } catch (Exception) { }
            return false;
        }

        /// <summary>
        /// 学生签到
        /// </summary>
        /// <param name="stuId">学生学号</param>
        /// <param name="stuTele">学生手机号码</param>
        /// <param name="stuMac">学生手机MAC</param>
        private void sign(string stuId,string stuTele,string stuMac)
        {
            stuTele = aesImp.getAesImp().encrypt(stuTele, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
            stuMac = aesImp.getAesImp().encrypt(stuMac, attendanceServerInfo.getAttendanceServerInfo().getRandomKey());
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                mysqlImp.getMysql().update("update timeattendance set stuTele='" + stuTele 
                    + "',stuMac='" + stuMac 
                    + "',signDate=CURDATE(),signTime=CURTIME(),if_sign=true where stuId ='" + stuId + "'");
            }
            else
            {
                mysqlImp.getMysql().update("update signattendance set stuTele='" + stuTele
                    + "',stuMac='" + stuMac
                    + "',signDate=CURDATE(),signTime=CURTIME(),score=100,if_sign=true where stuId ='" + stuId + "'");
            }
        }

        /// <summary>
        /// 返回持续时间和课堂成绩
        /// </summary>
        /// <param name="stuId">学生学号</param>
        /// <param name="signRsp">签到回复消息JSON对象</param>
        private void returnTime(string stuId,JObject signRsp)
        {
            DataTable table = mysqlImp.getMysql()
                .showTable("select keepTime,score from timeattendance where stuId='" + stuId + "'");
            signRsp.Add("keepTime",aesImp.getAesImp().encrypt(
                table.Rows[0]["keepTime"].ToString(),
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            signRsp.Add("interval", aesImp.getAesImp().encrypt(
                attendanceServerInfo.getAttendanceServerInfo().getStartServerInterval().ToString(),
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            signRsp.Add("score", aesImp.getAesImp().encrypt(
                table.Rows[0]["score"].ToString(),
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            signRsp.Add("result", aesImp.getAesImp().encrypt(
                "回复计时成功，请关闭屏幕后认真上课",
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
        }

        /// <summary>
        /// 学生手机客户端计时请求
        /// </summary>
        /// <param name="studentClient">学生手机客户端</param>
        /// <param name="stuId">学号</param>
        /// <param name="keepTime">持续计时时间</param>
        private void timeReq(attendanceServerSocket studentClient, string stuId, int keepTime)
        {
            JObject timeRsp = new JObject();
            timeRsp.Add("type", "timeRsp");
            int score = (int)(((float)keepTime / (float)attendanceServerInfo.getAttendanceServerInfo().getStartServerInterval()) * (float)100);
            if (score >= 100)
            {
                score = 100;
            }
            mysqlImp.getMysql().update("update timeattendance set score=" + score + ",keepTime = " + keepTime + " where stuId='" + stuId + "'");
            DataTable table = mysqlImp.getMysql().showTable("select keepTime,score from timeattendance where stuId='" + stuId + "'");
            timeRsp.Add("keepTime", aesImp.getAesImp().encrypt(
                table.Rows[0]["keepTime"].ToString(),
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            timeRsp.Add("score", aesImp.getAesImp().encrypt(
                table.Rows[0]["score"].ToString(),
                attendanceServerInfo.getAttendanceServerInfo().getRandomKey()));
            mysqlImp.getMysql().update("update timeattendance set allcore = score + ecore where stuId='"+stuId+"'");
            mysqlImp.getMysql().update("update timeattendance set allcore = 100 where allcore > 100 and stuId='" + stuId + "'");
            mysqlImp.getMysql().update("update timeattendance set allcore = 0 where allcore < 0 and stuId='" + stuId + "'");
            studentClient.sendMsg(timeRsp.ToString());
        }

        /// <summary>
        /// 随机点名返回触发震动的消息
        /// </summary>
        /// <param name="stuId">学号</param>
        public void randomCall(string stuId)
        {
            foreach (attendanceServerSocket studentClient in studentClientList.Keys)
            {
                if (studentClientList[studentClient] == stuId)
                {
                    JObject shock = new JObject();
                    shock.Add("type", "shock");
                    studentClient.sendMsg(shock.ToString());
                }
            }
        }

    }
}
