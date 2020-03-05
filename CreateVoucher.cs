using AccountingReportsManagement.MODULES;
using AccountingReportsManagement.MODULES.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingReportsManagement
{


    public partial class CreateVoucher : Form
    {
        int x = 0;             //PANEL DEFAULT LOCATION
        int noOfVoucher;
       
        // ################ INITIALIZE OBJECTS ##################
        Voucher cashVoucher = new CashVouchers();
        Voucher chckVoucher = new CheckVoucher();
        BindingSource bs = new BindingSource();
        BindingSource Account = new BindingSource();
        //#######################################################

        public CreateVoucher()
        {
            InitializeComponent();
        }

        private void CreateVoucher_Load(object sender, EventArgs e)
        {
           
            CreateVoucherClass cv = new CreateVoucherClass();
            Pnl_BodyVoucher.Location = new Point(0, 230);
            List <Databased> student= new List<Databased>();
          
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

            if (Pnl_BodyVoucher.Location.X == 0)
            {
                Btn_PrevButton.Visible = false;
            }

        }



  


        //################################# FOR SELECT VOUCHER TYPE PART ##################################
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

        private void Txt_CheckNum_Validated(object sender, EventArgs e)
        {
            Lbl_CheckNumber.Text = Txt_CheckNum.Text;
        }
        private void Txt_CheckNum_Validating(object sender, CancelEventArgs e)
        {
            long parsedValue;
            if (!long.TryParse(Txt_CheckNum.Text, out parsedValue) || Txt_CheckNum.Text.Length != 10)
            {
                Txt_CheckNum.Text = "";
                Lbl_InvalidCheck.Visible = true;
            }
            else
            {
                Lbl_InvalidCheck.Visible = false;
            }
        }
        private void Cmb_VoucherTypeSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            genVouchNumber();
        }
        //##################################################################################################



        //################################## TIMER AND NEXT,PREV BUTTON PART ################################
        private void Btn_NextButton_Click(object sender, EventArgs e)
        {
            if (Btn_NextButton.Text == "Close")
            {
                this.Close();
            }
            else if (Btn_NextButton.Text == "Save")
            {
                DialogResult res = MessageBox.Show("Save Voucher and Generate Report?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Tmr_TransNext.Enabled = true;
                }
                else
                {
                    Tmr_TransNext.Enabled = false;
                }
            }
            else
            {
                Tmr_TransNext.Enabled = true;
            }
        }
        private void Btn_PrevButton_Click(object sender, EventArgs e)
        {
            Tmr_TransPrev.Enabled = true;
        }
        private void Tmr_TransNext_Tick(object sender, EventArgs e)
        {
            if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == SystemColors.ControlDark && x > -986)
            {
                if (Cmb_VoucherTypeSelection.Text == "" || Txt_CheckNum.Text == "Enter Check Number" || Txt_CheckNum.Text == "" || Cmb_Currency.Text == "")
                {
                    Tmr_TransNext.Enabled = false;
                    MessageBox.Show("Please complete required fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    x -= 40;
                    Pnl_BodyVoucher.Location = new Point(x, 230);
                }
            }
            else if (gunaCircleButton4.BaseColor == Color.SeaGreen && Btn_DataVoucher.BaseColor == Color.SeaGreen && x > -1972)/////eto aayusin ko ngaun
            {
                Tmr_TransNext.Enabled = true;
                x -= 40;
                Pnl_BodyVoucher.Location = new Point(x, 230);
            }
            else
            {
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
                    Btn_NextButton.Text = "Save";
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
                    // Btn_PrevButton.Visible = false;
                    // gunaShadowPanel1.Visible = false;
                    Btn_PrevButton.Text = "New Voucher";
                    Btn_NextButton.Text = "Close";
                    GenerateReport(Cmb_VoucherTypeSelection.SelectedIndex);

                }
            }

        }//
        private void Tmr_TransPrev_Tick(object sender, EventArgs e)
        {
            if (Btn_Finalize.BaseColor == Color.SeaGreen && x < -986)
            {
                x += 40;
                Pnl_BodyVoucher.Location = new Point(x, 230);
                this.Close();
                CreateVoucher cv = new CreateVoucher();
                cv.Show();
            }
            else if (Btn_DataVoucher.BaseColor == Color.SeaGreen && Btn_Finalize.BaseColor == SystemColors.ControlDark && x < 0)
            {
                x += 40;
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
                        Btn_NextButton.Text = "Next";
                    }

                    Tmr_TransPrev.Enabled = false;
                }
            }
        }//



        //###################################################################################################




        //################################# Code Number Retrieve ############################################
        private void Cmb_PayableName_SelectedIndexChanged(object sender, EventArgs e)
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

        //###################################################################################################


        //################################ CREDIT OR DEBIT ##################################################
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

        //###################################################################################################



        //########################################### ADDING VOUCHER CONTENTS INTO TABLE PART ############################################

        private void DG_AddAccounts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double debit = 0;
            double credit = 0;
            for (int i = 0; i < DG_AddAccounts.Rows.Count; i++)
            {
                if (DG_AddAccounts.Rows[i].Cells[3].Value != "")
                {
                    debit += Convert.ToDouble(DG_AddAccounts.Rows[i].Cells[3].Value);
                }
                if (DG_AddAccounts.Rows[i].Cells[4].Value != "")
                {
                    credit += Convert.ToDouble(DG_AddAccounts.Rows[i].Cells[4].Value);
                }
               // label1.Text = credit.ToString();
               // label2.Text = debit.ToString();
              

                try
                {
                   label1.Text = String.Format("{0:n}", double.Parse(credit.ToString()));
                    label2.Text= String.Format("{0:n}", double.Parse(debit.ToString()));
                }
                catch (Exception ex)
                {
                }
            }
           
        }
        //################################################################################################################################






          







        //------------------------------------------------------------------------------------------------------------------------------------------------

        //########################################### BUTTONS IN FINAL PART ##############################################################
        private void Btn_Pdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Export Pdf File";
            SaveFile.DefaultExt = "pdf";
            SaveFile.InitialDirectory = @"C:\";
            SaveFile.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            SaveFile.ShowDialog();
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
              //  chckVoucher.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, SaveFile.FileName);

            }
            // checkVoucher.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"D:\Check Voucher.pdf");
            //MessageBox.Show("Exported Successful");
        }
        private void button1_Click(object sender, EventArgs e) => crystalReportViewer1.PrintReport();
        

        //################################################################################################################################






      
        public void GenerateReport(int selectedOpt)
        {
            
            switch (selectedOpt)
            {
                case 0:

                    break;
                case 1:
                    for (int i = 0; i < DG_AddAccounts.Rows.Count; i++)
                    {
                        if (DG_AddAccounts.Rows[i].Cells[2].Value.ToString() != "₱ - Philippine Peso")
                        {
                            if (DG_AddAccounts.Rows[i].Cells[3].Value.ToString() != "")
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[3].Value}','')");

                            }
                            else
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[4].Value}')");

                            }
                        }
                        else
                        {
                            if (DG_AddAccounts.Rows[i].Cells[3].Value.ToString() != "")
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[3].Value}','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','')");

                            }
                            else
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[4].Value}','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','')");

                            }
                        }
                    }
                  
                   
                    cashVoucher.Info(Cmb_PayableName.Text, Txt_SuppCode.Text, Lbl_CvNumber.Text, Lbl_CheckNumber.Text, Txt_Particular.Text, Txt_Other.Text, Lbl_TotalAmount.Text,gunaDateTimePicker1.Text);
                    cashVoucher.AddContent(DG_AddAccounts, Cmb_Currency.Text.Substring(0, 1).ToString(),label1.Text,label2.Text);
                    crystalReportViewer1.ReportSource = cashVoucher.GenerateVoucher();
                   cashVoucher.SaveVoucher();
                    break;
                case 2:
                    for (int i = 0; i < DG_AddAccounts.Rows.Count; i++)
                    {
                        if (DG_AddAccounts.Rows[i].Cells[2].Value.ToString() != "₱ - Philippine Peso")
                        {
                            if (DG_AddAccounts.Rows[i].Cells[3].Value.ToString() != "")
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[3].Value}','')");

                            }
                            else
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[4].Value}')");

                            }
                        }
                        else
                        {
                            if (DG_AddAccounts.Rows[i].Cells[3].Value.ToString() != "")
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[3].Value}','','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','')");

                            }
                            else
                            {
                                Databased content = new Databased($"insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('{Lbl_CvNumber.Text} ','{DG_AddAccounts.Rows[i].Cells[0].Value} ','{DG_AddAccounts.Rows[i].Cells[1].Value} ','','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {DG_AddAccounts.Rows[i].Cells[4].Value}','{DG_AddAccounts.Rows[i].Cells[2].Value} ','{DG_AddAccounts.Rows[i].Cells[2].Value.ToString().Substring(0, 1)} {Lbl_TotalAmount.Text}','','')");

                            }
                        }
                    }
                 
                    chckVoucher.Info(Cmb_PayableName.Text, Txt_SuppCode.Text, Lbl_CvNumber.Text, Lbl_CheckNumber.Text, Txt_Particular.Text, Txt_Other.Text, Lbl_TotalAmount.Text,gunaDateTimePicker1.Text);
                    chckVoucher.AddContent(DG_AddAccounts, Cmb_Currency.Text.Substring(0, 1).ToString(), label1.Text,label2.Text) ;
                    crystalReportViewer1.ReportSource = chckVoucher.GenerateVoucher();
                    chckVoucher.SaveVoucher();

                    break;
                default:
                    break;
            }

        }














        private void Btn_AddAcctoGrid_Click(object sender, EventArgs e)
        {
            DG_AddAccounts.Rows.Add(Cmb_LoadAddAccounts.Text, Txt_AddAccCode.Text, Cmb_Currency.Text, Txt_AddDebit.Text, Txt_AddCredit.Text);


            Cmb_LoadAddAccounts.Text = "";
            Txt_AddAccCode.Text = "";
            Txt_AddCredit.Text = "";
            Txt_AddDebit.Text = "";
            Cmb_LoadAddAccounts.Focus();
        }



        private void DG_AddAccounts_Validating(object sender, CancelEventArgs e)
        {
       
           
                Lbl_TotalAmount.Text = (DG_AddAccounts.Rows.Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[5].Value).Equals(true))
                .Sum(t => Convert.ToDouble(t.Cells[4].Value))).ToString();
            Lbl_TotalAmount.Text = String.Format("{0:n}", double.Parse(Lbl_TotalAmount.Text));

        }

        private void Txt_AddDebit_Validated(object sender, EventArgs e)
        {
            try
            {
                Txt_AddDebit.Text = String.Format("{0:n}", double.Parse(Txt_AddDebit.Text));
            }
            catch (Exception ex) 
            { 
            }
        }

        private void Txt_AddCredit_Validated(object sender, EventArgs e)
        {
            try
            {
                Txt_AddCredit.Text = String.Format("{0:n}", double.Parse(Txt_AddCredit.Text));
            }
            catch (Exception ex)
            {
            }

        }

        private void gunaDateTimePicker1_Validated(object sender, EventArgs e)
        {
               genVouchNumber();
        }
        string[] year;
        public void genVouchNumber() 
        {
            Voucher voucher = new CheckVoucher();
            if (Cmb_VoucherTypeSelection.SelectedIndex == 0)
            {
            
                year = gunaDateTimePicker1.Text.ToString().Split('-').ToArray();
                noOfVoucher = Convert.ToInt32(voucher.GetCount("Petty Cash Voucher", year[0].ToString(), year[1]).ToString()) + 1;
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;

               
                Lbl_CvNumber.Text = $"KMPV-{ year[0].ToString()}-{year[1].ToString()}-{noOfVoucher.ToString("0000")}";
            }
            else if (Cmb_VoucherTypeSelection.SelectedIndex == 1)
            {
               
                year = gunaDateTimePicker1.Text.ToString().Split('-').ToArray();
                noOfVoucher = Convert.ToInt32(voucher.GetCount("Cash Voucher", year[0].ToString(), year[1]).ToString()) + 1;
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;
              
                Lbl_CvNumber.Text = $"KM-CA-{ year[0].ToString()}-{year[1].ToString()}-{noOfVoucher.ToString("0000")}";

            }
            else if (Cmb_VoucherTypeSelection.SelectedIndex == 2)
            {
                DateTime dt = new DateTime();
               
             
                year = gunaDateTimePicker1.Text.ToString().Split('-').ToArray();
                noOfVoucher = Convert.ToInt32(voucher.GetCount("Check Voucher",year[0].ToString(),year[1]).ToString()) + 1;
                Pnl_AddCheckVoucher.Dock = DockStyle.Fill;

                
                Lbl_CvNumber.Text = $"KM-{ year[0].ToString()}-{year[1].ToString()}-{noOfVoucher.ToString("0000")}";
            }


        }
       
    }
}