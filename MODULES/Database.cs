using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace AccountingReportsManagement
{
    class Database
    {
        //initialize variables
        private readonly string ConnectionName = "host=" + Properties.Settings.Default.dbSource.ToString() + "; username =" + Properties.Settings.Default.dbUser.ToString() + "; password=" + Properties.Settings.Default.dbPass.ToString() + "; database=" + Properties.Settings.Default.dbName.ToString() + "; character set=utf8;";
        private string address;
        private string name;
        private string username;
        private string password;
        public MySqlCommand Command;
        public  DataTable queryTable= new DataTable();
        public BindingSource dataBind = new BindingSource();


        //START OF DATABASE CONNECTION METHODS
        public void ConnectionSettings(string Database_Address, string Database_Name, string Database_Username, string Database_password) {
            address = Database_Address;
            name = Database_Name;
            username = Database_Username;
            password = Database_password;
        }
        public void SaveSettings()
        {
            Properties.Settings.Default.dbSource = address;
            Properties.Settings.Default.dbName = name;
            Properties.Settings.Default.dbUser = username;
            Properties.Settings.Default.dbPass = password;
            Properties.Settings.Default.Save();
        }
    
        public void TestConnect(string Database_Address, string Database_Name, string Database_Username, string Database_password)
        {
            MySqlConnection conn = new MySqlConnection("host=" + Database_Address + "; username =" + Database_Username + "; password=" + Database_password + "; database=" + Database_Name + "; character set=utf8;");
            conn.Open();
            conn.Close();
        }

        //END OF DATABASE CONNECTION METHODS


        //START OF IMPORTING AND EXPORTING DATABASE SETTINGS
        public void Restore() {
            string constring = "server=localhost;user=KMTI_ACCOUNTING;pwd=KmtiAccounting2019;database=kmtiworkstation;";
            string file = "C:\\backup" + DateTime.Today.ToString("mm-dd-yyyy") + ".bak";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;
                        conn.Open();
                        mb.ImportFromFile(file);

                        conn.Close();
                    }
                }
            }
        }
        public void Backup()
        {
            string constring = "server=localhost;user=KMTI_ACCOUNTING;pwd=KmtiAccounting2019;database=kmtiworkstation;";
            string file = "C:\\backup" + DateTime.Today.ToString("mm-dd-yyyy") + ".bak";
            using (MySqlConnection conn = new MySqlConnection(constring))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        cmd.CommandTimeout = 0;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }
        //END OF IMPORTING AND EXPORTING DATABASE SETTINGS



        //START OF DATABASE CRUD METHODS
        public void AddChartAccount(string code,string title,string category)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionName);
            conn.Open();
            Command = new MySqlCommand("Insert into chartofaccountsentries (OrigAccountCode,NewAccountCode,AccountTitle,Category_Code) values('"+code+"','"+code+"B','"+title+"','"+category+"')", conn);
            Command.CommandTimeout = 0;
            Command.ExecuteNonQuery();
            conn.Close();
        }
        //END OF DATABASE CRUD METHODS
        public void GetQuery(String query)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionName);
            conn.Open();
            Command = new MySqlCommand(query, conn);
            Command.CommandTimeout = 0;
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(Command);
            sqlAdapter.Fill(queryTable);
            dataBind.DataSource = queryTable;
            conn.Close();
        }
      



    }
}
