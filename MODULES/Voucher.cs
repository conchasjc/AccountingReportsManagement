using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingReportsManagement.REPORTS;
namespace AccountingReportsManagement.MODULES
{
    //Voucher Interface
    interface IVoucher
    {
        void PrintVoucher();
        void CreateVoucher();
        void SaveVoucher();
        void ViewVoucher();
    }


    public class Voucher : IVoucher
    {
        protected string PayerName { get; set; }
        protected string PayerCode { get; set; }
        protected string VoucherType { get; set; }
        protected string VoucherGeneratedNumber { get; set; }
        protected string CheckNumber { get; set; }
        protected string Particulars { get; set; }
        protected string Others { get; set; }
        public void PayerInformation(string _name,string _code,string _generatedNumber,string _checkNumber,string _particulars,string _others)
        {
            this.PayerName = _name;
            this.PayerCode = _code;
           
            this.VoucherGeneratedNumber = _generatedNumber;
            this.CheckNumber = _checkNumber;
            this.Particulars = _particulars;
            this.Others = _others;
        }
        public void CreateVoucher()
        {
           
        }
        public void PrintVoucher()
        {

        }
        public void ViewVoucher()
        {
            
        }
        public virtual void SaveVoucher()
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others) values('" + DateTime.Today + "','" + this.VoucherType + "','" + this.CheckNumber + "','" + this.VoucherGeneratedNumber + "','" + this.PayerName + "','" + this.PayerCode + "','" + this.Particulars + "','" + this.Others + "')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        

    }





    //Voucher Types (POLYMORPHISM)
    public class PettyCash : Voucher
    {
        public override void SaveVoucher()
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others) values('" + DateTime.Today + "','Petty Cash Voucher','" + this.CheckNumber + "','" + this.VoucherGeneratedNumber + "','" + this.PayerName + "','" + this.PayerCode + "','" + this.Particulars + "','" + this.Others + "')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class Check : Voucher
    {
        public override void SaveVoucher()
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others) values('" + DateTime.Today + "','Check Voucher','" + this.CheckNumber + "','" + this.VoucherGeneratedNumber + "','" + this.PayerName + "','" + this.PayerCode + "','" + this.Particulars + "','" + this.Others + "')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    public class Cash : Voucher
    {
        public override void SaveVoucher()
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others) values('" + DateTime.Today + "','Cash Voucher','" + this.CheckNumber + "','" + this.VoucherGeneratedNumber + "','" + this.PayerName + "','" + this.PayerCode + "','" + this.Particulars + "','" + this.Others + "')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }



}
