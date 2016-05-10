using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BackgroundAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("正在安装服务...");
                    var isok = ServiceMaster.InstallService();
                    Console.WriteLine("安装服务：" + (isok ? "成功！" : "失败！"));
                    return;
                }
                else if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("正在卸载服务...");
                    var isok = ServiceMaster.UninstallService();
                    Console.WriteLine("卸载服务：" + (isok ? "成功！" : "失败！"));
                    return;
                }
                else if (args[0].Equals("-c", StringComparison.OrdinalIgnoreCase))
                {
                    ServiceMaster.RunService();
                    Console.WriteLine("服务已经运行，按任意健关闭！");
                    Console.ReadKey();
                }
                else if (args[0].Equals("-help", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("-i 安装服务");
                    Console.WriteLine("-u 卸载服务");
                    Console.WriteLine("-c 控制台运行服务");
                }
                else
                {
                    Console.WriteLine("-i 安装服务");
                    Console.WriteLine("-u 卸载服务");
                    Console.WriteLine("-c 控制台运行服务");
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("请使用正面参数启动程序：");
                    Console.WriteLine("-i 安装服务");
                    Console.WriteLine("-u 卸载服务");
                    Console.WriteLine("-c 控制台运行服务");
                    ServiceBase.Run(new WinService());
                }
                catch
                {
                    Console.WriteLine("-i 安装服务");
                    Console.WriteLine("-u 卸载服务");
                    Console.WriteLine("-c 控制台运行服务");
                }
            }
        }
    }
}
