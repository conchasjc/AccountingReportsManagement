using AccountingReportsManagement.MODULES;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingReportsManagement
{
    public partial class Frm_Main : Form
    {

        //Initialize class instance
        Database account = new Database();
        Database clientSupplier = new Database();
        ClientSupplier clients = new ClientSupplier();
   
        //-----------------------------------------INITIALIZE FORM---------------------------------------------//
        public Frm_Main()
        {
            InitializeComponent();
          
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

            Lbl_DateDisp.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            Tmr_ClockTick.Enabled = true;

            try
            {
                //Load Data for Account Entries
                account.GetQuery("Select OrigAccountCode , AccountTitle from chartofaccountsentries");
                for (int i = 0; i <= account.queryTable.Rows.Count - 1; i++)
                {
                    Grid_Accounts.Rows.Add(account.queryTable.Rows[i].ItemArray[0].ToString(), account.queryTable.Rows[i].ItemArray[1].ToString());
                }
                //End of Account Entries
             
                //Load Client Supplier Data
                Grid_Client.DataSource = clients.Load(1);
                Grid_Client.Columns[0].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells;
                clientSupplier.GetQuery("Select * from clientsuppliercategory;");
                //End of Client Supplier

                for (int i = 0; i <= clientSupplier.queryTable.Rows.Count - 1; i++)
                {
                    Cmb_ClientSupplierCategory.Items.Add(clientSupplier.queryTable.Rows[i].ItemArray[0].ToString() + " - " + clientSupplier.queryTable.Rows[i].ItemArray[1].ToString());
                    Cmb_FClientSupplier.Items.Add(clientSupplier.queryTable.Rows[i].ItemArray[0].ToString() + " - " + clientSupplier.queryTable.Rows[i].ItemArray[1].ToString());

                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Alt && e.KeyValue > '0' && e.KeyValue <= '9')
            {
                TC_VoucherReports.SelectedIndex = (int)(e.KeyValue - '1');
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode==Keys.Back)
            {
                if (Grid_Client.Focused == true)
                {
                   DialogResult res = MessageBox.Show("Delete " + Grid_Client.SelectedCells[0].Value.ToString() + " " + Grid_Client.SelectedCells[1].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        try
                        {
                            Databased deleteData = new Databased("Delete from clientsupplierentries where entryCode='" + Grid_Client.SelectedCells[0].Value.ToString() + "'");
                            clients.Load(1);
                        }
                        catch
                        { }
                    }
                }
                }
        }

        private void Tmr_ClockTick_Tick(object sender, EventArgs e)
        {
            Lbl_ClockDisp.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        //--------------------------------------------INITIAL FORM---------------------------------------------------------//






        //--------------------------------------------CLIENT BLOCK---------------------------------------------------------//

        private void Btn_UpdateClient_Click(object sender, EventArgs e)
        {
            if (Btn_UpdateClient.Text == "Update")
            {
              
                    Txt_ClientAdd.Enabled = true;
                    Txt_ClientCode.Enabled = true;
                    Txt_ClientName.Enabled = true;
                    Txt_ClientTin.Enabled = true;
                Grid_Client.Enabled = false;
                    Txt_ClientCode.Focus();
                    Btn_UpdateClient.Text = "Save";
                
            }
            else if (Btn_UpdateClient.Text == "Save")
            {
                DialogResult res = MessageBox.Show("Apply Changes?", "Update Client", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        clients.UpdateClient(Grid_Client.SelectedCells[0].Value.ToString(), Txt_ClientCode.Text, Txt_ClientName.Text, Txt_ClientTin.Text, Txt_ClientAdd.Text);
                        clients.Load(1);
                        Grid_Client.Enabled = true;
                        Txt_ClientAdd.Enabled = false;
                        Txt_ClientCode.Enabled = false;
                        Txt_ClientName.Enabled = false;
                        Txt_ClientTin.Enabled = false;
                        Btn_UpdateClient.Text = "Update";
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (res == DialogResult.No)
                {
                    
                    Grid_Client.Enabled = true;
                    Txt_ClientAdd.Enabled = false;
                    Txt_ClientCode.Enabled = false;
                    Txt_ClientName.Enabled = false;
                    Txt_ClientTin.Enabled = false;
                    Btn_UpdateClient.Text = "Update";
                   
                }
            }
        }

        private void Cmb_FClientSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_FClientSupplier.Text == "All") {
                Grid_Client.DataSource = clients.ComboBoxFilter("");
                Grid_Client.Focus();
                Grid_Client.MultiSelect = false;
                Grid_Client.MultiSelect = true;
                
                Grid_Client.Rows[0].Selected = true;
              

            }
            else { 

            Grid_Client.DataSource = clients.ComboBoxFilter(Cmb_FClientSupplier.Text.Substring(0, 2).ToString());
            Grid_Client.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Grid_Client.Focus();
                Grid_Client.MultiSelect = false;
                Grid_Client.MultiSelect = true;
            
                Grid_Client.Rows[0].Selected = true;
            }
        }
        private void Btn_AddClient_Click(object sender, EventArgs e)
        {
            try
            {

                clients.AddClient(Txt_AddClientCode.Text, Txt_AddClientName.Text, Cmb_ClientSupplierCategory.Text.Substring(7, Cmb_ClientSupplierCategory.Text.Length - 7).ToString(), Txt_AddClientTin.Text, Txt_AddClientAddress.Text);
                Txt_AddClientCode.Text = "";
                Txt_AddClientName.Text = "";
                Txt_AddClientTin.Text = "";
                Txt_AddClientAddress.Text = "";
                Txt_AddClientCode.Focus();
                clients.Load(1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Txt_clientSearch_Enter(object sender, EventArgs e)
        {
            Txt_clientSearch.Text = "";
            Txt_clientSearch.ForeColor = SystemColors.ControlText;
            Pb_clientSearchOn.Visible = true;
            Pb_clientSearchOff.Visible = false;
        }

        private void Txt_clientSearch_Leave(object sender, EventArgs e)
        {
            if (Txt_clientSearch.Text == "")
            {
                Txt_clientSearch.ForeColor = SystemColors.InactiveCaptionText;
                Txt_clientSearch.Text = "Enter Client Code or Client Name to Search...";
            }
            Pb_clientSearchOn.Visible = false;
            Pb_clientSearchOff.Visible = true;
        }



        private void Txt_clientSearch_TextChanged(object sender, EventArgs e)
        {
            if (Txt_clientSearch.Text == "Enter Client Code or Client Name to Search...") { 
            }
            else
            {
                Grid_Client.DataSource = clients.TextBoxFilter(Txt_clientSearch.Text);
            }
        }
        //-----------------------------------------END CLIENT BLOCK---------------------------------------------------------//





























        private void Txt_Search_Enter(object sender, EventArgs e)
        {
            Txt_Search.Text = "";
            Txt_Search.ForeColor = SystemColors.ControlText;
            Pb_SearchActive.Visible = true;
            Pb_SearchInactive.Visible = false;

        }

        private void Txt_Search_Leave(object sender, EventArgs e)
        {
            if (Txt_Search.Text == "")
            {
                Txt_Search.ForeColor = SystemColors.InactiveCaptionText;
                Txt_Search.Text = "Enter Account Code or Account Title to Search...";

            }
            Pb_SearchActive.Visible = false;
            Pb_SearchInactive.Visible = true;

        }

        private void databaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Database dbForm = new Frm_Database();
            dbForm.Show();
        }

      

        private void Tmr_MenuTransition_Tick(object sender, EventArgs e)
        {

            if (Pnl_MenuList.Size.Width != 255)
            {
                Pnl_MenuList.Width += 10;
            }
            else if (Pnl_MenuList.Size.Width == 255)
            {
                Tmr_MenuTransition.Enabled = false;
            }


        }
        int swt = 0;
        private void Pb_MenuBar_Click(object sender, EventArgs e)
        {

            if (swt == 0)
            {
                Tmr_MenuTransitionClose.Enabled = false;
                Tmr_MenuTransition.Enabled = true;
                swt = 1;
            }
            else if (Tmr_MenuTransition.Enabled == false & swt == 1)
            {
                Tmr_MenuTransition.Enabled = false;
                Tmr_MenuTransitionClose.Enabled = true;
                swt = 0;
            }
        }

        private void Tmr_MenuTransitionClose_Tick(object sender, EventArgs e)
        {
            if (Pnl_MenuList.Size.Width != 55)
            {
                Pnl_MenuList.Width -= 10;
            }
            else if (Pnl_MenuList.Size.Width == 55)
            {
                Tmr_MenuTransitionClose.Enabled = false;
            }
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            if (Tmr_MenuTransition.Enabled == false & swt == 1)
            {
                Tmr_MenuTransition.Enabled = false;
                Tmr_MenuTransitionClose.Enabled = true;
                swt = 0;
            }

        }

















        private void Btn_AddAccount_Click(object sender, EventArgs e)
        {
            Frm_ChartofAccount_add addAcc = new Frm_ChartofAccount_add(this);
            addAcc.Show();
            this.Enabled = false;
        }


 
        private void Grid_Client_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


          

            
        }
        

        private void Grid_Client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Txt_ClientCode.Text = Grid_Client.SelectedRows[0].Cells[0].Value.ToString();
            //Txt_ClientName.Text = Grid_Client.SelectedRows[0].Cells[1].Value.ToString();
            Database getInfo = new Database();

            getInfo.GetQuery("select * from clientsupplierentries where entryCode='" + Grid_Client.SelectedCells[0].Value.ToString() + "'");

            Txt_ClientCode.Text = getInfo.queryTable.Rows[0][0].ToString();
            Txt_ClientName.Text = getInfo.queryTable.Rows[0][1].ToString();
            Txt_ClientTin.Text = getInfo.queryTable.Rows[0][3].ToString();
            Txt_ClientAdd.Text = getInfo.queryTable.Rows[0][4].ToString();
            label13.Text = Grid_Client.SelectedCells[0].Value.ToString();
        }

       private void Grid_Client_SelectionChanged(object sender, EventArgs e)
        {
            Database getInfo = new Database();
            try
            {
                getInfo.GetQuery("select * from clientsupplierentries where entryCode='" + Grid_Client.SelectedCells[0].Value.ToString() + "'");
                Txt_ClientCode.Text = getInfo.queryTable.Rows[0][0].ToString();
                Txt_ClientName.Text = getInfo.queryTable.Rows[0][1].ToString();
                Txt_ClientTin.Text = getInfo.queryTable.Rows[0][3].ToString();
                Txt_ClientAdd.Text = getInfo.queryTable.Rows[0][4].ToString();
            }
            catch
            {

            }
        }
    }
}

