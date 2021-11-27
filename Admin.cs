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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            displayAdmin();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void displayAdmin()
        {
            Con.Open();
            string Query = "select * from AdminTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AdminDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void clear()
        {
            AdNameTb.Text = "";
            AdPassTb.Text = "";
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (AdNameTb.Text == "" || AdPassTb.Text == "")
            {
                MessageBox.Show("Missing formation!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AdminTbl (AdName,AdPass) values (@AN,@AP)", Con);
                    cmd.Parameters.AddWithValue("@AN", AdNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", AdPassTb.Text);                 
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Admin Added!");
                    Con.Close();
                    displayAdmin();
                    clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        int Key = 0;
        private void Editbtn_Click(object sender, EventArgs e)
        {
            if (AdNameTb.Text == "" || AdPassTb.Text == "")
            {
                MessageBox.Show("Missing information!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update AdminTbl set AdName=@AN,AdPass=@AP where AdId=@AKey", Con);
                    cmd.Parameters.AddWithValue("@AN", AdNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", AdPassTb.Text);
                    cmd.Parameters.AddWithValue("@AKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin was Updated!");
                    Con.Close();
                    displayAdmin();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }

        private void AdminDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdNameTb.Text = AdminDGV.SelectedRows[0].Cells[1].Value.ToString();
            AdPassTb.Text = AdminDGV.SelectedRows[0].Cells[2].Value.ToString();  
            if (AdNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AdminDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an Admin!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from AdminTbl where AdId=@AKey", Con);
                    cmd.Parameters.AddWithValue("@AKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin was Deleted!!");
                    Con.Close();
                    displayAdmin();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }



            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            employees obj = new employees();
            obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login okk = new Login();
            okk.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            products obj2 = new products();
            obj2.Show();
            this.Hide();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            secret ok = new secret();
            ok.Show();
            this.Hide();
        }
    }
}
