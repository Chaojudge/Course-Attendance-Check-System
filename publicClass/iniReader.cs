using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicClass
{
    public class iniReader
    {
        private static iniReader inireader = new iniReader();
        public static iniReader getINI()
        {
            return inireader;
        }

        private List<Dictionary<string, string>> INI
            = new List<Dictionary<string, string>>();

        public Dictionary<string, string> read(string path, string title)
        {
            if (path != null && title != null)
            {
                int firstEqual = -1;
                int firstLeft = -1;
                int firstRight = -1;
                string session = "", key = "", value = "";
                try
                {
                    using (StreamReader sr = new StreamReader(
                        path,
                        System.Text.Encoding.GetEncoding("gb2312")))
                    {
                        string str = "";
                        Dictionary<string, string> map = null;
                        while ((str = sr.ReadLine()) != null)
                        {
                            str = str.Trim();
                            firstEqual = str.IndexOf("=");
                            firstLeft = str.IndexOf("[");
                            firstRight = str.IndexOf("]");
                            if (firstRight > -1 && firstLeft > -1 && firstLeft < firstRight)
                            {
                                map = new Dictionary<string, string>();
                                INI.Add(map);
                                session = str.Substring(firstLeft + 1, str.Length - 2);
                                map.Add("session", session);
                            }
                            else if (firstEqual > -1)
                            {
                                value = str.Substring(firstEqual);
                                value = value.Replace("=", "");
                                value = value.Trim();
                                key = str.Substring(0, firstEqual);
                                key = key.Trim();
                                map.Add(key, value);
                            }
                        }
                    }
                    for (int i = 0; i < INI.Count; i++)
                    {
                        Dictionary<string, string> iniMap = INI[i];
                        foreach (string iniMap_key in iniMap.Keys)
                        {
                            if (iniMap["session"].Equals(title)) { return iniMap; }
                        }
                    }
                }
                catch (Exception) { return null; }
                return null;
            }
            return null;
        }
    }
}
