using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course_Attendance_Check_System.formImp
{
    class initializeInfo
    {
        private static initializeInfo initialize = new initializeInfo();
        public static initializeInfo getInitialize()
        {
            return initialize;
        }

        private initialize_welcome welcome = new initialize_welcome
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_statement statement = new initialize_statement
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_server server = new initialize_server
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_dataSource dataSource = new initialize_dataSource
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_classTime classTime = new initialize_classTime
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_process process = new initialize_process
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        private initialize_finish finish = new initialize_finish
        {
            TopLevel = false,
            FormBorderStyle = FormBorderStyle.None
        };
        public initialize_welcome getInitialize_welcome()
        {
            return welcome;
        }
        public initialize_statement getInitialize_statement()
        {
            return statement;
        }
        public initialize_server getInitalize_server()
        {
            return server;
        }
        public initialize_dataSource getInitialize_dataSource()
        {
            return dataSource;
        }
        public initialize_classTime getInitialize_classTime()
        {
            return classTime;
        }
        public initialize_process getInitialize_process()
        {
            return process;
        }
        public initialize_finish getInitialize_finish()
        {
            return finish;
        }
    }
}
