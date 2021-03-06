﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WestUniversitySystem
{
    class Family
    {
        private long studentSn;
        private string dadName;
        private string dadJob;
        private string dadNum;
        private string momName;
        private string momJob;
        private string momNum;
        private string guardName;
        private string relation;
        private string guardNum;
        private string parentAdd;

        static string connection = System.Configuration.ConfigurationManager.ConnectionStrings["Test"].ConnectionString;

        public Family() { }

        public Family(long studentSn, string dadName, string dadJob, string dadNum, string momName, string momJob, string momNum, string guardName, string relation, string guardNum, string parentAdd)
        {
            this.StudentSn = studentSn;
            this.DadName = dadName;
            this.DadJob = dadJob;
            this.DadNum = dadNum;
            this.MomName = momName;
            this.MomJob = momJob;
            this.MomNum = momNum;
            this.GuardName = guardName;
            this.Relation = relation;
            this.GuardNum = guardNum;
            this.ParentAdd = parentAdd;
        }

        public long StudentSn
        {
            get
            {
                return studentSn;
            }

            set
            {
                studentSn = value;
            }
        }

        public string DadName
        {
            get
            {
                return dadName;
            }

            set
            {
                dadName = value;
            }
        }

        public string DadJob
        {
            get
            {
                return dadJob;
            }

            set
            {
                dadJob = value;
            }
        }

        public string DadNum
        {
            get
            {
                return dadNum;
            }

            set
            {
                dadNum = value;
            }
        }

        public string MomName
        {
            get
            {
                return momName;
            }

            set
            {
                momName = value;
            }
        }

        public string MomJob
        {
            get
            {
                return momJob;
            }

            set
            {
                momJob = value;
            }
        }

        public string MomNum
        {
            get
            {
                return momNum;
            }

            set
            {
                momNum = value;
            }
        }

        public string GuardName
        {
            get
            {
                return guardName;
            }

            set
            {
                guardName = value;
            }
        }

        public string Relation
        {
            get
            {
                return relation;
            }

            set
            {
                relation = value;
            }
        }

        public string GuardNum
        {
            get
            {
                return guardNum;
            }

            set
            {
                guardNum = value;
            }
        }

        public string ParentAdd
        {
            get
            {
                return parentAdd;
            }

            set
            {
                parentAdd = value;
            }
        }

        public void Insert()
        {
            string query = "INSERT INTO `family_info` (`ID`, `StudentSN`, `DadName`, `DadJob`, `DadNum`, `MomName`, `MomJob`, `MomNum`, `GuardName`, `Relation`, `GuardNum`, `ParentAdd`) VALUES "
                + "(NULL, @StudentSn, @DadName, @DadJob, @DadNum, @MomName, @MomJob, @MomNum, @GuardName, @Relation, @GuardNum, @ParentAdd);";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@StudentSN", this.StudentSn.ToString());
                    myCommand.Parameters.AddWithValue("@DadName", this.DadName.ToString());
                    myCommand.Parameters.AddWithValue("@DadJob", this.DadJob.ToString());
                    myCommand.Parameters.AddWithValue("@DadNum", this.DadNum.ToString());
                    myCommand.Parameters.AddWithValue("@MomName", this.MomName.ToString());
                    myCommand.Parameters.AddWithValue("@MomJob", this.MomJob.ToString());
                    myCommand.Parameters.AddWithValue("@MomNum", this.MomNum.ToString());
                    myCommand.Parameters.AddWithValue("@GuardName", this.GuardName.ToString());
                    myCommand.Parameters.AddWithValue("@Relation", this.Relation.ToString());
                    myCommand.Parameters.AddWithValue("@GuardNum", this.GuardNum.ToString());
                    myCommand.Parameters.AddWithValue("@ParentAdd", this.ParentAdd.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    //MessageBox.Show("Family", "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void Update()
        {
            string query = "UPDATE `family_info` SET `DadName` = @DadName, `DadJob` = @DadJob, "
                + "`DadNum` = @DadNum, `MomName` = @MomName, `MomJob` = @MomJob, "
                + "`MomNum` = @MomNum, `GuardName` = @GuardName, `Relation` = @Relation, "
                + "`GuardNum` = @GuardNum, `ParentAdd` = @ParentAdd WHERE `family_info`.`StudentSN` = @StudentSN;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@StudentSN", this.StudentSn.ToString());
                    myCommand.Parameters.AddWithValue("@DadName", this.DadName.ToString());
                    myCommand.Parameters.AddWithValue("@DadJob", this.DadJob.ToString());
                    myCommand.Parameters.AddWithValue("@DadNum", this.DadNum.ToString());
                    myCommand.Parameters.AddWithValue("@MomName", this.MomName.ToString());
                    myCommand.Parameters.AddWithValue("@MomJob", this.MomJob.ToString());
                    myCommand.Parameters.AddWithValue("@MomNum", this.MomNum.ToString());
                    myCommand.Parameters.AddWithValue("@GuardName", this.GuardName.ToString());
                    myCommand.Parameters.AddWithValue("@Relation", this.Relation.ToString());
                    myCommand.Parameters.AddWithValue("@GuardNum", this.GuardNum.ToString());
                    myCommand.Parameters.AddWithValue("@ParentAdd", this.ParentAdd.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                    //MessageBox.Show("Educ Update\nSN:" + StudentSn.ToString(), "Successful");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void Delete()
        {
            string query = "DELETE FROM `family_info` WHERE `family_info`.`StudentSN` = @StudentSN;";

            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                using (MySqlCommand myCommand = new MySqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@StudentSN", this.StudentSn.ToString());

                    myCommand.CommandTimeout = 60;
                    myConn.Open();
                    int affectedRows = myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public void LoadValues(long studNum)
        {
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(connection))
                {
                    myConn.Open();
                    string query = "SELECT * FROM family_info WHERE StudentSN = " + studNum + ";";
                    using (MySqlCommand command = new MySqlCommand(query, myConn))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.StudentSn = reader.GetInt64(1);
                                this.DadName = reader.GetString(2);
                                this.DadJob = reader.GetString(3);
                                this.DadNum = reader.GetString(4);
                                this.MomName = reader.GetString(5);
                                this.MomJob = reader.GetString(6);
                                this.MomNum = reader.GetString(7);
                                this.GuardName = reader.GetString(8);
                                this.Relation = reader.GetString(9);
                                this.GuardNum = reader.GetString(10);
                                this.ParentAdd = reader.GetString(11);
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
    }
}
