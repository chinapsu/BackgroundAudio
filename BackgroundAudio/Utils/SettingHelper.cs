using Cocon90.Lib.Util.Ini;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BackgroundAudio.Utils
{
    public class SettingHelper
    {
        IniHelper ini = null;
        public SettingHelper()
        {
            //ini = new IniHelper(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\setting.cfg");
            //if (string.IsNullOrWhiteSpace(ReadServiceName()))
            //{
            //    ini.Write("Service", "Name", Assembly.GetExecutingAssembly().GetName().Name);
            //}
            //if (string.IsNullOrWhiteSpace(ReadServiceDiscription()))
            //{
            //    ini.Write("Service", "Discription", "数据同步服务！");
            //}
        }

        public string ReadServiceDiscription()
        {
            //return ini.Read("Service", "Discription");
            return "BackgroundAudio";
        }

        public string ReadServiceName()
        {
            return "BackgroundAudio";
        }
    }
}
