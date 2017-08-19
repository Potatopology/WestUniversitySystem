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
using System.Diagnostics;

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
        List<Enrollable> enrollable = new List<Enrollable>();

        public FormStudentEnroll()
        {
            InitializeComponent();
        }

        private void FormStudentEnroll_Load(object sender, EventArgs e)
        {
            fee.LoadValues();
            PopulateChecklistBox(LoadSubjects("Major"), chlMajor);
            PopulateChecklistBox(LoadSubjects("Minor"), chlMinor);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DisplayAdded();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (CalculateTuitionFee() == 0)
            {
                MessageBox.Show("No subject selected.", "Warning");
                btnCompute.Enabled = false;
            }
            else
            {
                DisplaySummary();
                btnCompute.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rdb1st.Checked = true;
            rdbCash.Checked = true;

            foreach (int i in chlMajor.CheckedIndices)
            {
                chlMajor.SetItemCheckState(i, CheckState.Unchecked);
            }
            foreach (int i in chlMinor.CheckedIndices)
            {
                chlMinor.SetItemCheckState(i, CheckState.Unchecked);
            }

            txtAdded.Text = "";
            txtSummary.Text = "";
            btnCompute.Enabled = false;
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {



            txtAdded.Text = "";
            txtSummary.Text = "";
            btnCompute.Enabled = false;
        }


        //-------------------------Methods-----------------------------
        private List<Enrollable> LoadSubjects(string type)
        {
            enrollable = new List<Enrollable>();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT subject, section, status, units, type FROM class join subjects WHERE class.Subject = subjects.Code AND Type = '" + type + "' AND Status NOT IN ('Closed', 'Dissolved') ORDER BY Subject;";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                enrollable.Add(new Enrollable()
                                {
                                    Subject = reader.GetString(0),
                                    Section = reader.GetString(1),
                                    Status = reader.GetString(2),
                                    Units = reader.GetInt32(3),
                                    Type = reader.GetString(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            Debug.Print(enrollable.ToString());
            return enrollable;
        }

        private void PopulateChecklistBox(List<Enrollable> subjects, CheckedListBox checkListBox)
        {
            foreach (Enrollable entry in subjects)
            {
                Debug.Print(entry.ToString());
                checkListBox.Items.Add(entry.Subject + " " + entry.Section);
            }
        }

        private void DisplayAdded()
        {
            bool isDuplicate = false;
            string temp = "";

            foreach (object itemChecked in chlMajor.CheckedItems)
            {
                if(temp == itemChecked.ToString().Substring(0, 7))
                {
                    isDuplicate = true;
                }
                temp = itemChecked.ToString().Substring(0, 7);
            }

            if (isDuplicate)
            {
                MessageBox.Show("You have selected sections with the same subject.\nPlease remove them.");
            }
            else
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
                btnCompute.Enabled = true;
            }
        }

        private int GetMajorUnits()
        {
            List<Enrollable> majorSubjects = LoadSubjects("Major");
            int majorUnits = 0;

            foreach (object itemChecked in chlMajor.CheckedItems)
            {
                foreach (Enrollable item in majorSubjects)
                {
                    if (itemChecked.ToString() == (item.Subject + " " + item.Section))
                    {
                        majorUnits += item.Units;
                    }
                }
            }
            return majorUnits;
        }

        private int GetMinorUnits()
        {
            List<Enrollable> minorSubjects = LoadSubjects("Minor");
            int minorUnits = 0;

            foreach (object itemChecked in chlMinor.CheckedItems)
            {
                foreach (Enrollable item in minorSubjects)
                {
                    if (itemChecked.ToString() == (item.Subject + " " + item.Section))
                    {
                        minorUnits += item.Units;
                    }
                }
            }
            return minorUnits;
        }

        public void Enroll()
        {
            foreach (object itemChecked in chlMajor.CheckedItems)
            {
                string query = "INSERT INTO `enrolled_class` (`ID`, `SN`, `Subject`, `Section`) VALUES (NULL, @SN, @Subject, @Section);";

                try
                {
                    using (MySqlConnection myConn = new MySqlConnection(connection))
                    using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                    {
                        myCommand.Parameters.AddWithValue("@SN", Nm);
                        myCommand.Parameters.AddWithValue("@Subject", itemChecked.ToString().Substring(0, 7));
                        myCommand.Parameters.AddWithValue("@Section", itemChecked.ToString().Substring(8, 12));
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
            foreach (object itemChecked in chlMinor.CheckedItems)
            {
                string query = "INSERT INTO `enrolled_class` (`ID`, `SN`, `Subject`, `Section`) VALUES (NULL, @SN, @Subject, @Section);";

                try
                {
                    using (MySqlConnection myConn = new MySqlConnection(connection))
                    using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                    {
                        myCommand.Parameters.AddWithValue("@SN", Nm);
                        myCommand.Parameters.AddWithValue("@Subject", itemChecked.ToString().Substring(0, 7));
                        myCommand.Parameters.AddWithValue("@Section", itemChecked.ToString().Substring(8, 12));
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
