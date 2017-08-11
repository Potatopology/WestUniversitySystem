using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

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













    }
}
