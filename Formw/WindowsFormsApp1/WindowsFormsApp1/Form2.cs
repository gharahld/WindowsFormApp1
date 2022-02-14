using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2(string text)
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            // gets connection to talk to file database
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ghara\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
            // the command for the DB using the connection
            SqlDataAdapter sda1 = new SqlDataAdapter(
                "Select Count(*) From LOGIN where USERNAME = '" + textBox1.Text + "'" , con);

            // prepare a table
            DataTable dt1 = new DataTable();

            // fill command result in table
            sda1.Fill(dt1);

            // check if result in the filled table is 1
            if (dt1.Rows[0][0].ToString() == "1")
            {
                // result == 1 : it exist already
                MessageBox.Show("This username is taken");

                // leave this function
                return;
            }
            // result != 1
            // we can proceed
            // because this username is NEW!!


            // Initialise the connection for the data
            SqlDataAdapter sda = new SqlDataAdapter( 
                // link the SQL database to the code
                "INSERT INTO LOGIN (USERNAME,PASSWORD,FIRST_NAME,LAST_NAME)  VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox1.Text + "','" + textBox2.Text + "');" +
                //get data from Secrets datatable
                "INSERT INTO Secrets (USERNAME,MESSAGE) VALUES('" + textBox3.Text + "', 'i'm new user messsage')", con);
            
            //initialized a table
            DataTable dt = new DataTable();
            
            //fill the datatable
            sda.Fill(dt);
            // show this message when the above was done 
            MessageBox.Show("The user was created!");
            Close();

    }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
