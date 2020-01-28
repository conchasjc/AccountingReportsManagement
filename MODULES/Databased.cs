using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
namespace AccountingReportsManagement
{
    class Databased
    {
        private string ConnectionName = "host=" + Properties.Settings.Default.dbSource.ToString() + "; username =" + Properties.Settings.Default.dbUser.ToString() + "; password=" + Properties.Settings.Default.dbPass.ToString() + "; database=" + Properties.Settings.Default.dbName.ToString() + "; character set=utf8;";
        private string address;
        private string name;
        private string username;
        private string password;
        MySqlConnection conn = new MySqlConnection();
        MySqlCommand Command;
        public DataSet queryTable = new DataSet();
       
        //DATABASE CONSTRUCTOR
        string Query;
        public Databased()
        {

        }
        public Databased(string query)
        {
            Query = query;
            conn.ConnectionString = ConnectionName;
            conn.Open();
            Command = new MySqlCommand(query, conn)
            {
                CommandTimeout = 0
            };
            Command.ExecuteNonQuery();
            conn.Close();
           
        }
        //END OF CONSTRUCTOR



        //DATABASE DATA SETTINGS METHODS

        public void ConnectionSettings(string Database_Address, string Database_Name, string Database_Username, string Database_password)
        {
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
        //END OF DATABASE REQUIREMENTS






        //DATABASE BACKUP & RESTORE

        public void Backup()
        {
            string constring =ConnectionName;
            string file = "C:\\ACCOUNTINGREPORTSBACKUP" + DateTime.Today.ToString("mm-dd-yyyy") + ".bak";
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

        public void Restore()
        {
            string constring = ConnectionName;
            string file = "C:\\ACCOUNTINGREPORTSBACKUP" + DateTime.Today.ToString("mm-dd-yyyy") + ".bak";
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


        //END OF DATABASE BACKUP & RESTORE





        //DATABASE CRUD OPERATION
        public object GetData()
        {
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(Command);
            sqlAdapter.Fill(queryTable);
            return queryTable.Tables[0];
        }

        public void AddData()
        {

        }



    }
}

