namespace LauncherRXJH
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.startGameButton = new System.Windows.Forms.Button();
            this.serverPortTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipAddressControl = new IPAddressControlLib.IPAddressControl();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(12, 66);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(185, 63);
            this.startGameButton.TabIndex = 0;
            this.startGameButton.Text = "START GAME";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Location = new System.Drawing.Point(75, 40);
            this.serverPortTextBox.MaxLength = 5;
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(122, 20);
            this.serverPortTextBox.TabIndex = 2;
            this.serverPortTextBox.Text = "1300";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Server Port";
            // 
            // ipAddressControl
            // 
            this.ipAddressControl.AllowInternalTab = false;
            this.ipAddressControl.AutoHeight = true;
            this.ipAddressControl.BackColor = System.Drawing.SystemColors.Window;
            this.ipAddressControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ipAddressControl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ipAddressControl.Location = new System.Drawing.Point(75, 14);
            this.ipAddressControl.MinimumSize = new System.Drawing.Size(87, 20);
            this.ipAddressControl.Name = "ipAddressControl";
            this.ipAddressControl.ReadOnly = false;
            this.ipAddressControl.Size = new System.Drawing.Size(122, 20);
            this.ipAddressControl.TabIndex = 5;
            this.ipAddressControl.Text = "127.0.0.1";
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(209, 141);
            this.Controls.Add(this.ipAddressControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverPortTextBox);
            this.Controls.Add(this.startGameButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EZ Launcher";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.TextBox serverPortTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private IPAddressControlLib.IPAddressControl ipAddressControl;
    }
}

