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

        public Student(int sn, string password, DateTime entryDate, int level, string status, string course, string major, string lastName, string firstName, string middleName, string address, string sex, DateTime bday, string bplace, string citizenship, string religion, string contact, string former, string tertiary, string secondary, string prim, string formerYear, string tertiaryYear, string secondaryYear, string primaryYear, int nsat, int form137, int transferCred, int tor, int gmc, int birthCert, string dadName, string dadJob, string dadNum, string momName, string momJob, string momNum, string guarName, string relation, string guarNum, string parentAdd)
        {
            this.sn = sn;
            this.password = password;
            this.entryDate = entryDate;
            this.level = level;
            this.status = status;
            this.course = course;
            this.major = major;
            this.lastName = lastName;
            this.firstName = firstName;
            this.middleName = middleName;
            this.address = address;
            this.sex = sex;
            this.bday = bday;
            this.bplace = bplace;
            this.citizenship = citizenship;
            this.religion = religion;
            this.contact = contact;
            this.former = former;
            this.tertiary = tertiary;
            this.secondary = secondary;
            this.prim = prim;
            this.formerYear = formerYear;
            this.tertiaryYear = tertiaryYear;
            this.secondaryYear = secondaryYear;
            this.primaryYear = primaryYear;
            this.nsat = nsat;
            this.form137 = form137;
            this.transferCred = transferCred;
            this.tor = tor;
            this.gmc = gmc;
            this.birthCert = birthCert;
            this.dadName = dadName;
            this.dadJob = dadJob;
            this.dadNum = dadNum;
            this.momName = momName;
            this.momJob = momJob;
            this.momNum = momNum;
            this.guarName = guarName;
            this.relation = relation;
            this.guarNum = guarNum;
            this.parentAdd = parentAdd;
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
            string query = "INSERT INTO student_info (Password, EntryDate, Level, Status,"
                + " CourseCode, Major, LastName, FirstName, MiddleName,"
                + " Address, Sex, BirthDate, BirthPlace, Citizenship, Religion, ContactNo,"
                + " Former, Tertiary, Secondary, Prim, FormerYear, TertiaryYear, SecondaryYear, PrimaryYear,"
                + " Nsat, Form137, TransferCred, Prim, Tor, Gmc, BirthCert,"
                + " DadName, DadJob, DadNum, MomName, MomJob, MomNum,"
                + " GuarName, Relation, GuarNum, ParentAdd"
                + ")"
                + " VALUES"
                + " (@Password,@EntryDate,@Level,@Status,@CourseCode,"
                + " @Major,@LastName,@FirstName,@MiddleName,@Address,@Sex,"
                + " @BirthDate,@BirthPlace,@Citizenship,@Religion,@ContactNo)"
                + " @Former, @Tertiary, @Secondary, @Prim, @FormerYear, @TertiaryYear, @SecondaryYear, @PrimaryYear,"
                + " @Nsat, @Form137, @TransferCred, @Prim, @Tor, @Gmc, @BirthCert,"
                + " @DadName, @DadJob, @DadNum, @MomName, @MomJob, @MomNum,"
                + " @GuarName, @Relation, @GuarNum, @ParentAdd"
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
                    myCommand.Parameters.AddWithValue("@Former", this.Sn.ToString());
                    myCommand.Parameters.AddWithValue("@Tertiary", this.Password.ToString());
                    myCommand.Parameters.AddWithValue("@Secondary", this.EntryDate.ToString());
                    myCommand.Parameters.AddWithValue("@Prim", this.Level.ToString());
                    myCommand.Parameters.AddWithValue("@FormerYear", this.Status.ToString());
                    myCommand.Parameters.AddWithValue("@TertiaryYear", this.Course.ToString());
                    myCommand.Parameters.AddWithValue("@SecondaryYear", this.Major.ToString());
                    myCommand.Parameters.AddWithValue("@PrimaryYear", this.LastName.ToString());
                    myCommand.Parameters.AddWithValue("@Nsat", this.FirstName.ToString());
                    myCommand.Parameters.AddWithValue("@Form137", this.MiddleName.ToString());
                    myCommand.Parameters.AddWithValue("@TransferCred", this.Address.ToString());
                    myCommand.Parameters.AddWithValue("@Tor", this.Sex.ToString());
                    myCommand.Parameters.AddWithValue("@Gmc", this.Bday.ToString());
                    myCommand.Parameters.AddWithValue("@BirthCert", this.Bplace.ToString());
                    myCommand.Parameters.AddWithValue("@DadName", this.Citizenship.ToString());
                    myCommand.Parameters.AddWithValue("@DadJob", this.Religion.ToString());
                    myCommand.Parameters.AddWithValue("@DadNum", this.Contact.ToString());
                    myCommand.Parameters.AddWithValue("@MomName", this.Citizenship.ToString());
                    myCommand.Parameters.AddWithValue("@MomJob", this.Religion.ToString());
                    myCommand.Parameters.AddWithValue("@MomNum", this.Contact.ToString());
                    myCommand.Parameters.AddWithValue("@GuarName", this.Citizenship.ToString());
                    myCommand.Parameters.AddWithValue("@Relation", this.Religion.ToString());
                    myCommand.Parameters.AddWithValue("@GuarNum", this.Contact.ToString());
                    myCommand.Parameters.AddWithValue("@ParentAdd", this.Contact.ToString());

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
