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
    public partial class secret : Form
    {
        public secret()
        {
            InitializeComponent();
            countdogs();
            countBirds();
            countcats();
            countfishs();
            countrabbits();
            countfood();
            countpigeon();
            counthamster();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void counthamster()
        {
            string Cat = "Hamster";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            HamLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countpigeon()
        {
            string Cat = "Pigeon";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PigLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countfood()
        {
            string Cat = "Food";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FoodLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countrabbits()
        {
            string Cat = "Rabbit";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            RabbitLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countfishs()
        {
            string Cat = "Fish";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            FishLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countdogs()
        {
            string Cat = "Dog";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DogsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countcats()
        {
            string Cat = "Cat";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CatsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }
        private void countBirds()
        {
            string Cat = "Bird";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select  Sum(PrQty) from ProductTbl where PrCat='" + Cat + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BirdsLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            products obj = new products();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            employees obj2 = new employees();
            obj2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Admin obj3 = new Admin();
            obj3.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login ok4 = new Login();
            ok4.Show();
            this.Hide();
        }
    }
}
