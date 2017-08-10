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
    public partial class FormLogin : Form
    {
        string connection;
        int ctr = 0;

        public FormLogin()
        {
            InitializeComponent();
            connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            string usercode = txtUser.Text;
            string password = txtPassword.Text;
            try
            {
                MySqlConnection myConn = new MySqlConnection(connection);

                MySqlCommand SelectCommand = new MySqlCommand("Select * from enroldb.user where Username='" + usercode + "' And Password ='" + password + "';", myConn);

                MySqlDataReader myReader;
                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;
                while (myReader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    MessageBox.Show("Logged In Successfully!", "Logged In");

                    //FormAdmin form = new FormAdmin();
                    //form.Passvalue = usercode;
                    //form.Show();
                    //this.Hide();
                }
                else if (usercode == "" && password == "")
                {
                    MessageBox.Show("No Input", "Incorrect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                }
                else
                {
                    ctr++;
                    MessageBox.Show("Unauthorized user! Attempts = " + ctr, "Incorrect",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                }
                if (ctr == 3)
                {
                    MessageBox.Show("You have exceeded 3 attempts", "Incorrect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
