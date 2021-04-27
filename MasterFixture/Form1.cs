using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Security.Principal;

namespace MasterFixture
{
    public partial class Form1 : Form
    {
       // OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=fixtureDB.mdb");
        public Form1()
        {
            InitializeComponent();
           



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fixtureDBDataSet3.Fixture' table. You can move, or remove it, as needed.
            this.fixtureTableAdapter.Fill(this.fixtureDBDataSet3.Fixture);
            // TODO: This line of code loads data into the 'fixtureDBDataSet2.personal' table. You can move, or remove it, as needed.
            this.personalTableAdapter1.Fill(this.fixtureDBDataSet2.personal);
            // TODO: This line of code loads data into the 'fixtureDBproducts.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.fixtureDBproducts.product);
            // TODO: This line of code loads data into the 'fixtureDBDataSet1.place' table. You can move, or remove it, as needed.
            this.placeTableAdapter.Fill(this.fixtureDBDataSet1.place);
            // TODO: This line of code loads data into the 'fixtureDBpersonalName.personal' table. You can move, or remove it, as needed.
            this.personalTableAdapter.Fill(this.fixtureDBpersonalName.personal);
            // TODO: This line of code loads data into the 'fixtureDBDataSet.place' table. You can move, or remove it, as needed.
            this.placeTableAdapter.Fill(this.fixtureDBDataSet.place);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_placeNo.Text=="") {
                MessageBox.Show("Enter place No");
            }
            else {
                connection.con.Open();
                string save = "Insert into place(placeNo, placeName)VALUES(" + txt_placeNo.Text + ", '" + txt_placeName.Text + "')";
                OleDbCommand command = new OleDbCommand(save, connection.con);
                command.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");

                string listFixture = "SELECT * FROM place ORDER BY ID DESC";
                OleDbCommand command66 = new OleDbCommand(listFixture, connection.con);
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = command66;
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                connection.con.Close();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string listFixture = "SELECT * FROM place ORDER BY ID DESC";
            OleDbCommand command66 = new OleDbCommand(listFixture, connection.con);
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command66;
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txt_personal_name.Text=="") {
                MessageBox.Show("Enter personal Name");
            } else 
            {

                String nowDate = DateTime.Now.ToString("MM/dd/yyyy");
                connection.con.Open();
                string save = "Insert into personal(name, surname,place_2,title,register_date)VALUES('" + txt_personal_name.Text + "', '" + txt_personal_surname.Text + "', '" + txt_personal_place.Text + "', '" + txt_personal_title.Text + "', " + nowDate + " )";
                OleDbCommand command1 = new OleDbCommand(save, connection.con);
                command1.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");
                connection.con.Close();

                string listFixture = "SELECT * FROM personal ORDER BY ID DESC";
                OleDbCommand command55 = new OleDbCommand(listFixture, connection.con);
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = command55;
                dt.Clear();
                da.Fill(dt);
                dataGridView2.DataSource = dt;

            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txt_productName.Text=="") 
            {
                MessageBox.Show("Enter product name");
            } 
            else 
            {
                String nowDate = DateTime.Now.ToString("MM/dd/yyyy");
                connection.con.Open();
                string save = "Insert into product(productName, productId,productQuantity,productRegisterDate)VALUES('" + txt_productName.Text + "', '" + txt_productId.Text + "', '" + txt_productQuantity.Text + "',  " + nowDate + " )";
                OleDbCommand command2 = new OleDbCommand(save, connection.con);
                command2.ExecuteNonQuery();
                MessageBox.Show("Successfully saved");

                string listFixture = "SELECT * FROM product ORDER BY ID DESC";
                OleDbCommand command77 = new OleDbCommand(listFixture, connection.con);
                OleDbDataAdapter da = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                da.SelectCommand = command77;
                dt.Clear();
                da.Fill(dt);
                dataGridView3.DataSource = dt;

                connection.con.Close();
            }

            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.placeTableAdapter.FillBy(this.fixtureDBDataSet.place);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            String nowDate = DateTime.Now.ToString("MM/dd/yyyy");
            connection.con.Open();
            string save = "Insert into Fixture(personalName, personalSurname,placeId,productId,registerDate)VALUES('" + comBx_name.SelectedValue + "', '" + comBx_surname.SelectedValue + "', '" + comBx_place.SelectedValue + "', '" + comBx_product.SelectedValue + "', " + nowDate + " )";
            OleDbCommand command3 = new OleDbCommand(save, connection.con);
            command3.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            

            string listFixture = "SELECT * FROM Fixture ORDER BY ID DESC";
            OleDbCommand command33 = new OleDbCommand(listFixture, connection.con);
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command33;
            dt.Clear();
            da.Fill(dt);
            dataGridFixture.DataSource = dt;

            connection.con.Close();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.dataGridFixture.Refresh();
            this.dataGridFixture.Parent.Refresh();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string listFixture = "SELECT * FROM product ORDER BY ID DESC";
            OleDbCommand command77 = new OleDbCommand(listFixture, connection.con);
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command77;
            dt.Clear();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string listFixture = "SELECT * FROM personal ORDER BY ID DESC";
            OleDbCommand command55 = new OleDbCommand(listFixture, connection.con);
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            da.SelectCommand = command55;
            dt.Clear();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridFixture.SelectedRows.Count > 0)
                {
                    connection.con.Open();
                    // dataGridFixture.Rows.RemoveAt(this.dataGridFixture.SelectedRows[0].Index);
                    int idFix = Convert.ToInt32(dataGridFixture.CurrentRow.Cells[0].Value);


                    string deleteFix = "delete from Fixture where ID=7";
                    OleDbCommand command89 = new OleDbCommand(deleteFix, connection.con);
                    command89.ExecuteNonQuery();
                    dataGridFixture.Refresh();
                    MessageBox.Show(idFix.ToString());

                    //show
                    string listFixture = "SELECT * FROM Fixture ORDER BY ID DESC";
                    OleDbCommand command51 = new OleDbCommand(listFixture, connection.con);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = command51;
                    dt.Clear();
                    da.Fill(dt);
                    dataGridFixture.DataSource = dt;

                    connection.con.Close();

                }
            }
            catch
            {

            }
        }

        private void btnPlaceDelete_Click(object sender, EventArgs e)
        {
            try 
            {
            
            } 
            catch 
            { 
            
            }
        }
    }
    }

