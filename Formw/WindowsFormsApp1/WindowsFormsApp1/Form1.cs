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

// Class container that contain the app name
namespace WindowsFormsApp1
{
    // public methd for form1
    public partial class Form1 : Form
    {
    // assign a variable and make it private. 
        private const string V = "' PUBLISH DATE ='";
        
        //method for form1

        public Form1()
        { 
        // constroctor for form1
            InitializeComponent();
        }
        // Method for form1 

        private void Form1_Load(object sender, EventArgs e)
        {
        // A method that will show the page
            Show();
        }
        //button1 when click

        private void Button1_Click(object sender, EventArgs e) 
        {
        //close the form
            Close();
        }
        //button2 when click
        
        private void Button2_Click(object sender, EventArgs e)
        {
            //initialized the connection

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ghara\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30;");
          // set the data command to the database
            SqlDataAdapter sda = new SqlDataAdapter(" Select Count(*) From LOGIN where USERNAME ='" + textBox1.Text + "' and PASSWORD ='" + textBox2.Text + "'", con);
          // set the data table
            DataTable dt = new DataTable();
            
          // fill that data table  
            sda.Fill(dt);
         //check if the datatable has a value
            if (dt.Rows[0][0].ToString() == "1")
            {
                //hide the current form
                Hide();
                // show the correspondent form when current button is pressed
                Form3 ss = new Form3(textBox1.Text);
                //show the form current form
                ss.Show();
            }
            else
            {
                //show that message if the condition above fail
                MessageBox.Show("Please check your USERNAME and PASSWORD");
            }
        }
           //button3 when click

        private void Button3_Click(object sender, EventArgs e)
        {
            //show form2
            Show();
            //display the form when button3 is pressed
            Form2 ss = new Form2(textBox1.Text);
            // show the form
            ss.Show();
        }
    }



}
    
