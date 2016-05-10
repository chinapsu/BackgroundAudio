using Cocon90.Lib.Util.Ini;
using Cocon90.Lib.Util.Window.Service;
using BackgroundAudio.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using BackgroundAudio.Service;

namespace BackgroundAudio
{
    public class ServiceMaster
    {
        static AudioMainService mainService = null;
        public static string ServiceName { get { return Tools.SettingHelper.ReadServiceName(); } }
        public static string ServiceDiscription { get { return Tools.SettingHelper.ReadServiceDiscription(); } }
        public static string ServiceExecutePath { get { return Assembly.GetExecutingAssembly().Location; } }
        /// <summary>
        /// 启动服务时发生
        /// </summary>
        public static void RunService()
        {
            if (mainService == null) mainService = new AudioMainService();
            mainService.Start();
        }
        /// <summary>
        /// 停止服务时发生
        /// </summary>
        public static void StopService()
        {
            mainService.Stop();
        }
        /// <summary>
        /// 执行安装并启动服务
        /// </summary>
        /// <returns></returns>
        public static bool InstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Start();
        }
        /// <summary>
        /// 执行卸载服务
        /// </summary>
        /// <returns></returns>
        public static bool UninstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Stop();
        }
    }
}
