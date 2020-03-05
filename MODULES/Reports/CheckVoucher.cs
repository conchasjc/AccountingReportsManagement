using AccountingReportsManagement.REPORTS;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingReportsManagement.MODULES.Reports
{

    class CheckVoucher : Voucher
    {
        CheckVouch checkVoucher = new CheckVouch();
        string words;
        string tDebit, tCredit,tAmountWords;
        
        public override void Info(string _payerName, string _payerCode, string _vouchNumber, string _checkNumber, string _particular, string _others, string _totalCreditAmount, string _date)
        {

            this.PayerName = _payerName;
            this.PayerCode = _payerCode;
            this.VoucherGeneratedNumber = _vouchNumber;
            this.CheckNumber = _checkNumber;
            this.Particulars = _particular;
            this.Others = _others;
            this.TotalCreditAmount = _totalCreditAmount;
            string[] dates = _date.ToString().Split('-').ToArray();
          
            this.SpecifiedDateVouch = _date;
        }
        public override void SaveVoucher()
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others,totalDebit,totalCredit,totalAmountWords) values('" +this.SpecifiedDateVouch + "','Check Voucher','" + this.CheckNumber + "','" + this.VoucherGeneratedNumber + "','" + this.PayerName + "','" + this.PayerCode + "','" + this.Particulars + "','" + this.Others + "','"+ tDebit.ToString() +"','"+tCredit.ToString()+"','"+ tAmountWords +"')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override void SaveContent()
        {
            Databased content = new Databased("insert into voucherpaymentinfos (VoucherGeneratedNumber,AccountTitle,Account_Code,Debit,Credit,Currency,AmountCredit,FDebit,FCredit) values('" + this.VoucherGeneratedNumber + "','" + this.AccountTitle + "','" + this.AccountCode + "','" + this.Debit + "','" + this.Credit + "','" + this.Currency + "','" + this.AmountCredit + "','" + this.FDebit + "','" + this.FCredit + "')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public override object GenerateVoucher()
        {
            


           
            TextObject payableName = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_PayableName"];
            TextObject supplierCode = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_RSupplierCode"];
            TextObject particular = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_RParticular"];
            TextObject checkNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_RCheckNo"];
            TextObject CVNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_RCVNo"];
            TextObject TCVNo = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_CVTop"];
            TextObject other = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_ROthers"];
            TextObject datess = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["PrintDate1"];
            payableName.Text = this.PayerName;
            supplierCode.Text = this.PayerCode;
            particular.Text = this.Particulars;
            checkNo.Text = this.CheckNumber;
            CVNo.Text = this.VoucherGeneratedNumber;
            TCVNo.Text = this.VoucherGeneratedNumber;
            other.Text = this.Others;
            string[] asdasd = this.SpecifiedDateVouch.ToString().Split('-').ToArray();
            string[] month = { "","January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            datess.Text = $"{month[int.Parse(asdasd[1].ToString())].ToString()} {asdasd[2].ToString()} ,{asdasd[0].ToString()}";
            return checkVoucher;
        }
        public string Indent(string value, int size)
        {
            var strArray = value.Split('\n');
            var sb = new StringBuilder();
            foreach (var s in strArray)
            sb.Append(new string(' ', size)).Append(s);
            return sb.ToString();
        }
        public override void AddContent(DataGridView table, string currencySymbol, string creditTotal, string debitTotal)
        {
            CreateVoucherDataSet cvds = new CreateVoucherDataSet();
            NumToWords convertNumber = new NumToWords();
            tDebit = $"{currencySymbol} {debitTotal}";
            tCredit = $"{currencySymbol} {creditTotal}";
            TextObject debit = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_Debit"];
            TextObject credit = (TextObject)checkVoucher.ReportDefinition.Sections["Section5"].ReportObjects["Txt_Credit"];
            TextObject amnt = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_Amount"];
            TextObject AmountWords = (TextObject)checkVoucher.ReportDefinition.Sections["Section2"].ReportObjects["Txt_AmountToWords"];
            
            debit.Text = $"{currencySymbol} {debitTotal}";
            credit.Text = $"{currencySymbol} {creditTotal}";
           
            string currencyShrt;


            if (currencySymbol.ToString() == "₱")
            {
               words = convertNumber.ConvertAmount(double.Parse(this.TotalCreditAmount), "Peso");
                currencyShrt = "₱";
            }
            else if (currencySymbol.ToString() == "$")
            {
               words = convertNumber.ConvertAmount(double.Parse(this.TotalCreditAmount), "Dollar");
                currencyShrt = "$";
            }
            else
            {
                words = convertNumber.ConvertAmount(double.Parse(this.TotalCreditAmount), "Yen");
                currencyShrt = "¥";
            }
          
            
            
            if (this.TotalCreditAmount != "0")
            {

                amnt.Text = $"{currencyShrt.ToString()} {this.TotalCreditAmount}";
                AmountWords.Text = words;
                tAmountWords = words;
            }
            else
            {
                amnt.Text = " ";
                AmountWords.Text = " ";
            }



            foreach (DataGridViewRow item in table.Rows)
            {
                if (item.Cells[3].Value == "")
                {
                    cvds.addVoucher.Rows.Add(Indent(item.Cells[0].Value.ToString(),10), "\t      " + item.Cells[1].Value, item.Cells[3].Value, $"{currencySymbol}  {item.Cells[4].Value}", "", "");
                }
                else
                {
                    cvds.addVoucher.Rows.Add(item.Cells[0].Value, item.Cells[1].Value, $"{currencySymbol} {item.Cells[3].Value}", item.Cells[4].Value, "", "");
                }
            }

            checkVoucher.SetDataSource(cvds);
        }
        public override string GetCount(string type,string year,string month)
        {
            Databased db = new Databased($"Select DateCreated from voucherpayee where DateCreated like '%{year}-{month}-%' and VoucherType='{type}'");
            db.GetData();
            return db.queryTable.Tables[0].Rows.Count.ToString("00");
        }
    }



}

