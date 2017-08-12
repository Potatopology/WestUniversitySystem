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

        Student student = new Student();

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
            insertValues();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void insertValues()
        {
            try
            {
                student.Password = Convert.ToString(txtPassword.Text);
                student.EntryDate = DateTime.Now;
                Debug.Print(student.EntryDate.ToString());
                student.Level = Convert.ToInt32(txtLevel.Text);
                student.Status = Convert.ToString(cmbStatus.Text);
                student.Course = Convert.ToString(txtCourse.Text);
                student.Major = Convert.ToString(txtMajor.Text);
                student.LastName = Convert.ToString(txtLast.Text);
                student.FirstName = Convert.ToString(txtFirst.Text);
                student.MiddleName = Convert.ToString(txtMiddle.Text);
                student.Address = Convert.ToString(txtAddress.Text);
                student.Sex = Convert.ToString(cmbSex.Text);
                student.Bday = Convert.ToDateTime(dtpBday.Text);
                Debug.Print(student.Bday.ToString());
                student.Bplace = Convert.ToString(txtBplace.Text);
                student.Citizenship = Convert.ToString(txtCitizen.Text);
                student.Religion = Convert.ToString(txtReligion.Text);
                student.Contact = Convert.ToString(txtContact.Text);
                student.Former = Convert.ToString(txtFormer.Text);
                student.Tertiary = Convert.ToString(txtTertiary.Text);
                student.Secondary = Convert.ToString(txtSecondary.Text);
                student.Prim = Convert.ToString(txtPrimary.Text);
                student.FormerYear = Convert.ToString(txtPrimaryYear.Text);
                student.TertiaryYear = Convert.ToString(txtTertiaryYear.Text);
                student.SecondaryYear = Convert.ToString(txtSecondaryYear.Text);
                student.PrimaryYear = Convert.ToString(txtPrimaryYear.Text);
                student.Nsat = Convert.ToInt32(chkNsat.Checked);
                student.Form137 = Convert.ToInt32(chk137.Checked);
                student.TransferCred = Convert.ToInt32(chkTransfer.Checked);
                student.Tor = Convert.ToInt32(chkTor.Checked);
                student.Gmc = Convert.ToInt32(chkGmc.Checked);
                student.BirthCert = Convert.ToInt32(chkBirth.Checked);
                student.DadName = Convert.ToString(txtDadName.Text);
                student.DadJob = Convert.ToString(txtDadJob.Text);
                student.DadNum = Convert.ToString(txtDadNum.Text);
                student.MomName = Convert.ToString(txtMomName.Text);
                student.MomJob = Convert.ToString(txtMomJob.Text);
                student.MomNum = Convert.ToString(txtMomNum.Text);
                student.GuarName = Convert.ToString(txtGuarName.Text);
                student.Relation = Convert.ToString(txtRelation.Text);
                student.GuarNum = Convert.ToString(txtGuarNum.Text);
                student.ParentAdd = Convert.ToString(txtParentAdd.Text);

                student.Insert();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }




    }
}
