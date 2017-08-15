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
        Education education = new Education();

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
            InsertValues();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void InsertValues()
        {
            try
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
                
                student.Insert();

                education.StudentSn = studentNum;
                education.FormerSchool = txtFormer.Text;
                education.FormerYears = txtFormerYear.Text;
                education.TertiaryEd = txtTertiary.Text;
                education.TertiaryYears = txtTertiaryYear.Text;
                education.SecondaryEd = txtSecondary.Text;
                education.SecondaryYears = txtSecondaryYear.Text;
                education.PrimaryEd = txtPrimary.Text;
                education.PrimaryYears = txtPrimaryYear.Text;

                education.Insert();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Source);
            }
        }




    }
}
