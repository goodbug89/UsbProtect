namespace SimpleDetector
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxAskMe = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sample app for the DriveDetector class";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "In the list below information about removable drives arriving and being removed w" +
                "ill appear.";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 83);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(333, 134);
            this.listBox1.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(277, 231);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // checkBoxAskMe
            // 
            this.checkBoxAskMe.AutoSize = true;
            this.checkBoxAskMe.Location = new System.Drawing.Point(19, 231);
            this.checkBoxAskMe.Name = "checkBoxAskMe";
            this.checkBoxAskMe.Size = new System.Drawing.Size(223, 17);
            this.checkBoxAskMe.TabIndex = 4;
            this.checkBoxAskMe.Text = "Ask me before drive can be disconnected";
            this.checkBoxAskMe.UseVisualStyleBackColor = true;
            this.checkBoxAskMe.CheckedChanged += new System.EventHandler(this.checkBoxAskMe_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(388, 261);
            this.Controls.Add(this.checkBoxAskMe);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Simple detector of removable drives";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.CheckBox checkBoxAskMe;
    }
}

