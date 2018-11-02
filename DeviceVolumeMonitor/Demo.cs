using System;
using System.Text;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Staging
{
    public class frmDeviceVolumeMonitor : System.Windows.Forms.Form
    {
        DeviceVolumeMonitor fNative;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.CheckBox cbAsync;
        private System.Windows.Forms.ListBox lbEvents;
        private System.Windows.Forms.Button bnClose;
        private System.Windows.Forms.CheckBox cbEnabled;
        private System.ComponentModel.IContainer components;

        public frmDeviceVolumeMonitor()
        {
            InitializeComponent();

            // -----------------------------------
            // DeviceVolumeMonitor create instance
            // -----------------------------------
            fNative = new DeviceVolumeMonitor(this.Handle);
            fNative.OnVolumeInserted += new DeviceVolumeAction(VolumeInserted);
            fNative.OnVolumeRemoved += new DeviceVolumeAction(VolumeRemoved);
            UpdateUI();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );

            // ------------------------------------
            // DeviceVolumeMonitor dispose instance
            // ------------------------------------
            if (fNative!=null)
            {
                fNative.Dispose();
                fNative = null;
            }
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbProperties = new System.Windows.Forms.GroupBox();
            this.cbAsync = new System.Windows.Forms.CheckBox();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            this.lbEvents = new System.Windows.Forms.ListBox();
            this.bnClose = new System.Windows.Forms.Button();
            this.gbProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProperties
            // 
            this.gbProperties.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                       this.lbEvents,
                                                                                       this.cbAsync,
                                                                                       this.cbEnabled});
            this.gbProperties.Location = new System.Drawing.Point(8, 8);
            this.gbProperties.Name = "gbProperties";
            this.gbProperties.Size = new System.Drawing.Size(288, 176);
            this.gbProperties.TabIndex = 0;
            this.gbProperties.TabStop = false;
            this.gbProperties.Text = "DeviceVolumeMonitor properties";
            // 
            // cbAsync
            // 
            this.cbAsync.Location = new System.Drawing.Point(8, 48);
            this.cbAsync.Name = "cbAsync";
            this.cbAsync.Size = new System.Drawing.Size(144, 16);
            this.cbAsync.TabIndex = 1;
            this.cbAsync.Tag = "110";
            this.cbAsync.Text = "Asynchronous events";
            this.cbAsync.Click += new System.EventHandler(this.UpdateNative);
            // 
            // cbEnabled
            // 
            this.cbEnabled.Location = new System.Drawing.Point(8, 24);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.Size = new System.Drawing.Size(144, 16);
            this.cbEnabled.TabIndex = 0;
            this.cbEnabled.Tag = "100";
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.Click += new System.EventHandler(this.UpdateNative);
            // 
            // lbEvents
            // 
            this.lbEvents.Location = new System.Drawing.Point(8, 72);
            this.lbEvents.Name = "lbEvents";
            this.lbEvents.Size = new System.Drawing.Size(272, 95);
            this.lbEvents.TabIndex = 2;
            // 
            // bnClose
            // 
            this.bnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bnClose.Location = new System.Drawing.Point(224, 192);
            this.bnClose.Name = "bnClose";
            this.bnClose.TabIndex = 1;
            this.bnClose.Tag = "999";
            this.bnClose.Text = "&Close";
            this.bnClose.Click += new System.EventHandler(this.UpdateNative);
            // 
            // frmDeviceVolumeMonitor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.bnClose;
            this.ClientSize = new System.Drawing.Size(304, 220);
            this.ControlBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.bnClose,
                                                                          this.gbProperties});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeviceVolumeMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeviceVolumeMonitor";
            this.gbProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        [STAThread]
        static void Main() 
        {
            Application.Run(new frmDeviceVolumeMonitor());
        }

        private void UpdateUI()
        {
            // -------------------------
            // Update the user interface
            // -------------------------
            cbEnabled.Enabled = fNative!=null;
            cbAsync.Enabled = fNative!=null;
            lbEvents.Enabled = fNative!=null;
            if (fNative!=null)
            {
                cbEnabled.Checked = fNative.Enabled;
                cbAsync.Checked = fNative.AsynchronousEvents;
                lbEvents.Enabled = fNative.Enabled;
            }
        }

        private void UpdateNative(object aSender,EventArgs aArgs)
        {
            // --------------------------
            // Update DeviceVolumeMonitor
            // --------------------------
            if (fNative!=null)
            {
                switch(((Control)aSender).Tag.ToString())
                {
                    case "100": fNative.Enabled = cbEnabled.Checked; break;
                    case "110": fNative.AsynchronousEvents = cbAsync.Checked; break;
                    case "999": this.Close(); break;
                }
            }
            UpdateUI();
        }

        private void VolumeInserted(int aMask)
        {
            // -------------------------
            // A volume was inserted
            // -------------------------
            lbEvents.Items.Add("Volume inserted in "+fNative.MaskToLogicalPaths(aMask));
        }

        private void VolumeRemoved(int aMask)
        {
            // --------------------
            // A volume was removed
            // --------------------
            lbEvents.Items.Add("Volume removed from "+fNative.MaskToLogicalPaths(aMask));
        }
    }
}
