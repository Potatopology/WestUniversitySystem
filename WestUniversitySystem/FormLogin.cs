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
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        
        private void Login()
        {
            if (EnrollDatabase.Login(txtUser.Text, txtPassword.Text, cmbType.Text))
            {
                MessageBox.Show("Login successful!", "Logged In");
            }
            else
            {
                MessageBox.Show("Incorrect SN or password", "Unauthorized User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




    }
}
