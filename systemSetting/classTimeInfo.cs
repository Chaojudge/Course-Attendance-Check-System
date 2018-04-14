namespace systemSetting
{
    public class classTimeInfo
    {
        private int interval;
        private int[] startHour;
        private int[] startMinute;
        private int[] endHour;
        private int[] endMinute;
        private static classTimeInfo classTimeSetting = new classTimeInfo();

        public void setClassTimeInfo(int interval,int[] startHour,int[] startMinute)
        {
            this.interval = interval;
            this.startHour = startHour;
            this.startMinute = startMinute;
        }

        public void setEndTimeInfo(int[] endHour,int[] endMinute)
        {
            this.endHour = endHour;
            this.endMinute = endMinute;
        }

        public int getInterval()
        {
            return interval;
        }

        public int[] getStartHour()
        {
            return startHour;
        }

        public int[] getStartMinute()
        {
            return startMinute;
        }

        public int[] getEndHour()
        {
            return endHour;
        }

        public int[] getEndMinute()
        {
            return endMinute;
        }

        public static classTimeInfo getClassTimeInfo()
        {
            return classTimeSetting;
        }
    }
}
