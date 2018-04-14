namespace systemSetting
{
    public class dataSourceInfo
    {
        private string dataSourceIP;
        private int dataSourcePort;
        private string dataBaseName;
        private string dataSourceUser;
        private string dataSourcePwd;
        private static dataSourceInfo dataSourceSetting = new dataSourceInfo();

        public void setDataSourceInfo(
            string dataSourceIP, int dataSourcePort,
            string dataBaseName, string dataSourceUser, string dataSourcePwd)
        {
            this.dataSourceIP = dataSourceIP;
            this.dataSourcePort = dataSourcePort;
            this.dataBaseName = dataBaseName;
            this.dataSourceUser = dataSourceUser;
            this.dataSourcePwd = dataSourcePwd;
        }

        public string getDataSourceIP()
        {
            return dataSourceIP;
        }

        public int getDataSourcePort()
        {
            return dataSourcePort;
        }

        public string getDataBaseName()
        {
            return dataBaseName;
        }

        public string getDataSourceUser()
        {
            return dataSourceUser;
        }

        public string getDataSourcePwd()
        {
            return dataSourcePwd;
        }

        public static dataSourceInfo getDataSourceInfo()
        {
            return dataSourceSetting;
        }
    }
}
