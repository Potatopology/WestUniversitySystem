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
    class Fee
    {
        private double tuitionMajor;
        private double tuitionMinor;
        private double misc1st;
        private double misc2nd;
        private double misc3rd;
        private double misc4th;
        private double lab;
        private double graduation;
        private double discount;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Fee()
        {
            LoadValues();
        }

        public Fee(double tuitionMajor, double tuitionMinor, double misc1st, double misc2nd, double misc3rd, double misc4th, double lab, double graduation, double discount)
        {
            this.TuitionMajor = tuitionMajor;
            this.TuitionMinor = tuitionMinor;
            this.Misc1st = misc1st;
            this.Misc2nd = misc2nd;
            this.Misc3rd = misc3rd;
            this.Misc4th = misc4th;
            this.Lab = lab;
            this.Graduation = graduation;
            this.Discount = discount;
        }

        public double TuitionMajor
        {
            get
            {
                return tuitionMajor;
            }

            set
            {
                tuitionMajor = value;
            }
        }

        public double TuitionMinor
        {
            get
            {
                return tuitionMinor;
            }

            set
            {
                tuitionMinor = value;
            }
        }

        public double Misc1st
        {
            get
            {
                return misc1st;
            }

            set
            {
                misc1st = value;
            }
        }

        public double Misc2nd
        {
            get
            {
                return misc2nd;
            }

            set
            {
                misc2nd = value;
            }
        }

        public double Misc3rd
        {
            get
            {
                return misc3rd;
            }

            set
            {
                misc3rd = value;
            }
        }

        public double Misc4th
        {
            get
            {
                return misc4th;
            }

            set
            {
                misc4th = value;
            }
        }

        public double Lab
        {
            get
            {
                return lab;
            }

            set
            {
                lab = value;
            }
        }

        public double Graduation
        {
            get
            {
                return graduation;
            }

            set
            {
                graduation = value;
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        private void Update()
        {
            string query = "UPDATE Fee SET tuition_major = @Major, tuition_minor = @Minor, misc_1st = @Misc1,"
                + " misc_2nd = @Misc2, misc_3rd = @Misc3, misc_4th = @Misc4,"
                + " lab = @Lab, graduation = @Grad, discount = @Disc"
                + " where id = 1;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@Major", this.TuitionMajor.ToString());
                    myCommand.Parameters.AddWithValue("@Minor", this.TuitionMinor.ToString());
                    myCommand.Parameters.AddWithValue("@Misc1", this.Misc1st.ToString());
                    myCommand.Parameters.AddWithValue("@Misc2", this.Misc2nd.ToString());
                    myCommand.Parameters.AddWithValue("@Misc3", this.Misc3rd.ToString());
                    myCommand.Parameters.AddWithValue("@Misc4", this.Misc4th.ToString());
                    myCommand.Parameters.AddWithValue("@Lab", this.Lab.ToString());
                    myCommand.Parameters.AddWithValue("@Grad", this.Graduation.ToString());
                    myCommand.Parameters.AddWithValue("@Disc", this.Discount.ToString());
                    
                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    MessageBox.Show("Completed updating fees", "Successful");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        
        private void LoadValues()
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT * FROM fee WHERE id = 1;";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.TuitionMajor = reader.GetDouble(1);
                                this.TuitionMinor = reader.GetDouble(2);
                                this.Misc1st = reader.GetDouble(3);
                                this.Misc2nd = reader.GetDouble(4);
                                this.Misc3rd = reader.GetDouble(5);
                                this.Misc4th = reader.GetDouble(6);
                                this.Lab = reader.GetDouble(7);
                                this.Graduation = reader.GetDouble(8);
                                this.Discount = reader.GetDouble(9);
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
