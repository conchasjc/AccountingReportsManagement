using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingReportsManagement.MODULES
{
    
    class CreateVoucherClass
    {
        public object viewVouchers()
        {
            Databased getList = new Databased("select DateCreated, VoucherGeneratedNumber ,VoucherType,ClientName from voucherpayee");
            return getList.GetData();
        
        }
        public object LoadClient()
        {
            Databased getInfo = new Databased("select entryCode,entryName from clientsupplierentries");
            return getInfo.GetData();
        }
        public object loadAccounts()
        {
            Databased getInfo = new Databased("select Content_Code,Content_Title from accountcontent");
            return getInfo.GetData();
        }

        public string getClient(string Name)
        {
            Database getInfo = new Database();
            getInfo.GetQuery("select entryCode from clientsupplierentries where entryName='" + Name + "'");
            return getInfo.queryTable.Rows[0][0].ToString();
        }
        public string getAccounts(string Name)
        {
            Database getInfo = new Database();
            getInfo.GetQuery("select Content_Code from accountcontent where Content_Title='" + Name + "'");
            return getInfo.queryTable.Rows[0][0].ToString();
        }

    

           
        public void addVoucher(string voucherType, string checkNumber,string voucherGeneratedNumber,string clientName,string clientCode,string particulars,string others)
        {
            Databased db = new Databased("insert into voucherpayee (DateCreated,VoucherType,CheckNumber,VoucherGeneratedNumber,ClientName,ClientCode,Particulars,Others) values('"+DateTime.Today +"','" + voucherType+"','" +checkNumber +"','" +voucherGeneratedNumber +"','" + clientName+"','" + clientCode+"','" +particulars +"','" +others +"')");
            MessageBox.Show("Voucher Added Succesfully", "Voucher Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      

        public string getVoucherCount()
        {
            Databased db = new Databased("Select DateCreated from voucherpayee where DateCreated='"+DateTime.Today.ToString("yyyy-MM-dd")+"'");
            db.GetData();
           return db.queryTable.Tables[0].Rows.Count.ToString("00");
           
        }

       
        
    }
}
