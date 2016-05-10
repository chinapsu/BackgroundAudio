using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace BackgroundAudio
{
    [RunInstaller(true)]
    partial class WinServiceInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;
        public WinServiceInstaller()
        {
            InitializeComponent();

            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = ServiceMaster.ServiceName;
            serviceInstaller.DisplayName = ServiceMaster.ServiceName;
            serviceInstaller.Description = ServiceMaster.ServiceName;
            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);
        }


        protected override void OnAfterInstall(IDictionary savedState)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Verb = "runas";
            p.Start();
            string Cmdstring = "sc start " + ServiceMaster.ServiceName; //CMD命令
            p.StandardInput.WriteLine(Cmdstring);
            p.StandardInput.WriteLine("exit");
        }

    }
}
