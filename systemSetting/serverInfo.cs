using System.IO;

namespace systemSetting
{
    public class serverInfo
    {
        private string serverIP;
        private int serverPort;
        private string mysqlPath;
        private FileInfo startMysqlBatFile;
        private FileInfo queryMysqlBatFile;
        private FileInfo stopMysqlBatFile;

        private static serverInfo serverSetting = new serverInfo();

        public void setServerInfo(string serverIP, int serverPort, string mysqlPath)
        {
            this.serverIP = serverIP;
            this.serverPort = serverPort;
            this.mysqlPath = mysqlPath;
        }

        public void setMysqlBatFile(string startMysqlBatFileName, string queryMysqlBatFileName, string stopMysqlBatFileName)
        {
            this.startMysqlBatFile = new FileInfo(mysqlPath + @"\" + startMysqlBatFileName);
            this.queryMysqlBatFile = new FileInfo(mysqlPath + @"\" + queryMysqlBatFileName);
            this.stopMysqlBatFile = new FileInfo(mysqlPath + @"\" + stopMysqlBatFileName);
        }

        public static serverInfo getServerInfo(){ return serverSetting; }
        public string getServerIP() { return serverIP; }
        public int getServerPort() { return serverPort; }
        public string getMysqlPath() { return mysqlPath; }
        public FileInfo getStartMysqlBatFile() { return startMysqlBatFile; }
        public FileInfo getQueryMysqlBatFile() { return queryMysqlBatFile; }
        public FileInfo getStopMysqlBatFile() { return stopMysqlBatFile; }
    }
}
