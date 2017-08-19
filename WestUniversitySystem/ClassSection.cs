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
    class ClassSection
    {
        private string subject;
        private string section;
        private int size;
        private int enrolled;
        private int available;
        private string status;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public ClassSection() { }

        public ClassSection(string subject, string section, int size, int enrolled, int available, string status)
        {
            this.Subject = subject;
            this.Section = section;
            this.Size = size;
            this.Enrolled = enrolled;
            this.Available = available;
            this.Status = status;
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public string Section
        {
            get
            {
                return section;
            }

            set
            {
                section = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public int Enrolled
        {
            get
            {
                return enrolled;
            }

            set
            {
                enrolled = value;
            }
        }

        public int Available
        {
            get
            {
                return available;
            }

            set
            {
                available = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO `class` (`ID`, `Subject`, `Section`, `Size`, `Enrolled`, `Available`, `Status`) VALUES (NULL, @Subject, @Section, @Size, @Enrolled, @Available, @Status);";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Subject", this.Subject.ToString());
                    myCommand.Parameters.AddWithValue("@Section", this.Section.ToString());
                    myCommand.Parameters.AddWithValue("@Size", this.Size.ToString());
                    myCommand.Parameters.AddWithValue("@Enrolled", this.Enrolled.ToString());
                    myCommand.Parameters.AddWithValue("@Available", (this.Size - this.Enrolled).ToString());

                    if(this.Status == "Dissolved")
                    {
                        myCommand.Parameters.AddWithValue("@Status", this.Status);
                    }
                    else if(this.Size - this.Enrolled <= 0)
                    {
                        myCommand.Parameters.AddWithValue("@Status", "Closed");
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Status", "Open");
                    }
                    

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Class Added", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void Update()
        {
            string query = "UPDATE `class` SET `Size`= @Size,`Enrolled`= @Enrolled,`Available`= @Available,`Status`= @Status WHERE `Subject`= @Subject AND `Section`= @Section;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Subject", this.Subject.ToString());
                    myCommand.Parameters.AddWithValue("@Section", this.Section.ToString());
                    myCommand.Parameters.AddWithValue("@Size", this.Size.ToString());
                    myCommand.Parameters.AddWithValue("@Enrolled", this.Enrolled.ToString());
                    myCommand.Parameters.AddWithValue("@Available", (this.Size - this.Enrolled).ToString());

                    if (this.Status == "Dissolved")
                    {
                        myCommand.Parameters.AddWithValue("@Status", this.Status);
                    }
                    else if (this.Size - this.Enrolled <= 0)
                    {
                        myCommand.Parameters.AddWithValue("@Status", "Closed");
                    }
                    else
                    {
                        myCommand.Parameters.AddWithValue("@Status", "Open");
                    }

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Class updated", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void Delete()
        {
            string query = "DELETE FROM `class` WHERE `Subject`= @Subject AND `Section`= @Section;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Subject", this.Subject.ToString());
                    myCommand.Parameters.AddWithValue("@Section", this.Section.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Class Deleted", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void LoadValues(string subj, string sect)
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT * FROM class WHERE `Subject`= '" + subj + "' AND `Section`= '" + sect + "';";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.Subject = reader.GetString(1);
                                this.Section = reader.GetString(2);
                                this.Size = reader.GetInt32(3);
                                this.Enrolled = reader.GetInt32(4);
                                this.Available = reader.GetInt32(5);
                                this.Status = reader.GetString(6);
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

        public void CountEnroll(string subj, string sect)
        {
            LoadValues(subj, sect);

            string query = "UPDATE `class` SET `Enrolled`= @Enrolled,`Available`= @Available WHERE `Subject`= '" + subj + "' AND `Section`= '" + sect + "';";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Enrolled", GetCount(subj, sect) + 1);
                    myCommand.Parameters.AddWithValue("@Available", (this.Size - (GetCount(subj, sect) + 1)).ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int GetCount(string subj, string sect)
        {
            string commandLine = "SELECT COUNT(*) FROM enrolled_class WHERE `Subject`= '" + subj + "' AND `Section`= '" + sect + "';";

            using (MySqlConnection connect = new MySqlConnection(connection))
            using (MySqlCommand cmd = new MySqlCommand(commandLine, connect))
            {
                connect.Open();
                MessageBox.Show(subj + " " + sect);
                MessageBox.Show(Convert.ToInt32(cmd.ExecuteScalar()).ToString());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


    }
}
