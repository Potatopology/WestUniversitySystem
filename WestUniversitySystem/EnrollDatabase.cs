using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WestUniversitySystem
{
    class EnrollDatabase
    {
        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public static bool Login(string usercode, string password, string type)
        {
            MySqlConnection myConn = new MySqlConnection();
            MySqlDataReader myReader = null;
            bool isFound = false;
            try
            {
                myConn = new MySqlConnection(connection);
                MySqlCommand SelectCommand = new MySqlCommand();
                if (type == "student")
                {
                    SelectCommand = new MySqlCommand("Select * from enroldb.student_info where SN='" + usercode + "' And Password ='" + password + "';", myConn);
                }
                else if(type == "admin")
                {
                    SelectCommand = new MySqlCommand("Select * from enroldb.user where Username='" + usercode + "' And Password ='" + password + "';", myConn);
                }
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    isFound = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Close();
                myReader.Close();
            }
            return isFound;
        }

        //TODO: create name to replace username
        public static string GetName(string usercode, string password)
        {
            string name = "";
            MySqlConnection myConn = new MySqlConnection();
            MySqlDataReader myReader = null;
            try
            {
                myConn = new MySqlConnection(connection);
                MySqlCommand SelectCommand = new MySqlCommand("Select * from enroldb.user where Username='" + usercode + "' And Password ='" + password + "';", myConn);
                
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    name = usercode;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myConn.Close();
                myReader.Close();
            }
            return usercode;
        }

        private string LoadSubjects(string usercode)
        {
            string name = null;
            using (MySqlConnection myConn = new MySqlConnection(connection))
            {
                myConn.Open();
                string query = "SELECT name FROM user WHERE Username = '" + usercode + "';";
                using (MySqlCommand command = new MySqlCommand(query, myConn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(0);
                        }
                    }
                }
            }

            return name;
        }

    }
}
