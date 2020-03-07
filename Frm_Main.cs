using AccountingReportsManagement.MODULES;
using AccountingReportsManagement.MODULES.VoucherPreviewModule;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingReportsManagement
{
    public partial class Frm_Main : Form
    {
        //Initialize class instance
        
        readonly Database  clientSupplier = new Database();
        readonly ClientSupplier clients = new ClientSupplier();
        readonly ChartofAccount accounts = new ChartofAccount();
        readonly CreateVoucherClass Payee = new CreateVoucherClass();
        //END OF INITIALIZATION

        BindingSource bs = new BindingSource();

        //-----------------------------------------INITIALIZE FORM---------------------------------------------//
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Lbl_DateDisp.Text = DateTime.Now.ToString("MMMM dd yyyy, dddd");
            Tmr_ClockTick.Enabled = true;
            if (CmbCategoryAcc.Text == "Category Account")
            {
                Cmb_SubCategory.Enabled = false;
            }
            try
           {
                bs.DataSource = Payee.viewVouchers();
                Grid_ViewPayee.DataSource = bs;
                Grid_ViewPayee.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                Grid_ViewPayee.RowsDefaultCellStyle.Padding = new Padding(3);
                //Load Data for Account Entries

                Grid_Accounts.DataSource = accounts.Load(1);
                Grid_Accounts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Grid_Accounts.Columns[0].DefaultCellStyle.Font = new Font(Grid_Accounts.Font, FontStyle.Bold);
                Grid_Accounts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                Grid_Accounts.RowsDefaultCellStyle.Padding = new Padding(3);
                //End of Account Entries
              

                //Load Client Supplier Data
                Grid_Client.DataSource = clients.Load(1);
                Grid_Client.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               
                clientSupplier.GetQuery("Select * from clientsuppliercategory;");
                Grid_Client.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                Grid_Client.RowsDefaultCellStyle.Padding = new Padding(3);
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
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
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
            else if (e.KeyCode == Keys.Escape && Txt_ClientCode.Enabled==true || Txt_ClientName.Enabled == true)
            {
                Grid_Client.Enabled = true;
                Txt_ClientAdd.Enabled = false;
                Txt_ClientCode.Enabled = false;
                Txt_ClientName.Enabled = false;
                Txt_ClientTin.Enabled = false;
                Btn_UpdateClient.Text = "Update";
            }
        }
  
        private void Tmr_ClockTick_Tick(object sender, EventArgs e)
        {
            Grid_ViewPayee.Refresh();
            Lbl_ClockDisp.Text = DateTime.Now.ToString("h:mm:ss tt");
            int x = 0;
            try {
                do
                {
                    if (Grid_Accounts.Rows[x].Cells[0].Value.ToString().Length.ToString() == "4")
                    {
                        Grid_Accounts.Rows[x].Cells[1].Style.ForeColor = Color.Red;
                       
                    }
                    x++;
                }
                while (x != Convert.ToInt32(Grid_Accounts.Rows.Count.ToString()));

            }
            catch {
               
            }
            }
        private void DatabaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Database dbForm = new Frm_Database();
            dbForm.Show();
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
            else 
            { 
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

        private void Grid_Client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database getInfo = new Database();
            getInfo.GetQuery($"select * from clientsupplierentries where entryCode='{Grid_Client.SelectedCells[0].Value.ToString()}'");
            Txt_ClientCode.Text = getInfo.queryTable.Rows[0][0].ToString();
            Txt_ClientName.Text = getInfo.queryTable.Rows[0][1].ToString();
            Txt_ClientTin.Text = getInfo.queryTable.Rows[0][3].ToString();
            Txt_ClientAdd.Text = getInfo.queryTable.Rows[0][4].ToString();
        }

        private void Grid_Client_SelectionChanged(object sender, EventArgs e)
        {
            Database getInfo = new Database();
            try
            {
                getInfo.GetQuery($"select * from clientsupplierentries where entryCode='{ Grid_Client.SelectedCells[0].Value.ToString()}'");
                Txt_ClientCode.Text = getInfo.queryTable.Rows[0][0].ToString();
                Txt_ClientName.Text = getInfo.queryTable.Rows[0][1].ToString();
                Txt_ClientTin.Text = getInfo.queryTable.Rows[0][3].ToString();
                Txt_ClientAdd.Text = getInfo.queryTable.Rows[0][4].ToString();
            }
            catch
            {

            }
        }

        //-----------------------------------------END CLIENT BLOCK---------------------------------------------------------//











        //---------------------------------------- START OF CHART OF ACCOUNTS BLOCK-----------------------------------------//

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

        //----------------------------------------- END OF CHART OF ACCOUNTS BLOCK------------------------------------------//

  
      
        //================================================ START OF SIDEBAR TRANSITION BLOCK===============================================//
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
                Pnl_MenuList.Focus();
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

        private void CmbCategoryAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbCategoryAcc.ForeColor = Color.Black;
            Cmb_SubCategory.Enabled = true;
            switch(CmbCategoryAcc.Text)
            {
                case "All Category":
                 Cmb_SubCategory.Items.Clear();
                 Cmb_SubCategory.Enabled = false;
                 Cmb_SubCategory.Text = "Sub-Category Account";
                 accounts.Load(1);
                break;
                case "Asset Accounts" :
                    Cmb_SubCategory.Items.Clear();
                    Cmb_SubCategory.Text = "";
                    Cmb_SubCategory.Items.Add("1000  CASH & CASH EQUIVALENTS");
                    Cmb_SubCategory.Items.Add("1200  ACCOUNTS RECEIVABLES TRADE");
                    Cmb_SubCategory.Items.Add("1300  INVENTORIES");
                    Cmb_SubCategory.Items.Add("1400  OTHER CURRENT ASSETS");
                    Cmb_SubCategory.Items.Add("1500  INVESTMENT PROPERTY");
                    Cmb_SubCategory.Items.Add("1600  PROPERTY, PLANT AND EQUIPMENT, NET");
                    Cmb_SubCategory.Items.Add("1700  INTANGIBLE ASSETS");
                    Cmb_SubCategory.Items.Add("1800  OTHER NON-CURRENT ASSETS");
                    Cmb_SubCategory.SelectedIndex=0;
                    
                break;
                case "Liabilities":
                    Cmb_SubCategory.Items.Clear();
                    Cmb_SubCategory.Text = "";
                    Cmb_SubCategory.Items.Add("2100  CURRENT LIABILITIES");
                    Cmb_SubCategory.Items.Add("2200  GOVERNMENT MANDATORY PAYABLE");
                    Cmb_SubCategory.Items.Add("2300  NON-CURRENT LIABILITIES");
                    Cmb_SubCategory.SelectedIndex = 0;
                break;
                case "Equity":
                    Cmb_SubCategory.Items.Clear();
                    Cmb_SubCategory.Text = "";
                    Cmb_SubCategory.Items.Add("3100-3299 SHAREHOLDERS EQUITY");
                    Cmb_SubCategory.Items.Add("3300-3599 CUMMULATIVE EARNINGS (LOSSES)");
                    Cmb_SubCategory.SelectedIndex = 0;
                break;
                case "Revenue Items":
                    Cmb_SubCategory.Items.Clear();
                    Cmb_SubCategory.Text = "";
                    Cmb_SubCategory.Items.Add("4000 NET SALES");
                    Cmb_SubCategory.Items.Add("5000 OTHER INCOME");
                    Cmb_SubCategory.Items.Add("6000 COST OF GOOD SOLD");
                    Cmb_SubCategory.Items.Add("6100 RAW MATERIALS USED");
                    Cmb_SubCategory.Items.Add("6200 DIRECT LABOR");
                    Cmb_SubCategory.Items.Add("6300 FACTORY OVERHEAD");
                    Cmb_SubCategory.SelectedIndex = 0;
                break;
                case "Operating Expenses":
                    Cmb_SubCategory.Items.Clear();
                    Cmb_SubCategory.Text = "";
                    Cmb_SubCategory.Items.Add("7100-7399 ADMINISTRATIVE COST");
                    Cmb_SubCategory.Items.Add("7400 SELLING MARKETING COST");
                    Cmb_SubCategory.Items.Add("7500 FINANCING COST");
                    Cmb_SubCategory.Items.Add("7600 OTHER EXPENSES");
                    Cmb_SubCategory.Items.Add("7800 MISCELLANEOUS EXPENSE");
                    Cmb_SubCategory.Items.Add("7900 PROVISION FOR INCOME TAX");
                    Cmb_SubCategory.Items.Add("8000 OTHER COMPREHENSIVE INCOME");
                    break;

            }
          
            
        }

        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            if (Txt_Search.Text == "Enter Account Code or Account Title to Search...")
            {
            }
            else
            {
                Grid_Accounts.DataSource = accounts.TextFilter(Txt_Search.Text);
            }
        }

        private void Btn_AddAcc_Click(object sender, EventArgs e)
        {
            try
            {
                accounts.AddAccounts(Cmb_AddAccSubCategory.Text, Txt_AddAccountCode.Text, Txt_AddAccountTitle.Text,Cmb_AddAccCategory.Text);
                Txt_AddAccountCode.Focus();
                accounts.Load(1);
                Grid_Accounts.Rows[Grid_Accounts.Rows.Count-2].Selected = false;
                Grid_Accounts.Rows[Grid_Accounts.Rows.Count - 1].Selected = true;
            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cmb_SubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbCategoryAcc.Text!="Equity") {
                Grid_Accounts.DataSource = accounts.CategoryPick(Cmb_SubCategory.Text.Substring(0, 4));
            }
            else
            {
                Grid_Accounts.DataSource = accounts.CategoryPick(Cmb_SubCategory.Text.Substring(0, 9));
            }
           
            Grid_Accounts.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;



        }

        private void Grid_Accounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Database getInfo = new Database();
            getInfo.GetQuery("select * from accountcontent where Content_Code='" + Grid_Accounts.SelectedCells[0].Value.ToString() + "'");
            Txt_UpdAccCode.Text = getInfo.queryTable.Rows[0][0].ToString();
            Txt_UpdAccName.Text = getInfo.queryTable.Rows[0][1].ToString();
            Cmb_UpdAccCategory.Text = getInfo.queryTable.Rows[0][3].ToString();
            Cmb_UpdSubAccCategory.Text = getInfo.queryTable.Rows[0][2].ToString();
        }

        private void Grid_Accounts_SelectionChanged(object sender, EventArgs e)
        {
            Database getInfo = new Database();
            try
            {
                getInfo.GetQuery("select * from accountcontent where Content_Code='" + Grid_Accounts.SelectedCells[0].Value.ToString() + "'");
                Txt_UpdAccCode.Text = getInfo.queryTable.Rows[0][0].ToString();
                Txt_UpdAccName.Text = getInfo.queryTable.Rows[0][1].ToString();
                Cmb_UpdAccCategory.Text = getInfo.queryTable.Rows[0][3].ToString();
                Cmb_UpdSubAccCategory.Text = getInfo.queryTable.Rows[0][2].ToString();
            }
            catch
            {

            }
        }

        private void Btn_UpdateAcc_Click(object sender, EventArgs e)
        {
            if (Btn_UpdateAcc.Text == "Update")
            {
                Cmb_UpdAccCategory.Enabled = true;
                Cmb_UpdSubAccCategory.Enabled = true;
                Txt_UpdAccCode.Enabled = true;
                Txt_UpdAccName.Enabled = true;
                Grid_Accounts.Enabled = false;
                Cmb_UpdAccCategory.Focus();
                Btn_UpdateAcc.Text = "Save";
            }
            else if (Btn_UpdateAcc.Text == "Save")
            {
                DialogResult res = MessageBox.Show("Apply Changes?", "Update Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        accounts.UpdateAccounts(Grid_Accounts.SelectedCells[0].Value.ToString(), Cmb_UpdAccCategory.Text, Cmb_UpdSubAccCategory.Text, Txt_UpdAccCode.Text, Txt_UpdAccName.Text);
                        accounts.Load(1);
                        Grid_Accounts.Enabled = true;
                        Cmb_UpdAccCategory.Enabled = false;
                        Cmb_UpdSubAccCategory.Enabled = false;
                        Txt_UpdAccCode.Enabled = false;
                        Txt_UpdAccName.Enabled = false;
                        Btn_UpdateAcc.Text = "Update";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (res == DialogResult.No)
                {
                    Grid_Accounts.Enabled = true;
                    Cmb_UpdAccCategory.Enabled = false;
                    Cmb_UpdSubAccCategory.Enabled = false;
                    Txt_UpdAccCode.Enabled = false;
                    Txt_UpdAccName.Enabled = false;
                    Btn_UpdateAcc.Text = "Update";
                }
            }
        }

        private void Cmb_AddAccCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Cmb_AddAccCategory.Text)
            {
                case "All Category":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Enabled = false;
                    Cmb_AddAccSubCategory.Text = "Sub-Category Account";
                    accounts.Load(1);
                    break;
                case "Asset Accounts":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Text = "";
                    Cmb_AddAccSubCategory.Items.Add("1000  CASH & CASH EQUIVALENTS");
                    Cmb_AddAccSubCategory.Items.Add("1200  ACCOUNTS RECEIVABLES TRADE");
                    Cmb_AddAccSubCategory.Items.Add("1300  INVENTORIES");
                    Cmb_AddAccSubCategory.Items.Add("1400  OTHER CURRENT ASSETS");
                    Cmb_AddAccSubCategory.Items.Add("1500  INVESTMENT PROPERTY");
                    Cmb_AddAccSubCategory.Items.Add("1600  PROPERTY, PLANT AND EQUIPMENT, NET");
                    Cmb_AddAccSubCategory.Items.Add("1700  INTANGIBLE ASSETS");
                    Cmb_AddAccSubCategory.Items.Add("1800  OTHER NON-CURRENT ASSETS");
                    Cmb_AddAccSubCategory.SelectedIndex = 0;

                    break;
                case "Liabilities":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Text = "";
                    Cmb_AddAccSubCategory.Items.Add("2100  CURRENT LIABILITIES");
                    Cmb_AddAccSubCategory.Items.Add("2200  GOVERNMENT MANDATORY PAYABLE");
                    Cmb_AddAccSubCategory.Items.Add("2300  NON-CURRENT LIABILITIES");
                    Cmb_AddAccSubCategory.SelectedIndex = 0;
                    break;
                case "Equity":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Text = "";
                    Cmb_AddAccSubCategory.Items.Add("3100-3299 SHAREHOLDERS EQUITY");
                    Cmb_AddAccSubCategory.Items.Add("3300-3599 CUMMULATIVE EARNINGS (LOSSES)");
                    Cmb_AddAccSubCategory.SelectedIndex = 0;
                    break;
                case "Revenue Items":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Text = "";
                    Cmb_AddAccSubCategory.Items.Add("4000 NET SALES");
                    Cmb_AddAccSubCategory.Items.Add("5000 OTHER INCOME");
                    Cmb_AddAccSubCategory.Items.Add("6000 COST OF GOOD SOLD");
                    Cmb_AddAccSubCategory.Items.Add("6100 RAW MATERIALS USED");
                    Cmb_AddAccSubCategory.Items.Add("6200 DIRECT LABOR");
                    Cmb_AddAccSubCategory.Items.Add("6300 FACTORY OVERHEAD");
                    Cmb_AddAccSubCategory.SelectedIndex = 0;
                    break;
                case "Operating Expenses":
                    Cmb_AddAccSubCategory.Items.Clear();
                    Cmb_AddAccSubCategory.Text = "";
                    Cmb_AddAccSubCategory.Items.Add("7100-7399 ADMINISTRATIVE COST");
                    Cmb_AddAccSubCategory.Items.Add("7400 SELLING MARKETING COST");
                    Cmb_AddAccSubCategory.Items.Add("7500 FINANCING COST");
                    Cmb_AddAccSubCategory.Items.Add("7600 OTHER EXPENSES");
                    Cmb_AddAccSubCategory.Items.Add("7800 MISCELLANEOUS EXPENSE");
                    Cmb_AddAccSubCategory.Items.Add("7900 PROVISION FOR INCOME TAX");
                    Cmb_AddAccSubCategory.Items.Add("8000 OTHER COMPREHENSIVE INCOME");
                    break;
                   
            }

        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            CreateVoucher cv = new CreateVoucher();
            cv.Show();
        }

        private void gunaTextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            label21.Text = gunaTextBox1.Text;
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            label21.Text = gunaTextBox1.Text;
        }





        //======================================================= END OF SIDEBAR BLOCK =============================================//

    }
}

