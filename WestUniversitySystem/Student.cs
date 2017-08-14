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
        private string former;
        private string tertiary;
        private string secondary;
        private string prim;
        private string formerYear;
        private string tertiaryYear;
        private string secondaryYear;
        private string primaryYear;
        private int nsat;
        private int form137;
        private int transferCred;
        private int tor;
        private int gmc;
        private int birthCert;
        private string dadName;
        private string dadJob;
        private string dadNum;
        private string momName;
        private string momJob;
        private string momNum;
        private string guarName;
        private string relation;
        private string guarNum;
        private string parentAdd;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Student() { }

        public Student(int sn, string password, DateTime entryDate, int level, string status, string course, string major, string lastName, string firstName, string middleName, string address, string sex, DateTime bday, string bplace, string citizenship, string religion, string contact, string former, string tertiary, string secondary, string prim, string formerYear, string tertiaryYear, string secondaryYear, string primaryYear, int nsat, int form137, int transferCred, int tor, int gmc, int birthCert, string dadName, string dadJob, string dadNum, string momName, string momJob, string momNum, string guarName, string relation, string guarNum, string parentAdd)
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
            this.Former = former;
            this.Tertiary = tertiary;
            this.Secondary = secondary;
            this.Prim = prim;
            this.FormerYear = formerYear;
            this.TertiaryYear = tertiaryYear;
            this.SecondaryYear = secondaryYear;
            this.PrimaryYear = primaryYear;
            this.Nsat = nsat;
            this.Form137 = form137;
            this.TransferCred = transferCred;
            this.Tor = tor;
            this.Gmc = gmc;
            this.BirthCert = birthCert;
            this.DadName = dadName;
            this.DadJob = dadJob;
            this.DadNum = dadNum;
            this.MomName = momName;
            this.MomJob = momJob;
            this.MomNum = momNum;
            this.GuarName = guarName;
            this.Relation = relation;
            this.GuarNum = guarNum;
            this.ParentAdd = parentAdd;
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

        public string Former
        {
            get
            {
                return former;
            }

            set
            {
                former = value;
            }
        }

        public string Tertiary
        {
            get
            {
                return tertiary;
            }

            set
            {
                tertiary = value;
            }
        }

        public string Secondary
        {
            get
            {
                return secondary;
            }

            set
            {
                secondary = value;
            }
        }

        public string Prim
        {
            get
            {
                return prim;
            }

            set
            {
                prim = value;
            }
        }

        public string FormerYear
        {
            get
            {
                return formerYear;
            }

            set
            {
                formerYear = value;
            }
        }

        public string TertiaryYear
        {
            get
            {
                return tertiaryYear;
            }

            set
            {
                tertiaryYear = value;
            }
        }

        public string SecondaryYear
        {
            get
            {
                return secondaryYear;
            }

            set
            {
                secondaryYear = value;
            }
        }

        public string PrimaryYear
        {
            get
            {
                return primaryYear;
            }

            set
            {
                primaryYear = value;
            }
        }

        public int Nsat
        {
            get
            {
                return nsat;
            }

            set
            {
                nsat = value;
            }
        }

        public int Form137
        {
            get
            {
                return form137;
            }

            set
            {
                form137 = value;
            }
        }

        public int TransferCred
        {
            get
            {
                return transferCred;
            }

            set
            {
                transferCred = value;
            }
        }

        public int Tor
        {
            get
            {
                return tor;
            }

            set
            {
                tor = value;
            }
        }

        public int Gmc
        {
            get
            {
                return gmc;
            }

            set
            {
                gmc = value;
            }
        }

        public int BirthCert
        {
            get
            {
                return birthCert;
            }

            set
            {
                birthCert = value;
            }
        }

        public string DadName
        {
            get
            {
                return dadName;
            }

            set
            {
                dadName = value;
            }
        }

        public string DadJob
        {
            get
            {
                return dadJob;
            }

            set
            {
                dadJob = value;
            }
        }

        public string DadNum
        {
            get
            {
                return dadNum;
            }

            set
            {
                dadNum = value;
            }
        }

        public string MomName
        {
            get
            {
                return momName;
            }

            set
            {
                momName = value;
            }
        }

        public string MomJob
        {
            get
            {
                return momJob;
            }

            set
            {
                momJob = value;
            }
        }

        public string MomNum
        {
            get
            {
                return momNum;
            }

            set
            {
                momNum = value;
            }
        }

        public string GuarName
        {
            get
            {
                return guarName;
            }

            set
            {
                guarName = value;
            }
        }

        public string Relation
        {
            get
            {
                return relation;
            }

            set
            {
                relation = value;
            }
        }

        public string GuarNum
        {
            get
            {
                return guarNum;
            }

            set
            {
                guarNum = value;
            }
        }

        public string ParentAdd
        {
            get
            {
                return parentAdd;
            }

            set
            {
                parentAdd = value;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO student_all (Password, EntryDate, Level, Status,"
                + " CourseCode, Major, LastName, FirstName, MiddleName,"
                + " Address, Sex, BirthDate, BirthPlace, Citizenship, Religion, ContactNo,"
                + " Former, Tertiary, Secondary, Prim, FormerYear, TertiaryYear, SecondaryYear, PrimaryYear,"
                + " Nsat, Form137, TransferCred, Tor, Gmc, BirthCert,"
                + " DadName, DadJob, DadNum, MomName, MomJob, MomNum,"
                + " GuarName, Relation, GuarNum, ParentAdd"
                + ")"
                + " VALUES"
                + " ('@Password','@EntryDate',@Level,@Status,'@CourseCode',"
                + " '@Major','@LastName','@FirstName','@MiddleName','@Address','@Sex',"
                + " '@BirthDate','@BirthPlace','@Citizenship','@Religion','@ContactNo'"
                + " '@Former', '@Tertiary', '@Secondary', '@Prim', '@FormerYear', '@TertiaryYear', '@SecondaryYear', '@PrimaryYear',"
                + " '@Nsat', '@Form137', '@TransferCred','@Tor', '@Gmc', '@BirthCert',"
                + " '@DadName', '@DadJob', '@DadNum', '@MomName', '@MomJob', '@MomNum',"
                + " '@GuarName', '@Relation', '@GuarNum', '@ParentAdd'"
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
                    myCommand.Parameters.AddWithValue("@Former", this.Former.ToString());
                    myCommand.Parameters.AddWithValue("@Tertiary", this.Tertiary.ToString());
                    myCommand.Parameters.AddWithValue("@Secondary", this.Secondary.ToString());
                    myCommand.Parameters.AddWithValue("@Prim", this.Prim.ToString());
                    myCommand.Parameters.AddWithValue("@FormerYear", this.FormerYear.ToString());
                    myCommand.Parameters.AddWithValue("@TertiaryYear", this.TertiaryYear.ToString());
                    myCommand.Parameters.AddWithValue("@SecondaryYear", this.SecondaryYear.ToString());
                    myCommand.Parameters.AddWithValue("@PrimaryYear", this.PrimaryYear.ToString());
                    myCommand.Parameters.AddWithValue("@Nsat", this.Nsat.ToString());
                    myCommand.Parameters.AddWithValue("@Form137", this.Form137.ToString());
                    myCommand.Parameters.AddWithValue("@TransferCred", this.TransferCred.ToString());
                    myCommand.Parameters.AddWithValue("@Tor", this.Tor.ToString());
                    myCommand.Parameters.AddWithValue("@Gmc", this.Gmc.ToString());
                    myCommand.Parameters.AddWithValue("@BirthCert", this.BirthCert.ToString());
                    myCommand.Parameters.AddWithValue("@DadName", this.DadName.ToString());
                    myCommand.Parameters.AddWithValue("@DadJob", this.DadJob.ToString());
                    myCommand.Parameters.AddWithValue("@DadNum", this.DadNum.ToString());
                    myCommand.Parameters.AddWithValue("@MomName", this.MomName.ToString());
                    myCommand.Parameters.AddWithValue("@MomJob", this.MomJob.ToString());
                    myCommand.Parameters.AddWithValue("@MomNum", this.MomNum.ToString());
                    myCommand.Parameters.AddWithValue("@GuarName", this.GuarName.ToString());
                    myCommand.Parameters.AddWithValue("@Relation", this.Relation.ToString());
                    myCommand.Parameters.AddWithValue("@GuarNum", this.GuarNum.ToString());
                    myCommand.Parameters.AddWithValue("@ParentAdd", this.ParentAdd.ToString());

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
