using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.formImp
{
    class formInfo
    {
        private static formInfo form = new formInfo();
        private form_load load;
        private form_initialize initialize;
        private form_attendance attendance;
        

        public void setForm_load(form_load load)
        {
            this.load = load;
        }
        public void setForm_initialize(form_initialize initialize)
        {
            this.initialize = initialize;
        }
        public void setForm_attendance(form_attendance attendance)
        {
            this.attendance = attendance;
        }


        public static formInfo getFormInfo()
        {
            return form;
        }
        public form_load getForm_load()
        {
            return load;
        }
        public form_initialize getForm_initialize()
        {
            return initialize;
        }
        public form_attendance getForm_attendance()
        {
            return attendance;
        }
        
    }
}
