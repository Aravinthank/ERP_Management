using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Paaku_Management
{
    class DBConnection
    {
        public MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public DBConnection()
        {
            Initialize();
        }
        public void Initialize()
        {
            server = "localhost";
            database = "vikram_industries";
            uid = "root";
            password = "bavithran@14";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        public MySqlDataAdapter selectadapter(string query)
        {
            MySqlDataAdapter data = new MySqlDataAdapter(query, connection);
            connection.Close();
            return data;
        }
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }

        }
        public void insertOrUpdate(string query)
        {
            // query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }

            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //Execute command
            cmd.ExecuteNonQuery();

            //close connection
            // this.CloseConnection();

        }
        public DataTable select(String selectQuery)
        {
            DataTable data = new DataTable();
            try
            {
                //open connection
                if (connection.State != System.Data.ConnectionState.Open) { connection.Open(); }
                MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection);

                adapter.Fill(data);
                foreach (DataRow row in data.Rows)
                {
                    //Console.WriteLine(row["COLUMN_NAME"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return data;
        }
    }
}
