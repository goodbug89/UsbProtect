using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace USBProtect
{
    public partial class Service1 : ServiceBase
    {
        private DriveDetector driveDetector = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //ManagementEventWatcher watcher = new ManagementEventWatcher();
            //WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2");
            //watcher.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
            //watcher.Query = query;
            //watcher.Start();
            //watcher.WaitForNextEvent();


            driveDetector = new DriveDetector();
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);
            driveDetector.QueryRemove += new DriveDetectorEventHandler(OnQueryRemove);
        }

        protected override void OnStop()
        {
            
        }

        // Called by DriveDetector when removable device in inserted 
        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            check_USB();
            // Report the event in the listbox.
            // e.Drive is the drive letter for the device which just arrived, e.g. "E:\\"
            //string s = "Drive arrived " + e.Drive;
            //listBox1.Items.Add(s);

            // If you want to be notified when drive is being removed (and be able to cancel it), 
            // set HookQueryRemove to true 
            //if (checkBoxAskMe.Checked)
            //    e.HookQueryRemove = true;
        }

        // Called by DriveDetector after removable device has been unpluged 
        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            // TODO: do clean up here, etc. Letter of the removed drive is in e.Drive;

            // Just add report to the listbox
            //string s = "Drive removed " + e.Drive;
            //listBox1.Items.Add(s);
        }

        // Called by DriveDetector when removable drive is about to be removed
        private void OnQueryRemove(object sender, DriveDetectorEventArgs e)
        {
            // Should we allow the drive to be unplugged?
            //if (checkBoxAskMe.Checked)
            //{
            //    if (MessageBox.Show("Allow remove?", "Query remove",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        e.Cancel = false;       // Allow removal
            //    else
            //        e.Cancel = true;        // Cancel the removal of the device  
            //}
        }
        void watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            check_USB();
        }

        private void check_USB()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            ManagementObjectCollection moc = mos.Get();

            foreach (ManagementObject mo in moc)
            {
                string model = (string)mo["Model"];
                string serial = (string)mo["PNPDeviceID"];
                string[] temp = serial.Split('&');
                serial = temp[3];
                temp = serial.Split('\\');
                serial = temp[1];
                string disk_no_str = (string)mo["Name"];
                string disk_no = disk_no_str.Substring(disk_no_str.Length - 1, 1);

                string driveLetter = "";
                string driveNumber = "";

                bool safeusb = false;

                if (model == "NUBICOM LICENSE USB USB Device")
                {
                    safeusb = true;
                }

                foreach (var drive in new ManagementObjectSearcher("Select * from Win32_LogicalDiskToPartition").Get().Cast<ManagementObject>().ToList())
                {
                    driveLetter = Regex.Match((string)drive["Dependent"], @"DeviceID=""(.*)""").Groups[1].Value;
                    driveNumber = Regex.Match((string)drive["Antecedent"], @"Disk #(\d*),").Groups[1].Value;
                    if (driveNumber == disk_no)
                    {
                        if (!safeusb)
                        {
                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            startInfo.FileName = "removedrive.exe";
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            startInfo.Arguments = driveLetter + " -L -b -e";
                            Process.Start(startInfo);
                        }
                        break;
                    }
                }
            }
        }
    }
}
