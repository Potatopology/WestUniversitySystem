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
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Enroll.Connect(txtUser.Text, txtPassword.Text))
            {
                MessageBox.Show("Logged In Successfully!", "Logged In");
            }
            else
            {
                MessageBox.Show("Unauthorized user!", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        





    }
}
