using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AccountingReportsManagement.MODULES
{
    class ClientSupplier:Databased
    {
        public BindingSource dataBind = new BindingSource();



        public object Load()
        {
            Databased db = new Databased("Select * from clientsupplierentries");
            db.GetData();
            dataBind.DataSource = db.queryTable.Tables[0];
        
            return dataBind;
        }

        public object Load(int columnIndex)
        {
            if (columnIndex ==1)
            {
                Databased db = new Databased("Select entryCode as Code, entryName as Client_Name from clientsupplierentries");
                db.GetData();
                dataBind.DataSource = db.queryTable.Tables[0];
                
            }
            return dataBind;

        }



        public void AddClient(string clientCode,string clientName,string clientCategory,string clientTin,string clientAddress) {
           
            Databased db = new Databased("insert into clientsupplierentries (entryCode,entryName,entryCategory,entryTin,entryAddress) values('"+ clientCode +"','"+ clientName+"','" + clientCategory+ "','"+ clientTin +"','"+ clientAddress+"')");
            MessageBox.Show("Client Data Added Succesfully", "Client Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public object ComboBoxFilter(string textFilter)
        {
            
          
           dataBind.Filter = "convert([Code],'System.String') LIKE '" +textFilter + "%'";
            return dataBind;
        }
        BindingSource bd = new BindingSource();

        public object TextBoxFilter(string textFilter)
        {
            bd.DataSource = dataBind;

            bd.Filter = "convert([Code],'System.String') LIKE '" + textFilter + "%' ";
            if (bd.Count==0) {
                bd.Filter = "convert([Client_Name],'System.String') LIKE '%" + textFilter + "%' ";
            }

            return dataBind;
        }

    }
}
