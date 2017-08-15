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
    class Education
    {
        private string studentSn;
        private string formerSchool;
        private string formerYears;
        private string tertiaryEd;
        private string tertiaryYears;
        private string secondaryEd;
        private string secondaryYears;
        private string primaryEd;
        private string primaryYears;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Education()
        {

        }

        public Education(string studentSn, string formerSchool, string formerYears, string tertiaryEd, string tertiaryYears, string secondaryEd, string secondaryYears, string primaryEd, string primaryYears)
        {
            this.studentSn = studentSn;
            this.formerSchool = formerSchool;
            this.formerYears = formerYears;
            this.tertiaryEd = tertiaryEd;
            this.tertiaryYears = tertiaryYears;
            this.secondaryEd = secondaryEd;
            this.secondaryYears = secondaryYears;
            this.primaryEd = primaryEd;
            this.primaryYears = primaryYears;
        }

        public string StudentSn
        {
            get
            {
                return studentSn;
            }

            set
            {
                studentSn = value;
            }
        }

        public string FormerSchool
        {
            get
            {
                return formerSchool;
            }

            set
            {
                formerSchool = value;
            }
        }

        public string FormerYears
        {
            get
            {
                return formerYears;
            }

            set
            {
                formerYears = value;
            }
        }

        public string TertiaryEd
        {
            get
            {
                return tertiaryEd;
            }

            set
            {
                tertiaryEd = value;
            }
        }

        public string TertiaryYears
        {
            get
            {
                return tertiaryYears;
            }

            set
            {
                tertiaryYears = value;
            }
        }

        public string SecondaryEd
        {
            get
            {
                return secondaryEd;
            }

            set
            {
                secondaryEd = value;
            }
        }

        public string SecondaryYears
        {
            get
            {
                return secondaryYears;
            }

            set
            {
                secondaryYears = value;
            }
        }

        public string PrimaryEd
        {
            get
            {
                return primaryEd;
            }

            set
            {
                primaryEd = value;
            }
        }

        public string PrimaryYears
        {
            get
            {
                return primaryYears;
            }

            set
            {
                primaryYears = value;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO `educational_background` (`ID`, `StudentSN`, `FormerSchool`, `FormerYears`, `TertiaryEd`, `TertiaryYears`, `SecondaryEd`, `SecondaryYears`, `PrimaryEd`, `PrimaryYears`) VALUES "
                + " (NULL, @Student_SN, @FormerSchool, @FormerYears, @TertiaryEd, @TertiaryYears, @SecondaryEd, @SecondaryYears, @PrimaryEd, @PrimaryYears);";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Student_SN", this.StudentSn.ToString());
                    myCommand.Parameters.AddWithValue("@FormerSchool", this.FormerSchool.ToString());
                    myCommand.Parameters.AddWithValue("@FormerYears", this.FormerYears.ToString());
                    myCommand.Parameters.AddWithValue("@TertiaryEd", this.TertiaryEd.ToString());
                    myCommand.Parameters.AddWithValue("@TertiaryYears", this.TertiaryYears.ToString());
                    myCommand.Parameters.AddWithValue("@SecondaryEd", this.SecondaryEd.ToString());
                    myCommand.Parameters.AddWithValue("@SecondaryYears", this.SecondaryYears.ToString());
                    myCommand.Parameters.AddWithValue("@PrimaryEd", this.PrimaryEd.ToString());
                    myCommand.Parameters.AddWithValue("@PrimaryYears", this.PrimaryYears.ToString());
                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Student account registered", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }

    

}
