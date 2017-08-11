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
    public partial class FormAdmin : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            txtName.Text = Nm;
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            FormStudentAccount form = new FormStudentAccount();
            form.Show();
            this.Close();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            FormSubjectOffering form = new FormSubjectOffering();
            form.Show();
            this.Close();
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            FormFee form = new FormFee();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin form = new FormLogin();
            form.Show();
            this.Close();
        }
    }
}
