using Course_Attendance_Check_System.form.Form_attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.formImp
{
    public class attendanceInfo
    {
        private static attendanceInfo attendance = new attendanceInfo();
        public static attendanceInfo getAttendance()
        {
            return attendance;
        }

        private attendance_loadStudentList loadStudentList = new attendance_loadStudentList
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };

        private attendance_startCheck startCheck = new attendance_startCheck
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };

        private attendance_endCheck endCheck = new attendance_endCheck
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };

        public attendance_loadStudentList getLoadStudentList()
        {
            return loadStudentList;
        }

        public attendance_startCheck getStartCheck()
        {
            return startCheck;
        }

        public attendance_endCheck getEndCheck()
        {
            return endCheck;
        }

        private attendance_manualSign manualSign;
        public void setManualSign(attendance_manualSign manualSign)
        {
            this.manualSign = manualSign;
        }
        public attendance_manualSign getManualSign()
        {
            return manualSign;
        }

        private attendance_rewardAndPunish rewardAndPunish;
        public void setRewardAndPunish(attendance_rewardAndPunish rewardAndPunish)
        {
            this.rewardAndPunish = rewardAndPunish;
        }
        public attendance_rewardAndPunish getRewardAndPunish()
        {
            return rewardAndPunish;
        }
    }
}
