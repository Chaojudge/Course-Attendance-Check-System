using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemSetting
{
    public class attendanceServerInfo
    {
        private static attendanceServerInfo attendanceServer = new attendanceServerInfo();
        public static attendanceServerInfo getAttendanceServerInfo()
        {
            return attendanceServer;
        }

        private int startServerHour;
        private int startServerMinute;
        private int startServerInterval;

        private int attendantStudentCount;
        private int absentStudentCount;
        private int allStudentCount;

        private string mainKey;
        private string randomKey;

        public void setStartServerTime(int startServerHour, int startServerMinute, int startServerInterval)
        {
            this.startServerHour = startServerHour;
            this.startServerMinute = startServerMinute;
            this.startServerInterval = startServerInterval;
        }

        public void setAttendanceResult(int attendantStudentCount, int absentStudentCount, int allStudentCount)
        {
            this.attendantStudentCount = attendantStudentCount;
            this.absentStudentCount = absentStudentCount;
            this.allStudentCount = allStudentCount;
        }

        public void setServerKey(string mainKey, string randomKey)
        {
            this.mainKey = mainKey;
            this.randomKey = randomKey;
        }

        public int getStartServerHour()
        {
            return startServerHour;
        }

        public int getStartServerMinute()
        {
            return startServerMinute;
        }

        public int getStartServerInterval()
        {
            return startServerInterval;
        }

        public int getAttendanceStudentCount()
        {
            return attendantStudentCount;
        }

        public int getAbsentStudentCount()
        {
            return absentStudentCount;
        }

        public int getAllStudentCount()
        {
            return allStudentCount;
        }

        public string getMainKey()
        {
            return mainKey;
        }

        public string getRandomKey()
        {
            return randomKey;
        }
    }
}
