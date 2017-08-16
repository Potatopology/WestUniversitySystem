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
    class Requirement
    {
        private long studentSn;
        private int nsat;
        private int form137;
        private int transferCred;
        private int tor;
        private int gmc;
        private int birthCert;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Requirement() { }

        public Requirement(long studentSn, int nsat, int form137, int transferCred, int tor, int gmc, int birthCert)
        {
            this.StudentSn = studentSn;
            this.Nsat = nsat;
            this.Form137 = form137;
            this.TransferCred = transferCred;
            this.Tor = tor;
            this.Gmc = gmc;
            this.BirthCert = birthCert;
        }

        public long StudentSn
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

        public void Insert()
        {
            string query = "INSERT INTO `requirements` (`ID`, `StudentSN`, `NSAT`, `Form137`, `TransferCred`, `TOR`, `GMC`, `BirthCert`) VALUES "
                + "(NULL, @StudentSN, , @NSAT, @Form137, @TransferCred, @TOR, @GMC, @BirthCert);";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@StudentSN", this.StudentSn.ToString());
                    myCommand.Parameters.AddWithValue("@NSAT", this.Nsat.ToString());
                    myCommand.Parameters.AddWithValue("@Form137", this.Form137.ToString());
                    myCommand.Parameters.AddWithValue("@TransferCred", this.TransferCred.ToString());
                    myCommand.Parameters.AddWithValue("@TOR", this.Tor.ToString());
                    myCommand.Parameters.AddWithValue("@GMC", this.Gmc.ToString());
                    myCommand.Parameters.AddWithValue("@BirthCert", this.BirthCert.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Requirements", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
