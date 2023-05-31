using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personnel_Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-N0BSSOE;Initial Catalog=Personnel_Database;Integrated Security=True");



        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnlist_Click(object sender, EventArgs e)
        {
            this.personnel_TableTableAdapter.Fill(this.personnel_DatabaseDataSet.Personnel_Table);
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.personnel_TableTableAdapter.FillBy(this.personnel_DatabaseDataSet.Personnel_Table);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sqlQuery="insert into Personnel_Table (name,surname,location,salary,occupation)" +
                "values (@p1,@p2,@p3,@p4,@p5)";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@p1",name.Text);
            command.Parameters.AddWithValue("@p2", surname.Text);
            command.Parameters.AddWithValue("@p3", location.Text);
            command.Parameters.AddWithValue("@p4", salary.Text);
            command.Parameters.AddWithValue("@p5", occupation.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("successful");

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sqlQuery = "delete from Personnel_Table where id=@p1";
            SqlCommand command=new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@p1",id.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("deleted");
        }

        private void btnuptade_Click(object sender, EventArgs e)
        {
            connection.Open();
            string sqlQuery = "UPDATE Personnel_Table SET name = @p1, surname = @p2, salary = @p3, location = @p4, occupation = @p5 WHERE id = @p6";
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@p1", name.Text);
            command.Parameters.AddWithValue("@p2", surname.Text);
            command.Parameters.AddWithValue("@p3", salary.Text);
            command.Parameters.AddWithValue("@p4", location.Text);
            command.Parameters.AddWithValue("@p5", occupation.Text);
            command.Parameters.AddWithValue("@p6", id.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Updated");


        }

        public void clear()
        {
            name.Text = "";
            surname.Text = "";
            location.Text = "";
            salary.Text = "";
            id.Text = "";
            occupation.Text = "";
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
