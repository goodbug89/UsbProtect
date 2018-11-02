using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace InstallUSBProtect
{
    public partial class MainForm : Form
    {
        string ServiceName = "Nubicom USB Protect";
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            ManagementObjectCollection moc = mos.Get();

            bool safeusb = false;
            foreach (ManagementObject mo in moc)
            {
                string model = (string)mo["Model"];
                if (model == "NUBICOM LICENSE USB USB Device")
                {
                    safeusb = true;
                }
            }
            if (!safeusb)
            {
                MessageBox.Show("정품 USB가 아닙니다.\n(주)누비콤으로 문의 바랍니다.","Nubicom USB Protect");
                Application.Exit();
            }

            System.ServiceProcess.ServiceController svr = new System.ServiceProcess.ServiceController(ServiceName);
            string strname;
            try
            {
                strname = svr.DisplayName;
            }
            catch
            {
                strname = "";
            }

            if (strname != "")
            {
                button_install.Enabled = false;
                button_uninstall.Enabled = true;
            }
            else
            {
                button_install.Enabled = true;
                button_uninstall.Enabled = false;
            }
        }

        private void button_install_Click(object sender, EventArgs e)
        {
            string svcPath;

            //string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            //string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string path = programFilesX86 + "\\" + "Nubicom USB Protect";

            //MessageBox.Show(path);
            System.IO.Directory.CreateDirectory(path);
            string[] copyfilename = new string[5];

            copyfilename[0] = "USBProtect.pdb";
            copyfilename[1] = "USBProtect.exe";
            copyfilename[2] = "USBProtect.exe.config";
            copyfilename[3] = "RemoveDrive.exe";
            copyfilename[4] = "RemoveDrive64.exe";

            for (int i = 0; i < copyfilename.Length; i++)
            {
                try
                {
                    // Will not overwrite if the destination file already exists.
                    File.Copy(Path.Combine(Application.StartupPath, copyfilename[i]), Path.Combine(path, copyfilename[i]));
                }

                catch (System.UnauthorizedAccessException copyError)
                {
                    Console.WriteLine(copyError.Message);
                }
                // Catch exception if the file was already copied.
                catch (IOException copyError)
                {
                    Console.WriteLine(copyError.Message);
                }
            }

            //path to the service that you want to install
            svcPath = Path.Combine(path, copyfilename[1]);
            ServiceInstaller c = new ServiceInstaller();
            c.InstallService(svcPath, ServiceName, ServiceName);
            MessageBox.Show("성공적으로 설치되었습니다.", "Nubicom USB Protect");
            Application.Exit();
        }

        private void button_uninstall_Click(object sender, EventArgs e)
        {
            foreach (var process in Process.GetProcessesByName("USBProtect"))
            {
                process.Kill();
                Thread.Sleep(1000);
            }

            ServiceInstaller c = new ServiceInstaller();
            c.UnInstallService(ServiceName);

            //string programFiles = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
            //string programFilesX86 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
            string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            string path = programFilesX86 + "\\" + "Nubicom USB Protect";

            string[] copyfilename = new string[5];

            copyfilename[0] = "USBProtect.pdb";
            copyfilename[1] = "USBProtect.exe";
            copyfilename[2] = "USBProtect.exe.config";
            copyfilename[3] = "RemoveDrive.exe";
            copyfilename[4] = "RemoveDrive64.exe";

            for (int i = 0; i < copyfilename.Length; i++)
            {
                try
                {
                    // Will not overwrite if the destination file already exists.
                    File.Delete(Path.Combine(path, copyfilename[i]));
                }

                // Catch exception if the file was already copied.
                catch (IOException copyError)
                {
                    Console.WriteLine(copyError.Message);
                }
            }

            System.IO.Directory.Delete(path);
            
            MessageBox.Show("성공적으로 삭제되었습니다.", "Nubicom USB Protect");
            Application.Exit();

        }
        
    }
}
