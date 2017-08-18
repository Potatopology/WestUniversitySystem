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

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public ClassSection() { }

        public ClassSection(string subject, string section, int size, int enrolled, int available)
        {
            this.Subject = subject;
            this.Section = section;
            this.Size = size;
            this.Enrolled = enrolled;
            this.Available = available;
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

        public void Insert()
        {
            string query = "INSERT INTO `class` (`ID`, `Subject`, `Section`, `Size`, `Enrolled`, `Available`) VALUES (NULL, @Subject, @Section, @Size, @Enrolled, @Available);";

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

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Class registered", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void Update()
        {
            string query = "UPDATE `class` SET `Size`= @Size,`Enrolled`= @Enrolled,`Available`= @Available WHERE `Subject`= @Subject AND `Section`= @Section;";

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
                    MessageBox.Show("Student Info Deleted", "Successful");
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
                    string query = "SELECT * FROM student_info WHERE `Subject`= " + subj + " AND `Section`= " + sect + ";";
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
