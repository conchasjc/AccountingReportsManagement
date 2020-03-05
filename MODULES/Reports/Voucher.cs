using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingReportsManagement.REPORTS;
namespace AccountingReportsManagement.MODULES.Reports
{
    abstract class Voucher
    {

        //Voucher Information Properties
        protected string VoucherType { get; set; }
        protected string PayerName { get; set; }
        protected string PayerCode { get; set; }
        protected string VoucherGeneratedNumber { get; set; }
        protected string CheckNumber { get; set; }
        protected string Particulars { get; set; }
        protected string Others { get; set; }
        protected string TotalCreditAmount { get; set; }
        protected string TotalCredit { get; set; }
        protected string TotalDebit { get; set; }
        protected string SpecifiedDateVouch { get; set; }


        //Voucher Information Content
        protected string AccountTitle { get; set; }
        protected string AccountCode { get; set; }
        protected double Debit { get; set; }
        protected double Credit { get; set; }
        protected string Currency { get; set; }
        protected double AmountCredit { get; set; }
        protected double FDebit { get; set; }
        protected double FCredit { get; set; }



        public virtual void Info(string _payerName, string _payerCode, string _vouchNumber, string _checkNumber, string _particular, string _others, string _totalCreditAmount,string _date) { }
        public virtual object GenerateVoucher()
        {
            return 0;
            //this will process all of voucher content
        }
        public virtual void AddContent(DataGridView tableGrid, string currencySymbol, string creditTotal, string debitTota)
        {
            //this will use to add contents in voucher
        }
        public virtual string GetCount(string type,string year,string month)
        {
            return "";
        }
        public virtual void SaveVoucher()
        {


        }
        public virtual void SaveContent()
        {

        }
    }
}
