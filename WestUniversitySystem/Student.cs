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
        private int level;
        private string status;
        private string course;
        private string major;
        private string lastName;
        private string firstName;
        private string middleName;
        private string address;
        private string sex;
        private DateTime bday;
        private string bplace;
        private string citizenship;
        private string religion;
        private string contact;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Student()
        {

        }

        public Student(string password, DateTime entryDate, int level, string status, string course, string major, string lastName, string firstName, string middleName, string address, string sex, DateTime bday, string bplace, string citizenship, string religion, string contact)
        {
            this.Sn = 0;
            this.Password = password;
            this.EntryDate = entryDate;
            this.Level = level;
            this.Status = status;
            this.Course = course;
            this.Major = major;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Address = address;
            this.Sex = sex;
            this.Bday = bday;
            this.Bplace = bplace;
            this.Citizenship = citizenship;
            this.Religion = religion;
            this.Contact = contact;
        }

        public Student(int sn, string password, DateTime entryDate, int level, string status, string course, string major, string lastName, string firstName, string middleName, string address, string sex, DateTime bday, string bplace, string citizenship, string religion, string contact)
        {
            this.Sn = sn;
            this.Password = password;
            this.EntryDate = entryDate;
            this.Level = level;
            this.Status = status;
            this.Course = course;
            this.Major = major;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.Address = address;
            this.Sex = sex;
            this.Bday = bday;
            this.Bplace = bplace;
            this.Citizenship = citizenship;
            this.Religion = religion;
            this.Contact = contact;
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

        public string Course
        {
            get
            {
                return course;
            }

            set
            {
                course = value;
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
            string query = "INSERT INTO student_info (Password, EntryDate, Level, Status,"
                + " CourseCode, Major, LastName, FirstName, MiddleName,"
                + " Address, Sex, BirthDate, BirthPlace, Citizenship, Religion, ContactNo)"
                + " VALUES"
                + " (@Password,@EntryDate,@Level,@Status,@CourseCode,"
                + " @Major,@LastName,@FirstName,@MiddleName,@Address,@Sex,"
                + " @BirthDate,@BirthPlace,@Citizenship,@Religion,@ContactNo)"
                + ");";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    //myCommand.Parameters.AddWithValue("@SN", this.Sn.ToString());
                    myCommand.Parameters.AddWithValue("@Password", this.Password.ToString());
                    myCommand.Parameters.AddWithValue("@EntryDate", this.EntryDate.ToString());
                    myCommand.Parameters.AddWithValue("@Level", this.Level.ToString());
                    myCommand.Parameters.AddWithValue("@Status", this.Status.ToString());
                    myCommand.Parameters.AddWithValue("@CourseCode", this.Course.ToString());
                    myCommand.Parameters.AddWithValue("@Major", this.Major.ToString());
                    myCommand.Parameters.AddWithValue("@LastName", this.LastName.ToString());
                    myCommand.Parameters.AddWithValue("@FirstName", this.FirstName.ToString());
                    myCommand.Parameters.AddWithValue("@MiddleName", this.MiddleName.ToString());
                    myCommand.Parameters.AddWithValue("@Address", this.Address.ToString());
                    myCommand.Parameters.AddWithValue("@Sex", this.Sex.ToString());
                    myCommand.Parameters.AddWithValue("@BirthDate", this.Bday.ToString());
                    myCommand.Parameters.AddWithValue("@BirthPlace", this.Bplace.ToString());
                    myCommand.Parameters.AddWithValue("@Citizenship", this.Citizenship.ToString());
                    myCommand.Parameters.AddWithValue("@Religion", this.Religion.ToString());
                    myCommand.Parameters.AddWithValue("@ContactNo", this.Contact.ToString());

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

        public override string ToString()
        {
            return "SN: " + this.Sn.ToString() + "\n"
                + "Password: " + this.Password.ToString() + "\n"
                + "EntryDate: " + this.EntryDate.ToString() + "\n"
                + "Level: " + this.Level.ToString() + "\n"
                + "Status: " + this.Status.ToString() + "\n"
                + "CourseCode: " + this.Course.ToString() + "\n"
                + "Major: " + this.Major.ToString() + "\n"
                + "LastName: " + this.LastName.ToString() + "\n"
                + "FirstName: " + this.FirstName.ToString() + "\n"
                + "MiddleName: " + this.MiddleName.ToString() + "\n"
                + "Address: " + this.Address.ToString() + "\n"
                + "Sex: " + this.Sex.ToString() + "\n"
                + "BirthDate: " + this.Bday.ToString() + "\n"
                + "BirthPlace: " + this.Bplace.ToString() + "\n"
                + "Citizenship: " + this.Citizenship.ToString() + "\n"
                + "Religion: " + this.Religion.ToString() + "\n"
                + "ContactNo: " + this.Contact.ToString();
        }

    }
}
