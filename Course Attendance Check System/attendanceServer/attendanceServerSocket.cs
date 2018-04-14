using Course_Attendance_Check_System.formImp;
using System;
using System.Net.Sockets;
using System.Text;
using publicClass;
using systemSetting;

namespace Course_Attendance_Check_System.attendanceServer
{
    class attendanceServerSocket
    {
        private Socket studentClient;

        /// <summary>
        /// attendaceServerSocket构造器
        /// </summary>
        /// <param name="studentClient"></param>
        public attendanceServerSocket(Socket studentClient)
        {
            this.studentClient = studentClient;
        }

        /// <summary>
        /// 考勤服务端接收学生手机客户端消息
        /// </summary>
        public void receiveMsg()
        {
            byte[] message = new byte[1024];
            string messageStr = string.Empty;
            while (true)
            {
                try
                {
                    int length = studentClient.Receive(message);
                    if (length >= 1)
                    {
                        messageStr = Encoding.UTF8.GetString(message).Trim();
                        //attendanceInfo.getAttendance().getStartCheck().showServerReceive("获取客户端密文消息："+messageStr);
                        messageStr = messageStr.Substring(0, messageStr.IndexOf("#####"));
                        string decryptMessageStr = 
                            aesImp.getAesImp().decrypt(messageStr, attendanceServerInfo.getAttendanceServerInfo().getMainKey());
                        //attendanceInfo.getAttendance().getStartCheck().showServerReceive("获取客户端截取密文消息：" + messageStr);
                        attendanceInfo.getAttendance().getStartCheck().showServerReceive("获取客户端消息[解密后]："+ decryptMessageStr);
                        message = new byte[1024];
                        attendanceServerManager.getManager().messageManager(this, decryptMessageStr);
                    }
                }
                catch (Exception ex)
                {
                    attendanceInfo.getAttendance().getStartCheck().showServerReceive("客户端：" 
                        + studentClient.RemoteEndPoint + "断开连接");
                    Console.WriteLine("错误：" + ex.ToString());
                    attendanceServerManager.getManager().removeStudentClient(this);
                    break;
                }
            }
        }

        /// <summary>
        /// 考勤服务端发送给学生手机客户端消息
        /// </summary>
        /// <param name="msg"></param>
        public void sendMsg(string msg)
        {
            studentClient.Send(Encoding.UTF8.GetBytes(aesImp.getAesImp()
                .encrypt(msg,attendanceServerInfo.getAttendanceServerInfo().getMainKey()) 
                + "#####\r\n"));
        }
    }
}
