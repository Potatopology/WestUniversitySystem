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
    class Student
    {
        private int sn;
        private string password;
        private DateTime entryDate;
        private string firstName;
        private string middleName;
        private string lastName;
        private int level;
        private string status;
        private string major;
        private string address;
        private string sex;
        private DateTime bday;
        private string bplace;
        private string citizenship;
        private string religion;
        private string contact;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Student(int sn, string password, DateTime entryDate, string firstName, string middleName, string lastName, int level, string status, string major, string address, string sex, DateTime bday, string bplace, string citizenship, string religion, string contact)
        {
            this.sn = sn;
            this.password = password;
            this.entryDate = entryDate;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.level = level;
            this.status = status;
            this.major = major;
            this.address = address;
            this.sex = sex;
            this.bday = bday;
            this.bplace = bplace;
            this.citizenship = citizenship;
            this.religion = religion;
            this.contact = contact;
        }

        public int Sn
        {
            get
            {
                return sn;
            }

            set
            {
                sn = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public DateTime EntryDate
        {
            get
            {
                return entryDate;
            }

            set
            {
                entryDate = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
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

        public string Major
        {
            get
            {
                return major;
            }

            set
            {
                major = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public DateTime Bday
        {
            get
            {
                return bday;
            }

            set
            {
                bday = value;
            }
        }

        public string Bplace
        {
            get
            {
                return bplace;
            }

            set
            {
                bplace = value;
            }
        }

        public string Citizenship
        {
            get
            {
                return citizenship;
            }

            set
            {
                citizenship = value;
            }
        }

        public string Religion
        {
            get
            {
                return religion;
            }

            set
            {
                religion = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }

            set
            {
                contact = value;
            }
        }

        public void Insert()
        {
            string query = "UPDATE fees SET tuition_major = @Major, tuition_minor = @Minor, misc_1st = @Misc1,"
                + " misc_2nd = @Misc2, misc_3rd = @Misc3, misc_4th = @Misc4,"
                + " lab = @Lab, graduation = @Grad, discount = @Disc"
                + " where id = 1;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    //myCommand.Parameters.AddWithValue("@Major", this.TuitionMajor.ToString());
                    //myCommand.Parameters.AddWithValue("@Minor", this.TuitionMinor.ToString());
                    //myCommand.Parameters.AddWithValue("@Misc1", this.Misc1st.ToString());
                    //myCommand.Parameters.AddWithValue("@Misc2", this.Misc2nd.ToString());
                    //myCommand.Parameters.AddWithValue("@Misc3", this.Misc3rd.ToString());
                    //myCommand.Parameters.AddWithValue("@Misc4", this.Misc4th.ToString());
                    //myCommand.Parameters.AddWithValue("@Lab", this.Lab.ToString());
                    //myCommand.Parameters.AddWithValue("@Grad", this.Graduation.ToString());
                    //myCommand.Parameters.AddWithValue("@Disc", this.Discount.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Completed updating fees", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


    }
}
