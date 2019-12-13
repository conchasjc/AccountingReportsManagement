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
    public partial class Frm_ChartofAccount_add : Form
    {
        private readonly Frm_Main _formMain;
        Database db = new Database();
        public Frm_ChartofAccount_add(Frm_Main _formMain)
        {
           
            InitializeComponent();
            this._formMain = _formMain;
          

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            Close();
            Frm_Main frmMain = new Frm_Main();
            frmMain.Enabled = true;
        }

        private void Txt_Code_Enter(object sender, EventArgs e)
        {
            Txt_Code.Text = "";
        }

        private void Txt_Code_Leave(object sender, EventArgs e)
        {
            if (Txt_Code.Text=="") {
                Txt_Code.Text = "Enter Account Code";
            }
        }

        private void Txt_AccountTitle_Enter(object sender, EventArgs e)
        {
            Txt_AccountTitle.Text = "";
        }

        private void Txt_AccountTitle_Leave(object sender, EventArgs e)
        {
            if (Txt_AccountTitle.Text == "")
            {
                Txt_AccountTitle.Text = "Enter Account Title";
            }
        }

        private void Frm_ChartofAccount_add_Load(object sender, EventArgs e)
        {
            try
            {
                db.GetQuery("Select * from chartofaccountscategory;");
                for (int i = 0; i <= db.queryTable.Rows.Count - 1; i++)
                {
                    Cmb_CategoryList.Items.Add(db.queryTable.Rows[i].ItemArray[0].ToString()+ " - "+db.queryTable.Rows[i].ItemArray[1].ToString());

                }
                gunaLabel5.Text = db.queryTable.Rows[2].ItemArray[2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Frm_ChartofAccount_add_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            _formMain.Enabled = true;
        }
      
        private void Cmb_CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            gunaLabel5.Visible = true;
           gunaLabel5.Text = db.queryTable.Rows[Cmb_CategoryList.SelectedIndex].ItemArray[2].ToString();
        }

        private void Btn_AddCode_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            try
            {
                db.AddChartAccount(Txt_Code.Text, Txt_AccountTitle.Text, Cmb_CategoryList.Text.Substring(0, 9));
                MessageBox.Show("Account Added Successfully", "Add Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Txt_AccountTitle.Text = "";
                Txt_Code.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
