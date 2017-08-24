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
    class Subject
    {
        private string code;
        private string description;
        private int units;
        private string type;
        private int year;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        
        public Subject() { }

        public Subject(string code, string description, int units, string type, int year)
        {
            this.Code = code;
            this.Description = description;
            this.Units = units;
            this.Type = type;
            this.Year = year;
        }

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO subjects (Code ,Description, Units, Type, Year) VALUES (@Code, @Description, @Units, @Type, @Year)";

            try
            {
                using (MySqlConnection myCon = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Code", this.Code);
                    myCommand.Parameters.AddWithValue("@Description", this.Description);
                    myCommand.Parameters.AddWithValue("@Units", this.Units);
                    myCommand.Parameters.AddWithValue("@Type", this.Type);
                    myCommand.Parameters.AddWithValue("@Year", this.Year);
                    myCommand.CommandTimeout = 60;
                    myCon.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Added subject.", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Update()
        {
            string query = "UPDATE subjects set Description = @Description, Units = @Units, Type = @Type, Year = @Year where Code = @Code;";

            try
            {
                using (MySqlConnection myCon = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Code", this.Code);
                    myCommand.Parameters.AddWithValue("@Description", this.Description);
                    myCommand.Parameters.AddWithValue("@Units", this.Units);
                    myCommand.Parameters.AddWithValue("@Type", this.Type);
                    myCommand.Parameters.AddWithValue("@Year", this.Year);
                    myCommand.CommandTimeout = 60;
                    myCon.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated subject", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Delete()
        {
            string query = "DELETE FROM subjects WHERE Code = @Code;";

            try
            {
                using (MySqlConnection myCon = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Code", this.Code);
                    myCommand.CommandTimeout = 60;
                    myCon.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted", "Deleted");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void LoadValues(string code)
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT * FROM subject WHERE `Code`= '" + code + "';";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.Code = reader.GetString(0);
                                this.Description = reader.GetString(1);
                                this.Units = reader.GetInt32(2);
                                this.Type = reader.GetString(3);
                                this.Year = reader.GetInt32(4);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
