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
    public partial class FormFee : Form
    {
        private string Nm = "";
        public string Passvalue
        {
            get { return Nm; }
            set { Nm = value; }
        }

        Fee fee = null;

        public FormFee()
        {
            InitializeComponent();
        }

        private void FormFee_Load(object sender, EventArgs e)
        {
            lblName.Text = Nm;
            fee = new Fee();
            txtOrig.Text = "Original Values\n" + fee.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFees();
            txtOrig.Text = "Original Values\n" + fee.ToString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormAdmin form = new FormAdmin();
            form.Passvalue = Nm;
            form.Show();
            this.Close();
        }

        private void UpdateFees()
        {
            try
            {
                fee.TuitionMajor = Convert.ToDouble(txtMajor.Text);
                fee.TuitionMinor = Convert.ToDouble(txtMinor.Text);
                fee.Misc1st = Convert.ToDouble(txt1st.Text);
                fee.Misc2nd = Convert.ToDouble(txt2nd.Text);
                fee.Misc3rd = Convert.ToDouble(txt3rd.Text);
                fee.Misc4th = Convert.ToDouble(txt4th.Text);
                fee.Lab = Convert.ToDouble(txtLab.Text);
                fee.Graduation = Convert.ToDouble(txtGrad.Text);
                fee.Discount = Convert.ToDouble(txtDisc.Text);
                fee.Update();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        
    }
}
