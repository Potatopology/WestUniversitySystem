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
        Requirement requirement = new Requirement();
        Family family = new Family();

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
            Insert();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }



        //---
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

        private void Edit()
        {
            try
            {
                AssignValues();
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
    }
}
