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
    public partial class products : Form
    {
        public products()
        {
            InitializeComponent();
            displayproduct();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void displayproduct()
        {
            Con.Open();
            string Query = "select * from ProductTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void clear()
        {
            ProNameTb.Text = "";
            ProCategorytb.SelectedIndex = 0;
            QuantityTb.Text = "";
            priceTb.Text = "";

        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ProNameTb.Text == "" || ProCategorytb.SelectedIndex == -1 || QuantityTb.Text == "" || priceTb.Text == "")
            {
                MessageBox.Show("Missing formation!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ProductTbl (PrName,PrCat,PrQty,PrPrice) values (@PN,@PC,@PQ,@PP)", Con);
                    cmd.Parameters.AddWithValue("@PN", ProNameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", ProCategorytb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", QuantityTb.Text);
                    cmd.Parameters.AddWithValue("@PP", priceTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product  Added!");
                    Con.Close();
                    displayproduct();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }

            }
        }
        int Key = 0;
        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProNameTb.Text = ProductDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProCategorytb.Text = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            QuantityTb.Text = ProductDGV.SelectedRows[0].Cells[3].Value.ToString();
            priceTb.Text = ProductDGV.SelectedRows[0].Cells[4].Value.ToString();
       
            if (ProNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ProductDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select an Product!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from ProductTbl where PrId=@PKey", Con);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product was Deleted!!");
                    Con.Close();
                    displayproduct();
                    clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }



            }
        }
        private void editbtn_Click(object sender, EventArgs e)
        {
            if (ProNameTb.Text == "" || ProCategorytb.SelectedIndex == -1 || QuantityTb.Text == "" || priceTb.Text == "")
            {
                MessageBox.Show("Missing formation!");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update ProductTbl set PrName=@PN,PrCat=@PC,PrQty=@PQ,PrPrice=@PP where PrId = @PKey", Con);
                    cmd.Parameters.AddWithValue("@PN", ProNameTb.Text);
                    cmd.Parameters.AddWithValue("@PC", ProCategorytb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PQ", QuantityTb.Text);
                    cmd.Parameters.AddWithValue("@PP", priceTb.Text);
                    cmd.Parameters.AddWithValue("@PKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product  Edited!");
                    Con.Close();
                    displayproduct();
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            employees obj2 = new employees();
            obj2.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           // customers obj3 = new customers();
            //obj3.Show();
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
    }
}
