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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label4_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            passTb.Text = "";
            RoleCb.SelectedIndex = -1;
            RoleCb.Text = "Role";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RoleCb.SelectedIndex ==-1)
            {
                MessageBox.Show("Select a Role!");
            }else if (RoleCb.SelectedIndex== 0)
            {
                if (UnameTb.Text == "" || passTb.Text == "")
                {
                    MessageBox.Show("Enter Both Admin Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AdminTbl where AdName='" + UnameTb.Text + "'and AdPass='" + passTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if(dt.Rows[0][0].ToString()=="1")
                    {
                        secret lol = new secret();
                        lol.Show();
                        this.Hide();
                    }
                   else
                    {
                        MessageBox.Show("Wrong Admin Name Or Password");
                        UnameTb.Text = "";
                        passTb.Text = "";
                    }
                    Con.Close();
                }

            }
            else
            {
                if (UnameTb.Text == "" || passTb.Text == "")
                {
                    MessageBox.Show("Enter Both Employee Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EmpName='" + UnameTb.Text + "'and EmpPass='" + passTb.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        homes obj = new homes();
                        obj.Show();
                        this.Hide();
                        Con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Employee Name Or Password");
                        UnameTb.Text = "";
                        passTb.Text = "";
                    }
                    Con.Close();
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
