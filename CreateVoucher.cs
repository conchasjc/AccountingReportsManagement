using AccountingReportsManagement.MODULES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AccountingReportsManagement.REPORTS;
using System.IO;

namespace AccountingReportsManagement
{
    public partial class CreateVoucher : Form
    {
        BindingSource bs = new BindingSource();
        BindingSource Account = new BindingSource();
        CheckVouch checkVoucher = new CheckVouch();
        CashVoucher cashVoucher = new CashVoucher();
        Voucher petty = new PettyCash();
        Voucher check = new Check();
        Voucher cash = new Cash();
        int x = 0;//Controlling Panel Location
         
        public CreateVoucher()
        {
            InitializeComponent();
        }
        int noOfVoucher;
        private void CreateVoucher_Load(object sender, EventArgs e)
        {
            CreateVoucherClass cv = new CreateVoucherClass();
            noOfVoucher=Convert.ToInt32(cv.getVoucherCount())+1;
            
            try
            {
                bs.DataSource = cv.LoadClient();
                Cmb_PayableName.ValueMember = "entryName";
                bs.Sort = "entryName ASC";
                Cmb_PayableName.DataSource = bs;
                Cmb_PayableName.Text = "";
                Txt_SuppCode.Text = "";
                Account.DataSource = cv.loadAccounts();
                Cmb_LoadAddAccounts.ValueMember = "Content_Title";
                Account.Sort = "Content_Title ASC";
                Cmb_LoadAddAccounts.DataSource = Account;
                Cmb_LoadAddAccounts.Text = "";
                Txt_AddAccCode.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Pnl_BodyVoucher.Location = new Point(0, 230);
            if (Pnl_BodyVoucher.Location.X == 0)
            {
                Btn_PrevButton.Visible = false;
            }
        }



        private void Txt_CheckNum_Enter(object sender, EventArgs e)
        {
            Txt_CheckNum.Text = "";
        }

        private void Txt_CheckNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Tmr_TransNext.Enabled = true;
                Cmb_PayableName.Focus();
            }
        }


        //***************** TIMER AND BUTTON *******************//
        private void Btn_NextButton_Click(object sender, EventArgs e)
        {
            Tmr_TransNext.Enabled = true;
        }

        private void Btn_PrevButton_Click(object sender, EventArgs e)
        {
            Tmr_TransPrev.Enabled = true;
        }

