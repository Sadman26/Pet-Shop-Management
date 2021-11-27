using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace thursday
{
    public partial class employees : Form
    {
        public employees()
        {
            InitializeComponent();
            displayEmp();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void displayEmp()
        {
            Con.Open();
            string Query = "select * from EmployeeTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        private void clear()
        {
            EmpNameTb.Text = "";
            EmpAddTb.Text = "";
            EmpPhoneTb.Text = "";
            PasswordTb.Text = "";
        }
        int Key = 0;
        private void Savebtn_Click(object sender, EventArgs e)
        {
            if(EmpNameTb.Text==""||EmpAddTb.Text==""||EmpPhoneTb.Text==""||PasswordTb.Text=="")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl (EmpName,EmpAdd,EmpDOB,EmpPhone,EmpPass) values (@EN,@EA,@ED,@EP,@Epa)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Added!");
                    Con.Close();
                    displayEmp();
                    clear(); 

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }



            }

        }

        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            EmpNameTb.Text = EmployeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text= EmployeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Text= EmployeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text= EmployeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            PasswordTb.Text= EmployeesDGV.SelectedRows[0].Cells[5].Value.ToString();
            if(EmpNameTb.Text=="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(EmployeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || EmpAddTb.Text == "" || EmpPhoneTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing formation!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update EmployeeTbl set EmpName=@EN,EmpAdd=@EA,EmpDOB=@ED,EmpPhone=@EP,EmpPass=@Epa where EmpNum=@Ekey", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EPa", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Ekey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Updated!");
                    Con.Close();
                    displayEmp();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }

        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Select an Employee!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EmpNum=@EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted!!");
                    Con.Close();
                    displayEmp();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }



            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            secret ok = new secret();
            ok.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            products obj3 = new products();
            obj3.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           // customers obj4 = new customers();
            //obj4.Show();
            //this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login ok4 = new Login();
            ok4.Show();
            this.Hide();
              
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin obj5 = new Admin();
            obj5.Show();
            this.Hide();
        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
