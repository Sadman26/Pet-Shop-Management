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
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
            displaypets();
            getcustomer();
            displayTransiction();
           // insertBill();
           
          //  updateqty();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SADMAN\Documents\PetShopDb.mdf;Integrated Security=True;Connect Timeout=30");

        public void insertBill()
        {
            try
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into lolTbl (BDATE,CustName,ProductName,Amount) values (@BD,@CN,@PN,@AM)", Con);
                cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                cmd.Parameters.AddWithValue("@CN", custnametb.Text);
                cmd.Parameters.AddWithValue("@PN", ProNameTb.Text);
                cmd.Parameters.AddWithValue("@AM", grdtotal);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill Was Saved!");
                Con.Close();
                displayTransiction();
                //clear();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void displayTransiction()
        {
            Con.Open();
            string Query = "select * from lolTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            transactionDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void getcustomer()
        {
            Con.Open();
            string Query = "select CustName from CustomerTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            omgDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void updateqty()
        {
            try
            {
                int newqty = stock - Convert.ToInt32(QuantityTb.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("update ProductTbl set PrQty=@PQ where PrId = @PKey", Con);
                cmd.Parameters.AddWithValue("@PQ", newqty);
                
                cmd.Parameters.AddWithValue("@PKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product  Added!");
                Con.Close();
                displaypets();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);

            }
        }
        private void displaypets()
        {
            Con.Open();
            string Query = "select * from ProductTbl ";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PetsDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        int Key = 0,stock;
        int n = 0,grdtotal = 0;
        int petid, petprice,petqty,pettotal;

        private void deletebtn_Click(object sender, EventArgs e)
        {
            print.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                print.Print();
            }
            insertBill();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            homes obj = new homes();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            customers obj2 = new customers();
            obj2.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Login ok4 = new Login();
            ok4.Show();
            this.Hide();
        }

        private void omgDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            custnametb.Text = omgDGV.SelectedRows[0].Cells[0].Value.ToString();
        }

        string petname;
        int pos = 60;
        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("BD PET SHOP", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(80));
            e.Graphics.DrawString("ID NAME QUANTITY PRICE  TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26,40));
            foreach(DataGridViewRow row in hishabDGV.Rows)
            {
                petid = Convert.ToInt32(row.Cells["Column1"].Value);
                petname = "" + row.Cells["Column2"].Value;
                petprice = Convert.ToInt32(row.Cells["Column3"].Value);
                petqty= Convert.ToInt32(row.Cells["Column4"].Value);
                pettotal = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString(""+petid, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + petname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45,pos));
                e.Graphics.DrawString("" + petprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + petqty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + pettotal, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Total Bill: "+grdtotal+" Tk", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(50,pos+50));
            e.Graphics.DrawString("*****************WELCOME***********************", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(10,pos+85));

        }

        private void AddtoBill_Click(object sender, EventArgs e)
        {
            if(QuantityTb.Text=="" || Convert.ToInt32(QuantityTb.Text)>stock)
            {
                MessageBox.Show("Enter Correct Quantity");
            }
            else
            {
                int total = Convert.ToInt32(QuantityTb.Text) * Convert.ToInt32(priceTb.Text);
                DataGridViewRow newrow = new DataGridViewRow();
                newrow.CreateCells(hishabDGV);
                newrow.Cells[0].Value = n + 1;
                newrow.Cells[1].Value = ProNameTb.Text;
                newrow.Cells[2].Value = QuantityTb.Text;
                newrow.Cells[3].Value = priceTb.Text;
                newrow.Cells[4].Value = total;
                hishabDGV.Rows.Add(newrow);
                grdtotal = grdtotal + total;
                Tk.Text = grdtotal + "Tk";
                n++;
                updateqty();
            }
        }

        private void PetsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProNameTb.Text = PetsDGV.SelectedRows[0].Cells[1].Value.ToString();
            //ProCategorytb.Text = ProductDGV.SelectedRows[0].Cells[2].Value.ToString();
            stock = Convert.ToInt32(PetsDGV.SelectedRows[0].Cells[3].Value.ToString());
            priceTb.Text = PetsDGV.SelectedRows[0].Cells[4].Value.ToString();

            if (ProNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PetsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
