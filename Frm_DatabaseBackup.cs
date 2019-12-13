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
    public partial class Frm_DatabaseBackup : Form
    {
        public Frm_DatabaseBackup()
        {
            InitializeComponent();
        }

        private void Btn_Backup_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.Backup();
        }
    }
}
