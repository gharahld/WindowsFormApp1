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

//container which contain the name of the app

namespace WindowsFormsApp1
{
    //Method for form3
    public partial class Form3 : Form
    {
    //class method for myusername
  
        public string myUsername;
        //class method for form3 which contain username

        public Form3(string username)
        {
        //it's a constructor for form3
            InitializeComponent();
            //assign myUsername a value
            myUsername = username;
        }
        //method for main page

        private void Main_Load(object sender, EventArgs e)
        {

        }
        //method for the button1 on click


        private void Button1_Click(object sender, EventArgs e)
        {
            //Initialise the connection for the data
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ghara\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
            //set the command for the database
            SqlDataAdapter sda = new SqlDataAdapter("Select MESSAGE From Secrets where username ='" + myUsername + "'", con);
            //Initialized a table
            DataTable dt = new DataTable();
            //fill the table
            sda.Fill(dt);
            //check te message in the table
            string message = dt.Rows[0][0].ToString();
            //create the variable message
            richTextBox1.Text = message;
            //display the username an the correspondant message
            MessageBox.Show(myUsername + "Loading" + message); 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Initialise the connection for the data
        
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ghara\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
            //set the command for the database
            SqlDataAdapter sda = new SqlDataAdapter("UPDATE Secrets  SET MESSAGE = '" + richTextBox1.Text + "', PUBLISH_DATE = '" + dateTimePicker1.Value.ToString() + "' WHERE USERNAME = '" + myUsername + "'", con);
            //Initialized a table
            DataTable dt = new DataTable();
            //fill the table
            sda.Fill(dt);
            //save the correspondent message
            MessageBox.Show(myUsername + " Saving: " + richTextBox1.Text);  
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
