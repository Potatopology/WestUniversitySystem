﻿using System;
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
        public FormFee()
        {
            InitializeComponent();
        }

        private void FormFee_Load(object sender, EventArgs e)
        {
            Fee fee = new Fee();
            txtOrig.Text = fee.ToString();
        }
    }
}
