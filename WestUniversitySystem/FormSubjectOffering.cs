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

        Subject subject = new Subject();

        public FormSubjectOffering()
        {
            InitializeComponent();
        }

        private void FormSubjectOffering_Load(object sender, EventArgs e)
        {
            Startup();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ValidateInsert();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ActivateEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ShowDeleteDialog();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            ValidateEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForms();
            Startup();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvSubjects.Rows[e.RowIndex];
                txtChosenCode.Text = row.Cells["CODE"].Value.ToString();
            }
        }

        //---------------------------------CRUD Methods---------------------------------
        private void AssignValues()
        {
            subject.Code = txtCode.Text;
            subject.Description = txtDescription.Text;
            subject.Units = Convert.ToInt32(txtUnits.Text);
            subject.Type = cmbType.Text;
            subject.Year = Convert.ToInt32(txtYear.Text);
        }

        private void AssignValues(string code)
        {
            subject.Code = code;
            subject.Description = txtDescription.Text;
            subject.Units = Convert.ToInt32(txtUnits.Text);
            subject.Type = cmbType.Text;
            subject.Year = Convert.ToInt32(txtYear.Text);
        }

        private void Insert()
        {
            AssignValues();
            subject.Insert();
        }

        private void Edit(string code)
        {
            AssignValues(code);
            subject.Update();
        }

        private void LoadValues(string code)
        {
            subject.LoadValues(code);
        }

        private void Delete()
        {
            try
            {
                LoadValues(txtChosenCode.Text);
                subject.Delete();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }

        //---------------------------------UI Methods---------------------------------
        private void Startup()
        {
            lblName.Text = Nm;
            btnCreate.Visible = true;
            btnFinish.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            cmbType.SelectedIndex = 0;
            txtCode.Enabled = true;
            txtChosenCode.Text = "";
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            this.dgvSubjects.DataSource = null;
            this.dgvSubjects.Rows.Clear();

            String query = "select * from enroldb.class;";
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

        private void SetToForm()
        {
            txtCode.Text = subject.Code;
            txtDescription.Text = subject.Description;
            txtUnits.Text = subject.Units.ToString();
            cmbType.Text = subject.Type;
            txtYear.Text = subject.Year.ToString();
        }

        private void ClearForms()
        {
            txtCode.Text = "";
            txtDescription.Text = "";
            txtUnits.Text = "";
            cmbType.SelectedIndex = 0;
            txtYear.Text = "";

            txtChosenCode.Text = "";
        }

        private void ShowDeleteDialog()
        {
            if (txtChosenCode.Text == "")
            {
                MessageBox.Show("Please select subject from list.");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("You are about to delete, confirm?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Delete();
                    Startup();
                }
            }
        }

        private void ActivateEdit()
        {
            if (txtChosenCode.Text == "")
            {
                MessageBox.Show("Please select subject from list.");
            }
            else
            {
                LoadValues(txtChosenCode.Text);
                SetToForm();
                btnCreate.Visible = false;
                btnFinish.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                txtCode.Enabled = false;
            }
        }

        private void Search(string param)
        {
            this.dgvSubjects.DataSource = null;
            this.dgvSubjects.Rows.Clear();

            string query = "SELECT * FROM enroldb.subject WHERE Code LIKE '%" + param + "%'"
                + " OR Description LIKE '%" + param + "%'"
                + " OR Units LIKE '%" + param + "%'"
                + " OR Type LIKE '%" + param + "%'"
                + " OR Year LIKE '%" + param + "%'"
                + ";";

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

        //---------------------------------Control Methods---------------------------------
        private void ValidateInsert()
        {
            if (txtCode.Text == "" || txtDescription.Text == "" || txtUnits.Text == "" || txtYear.Text == "")
            {
                MessageBox.Show("Please fill-in all required information.");
            }
            else
            {
                Insert();
                ClearForms();
                Startup();
            }
        }

        private void ValidateEdit()
        {
            if (txtCode.Text == "" || txtDescription.Text == "" || txtUnits.Text == "" || txtYear.Text == "")
            {
                MessageBox.Show("Please fill-in all required information.");
            }
            else
            {
                Edit(txtChosenCode.Text);
                ClearForms();
                Startup();
            }
        }

    }
}
