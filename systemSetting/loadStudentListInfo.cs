using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace systemSetting
{
    public class loadStudentListInfo
    {
        private static loadStudentListInfo loadStudent = new loadStudentListInfo();
        public static loadStudentListInfo getLoadStudent()
        {
            return loadStudent;
        }

        private string studentListPath;
        private string outputAttendancePath;
        private bool attendanceType;

        public void setLoadStudentListInfo(string studentListPath,string outputAttendancePath,bool attendanceType)
        {
            this.studentListPath = studentListPath;
            this.outputAttendancePath = outputAttendancePath;
            this.attendanceType = attendanceType;
        }

        public string getStudentListPath()
        {
            return studentListPath;
        }

        public string getOutputAttendancePath ()
        {
            return outputAttendancePath;
        }

        public bool getAttendanceType()
        {
            return attendanceType;
        }
    }
}
