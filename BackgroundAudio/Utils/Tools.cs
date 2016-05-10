using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackgroundAudio.Utils
{
    public class Tools
    {
        static SettingHelper settingHelper = null;
        public static SettingHelper SettingHelper
        {
            get
            {
                if (settingHelper == null) settingHelper = new SettingHelper();
                return settingHelper;
            }
        }
    }
}
