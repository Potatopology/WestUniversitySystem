namespace WestUniversitySystem
{
    partial class FormStudentEnroll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudentEnroll));
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdded = new System.Windows.Forms.RichTextBox();
            this.chlMinor = new System.Windows.Forms.CheckedListBox();
            this.chlMajor = new System.Windows.Forms.CheckedListBox();
            this.txtSummary = new System.Windows.Forms.RichTextBox();
            this.grbPay = new System.Windows.Forms.GroupBox();
            this.rdbInstall = new System.Windows.Forms.RadioButton();
            this.rdbCash = new System.Windows.Forms.RadioButton();
            this.grbYear = new System.Windows.Forms.GroupBox();
            this.rdb4th = new System.Windows.Forms.RadioButton();
            this.rdb3rd = new System.Windows.Forms.RadioButton();
            this.rdb2nd = new System.Windows.Forms.RadioButton();
            this.rdb1st = new System.Windows.Forms.RadioButton();
            this.btnCompute = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grbPay.SuspendLayout();
            this.grbYear.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(362, 392);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 25);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add Subjects";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Minor Subjects";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Major Subjects";
            // 
            // txtAdded
            // 
            this.txtAdded.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtAdded.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdded.ForeColor = System.Drawing.Color.White;
            this.txtAdded.Location = new System.Drawing.Point(837, 88);
            this.txtAdded.Name = "txtAdded";
            this.txtAdded.Size = new System.Drawing.Size(350, 148);
            this.txtAdded.TabIndex = 20;
            this.txtAdded.Text = "";
            // 
            // chlMinor
            // 
            this.chlMinor.FormattingEnabled = true;
            this.chlMinor.Location = new System.Drawing.Point(415, 242);
            this.chlMinor.Name = "chlMinor";
            this.chlMinor.Size = new System.Drawing.Size(350, 137);
            this.chlMinor.TabIndex = 19;
            // 
            // chlMajor
            // 
            this.chlMajor.FormattingEnabled = true;
            this.chlMajor.Location = new System.Drawing.Point(59, 242);
            this.chlMajor.Name = "chlMajor";
            this.chlMajor.Size = new System.Drawing.Size(350, 137);
            this.chlMajor.TabIndex = 18;
            // 
            // txtSummary
            // 
            this.txtSummary.BackColor = System.Drawing.Color.RoyalBlue;
            this.txtSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSummary.ForeColor = System.Drawing.Color.White;
            this.txtSummary.Location = new System.Drawing.Point(837, 242);
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(350, 148);
            this.txtSummary.TabIndex = 17;
            this.txtSummary.Text = "";
            // 
            // grbPay
            // 
            this.grbPay.Controls.Add(this.rdbInstall);
            this.grbPay.Controls.Add(this.rdbCash);
            this.grbPay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPay.Location = new System.Drawing.Point(488, 115);
            this.grbPay.Name = "grbPay";
            this.grbPay.Size = new System.Drawing.Size(200, 75);
            this.grbPay.TabIndex = 16;
            this.grbPay.TabStop = false;
            this.grbPay.Text = "Mode of Payment";
            // 
            // rdbInstall
            // 
            this.rdbInstall.AutoSize = true;
            this.rdbInstall.Location = new System.Drawing.Point(94, 35);
            this.rdbInstall.Name = "rdbInstall";
            this.rdbInstall.Size = new System.Drawing.Size(84, 19);
            this.rdbInstall.TabIndex = 14;
            this.rdbInstall.Text = "Installment";
            this.rdbInstall.UseVisualStyleBackColor = true;
            // 
            // rdbCash
            // 
            this.rdbCash.AutoSize = true;
            this.rdbCash.Checked = true;
            this.rdbCash.Location = new System.Drawing.Point(25, 35);
            this.rdbCash.Name = "rdbCash";
            this.rdbCash.Size = new System.Drawing.Size(51, 19);
            this.rdbCash.TabIndex = 4;
            this.rdbCash.TabStop = true;
            this.rdbCash.Text = "Cash";
            this.rdbCash.UseVisualStyleBackColor = true;
            // 
            // grbYear
            // 
            this.grbYear.Controls.Add(this.rdb4th);
            this.grbYear.Controls.Add(this.rdb3rd);
            this.grbYear.Controls.Add(this.rdb2nd);
            this.grbYear.Controls.Add(this.rdb1st);
            this.grbYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbYear.Location = new System.Drawing.Point(137, 115);
            this.grbYear.Name = "grbYear";
            this.grbYear.Size = new System.Drawing.Size(325, 75);
            this.grbYear.TabIndex = 15;
            this.grbYear.TabStop = false;
            this.grbYear.Text = "Year Level";
            // 
            // rdb4th
            // 
            this.rdb4th.AutoSize = true;
            this.rdb4th.Location = new System.Drawing.Point(239, 35);
            this.rdb4th.Name = "rdb4th";
            this.rdb4th.Size = new System.Drawing.Size(67, 19);
            this.rdb4th.TabIndex = 3;
            this.rdb4th.Text = "4th Year";
            this.rdb4th.UseVisualStyleBackColor = true;
            // 
            // rdb3rd
            // 
            this.rdb3rd.AutoSize = true;
            this.rdb3rd.Location = new System.Drawing.Point(166, 35);
            this.rdb3rd.Name = "rdb3rd";
            this.rdb3rd.Size = new System.Drawing.Size(67, 19);
            this.rdb3rd.TabIndex = 2;
            this.rdb3rd.Text = "3rd Year";
            this.rdb3rd.UseVisualStyleBackColor = true;
            // 
            // rdb2nd
            // 
            this.rdb2nd.AutoSize = true;
            this.rdb2nd.Location = new System.Drawing.Point(90, 35);
            this.rdb2nd.Name = "rdb2nd";
            this.rdb2nd.Size = new System.Drawing.Size(70, 19);
            this.rdb2nd.TabIndex = 1;
            this.rdb2nd.Text = "2nd Year";
            this.rdb2nd.UseVisualStyleBackColor = true;
            // 
            // rdb1st
            // 
            this.rdb1st.AutoSize = true;
            this.rdb1st.Checked = true;
            this.rdb1st.Location = new System.Drawing.Point(19, 35);
            this.rdb1st.Name = "rdb1st";
            this.rdb1st.Size = new System.Drawing.Size(65, 19);
            this.rdb1st.TabIndex = 0;
            this.rdb1st.TabStop = true;
            this.rdb1st.Text = "1st Year";
            this.rdb1st.UseVisualStyleBackColor = true;
            // 
            // btnCompute
            // 
            this.btnCompute.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompute.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCompute.Enabled = false;
            this.btnCompute.FlatAppearance.BorderSize = 0;
            this.btnCompute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompute.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompute.ForeColor = System.Drawing.Color.White;
            this.btnCompute.Location = new System.Drawing.Point(905, 442);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(109, 25);
            this.btnCompute.TabIndex = 27;
            this.btnCompute.Text = "Compute";
            this.btnCompute.UseVisualStyleBackColor = false;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1026, 442);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(109, 26);
            this.btnReset.TabIndex = 26;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(958, 393);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 17);
            this.lblTotal.TabIndex = 25;
            this.lblTotal.Text = "TOTAL NO. OF UNITS:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 60);
            this.panel1.TabIndex = 29;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Open Sans Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(60, 19);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(69, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "<name>";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WestUniversitySystem.Properties.Resources.icons8_Contacts_64_white;
            this.pictureBox1.Location = new System.Drawing.Point(24, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::WestUniversitySystem.Properties.Resources.icons8_Exit_64_white;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Location = new System.Drawing.Point(1202, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(30, 30);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // FormStudentEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1244, 661);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCompute);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAdded);
            this.Controls.Add(this.chlMinor);
            this.Controls.Add(this.chlMajor);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.grbPay);
            this.Controls.Add(this.grbYear);
            this.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormStudentEnroll";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormStudentEnroll";
            this.Load += new System.EventHandler(this.FormStudentEnroll_Load);
            this.grbPay.ResumeLayout(false);
            this.grbPay.PerformLayout();
            this.grbYear.ResumeLayout(false);
            this.grbYear.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtAdded;
        private System.Windows.Forms.CheckedListBox chlMinor;
        private System.Windows.Forms.CheckedListBox chlMajor;
        private System.Windows.Forms.RichTextBox txtSummary;
        private System.Windows.Forms.GroupBox grbPay;
        private System.Windows.Forms.RadioButton rdbInstall;
        private System.Windows.Forms.RadioButton rdbCash;
        private System.Windows.Forms.GroupBox grbYear;
        private System.Windows.Forms.RadioButton rdb4th;
        private System.Windows.Forms.RadioButton rdb3rd;
        private System.Windows.Forms.RadioButton rdb2nd;
        private System.Windows.Forms.RadioButton rdb1st;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogout;
    }
}