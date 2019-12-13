namespace AccountingReportsManagement
{
    partial class Frm_Database
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Database));
            this.Btn_DbSave = new System.Windows.Forms.Button();
            this.Btn_DbExit = new System.Windows.Forms.Button();
            this.Lbl_DbSource = new System.Windows.Forms.Label();
            this.Lbl_DbName = new System.Windows.Forms.Label();
            this.Lbl_DbUser = new System.Windows.Forms.Label();
            this.Lbl_DbPass = new System.Windows.Forms.Label();
            this.Txt_DbSource = new System.Windows.Forms.TextBox();
            this.Txt_DbName = new System.Windows.Forms.TextBox();
            this.Txt_DbUser = new System.Windows.Forms.TextBox();
            this.Txt_DbPass = new System.Windows.Forms.TextBox();
            this.Pnl_DbHeader = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Pnl_FormBar = new System.Windows.Forms.Panel();
            this.Pcb_Logo = new System.Windows.Forms.PictureBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.Lbl_Name = new System.Windows.Forms.Label();
            this.Lbl_FormName = new System.Windows.Forms.Label();
            this.Lbl_DbHelp = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_HeaderHelp = new System.Windows.Forms.Label();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.Btn_TestConnect = new System.Windows.Forms.Button();
            this.Pnl_DbHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Pnl_FormBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Logo)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_DbSave
            // 
            this.Btn_DbSave.Location = new System.Drawing.Point(500, 310);
            this.Btn_DbSave.Name = "Btn_DbSave";
            this.Btn_DbSave.Size = new System.Drawing.Size(99, 25);
            this.Btn_DbSave.TabIndex = 5;
            this.Btn_DbSave.Text = "&Save";
            this.Btn_DbSave.UseVisualStyleBackColor = true;
            this.Btn_DbSave.Click += new System.EventHandler(this.Btn_DbSave_Click);
            // 
            // Btn_DbExit
            // 
            this.Btn_DbExit.Location = new System.Drawing.Point(605, 310);
            this.Btn_DbExit.Name = "Btn_DbExit";
            this.Btn_DbExit.Size = new System.Drawing.Size(99, 25);
            this.Btn_DbExit.TabIndex = 6;
            this.Btn_DbExit.Text = "E&xit";
            this.Btn_DbExit.UseVisualStyleBackColor = true;
            this.Btn_DbExit.Click += new System.EventHandler(this.Btn_DbExit_Click);
            // 
            // Lbl_DbSource
            // 
            this.Lbl_DbSource.AutoSize = true;
            this.Lbl_DbSource.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DbSource.Location = new System.Drawing.Point(206, 135);
            this.Lbl_DbSource.Name = "Lbl_DbSource";
            this.Lbl_DbSource.Size = new System.Drawing.Size(115, 20);
            this.Lbl_DbSource.TabIndex = 2;
            this.Lbl_DbSource.Text = "Server Address:";
            // 
            // Lbl_DbName
            // 
            this.Lbl_DbName.AutoSize = true;
            this.Lbl_DbName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DbName.Location = new System.Drawing.Point(200, 177);
            this.Lbl_DbName.Name = "Lbl_DbName";
            this.Lbl_DbName.Size = new System.Drawing.Size(121, 20);
            this.Lbl_DbName.TabIndex = 3;
            this.Lbl_DbName.Text = "Database Name:";
            // 
            // Lbl_DbUser
            // 
            this.Lbl_DbUser.AutoSize = true;
            this.Lbl_DbUser.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DbUser.Location = new System.Drawing.Point(172, 220);
            this.Lbl_DbUser.Name = "Lbl_DbUser";
            this.Lbl_DbUser.Size = new System.Drawing.Size(149, 20);
            this.Lbl_DbUser.TabIndex = 4;
            this.Lbl_DbUser.Text = "Database Username:";
            // 
            // Lbl_DbPass
            // 
            this.Lbl_DbPass.AutoSize = true;
            this.Lbl_DbPass.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DbPass.Location = new System.Drawing.Point(177, 268);
            this.Lbl_DbPass.Name = "Lbl_DbPass";
            this.Lbl_DbPass.Size = new System.Drawing.Size(144, 20);
            this.Lbl_DbPass.TabIndex = 5;
            this.Lbl_DbPass.Text = "Database Password:";
            // 
            // Txt_DbSource
            // 
            this.Txt_DbSource.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DbSource.Location = new System.Drawing.Point(327, 136);
            this.Txt_DbSource.Name = "Txt_DbSource";
            this.Txt_DbSource.Size = new System.Drawing.Size(377, 23);
            this.Txt_DbSource.TabIndex = 1;
            this.Txt_DbSource.MouseLeave += new System.EventHandler(this.Txt_DbSource_MouseLeave);
            this.Txt_DbSource.MouseHover += new System.EventHandler(this.Txt_DbSource_MouseHover);
            // 
            // Txt_DbName
            // 
            this.Txt_DbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DbName.Location = new System.Drawing.Point(327, 178);
            this.Txt_DbName.Name = "Txt_DbName";
            this.Txt_DbName.Size = new System.Drawing.Size(377, 23);
            this.Txt_DbName.TabIndex = 2;
            this.Txt_DbName.MouseLeave += new System.EventHandler(this.Txt_DbName_MouseLeave);
            this.Txt_DbName.MouseHover += new System.EventHandler(this.Txt_DbName_MouseHover);
            // 
            // Txt_DbUser
            // 
            this.Txt_DbUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DbUser.Location = new System.Drawing.Point(327, 221);
            this.Txt_DbUser.Name = "Txt_DbUser";
            this.Txt_DbUser.Size = new System.Drawing.Size(377, 23);
            this.Txt_DbUser.TabIndex = 3;
            this.Txt_DbUser.MouseLeave += new System.EventHandler(this.Txt_DbUser_MouseLeave);
            this.Txt_DbUser.MouseHover += new System.EventHandler(this.Txt_DbUser_MouseHover);
            // 
            // Txt_DbPass
            // 
            this.Txt_DbPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_DbPass.Location = new System.Drawing.Point(327, 265);
            this.Txt_DbPass.Name = "Txt_DbPass";
            this.Txt_DbPass.PasswordChar = '•';
            this.Txt_DbPass.Size = new System.Drawing.Size(377, 23);
            this.Txt_DbPass.TabIndex = 4;
            this.Txt_DbPass.MouseLeave += new System.EventHandler(this.Txt_DbPass_MouseLeave);
            this.Txt_DbPass.MouseHover += new System.EventHandler(this.Txt_DbPass_MouseHover);
            // 
            // Pnl_DbHeader
            // 
            this.Pnl_DbHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(52)))), ((int)(((byte)(96)))));
            this.Pnl_DbHeader.Controls.Add(this.pictureBox1);
            this.Pnl_DbHeader.Controls.Add(this.Pnl_FormBar);
            this.Pnl_DbHeader.Controls.Add(this.Lbl_FormName);
            this.Pnl_DbHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_DbHeader.Location = new System.Drawing.Point(0, 0);
            this.Pnl_DbHeader.Name = "Pnl_DbHeader";
            this.Pnl_DbHeader.Size = new System.Drawing.Size(738, 92);
            this.Pnl_DbHeader.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::AccountingReportsManagement.Properties.Resources.icons8_database_administrator_64;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(22, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Pnl_FormBar
            // 
            this.Pnl_FormBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(81)))), ((int)(((byte)(146)))));
            this.Pnl_FormBar.Controls.Add(this.Pcb_Logo);
            this.Pnl_FormBar.Controls.Add(this.gunaControlBox1);
            this.Pnl_FormBar.Controls.Add(this.Lbl_Name);
            this.Pnl_FormBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_FormBar.Location = new System.Drawing.Point(0, 0);
            this.Pnl_FormBar.Name = "Pnl_FormBar";
            this.Pnl_FormBar.Size = new System.Drawing.Size(738, 32);
            this.Pnl_FormBar.TabIndex = 1;
            // 
            // Pcb_Logo
            // 
            this.Pcb_Logo.BackgroundImage = global::AccountingReportsManagement.Properties.Resources.kmtioriglogo1;
            this.Pcb_Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pcb_Logo.Location = new System.Drawing.Point(3, 4);
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
            this.gunaControlBox1.Location = new System.Drawing.Point(705, 1);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(81)))), ((int)(((byte)(69)))));
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(33, 31);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // Lbl_Name
            // 
            this.Lbl_Name.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Name.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_Name.Location = new System.Drawing.Point(0, 9);
            this.Lbl_Name.Name = "Lbl_Name";
            this.Lbl_Name.Size = new System.Drawing.Size(738, 23);
            this.Lbl_Name.TabIndex = 1;
            this.Lbl_Name.Text = "Kusakabe && Maeno Tech Inc. Accounting Reports System";
            this.Lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_FormName
            // 
            this.Lbl_FormName.AutoSize = true;
            this.Lbl_FormName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_FormName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.Lbl_FormName.Location = new System.Drawing.Point(66, 38);
            this.Lbl_FormName.Name = "Lbl_FormName";
            this.Lbl_FormName.Size = new System.Drawing.Size(346, 45);
            this.Lbl_FormName.TabIndex = 0;
            this.Lbl_FormName.Text = "DATABASE SETTINGS";
            // 
            // Lbl_DbHelp
            // 
            this.Lbl_DbHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(141)))), ((int)(((byte)(143)))));
            this.Lbl_DbHelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DbHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Lbl_DbHelp.Location = new System.Drawing.Point(7, 32);
            this.Lbl_DbHelp.Name = "Lbl_DbHelp";
            this.Lbl_DbHelp.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Lbl_DbHelp.Size = new System.Drawing.Size(141, 226);
            this.Lbl_DbHelp.TabIndex = 8;
            this.Lbl_DbHelp.Text = " This will allow the system to establish database connection.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(141)))), ((int)(((byte)(143)))));
            this.panel2.Controls.Add(this.Lbl_HeaderHelp);
            this.panel2.Controls.Add(this.Lbl_DbHelp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(148, 269);
            this.panel2.TabIndex = 9;
            // 
            // Lbl_HeaderHelp
            // 
            this.Lbl_HeaderHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(141)))), ((int)(((byte)(143)))));
            this.Lbl_HeaderHelp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_HeaderHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(235)))), ((int)(((byte)(137)))));
            this.Lbl_HeaderHelp.Location = new System.Drawing.Point(3, 13);
            this.Lbl_HeaderHelp.Name = "Lbl_HeaderHelp";
            this.Lbl_HeaderHelp.Size = new System.Drawing.Size(145, 19);
            this.Lbl_HeaderHelp.TabIndex = 9;
            this.Lbl_HeaderHelp.Text = "Database Setting";
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.Lbl_Name;
            // 
            // Btn_TestConnect
            // 
            this.Btn_TestConnect.Location = new System.Drawing.Point(181, 310);
            this.Btn_TestConnect.Name = "Btn_TestConnect";
            this.Btn_TestConnect.Size = new System.Drawing.Size(99, 25);
            this.Btn_TestConnect.TabIndex = 10;
            this.Btn_TestConnect.Text = "&Test Connect";
            this.Btn_TestConnect.UseVisualStyleBackColor = true;
            this.Btn_TestConnect.Click += new System.EventHandler(this.Btn_TestConnect_Click);
            // 
            // Frm_Database
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 361);
            this.Controls.Add(this.Btn_TestConnect);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Pnl_DbHeader);
            this.Controls.Add(this.Txt_DbPass);
            this.Controls.Add(this.Txt_DbUser);
            this.Controls.Add(this.Txt_DbName);
            this.Controls.Add(this.Txt_DbSource);
            this.Controls.Add(this.Lbl_DbPass);
            this.Controls.Add(this.Lbl_DbUser);
            this.Controls.Add(this.Lbl_DbName);
            this.Controls.Add(this.Lbl_DbSource);
            this.Controls.Add(this.Btn_DbExit);
            this.Controls.Add(this.Btn_DbSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Database";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kusakabe & Maeno Tech Inc.";
            this.Load += new System.EventHandler(this.Frm_Database_Load);
            this.Pnl_DbHeader.ResumeLayout(false);
            this.Pnl_DbHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Pnl_FormBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pcb_Logo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_DbSave;
        private System.Windows.Forms.Button Btn_DbExit;
        private System.Windows.Forms.Label Lbl_DbSource;
        private System.Windows.Forms.Label Lbl_DbName;
        private System.Windows.Forms.Label Lbl_DbUser;
        private System.Windows.Forms.Label Lbl_DbPass;
        private System.Windows.Forms.TextBox Txt_DbSource;
        private System.Windows.Forms.TextBox Txt_DbName;
        private System.Windows.Forms.TextBox Txt_DbUser;
        private System.Windows.Forms.TextBox Txt_DbPass;
        private System.Windows.Forms.Panel Pnl_DbHeader;
        private System.Windows.Forms.Label Lbl_DbHelp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_HeaderHelp;
        private System.Windows.Forms.Label Lbl_FormName;
        private System.Windows.Forms.Panel Pnl_FormBar;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl_Name;
        private System.Windows.Forms.Button Btn_TestConnect;
        private System.Windows.Forms.PictureBox Pcb_Logo;
    }
}