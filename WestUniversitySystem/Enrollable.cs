using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestUniversitySystem
{
    class Enrollable
    {
        private string subject;
        private string section;
        private string status;
        private int units;
        private string type;

        public Enrollable() { }

        public Enrollable(string subject, string section, string status, int units, string type)
        {
            this.Subject = subject;
            this.Section = section;
            this.Status = status;
            this.Units = units;
            this.Type = type;
        }

        public string Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public string Section
        {
            get
            {
                return section;
            }

            set
            {
                section = value;
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

        public int Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
