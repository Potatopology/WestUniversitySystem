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
    public partial class FormSubjectOffering : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }
        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public FormSubjectOffering()
        {
            InitializeComponent();
        }

        private void FormSubjectOffering_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //form functions
        private void ClearInput()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            txtUnits.Text = "";
            cmbType.SelectedIndex = 0;
        }

        private void DisplayInGrid()
        {
            this.dgvSubjects.DataSource = null;
            this.dgvSubjects.Rows.Clear();
            
            String query = "select * from enroldb.subjects;";
            MySqlConnection conDB = new MySqlConnection(connection);
            MySqlCommand cmdDB = new MySqlCommand(query, conDB);

            try
            {
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = cmdDB;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dTable;
                dgvSubjects.DataSource = bSource;
                MyAdapter.Update(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ShowDeleteDialog()
        {
            DialogResult dialogResult = MessageBox.Show("You are about to delete, confirm?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Delete("subjects", txtCode.Text);
            }
        }

        //sql functions
        private void Insert(params string[] args) //format: table, code, description, units, type
        {
            string query = "INSERT INTO subjects (Code ,Description, Units, Type) VALUES (@Code, @Description, @Units, @Type)";

            using (MySqlConnection myCon = new MySqlConnection(connection))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Code", args[1]);
                myCommand.Parameters.AddWithValue("@Description", args[2]);
                myCommand.Parameters.AddWithValue("@Units", args[3]);
                myCommand.Parameters.AddWithValue("@Type", args[4]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Added to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());
            }
        }

        private void GetAndInsertValues(string code, string description, string units, string type)
        {
            if (code == "" || description == "" || units == "")
            {
                MessageBox.Show("Please Fill in all the requirements!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Insert("subjects", code, description, units, type);
                    ClearInput();
                    DisplayInGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //TODO: Int only validation for units
        }

        private void Update(params string[] args) //format: table, code, description, units, type
        {
            string query = "UPDATE subjects set Description = @Description, Units = @Units, Type = @Type where Code = @Code;";

            using (MySqlConnection myCon = new MySqlConnection(connection))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Code", args[1]);
                myCommand.Parameters.AddWithValue("@Description", args[2]);
                myCommand.Parameters.AddWithValue("@Units", args[3]);
                myCommand.Parameters.AddWithValue("@Type", args[4]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Updated to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());

                ClearInput();
                DisplayInGrid();
            }
        }

        private void Delete(params string[] args) //format: table, code
        {
            string query = "DELETE FROM  subjects WHERE Code = @Code;";
            using (MySqlConnection myCon = new MySqlConnection(connection))
            using (MySqlCommand myCommand = new MySqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@Code", args[1]);
                myCommand.CommandTimeout = 60;
                myCon.Open();
                int affectedRows = myCommand.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted to " + args[0] + " \nAffected Rows: " + affectedRows.ToString());

                ClearInput();
                DisplayInGrid();
            }
        }

        //method for validations
        public void OnlyNum(object sender, KeyPressEventArgs e, Boolean isDecimal)
        {
            //accepts decimal
            if (isDecimal)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > 0))
                {
                    e.Handled = true;
                }
            }
            //only accepts unsigned int
            else
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        
    }
}
