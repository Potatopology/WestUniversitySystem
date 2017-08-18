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
    public partial class FormSubjectInventory : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }

        ClassSection classSection = new ClassSection();

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public FormSubjectInventory()
        {
            InitializeComponent();
        }

        private void FormSubjectInventory_Load(object sender, EventArgs e)
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

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvClass.Rows[e.RowIndex];
                txtChosenSubj.Text = row.Cells["Subject"].Value.ToString();
                txtChosenSect.Text = row.Cells["Section"].Value.ToString();
            }
        }

        //---------------------------------CRUD Methods---------------------------------
        private void AssignValues()
        {
            classSection.Subject = cmbSubject.Text;
            classSection.Section = txtSection.Text;
            classSection.Size = Convert.ToInt32(txtSize.Text);
            classSection.Enrolled = Convert.ToInt32(txtEnrolled.Text);
            classSection.Available = classSection.Size - classSection.Enrolled;
            classSection.Status = cmbStatus.Text;
        }

        private void AssignValues(string subj, string sect)
        {
            classSection.Subject = subj;
            classSection.Section = sect;
            classSection.Size = Convert.ToInt32(txtSize.Text);
            classSection.Enrolled = Convert.ToInt32(txtEnrolled.Text);
            classSection.Available = classSection.Size - classSection.Enrolled;
            classSection.Status = cmbStatus.Text;
        }

        private void Insert()
        {
            AssignValues();
            classSection.Insert();
        }

        private void Edit(string subj, string sect)
        {
            AssignValues(subj, sect);
            classSection.Update();
        }

        private void LoadValues(string subj, string sect)
        {
            classSection.LoadValues(subj, sect);
        }

        private void Delete()
        {
            try
            {
                LoadValues(txtChosenSubj.Text, txtChosenSect.Text);
                classSection.Delete();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }
        //---------------------------------UI Methods---------------------------------
        private void SetComboValues()
        {
            cmbSubject.Items.Clear();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT Code FROM subjects;";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbSubject.Items.Add(reader.GetString(0));
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

        private void Startup()
        {
            lblName.Text = Nm;
            btnCreate.Visible = true;
            btnFinish.Visible = false;
            btnCancel.Visible = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            try
            {
                SetComboValues();
                cmbSubject.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmbStatus.SelectedIndex = 0;
            cmbSubject.Enabled = true;
            txtSection.Enabled = true;
            txtChosenSubj.Text = "";
            txtChosenSect.Text = "";
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            this.dgvClass.DataSource = null;
            this.dgvClass.Rows.Clear();

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
                dgvClass.DataSource = bSource;
                MyAdapter.Update(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetToForm()
        {
            cmbSubject.Text = classSection.Subject;
            txtSection.Text = classSection.Section;
            txtSize.Text = classSection.Size.ToString();
            txtEnrolled.Text = classSection.Enrolled.ToString();
            txtAvailable.Text = classSection.Available.ToString();
            cmbStatus.Text = classSection.Status;
        }

        private void ClearForms()
        {
            cmbSubject.SelectedIndex = 0;
            txtSection.Text = "";
            txtSize.Text = "";
            txtEnrolled.Text = "";
            txtAvailable.Text = "";
            cmbStatus.SelectedIndex = 0;

            txtChosenSubj.Text = "";
            txtChosenSect.Text = "";
        }

        private void ShowDeleteDialog()
        {
            if (txtChosenSubj.Text == "" || txtChosenSect.Text == "")
            {
                MessageBox.Show("Please select class from list.");
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
            if (txtChosenSubj.Text == "" || txtChosenSect.Text == "")
            {
                MessageBox.Show("Please select student from list.");
            }
            else
            {
                LoadValues(txtChosenSubj.Text, txtChosenSect.Text);
                SetToForm();
                btnCreate.Visible = false;
                btnFinish.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                cmbSubject.Enabled = false;
                txtSection.Enabled = false;
            }
        }

        private void Search(string param)
        {
            this.dgvClass.DataSource = null;
            this.dgvClass.Rows.Clear();

            string query = "SELECT * FROM enroldb.class WHERE Subject LIKE '%" + param + "%'"
                + " OR Section LIKE '%" + param + "%'"
                + " OR Status LIKE '%" + param + "%'"
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
                dgvClass.DataSource = bSource;
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
            if (txtSection.Text == "" || txtSize.Text == "" || txtEnrolled.Text == "")
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
            if (txtSection.Text == "" || txtSize.Text == "" || txtEnrolled.Text == "")
            {
                MessageBox.Show("Please fill-in all required information.");
            }
            else
            {
                Edit(txtChosenSubj.Text, txtChosenSect.Text);
                ClearForms();
                Startup();
            }
        }

    }
}
