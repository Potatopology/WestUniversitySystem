using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;


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
        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        Student student = new Student();
        Education education = new Education();
        Requirement requirement = new Requirement();
        Family family = new Family();

        public FormStudentAccount()
        {
            InitializeComponent();
        }

        private void FormStudentAccount_Load(object sender, EventArgs e)
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

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvStudent.Rows[e.RowIndex];
                txtChosen.Text = row.Cells["SN"].Value.ToString();
            }
        }

        //---------------------------------CRUD Methods---------------------------------
        private void AssignValues()
        {
            long studentNum = Student.ValidateSN(2017);
            student.Sn = studentNum;
            student.Password = txtPassword.Text;
            student.EntryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            student.Level = Convert.ToInt32(txtLevel.Text);
            student.Status = cmbStatus.Text;
            student.Course = txtCourse.Text;
            student.Major = txtMajor.Text;
            student.LastName = txtLast.Text;
            student.FirstName = txtFirst.Text;
            student.MiddleName = txtMiddle.Text;
            student.Address = txtAddress.Text;
            student.Sex = cmbSex.Text;
            student.Bday = dtpBday.Text;
            student.Bplace = txtBplace.Text;
            student.Citizenship = txtCitizen.Text;
            student.Religion = txtReligion.Text;
            student.Contact = txtContact.Text;


            education.StudentSn = studentNum;
            education.FormerSchool = txtFormer.Text;
            education.FormerYears = txtFormerYear.Text;
            education.TertiaryEd = txtTertiary.Text;
            education.TertiaryYears = txtTertiaryYear.Text;
            education.SecondaryEd = txtSecondary.Text;
            education.SecondaryYears = txtSecondaryYear.Text;
            education.PrimaryEd = txtPrimary.Text;
            education.PrimaryYears = txtPrimaryYear.Text;

            requirement.StudentSn = studentNum;
            requirement.Nsat = Convert.ToInt16(chkNsat.Checked);
            requirement.Form137 = Convert.ToInt16(chk137.Checked);
            requirement.TransferCred = Convert.ToInt16(chkTransfer.Checked);
            requirement.Tor = Convert.ToInt16(chkTor.Checked);
            requirement.Gmc = Convert.ToInt16(chkGmc.Checked);
            requirement.BirthCert = Convert.ToInt16(chkBirth.Checked);

            family.StudentSn = studentNum;
            family.DadName = txtDadName.Text;
            family.DadJob = txtDadJob.Text;
            family.DadNum = txtDadNum.Text;
            family.MomName = txtMomName.Text;
            family.MomJob = txtMomJob.Text;
            family.MomNum = txtMomNum.Text;
            family.GuardName = txtGuarName.Text;
            family.Relation = txtRelation.Text;
            family.GuardNum = txtGuarNum.Text;
            family.ParentAdd = txtParentAdd.Text;
        }

        private void AssignValues(long studentNum)
        {
            student.Sn = studentNum;
            student.Password = txtPassword.Text;
            student.EntryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            student.Level = Convert.ToInt32(txtLevel.Text);
            student.Status = cmbStatus.Text;
            student.Course = txtCourse.Text;
            student.Major = txtMajor.Text;
            student.LastName = txtLast.Text;
            student.FirstName = txtFirst.Text;
            student.MiddleName = txtMiddle.Text;
            student.Address = txtAddress.Text;
            student.Sex = cmbSex.Text;
            student.Bday = dtpBday.Text;
            student.Bplace = txtBplace.Text;
            student.Citizenship = txtCitizen.Text;
            student.Religion = txtReligion.Text;
            student.Contact = txtContact.Text;


            education.StudentSn = studentNum;
            education.FormerSchool = txtFormer.Text;
            education.FormerYears = txtFormerYear.Text;
            education.TertiaryEd = txtTertiary.Text;
            education.TertiaryYears = txtTertiaryYear.Text;
            education.SecondaryEd = txtSecondary.Text;
            education.SecondaryYears = txtSecondaryYear.Text;
            education.PrimaryEd = txtPrimary.Text;
            education.PrimaryYears = txtPrimaryYear.Text;

            requirement.StudentSn = studentNum;
            requirement.Nsat = Convert.ToInt16(chkNsat.Checked);
            requirement.Form137 = Convert.ToInt16(chk137.Checked);
            requirement.TransferCred = Convert.ToInt16(chkTransfer.Checked);
            requirement.Tor = Convert.ToInt16(chkTor.Checked);
            requirement.Gmc = Convert.ToInt16(chkGmc.Checked);
            requirement.BirthCert = Convert.ToInt16(chkBirth.Checked);

            family.StudentSn = studentNum;
            family.DadName = txtDadName.Text;
            family.DadJob = txtDadJob.Text;
            family.DadNum = txtDadNum.Text;
            family.MomName = txtMomName.Text;
            family.MomJob = txtMomJob.Text;
            family.MomNum = txtMomNum.Text;
            family.GuardName = txtGuarName.Text;
            family.Relation = txtRelation.Text;
            family.GuardNum = txtGuarNum.Text;
            family.ParentAdd = txtParentAdd.Text;
        }

        private void Insert()
        {
            try
            {
                AssignValues();
                student.Insert();
                education.Insert();
                requirement.Insert();
                family.Insert();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }

        private void Edit(long sn)
        {
            try
            {
                AssignValues(sn);
                student.Update();
                education.Update();
                requirement.Update();
                family.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }

        }

        private void Delete()
        {
            try
            {
                LoadValues(Convert.ToInt64(txtChosen.Text));
                student.Delete();
                education.Delete();
                requirement.Delete();
                family.Delete();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }

        private void LoadValues(long sn)
        {
            student.LoadValues(sn);
            education.LoadValues(sn);
            requirement.LoadValues(sn);
            family.LoadValues(sn);
        }

        private void SetToForm()
        {
            txtFirst.Text = student.FirstName;
            txtMiddle.Text = student.MiddleName;
            txtLast.Text = student.LastName;
            txtLevel.Text = student.Level.ToString();
            cmbStatus.Text = student.Status;
            txtCourse.Text = student.Course;
            txtMajor.Text = student.Major;
            txtAddress.Text = student.Address;
            cmbSex.Text = student.Sex;
            dtpBday.Text = student.Bday;
            txtBplace.Text = student.Bplace;
            txtCitizen.Text = student.Citizenship;
            txtReligion.Text = student.Religion;
            txtContact.Text = student.Contact;
            txtPassword.Text = student.Password;

            txtFormer.Text = education.FormerSchool;
            txtFormerYear.Text = education.FormerYears;
            txtTertiary.Text = education.TertiaryEd;
            txtTertiaryYear.Text = education.TertiaryYears;
            txtSecondary.Text = education.SecondaryEd;
            txtSecondaryYear.Text = education.SecondaryYears;
            txtPrimary.Text = education.PrimaryEd;
            txtPrimaryYear.Text = education.PrimaryYears;

            chkNsat.Checked = Convert.ToBoolean(requirement.Nsat);
            chk137.Checked = Convert.ToBoolean(requirement.Form137);
            chkTransfer.Checked = Convert.ToBoolean(requirement.TransferCred);
            chkTor.Checked = Convert.ToBoolean(requirement.Tor);
            chkGmc.Checked = Convert.ToBoolean(requirement.Gmc);
            chkBirth.Checked = Convert.ToBoolean(requirement.BirthCert);

            txtDadName.Text = family.DadName;
            txtDadJob.Text = family.DadJob;
            txtDadNum.Text = family.DadNum;
            txtMomName.Text = family.MomName;
            txtMomJob.Text = family.MomJob;
            txtMomNum.Text = family.MomNum;
            txtGuarName.Text = family.GuardName;
            txtRelation.Text = family.Relation;
            txtGuarNum.Text = family.GuardNum;
            txtParentAdd.Text = family.ParentAdd;
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
            cmbStatus.SelectedIndex = 0;
            cmbSex.SelectedIndex = 0;
            txtChosen.Text = "";
            DisplayInGrid();
        }

        private void ClearForms()
        {
            txtFirst.Text = "";
            txtMiddle.Text = "";
            txtLast.Text = "";
            txtLevel.Text = "";
            cmbStatus.SelectedIndex = 0;
            txtCourse.Text = "";
            txtMajor.Text = "";
            txtAddress.Text = "";
            cmbSex.SelectedIndex = 0;
            dtpBday.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
            txtBplace.Text = "";
            txtCitizen.Text = "";
            txtReligion.Text = "";
            txtContact.Text = "";
            txtPassword.Text = "";

            txtFormer.Text = "";
            txtFormerYear.Text = "";
            txtTertiary.Text = "";
            txtTertiaryYear.Text = "";
            txtSecondary.Text = "";
            txtSecondaryYear.Text = "";
            txtPrimary.Text = "";
            txtPrimaryYear.Text = "";

            chkNsat.Checked = false;
            chk137.Checked = false;
            chkTransfer.Checked = false;
            chkTor.Checked = false;
            chkGmc.Checked = false;
            chkBirth.Checked = false;

            txtDadName.Text = "";
            txtDadJob.Text = "";
            txtDadNum.Text = "";
            txtMomName.Text = "";
            txtMomJob.Text = "";
            txtMomNum.Text = "";
            txtGuarName.Text = "";
            txtRelation.Text = "";
            txtGuarNum.Text = "";
            txtParentAdd.Text = "";

            txtChosen.Text = "";
        }

        private void DisplayInGrid()
        {
            this.dgvStudent.DataSource = null;
            this.dgvStudent.Rows.Clear();

            String query = "select * from enroldb.student_info;";
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
                dgvStudent.DataSource = bSource;
                MyAdapter.Update(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDeleteDialog()
        {
            if (txtChosen.Text == "")
            {
                MessageBox.Show("Please select student from list.");
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
            if (txtChosen.Text == "")
            {
                MessageBox.Show("Please select student from list.");
            }
            else
            {
                LoadValues(Convert.ToInt64(txtChosen.Text));
                SetToForm();
                btnCreate.Visible = false;
                btnFinish.Visible = true;
                btnCancel.Visible = true;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        //---------------------------------Control Methods---------------------------------
        private void ValidateInsert()
        {
            if (txtFirst.Text == "" || txtMiddle.Text == "" || txtLast.Text == "" || txtLevel.Text == ""
                || txtCourse.Text == "" || txtMajor.Text == "" || txtAddress.Text == "" || txtBplace.Text == ""
                || txtCitizen.Text == "" || txtReligion.Text == "" || txtContact.Text == "" || txtPassword.Text == ""
                || txtFormer.Text == "" || txtFormerYear.Text == "" || txtTertiary.Text == "" || txtTertiaryYear.Text == ""
                || txtSecondary.Text == "" || txtSecondaryYear.Text == "" || txtPrimary.Text == "" || txtPrimaryYear.Text == ""
                || txtDadName.Text == "" || txtDadJob.Text == "" || txtDadNum.Text == ""
                || txtMomName.Text == "" || txtMomJob.Text == "" || txtMomNum.Text == ""
                || txtGuarName.Text == "" || txtRelation.Text == "" || txtGuarNum.Text == ""|| txtParentAdd.Text == "")
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
            if (txtFirst.Text == "" || txtMiddle.Text == "" || txtLast.Text == "" || txtLevel.Text == ""
                || txtCourse.Text == "" || txtMajor.Text == "" || txtAddress.Text == "" || txtBplace.Text == ""
                || txtCitizen.Text == "" || txtReligion.Text == "" || txtContact.Text == "" || txtPassword.Text == ""
                || txtFormer.Text == "" || txtFormerYear.Text == "" || txtTertiary.Text == "" || txtTertiaryYear.Text == ""
                || txtSecondary.Text == "" || txtSecondaryYear.Text == "" || txtPrimary.Text == "" || txtPrimaryYear.Text == ""
                || txtDadName.Text == "" || txtDadJob.Text == "" || txtDadNum.Text == ""
                || txtMomName.Text == "" || txtMomJob.Text == "" || txtMomNum.Text == ""
                || txtGuarName.Text == "" || txtRelation.Text == "" || txtGuarNum.Text == "" || txtParentAdd.Text == "")
            {
                MessageBox.Show("Please fill-in all required information.");
            }
            else
            {
                Edit(Convert.ToInt64(txtChosen.Text));
                ClearForms();
                Startup();
            }
        }

        //TODO: Create an adjugate for validate
    }
}
