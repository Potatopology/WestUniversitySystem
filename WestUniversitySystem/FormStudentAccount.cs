using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WestUniversitySystem
{
    public partial class FormStudentAccount : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }

        public FormStudentAccount()
        {
            InitializeComponent();
        }

        private void FormStudentAccount_Load(object sender, EventArgs e)
        {
            lblName.Text = Nm;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }






    }
}
