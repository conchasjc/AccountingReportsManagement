using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AccountingReportsManagement.MODULES
{
    class ChartofAccount : Databased
    {
        public BindingSource DataBind = new BindingSource();
        readonly BindingSource bd = new BindingSource();

        public object Load()
        {
            Databased dataQuery = new Databased("Select * from chartofaccountsentries");
            dataQuery.GetData();
            DataBind.DataSource = dataQuery.queryTable.Tables[0];
            return DataBind;

        }

        public object Load(int columnIndex)
        {
            if (columnIndex == 1)
            {
                Databased dataQuery = new Databased("Select Content_Code as Code, Content_Title as AccountName from accountcontent");
                dataQuery.GetData();
                DataBind.DataSource = dataQuery.queryTable.Tables[0];
            }

            return DataBind;
        }

        public object TextFilter(string textToFilter)
        {
            bd.DataSource = DataBind;
            bd.Filter = "convert([Code],'System.String') LIKE '" + textToFilter + "%' ";
            if (bd.Count == 0)
            {
                bd.Filter = "convert([AccountName],'System.String') LIKE '%" + textToFilter + "%' ";
            }

            return DataBind;
        }

        public void AddAccounts(string clientSubCategory, string clientCode, string clientTitle, string clientMainCategory)
        {
            Databased db = new Databased("insert into accountcontent(Content_Code,Content_Title, Account_Code,Account_MainCat) values ('" + clientCode + "','" + clientTitle + "','" + clientSubCategory + "','" + clientMainCategory + "')");
            MessageBox.Show("Account Added Succesfully", "Chart of Accounts", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateAccounts(string oldAccCode, string category, string subCategory, string accCode, string accName)
        {
            Databased db = new Databased("update accountcontent set Content_Code='" + accCode + "',Content_Title='" + accName + "',Account_MainCat='" + category + "',Account_Code='" + subCategory + "' where Content_Code='" + oldAccCode + "'");
            MessageBox.Show("Update Successful.", "Account Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public object CategoryPick(string Category)
        {
            Databased dataQuery = new Databased("Select Content_Code as Code, Content_Title as AccountName from accountcontent where Account_Code='" + Category + "'");
            dataQuery.GetData();
            DataBind.DataSource = dataQuery.queryTable.Tables[0];
            return DataBind;
        }
    }
}
