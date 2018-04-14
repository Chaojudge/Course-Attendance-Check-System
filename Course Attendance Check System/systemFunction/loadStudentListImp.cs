using Course_Attendance_Check_System.formImp;
using publicClass;
using System;
using System.Data;
using System.IO;
using systemSetting;

namespace Course_Attendance_Check_System.systemFunction
{
    class loadStudentListImp
    {
        private static loadStudentListImp loadStudentList = new loadStudentListImp();

        /// <summary>
        /// 获取实例化后的loadStudentList对象
        /// </summary>
        /// <returns>返回实例化后的loadStudentList对象</returns>
        public static loadStudentListImp getLoadStudentListImp()
        {
            return loadStudentList;
        }

        /// <summary>
        /// 保存学生名单文件路径并设置考勤模式
        /// </summary>
        /// <param name="studentListPath"></param>
        /// <param name="outputAttendancePath"></param>
        /// <param name="attendanceType"></param>
        public void saveLoadStudentListInfo(string studentListPath, string outputAttendancePath,bool attendanceType)
        {
            loadStudentListInfo.getLoadStudent().setLoadStudentListInfo(studentListPath, outputAttendancePath, attendanceType);
        }

        /// <summary>
        /// 导入学生名单到数据库
        /// </summary>
        public void loadStudent()
        {
            try
            {  
                using (StreamReader sr = new StreamReader(
                    loadStudentListInfo.getLoadStudent().getStudentListPath(),
                    System.Text.Encoding.GetEncoding("gb2312")))
                {
                    string str;
                    string[] strs = new string[20];
                    if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                    {
                        truncate("timeattendance");
                    }
                    else
                    {
                        truncate("signattendance");
                    }
                    while ((str = sr.ReadLine()) != null)
                    {
                        if (str.IndexOf("//") > -1)
                        {
                            continue;
                        }
                        else
                        {
                            strs = str.Split(',');
                            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
                            {
                                mysqlImp.getMysql().update(""
                                    + "insert into " 
                                    + "timeattendance" 
                                    + "(stuId,stuClassName,stuName,stuTele,stuMac,score,ecore,allcore,signDate,signTime,keepTime,if_sign) "
                                    + "value('" + strs[0] + "',"
                                    + "'" + strs[1] + "',"
                                    + "'" + strs[2] + "',null,null,0,0,0,'00-00-00','00:00:00',0,0);");
                            }
                            else
                            {
                                mysqlImp.getMysql().update(""
                                + "insert into "
                                + "signattendance"
                                + "(stuId,stuClassName,stuName,stuTele,stuMac,score,ecore,allcore,signDate,signTime,if_sign) "
                                    + "value('" + strs[0] + "',"
                                    + "'" + strs[1] + "',"
                                    + "'" + strs[2] + "',null,null,0,0,0,'00-00-00','00:00:00',0);");
                            }
                        }
                    }
                }
                showStudentList();
                showAllStudentCount();
                attendanceInfo.getAttendance().getLoadStudentList().setLoadBtnToStartCheck();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 清除学生名单数据库表
        /// </summary>
        /// <param name="tableName"></param>
        private void truncate(string tableName)
        {
            try
            {
                if (tableName.Equals("timeattendance"))
                {
                    mysqlImp.getMysql().update("insert into timehistory"+
                        "(stuId,stuClassName,stuName,stuTele,stuMac,score,ecore,allcore,signDate,signTime,keepTime,if_sign) "
                        + "select * from timeattendance;");
                    mysqlImp.getMysql().update("truncate table timeattendance;");
                }
                else if (tableName.Equals("signattendance"))
                {
                    mysqlImp.getMysql().update("insert into signhistory" +
                        "(stuId,stuClassName,stuName,stuTele,stuMac,score,ecore,allcore,signDate,signTime,if_sign) "
                        + "select * from signattendance;");
                    mysqlImp.getMysql().update("truncate table signattendance;");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 预览学生名单
        /// </summary>
        private void showStudentList()
        {
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                attendanceInfo.getAttendance().getLoadStudentList().showStudentList(
                    mysqlImp.getMysql().showTable("select stuId as '学号',stuClassName as '班级',stuName as '姓名' from timeattendance"));
            }
            else
            {
                attendanceInfo.getAttendance().getLoadStudentList().showStudentList(
                    mysqlImp.getMysql().showTable("select stuId as '学号',stuClassName as '班级',stuName as '姓名' from signattendance"));
            }
        }

        /// <summary>
        /// 计算并显示学生总数
        /// </summary>
        private void showAllStudentCount()
        {
            DataTable table = new DataTable();
            if (loadStudentListInfo.getLoadStudent().getAttendanceType())
            {
                table = mysqlImp.getMysql().showTable("select count(*) from timeattendance");
            }
            else
            {
                table = mysqlImp.getMysql().showTable("select count(*) from signattendance");
            }
            foreach (DataRow row in table.Rows)
            {
                attendanceInfo.getAttendance().getLoadStudentList().showAllStudentCount(Convert.ToInt32(row["count(*)"]));
            }
        }
    }
}
