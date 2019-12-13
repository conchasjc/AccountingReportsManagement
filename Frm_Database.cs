using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingReportsManagement
{
    public partial class Frm_Database : Form
    {
        public Frm_Database()
        {
            InitializeComponent();
        }

        private void Frm_Database_Load(object sender, EventArgs e)
        {
           
        }

        private void Txt_DbSource_MouseHover(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Server Address";
            Lbl_DbHelp.Text = "\t \t Enter Server's Name or Database IP Address.";
        }

        private void Txt_DbSource_MouseLeave(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Database Setting";
            Lbl_DbHelp.Text = "\t \t This will allow the system to establish database connection.";
        }

        private void Txt_DbName_MouseHover(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Database Name";
            Lbl_DbHelp.Text = "\t \t Please enter database name.";
        }

        private void Txt_DbName_MouseLeave(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Database Setting";
            Lbl_DbHelp.Text = "\t \t This will allow the system to establish database connection.";
        }

        private void Btn_DbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txt_DbUser_MouseHover(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Username";
            Lbl_DbHelp.Text = "\t \t Please enter username for database connection.";
        }

        private void Txt_DbUser_MouseLeave(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Database Setting";
            Lbl_DbHelp.Text = "\t \t This will allow the system to establish database connection.";
        }

        private void Txt_DbPass_MouseHover(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Password";
            Lbl_DbHelp.Text = "\t \t Please enter password for database connection.";
        }

        private void Txt_DbPass_MouseLeave(object sender, EventArgs e)
        {
            Lbl_HeaderHelp.Text = "Database Setting";
            Lbl_DbHelp.Text = "\t \t This will allow the system to establish database connection.";
        }

        private void Btn_TestConnect_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            try
            {
                db.TestConnect(Txt_DbSource.Text, Txt_DbName.Text, Txt_DbUser.Text, Txt_DbPass.Text);
                MessageBox.Show("Test Connection Succeeded.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_DbSave_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.ConnectionSettings(Txt_DbSource.Text, Txt_DbName.Text, Txt_DbUser.Text, Txt_DbPass.Text);
            db.SaveSettings();
        }
    }
}
