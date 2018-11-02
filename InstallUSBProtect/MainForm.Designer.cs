namespace InstallUSBProtect
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.button_install = new System.Windows.Forms.Button();
            this.button_uninstall = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_install
            // 
            this.button_install.Location = new System.Drawing.Point(371, 131);
            this.button_install.Name = "button_install";
            this.button_install.Size = new System.Drawing.Size(96, 36);
            this.button_install.TabIndex = 0;
            this.button_install.Text = "Install";
            this.button_install.UseVisualStyleBackColor = true;
            this.button_install.Click += new System.EventHandler(this.button_install_Click);
            // 
            // button_uninstall
            // 
            this.button_uninstall.Location = new System.Drawing.Point(473, 131);
            this.button_uninstall.Name = "button_uninstall";
            this.button_uninstall.Size = new System.Drawing.Size(96, 36);
            this.button_uninstall.TabIndex = 1;
            this.button_uninstall.Text = "Uninstall";
            this.button_uninstall.UseVisualStyleBackColor = true;
            this.button_uninstall.Click += new System.EventHandler(this.button_uninstall_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(581, 179);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 179);
            this.Controls.Add(this.button_uninstall);
            this.Controls.Add(this.button_install);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Install/Uninstall Program for Nubicom USB Protect";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_install;
        private System.Windows.Forms.Button button_uninstall;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