        private void Tmr_TransNext_Tick(object sender, EventArgs e)
        {
            if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == SystemColors.ControlDark && x > -986)
            {
                //***************************************************************************************************************//
                if (Cmb_VoucherTypeSelection.Text == "" || Txt_CheckNum.Text == "Enter Check Number" || Txt_CheckNum.Text == "")
                {
                    Tmr_TransNext.Enabled = false;
                    MessageBox.Show("Please complete required fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    x = x - 40;
                    Pnl_BodyVoucher.Location = new Point(x, 230);
                }
                //***************************************************************************************************************//
            }
            else if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == Color.SeaGreen && x > -1972)
            {
                x = x - 40;
                Pnl_BodyVoucher.Location = new Point(x, 230);
            }
            else
            {
                //*********************************************************************************************************************//
                if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == SystemColors.ControlDark && x < -986)
                {
                    Pnl_BodyVoucher.Location = new Point(-986, 230);
                    Tmr_TransNext.Enabled = false;
                    Pnl_LineOne.BackColor = Color.SeaGreen;
                    Btn_DataVoucher.BaseColor = Color.SeaGreen;
                    Btn_DataVoucher.OnHoverBaseColor = Color.SeaGreen;
                    Btn_DataVoucher.OnPressedColor = Color.SeaGreen;
                    Btn_PrevButton.BaseColor = Color.SeaGreen;
                    Btn_PrevButton.OnHoverBaseColor = Color.MediumSeaGreen;
                    Lbl_GDataVoucher.Font = new Font(this.Font, FontStyle.Bold);
                    Lbl_GVoucherType.Font = new Font(this.Font, FontStyle.Regular);
                    Btn_PrevButton.Visible = true;
                    gunaShadowPanel1.Visible = true;
                }
                else if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == Color.SeaGreen && x < -1972)
                {
                    Pnl_BodyVoucher.Location = new Point(-1972, 230);
                    Tmr_TransNext.Enabled = false;
                    Pnl_LineTwo.BackColor = Color.SeaGreen;
                    Btn_Finalize.BaseColor = Color.SeaGreen;
                    Btn_Finalize.OnHoverBaseColor = Color.SeaGreen;
                    Btn_Finalize.OnPressedColor = Color.SeaGreen;
                    Btn_PrevButton.BaseColor = Color.SeaGreen;
                    Btn_PrevButton.OnHoverBaseColor = Color.MediumSeaGreen;
                    Lbl_GFinalize.Font = new Font(this.Font, FontStyle.Bold);
                    Lbl_GDataVoucher.Font = new Font(this.Font, FontStyle.Regular);
                    Btn_NextButton.Text = "Save";
                    GenerateReport();
                }
                //******************************************************************************************************************//
            }
        }

        
        private void Cmb_VoucherTypeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_VoucherTypeSelection.SelectedIndex == 0)
            {
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;
                Lbl_CvNumber.Text = "KMPV-" + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-";
            }
            else if (Cmb_VoucherTypeSelection.SelectedIndex == 1)
            {
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;
                Lbl_CvNumber.Text = "KM-CV-" + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + "01";
                crystalReportViewer1.ReportSource = cashVoucher;
            }
            else if (Cmb_VoucherTypeSelection.SelectedIndex == 2)
            {
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;
                Lbl_CvNumber.Text = "KM-" + DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + noOfVoucher.ToString("00");
                crystalReportViewer1.ReportSource = checkVoucher;
            }
        }

        private void Tmr_TransPrev_Tick(object sender, EventArgs e)
        {
            if (Btn_Finalize.BaseColor == Color.SeaGreen && x < -986)
            {
                x = x + 40;
                Pnl_BodyVoucher.Location = new Point(x, 230);
            }
            else if (Btn_DataVoucher.BaseColor == Color.SeaGreen && Btn_Finalize.BaseColor == SystemColors.ControlDark && x < 0)
            {
                x = x + 40;
                Pnl_BodyVoucher.Location = new Point(x, 230);
            }
            else
            {

                if (Btn_DataVoucher.BaseColor == Color.SeaGreen && Btn_Finalize.BaseColor == Color.SeaGreen && x > -986)
                {
                    Pnl_BodyVoucher.Location = new Point(-986, 230);
                    Pnl_LineTwo.BackColor = SystemColors.ControlDark;
                    Btn_Finalize.BaseColor = SystemColors.ControlDark;
                    Btn_Finalize.OnHoverBaseColor = SystemColors.ControlDark;

                    if (Pnl_BodyVoucher.Location.X == -986)
                    {
                        Lbl_GDataVoucher.Font = new Font(this.Font, FontStyle.Bold);
                        Lbl_GFinalize.Font = new Font(this.Font, FontStyle.Regular);
                    }

                    Tmr_TransPrev.Enabled = false;
                }
                else if (Btn_DataVoucher.BaseColor == Color.SeaGreen && Btn_Finalize.BaseColor == SystemColors.ControlDark && x >= 0)
                {
                    Pnl_BodyVoucher.Location = new Point(0, 230);
                    Pnl_LineOne.BackColor = SystemColors.ControlDark;
                    Btn_DataVoucher.BaseColor = SystemColors.ControlDark;
                    Btn_DataVoucher.OnHoverBaseColor = SystemColors.ControlDark;

                    if (Pnl_BodyVoucher.Location.X == 0)
                    {
                        Lbl_GDataVoucher.Font = new Font(this.Font, FontStyle.Regular);
                        Lbl_GVoucherType.Font = new Font(this.Font, FontStyle.Bold);
                        Btn_PrevButton.BaseColor = SystemColors.AppWorkspace;
                        Btn_PrevButton.Visible = false;
                        gunaShadowPanel1.Visible = false;
                    }

                    Tmr_TransPrev.Enabled = false;
                }
            }
        }


        private void Txt_CheckNum_Validated(object sender, EventArgs e)
        {
            Lbl_CheckNumber.Text = Txt_CheckNum.Text;
        }

        //************************************************************************************************************************************************//


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateVoucherClass cv = new CreateVoucherClass();
            cv.getClient(Cmb_PayableName.Text);
            Txt_SuppCode.Text = cv.getClient(Cmb_PayableName.Text);
            Cmb_PayableName.Text = Cmb_PayableName.Text.ToString().ToUpper();

        }




























      

        private void Cmb_LoadAddAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateVoucherClass cv = new CreateVoucherClass();
            cv.getAccounts(Cmb_LoadAddAccounts.Text);
            Txt_AddAccCode.Text = cv.getAccounts(Cmb_LoadAddAccounts.Text);
           Cmb_LoadAddAccounts.Text = Cmb_LoadAddAccounts.Text.ToString().ToUpper();
        }

        private void Btn_AddAcctoGrid_Click(object sender, EventArgs e)
        {
            DG_AddAccounts.Rows.Add(Cmb_LoadAddAccounts.Text, Txt_AddAccCode.Text,RB_PesoCurrency.Text,Txt_AddDebit.Text,Txt_AddCredit.Text);
          
           
            if (Txt_AddDebit.Text!="") {
                TextObject accTitle = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RAccTitle"];
                accTitle.Text = accTitle.Text + "\n\n" + Cmb_LoadAddAccounts.Text;
                TextObject accCode = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RAccCode"];
                accCode.Text = accCode.Text + "\n\n" + Txt_AddAccCode.Text;
            }
            else
            {
                TextObject accTitle = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RAccTitle"];
                accTitle.Text = accTitle.Text + "\n\n\t\t" + Cmb_LoadAddAccounts.Text;
                TextObject accCode = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RAccCode"];
                accCode.Text = accCode.Text + "\n\n\t\t" + Txt_AddAccCode.Text;
            }
            if (RB_ForeignCurrency.Checked == true)
            {
                TextObject Fdebit = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RFDebit"];
                Fdebit.Text = Fdebit.Text + "\n\n" + "$ " + Txt_AddDebit.Text;
                TextObject fCredit = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RFCredit"];
                fCredit.Text = fCredit.Text + "\n\n" +"$ "+ Txt_AddCredit.Text;
            }
            else
            {
                TextObject Pdebit = (TextObject)checkVoucher.ReportDefinition.Sections["DetailSection1"].ReportObjects["Txt_RPDebit"];
                Pdebit.Text = Txt_AddDebit.Text;
            }
            NumToWords nw = new NumToWords();
            string words = nw.ConvertAmount(double.Parse(Txt_AddCredit.Text));
            TextObject AmountServe = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Amount"];
            AmountServe.Text = Txt_AddCredit.Text;
            TextObject AmountWords = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_AmountToWords"];
            AmountWords.Text = words;
            Cmb_LoadAddAccounts.Text = "";
            Txt_AddAccCode.Text = "";
            Txt_AddCredit.Text = "";
            Txt_AddDebit.Text = "";
            Cmb_LoadAddAccounts.Focus();
         
        }

        private void Txt_AddDebit_TextChanged(object sender, EventArgs e)
        {
            if (Txt_AddDebit.Text != "")
            {
                Txt_AddCredit.Enabled = false;
            }
            else
            {
                Txt_AddCredit.Enabled = true;
            }
        }

        private void Txt_AddCredit_TextChanged(object sender, EventArgs e)
        {
            if (Txt_AddCredit.Text != "")
            {
                Txt_AddDebit.Enabled = false;
            }
            else
            {
                Txt_AddDebit.Enabled = true;
            }
        }

       


      
  


        private void Btn_Pdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Export Pdf File";
            SaveFile.DefaultExt = "pdf";
            SaveFile.InitialDirectory = @"C:\"; 
            SaveFile.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
          
            if (SaveFile.ShowDialog()==DialogResult.OK)
            {
               
                    checkVoucher.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, SaveFile.FileName);
                
            }
           // checkVoucher.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Check Voucher.pdf");
            //MessageBox.Show("Exported Successful");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }


        private void GenerateReport() 
        {
            TextObject payableName = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_PayableName"];
            TextObject supplierCode = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_RSupplierCode"];
            payableName.Text = Cmb_PayableName.Text;
            supplierCode.Text = Txt_SuppCode.Text;


            TextObject particular = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_RParticular"];
            TextObject checkNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_RCheckNo"];
            TextObject CVNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_RCVNo"];
            TextObject TCVNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_CVTop"];
            particular.Text = Txt_Particu.Text;
            checkNo.Text = Lbl_CheckNumber.Text;
            CVNo.Text = Lbl_CvNumber.Text;
            TCVNo.Text = Lbl_CvNumber.Text;
            try
            {
                //CreateVoucherClass cv = new CreateVoucherClass();
                //cv.addVoucher("Check Voucher", Lbl_CheckNumber.Text, Lbl_CvNumber.Text, Cmb_PayableName.Text, Txt_SuppCode.Text, Txt_Particu.Text, Txt_other.Text);
                switch (Cmb_VoucherTypeSelection.SelectedIndex)
                {
                    case 0:
                        petty.PayerInformation(Cmb_PayableName.Text, Txt_SuppCode.Text, Lbl_CvNumber.Text, Lbl_CheckNumber.Text, Txt_Particu.Text, Txt_other.Text);
                        petty.SaveVoucher();
                    break;
                    case 1:
                       cash.PayerInformation(Cmb_PayableName.Text, Txt_SuppCode.Text, Lbl_CvNumber.Text, Lbl_CheckNumber.Text, Txt_Particu.Text, Txt_other.Text);
                        cash.SaveVoucher();
                    break;
                    case 2:
                        check.PayerInformation(Cmb_PayableName.Text, Txt_SuppCode.Text, Lbl_CvNumber.Text, Lbl_CheckNumber.Text, Txt_Particu.Text, Txt_other.Text);
                        check.SaveVoucher();
                    break; 
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"");
            }
        }

        public string Amount(string amount) 
        {
            return amount;
        }

        private void DG_AddAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in DG_AddAccounts.Rows)
            {
                bool isSelected = Convert.ToBoolean(Dg_Checkbox.ValueType);
                if (isSelected)
                {
                    gunaLabel16.Text = row.Cells[4].Value.ToString();
                    
                }
            }
        }

  
    }
}
