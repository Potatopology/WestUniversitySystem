using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WestUniversitySystem
{
    public partial class FormStudentEnroll : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }
        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        Fee fee = new Fee();

        public FormStudentEnroll()
        {
            InitializeComponent();
        }

        private void FormStudentEnroll_Load(object sender, EventArgs e)
        {
            fee.LoadValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnCompute_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }


        //-------------------------Methods-----------------------------
        private Dictionary<string, int> LoadSubjects(string type)
        {
            Dictionary<string, int> subjects = new Dictionary<string, int>();
            
            using (MySqlConnection myConn = new MySqlConnection(connection))
            {
                myConn.Open();
                string query = "SELECT code, units, description FROM subjects WHERE type = '" + type + "';";
                using (MySqlCommand command = new MySqlCommand(query, myConn))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(reader.GetString(0) + " - " + reader.GetString(2) + " (" + reader.GetString(1) + " units)", reader.GetInt32(1));
                        }
                    }
                }
            }

            return subjects;
        }

        private void PopulateChecklistBox(Dictionary<string, int> subjects, CheckedListBox checkListBox)
        {
            foreach (KeyValuePair<string, int> entry in subjects)
            {
                checkListBox.Items.Add(entry.Key);
            }
        }

        private void DisplayAdded()
        {
            txtAdded.Text = "";
            foreach (object itemChecked in chlMajor.CheckedItems)
            {
                txtAdded.Text += itemChecked.ToString() + "\n";
            }
            foreach (object itemChecked in chlMinor.CheckedItems)
            {
                txtAdded.Text += itemChecked.ToString() + "\n";
            }
            lblTotal.Text = "TOTAL NO. OF UNITS: " + (GetMajorUnits() + GetMinorUnits()).ToString();
        }

        private int GetMajorUnits()
        {
            Dictionary<string, int> majorSubjects = LoadSubjects("Major");
            int majorUnits = 0;

            foreach (object itemChecked in chlMajor.CheckedItems)
            {
                foreach (KeyValuePair<string, int> item in majorSubjects)
                {
                    if (itemChecked.ToString() == item.Key)
                    {
                        majorUnits += item.Value;
                    }
                }
            }
            return majorUnits;
        }

        private int GetMinorUnits()
        {
            Dictionary<string, int> minorSubjects = LoadSubjects("Minor");
            int minorUnits = 0;

            foreach (object itemChecked in chlMinor.CheckedItems)
            {
                foreach (KeyValuePair<string, int> item in minorSubjects)
                {
                    if (itemChecked.ToString() == item.Key)
                    {
                        minorUnits += item.Value;
                    }
                }
            }
            return minorUnits;
        }





        //-------------------------Fee Methods-----------------------------
        private double CalculateTuitionFee()
        {
            int majorSubs = GetMajorUnits();
            int minorSubs = GetMinorUnits();

            double majorFee = fee.TuitionMajor;
            double minorFee = fee.TuitionMinor;

            return majorSubs * majorFee + minorSubs * minorFee;
        }

        private double CalculateMiscFee()
        {
            double pay = 0;

            if (rdb1st.Checked)
            {
                pay = fee.Misc1st;
            }
            else if (rdb2nd.Checked)
            {
                pay = fee.Misc2nd;
            }
            else if (rdb3rd.Checked)
            {
                pay = fee.Misc3rd;
            }
            else if (rdb4th.Checked)
            {
                pay = fee.Misc4th;
            }

            return pay;
        }

        private double CalculateLabFee()
        {
            int majorSubs = GetMajorUnits();

            double labFee = fee.Lab;

            return majorSubs * labFee;
        }

        private double CalculateGradFee()
        {
            double pay = 0;

            if (rdb4th.Checked)
            {
                pay = fee.Graduation;
            }

            return pay;
        }

        private double CalculateDiscount()
        {
            double tuition = CalculateTuitionFee();
            double discount = 0;

            if (rdbCash.Checked)
            {
                discount = tuition * (fee.Discount * 0.01);
            }

            return discount;
        }

        private double CalculateGrossBill()
        {
            return CalculateTuitionFee() + CalculateMiscFee() + CalculateLabFee() + CalculateGradFee() - CalculateDiscount();
        }

        private void DisplaySummary()
        {
            txtSummary.Text = "TUITION FEE: " + CalculateTuitionFee().ToString() + "\n"
                + "MISCELLANEOUS FEE: " + CalculateMiscFee().ToString() + "\n"
                + "GRADUATION FEE: " + CalculateGradFee().ToString() + "\n"
                + "LABORATORY FEE: " + CalculateLabFee().ToString() + "\n"
                + "DISCOUNT: " + CalculateDiscount().ToString() + "\n"
                + "TOTAL PAYMENT: " + CalculateGrossBill().ToString();
        }
    }
}
