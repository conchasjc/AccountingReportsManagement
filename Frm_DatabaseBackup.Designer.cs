namespace AccountingReportsManagement
{
    partial class Frm_DatabaseBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DatabaseBackup));
            this.Pnl_FormBar = new System.Windows.Forms.Panel();
            this.Pcb_Logo = new System.Windows.Forms.PictureBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_DbHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lbl_FormName = new System.Windows.Forms.Label();
            this.Btn_Backup = new Guna.UI.WinForms.GunaAdvenceButton();
            this.Txt_BackUpPath = new Guna.UI.WinForms.GunaLineTextBox();
            this.Fbd_BackupBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.Pnl_FormBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Logo)).BeginInit();
            this.Pnl_DbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl_FormBar
            // 
            this.Pnl_FormBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(146)))));
            this.Pnl_FormBar.Controls.Add(this.Pcb_Logo);
            this.Pnl_FormBar.Controls.Add(this.gunaControlBox1);
            this.Pnl_FormBar.Controls.Add(this.label1);
            this.Pnl_FormBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_FormBar.Location = new System.Drawing.Point(0, 0);
            this.Pnl_FormBar.Name = "Pnl_FormBar";
            this.Pnl_FormBar.Size = new System.Drawing.Size(589, 32);
            this.Pnl_FormBar.TabIndex = 3;
            // 
            // Pcb_Logo
            // 
            this.Pcb_Logo.BackgroundImage = global::AccountingReportsManagement.Properties.Resources.kmtioriglogo1;
            this.Pcb_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pcb_Logo.Location = new System.Drawing.Point(3, 5);
            this.Pcb_Logo.Name = "Pcb_Logo";
            this.Pcb_Logo.Size = new System.Drawing.Size(22, 22);
            this.Pcb_Logo.TabIndex = 2;
            this.Pcb_Logo.TabStop = false;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.White;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(556, 1);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(81)))), ((int)(((byte)(69)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(33, 31);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kusakabe && Maeno Tech Inc. Accounting Reports System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pnl_DbHeader
            // 
            this.Pnl_DbHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.Pnl_DbHeader.Controls.Add(this.pictureBox1);
            this.Pnl_DbHeader.Controls.Add(this.Lbl_FormName);
            this.Pnl_DbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_DbHeader.Location = new System.Drawing.Point(0, 32);
            this.Pnl_DbHeader.Name = "Pnl_DbHeader";
            this.Pnl_DbHeader.Size = new System.Drawing.Size(589, 63);
            this.Pnl_DbHeader.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AccountingReportsManagement.Properties.Resources.icons8_database_administrator_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Lbl_FormName
            // 
            this.Lbl_FormName.AutoSize = true;
            this.Lbl_FormName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.Lbl_FormName.Location = new System.Drawing.Point(66, 9);
            this.Lbl_FormName.Name = "Lbl_FormName";
            this.Lbl_FormName.Size = new System.Drawing.Size(325, 45);
            this.Lbl_FormName.TabIndex = 0;
            this.Lbl_FormName.Text = "BACKUP DATABASE";
            // 
            // Btn_Backup
            // 
            this.Btn_Backup.AnimationHoverSpeed = 0.07F;
            this.Btn_Backup.AnimationSpeed = 0.03F;
            this.Btn_Backup.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Btn_Backup.BorderColor = System.Drawing.Color.Black;
            this.Btn_Backup.CheckedBaseColor = System.Drawing.Color.Gray;
            this.Btn_Backup.CheckedBorderColor = System.Drawing.Color.Black;
            this.Btn_Backup.CheckedForeColor = System.Drawing.Color.White;
            this.Btn_Backup.CheckedImage = ((System.Drawing.Image)(resources.GetObject("Btn_Backup.CheckedImage")));
            this.Btn_Backup.CheckedLineColor = System.Drawing.Color.DimGray;
            this.Btn_Backup.FocusedColor = System.Drawing.Color.Empty;
            this.Btn_Backup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Btn_Backup.ForeColor = System.Drawing.Color.White;
            this.Btn_Backup.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Backup.Image")));
            this.Btn_Backup.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_Backup.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.Btn_Backup.Location = new System.Drawing.Point(307, 248);
            this.Btn_Backup.Name = "Btn_Backup";
            this.Btn_Backup.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.Btn_Backup.OnHoverBorderColor = System.Drawing.Color.Black;
            this.Btn_Backup.OnHoverForeColor = System.Drawing.Color.White;
            this.Btn_Backup.OnHoverImage = null;
            this.Btn_Backup.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.Btn_Backup.OnPressedColor = System.Drawing.Color.Black;
            this.Btn_Backup.Size = new System.Drawing.Size(121, 45);
            this.Btn_Backup.TabIndex = 9;
            this.Btn_Backup.Text = "gunaAdvenceButton1";
            this.Btn_Backup.Click += new System.EventHandler(this.Btn_Backup_Click);
            // 
            // Txt_BackUpPath
            // 
            this.Txt_BackUpPath.BackColor = System.Drawing.Color.White;
            this.Txt_BackUpPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt_BackUpPath.Enabled = false;
            this.Txt_BackUpPath.FocusedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.Txt_BackUpPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Txt_BackUpPath.LineColor = System.Drawing.Color.Gainsboro;
            this.Txt_BackUpPath.Location = new System.Drawing.Point(126, 153);
            this.Txt_BackUpPath.Name = "Txt_BackUpPath";
            this.Txt_BackUpPath.PasswordChar = '\0';
            this.Txt_BackUpPath.Size = new System.Drawing.Size(433, 33);
            this.Txt_BackUpPath.TabIndex = 10;
            // 
            // Frm_DatabaseBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 305);
            this.Controls.Add(this.Txt_BackUpPath);
            this.Controls.Add(this.Btn_Backup);
            this.Controls.Add(this.Pnl_DbHeader);
            this.Controls.Add(this.Pnl_FormBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DatabaseBackup";
            this.Text = "Frm_DatabaseBackup";
            this.Pnl_FormBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Logo)).EndInit();
            this.Pnl_DbHeader.ResumeLayout(false);
            this.Pnl_DbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Pnl_FormBar;
        private System.Windows.Forms.PictureBox Pcb_Logo;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pnl_DbHeader;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl_FormName;
        private Guna.UI.WinForms.GunaAdvenceButton Btn_Backup;
        private Guna.UI.WinForms.GunaLineTextBox Txt_BackUpPath;
        private System.Windows.Forms.FolderBrowserDialog Fbd_BackupBrowser;
    }
}