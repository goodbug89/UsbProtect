using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace USBProtect
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {
            System.ServiceProcess.ServiceController svr = new System.ServiceProcess.ServiceController(this.serviceInstaller1.ServiceName);
            if (svr != null)
            {
                svr.Start();
            }
        }

        private void serviceInstaller1_BeforeUninstall(object sender, InstallEventArgs e)
        {
            System.ServiceProcess.ServiceController svr = new System.ServiceProcess.ServiceController(this.serviceInstaller1.ServiceName);
            if (svr != null)
            {
                svr.Stop();
            }
        }
    }
}
