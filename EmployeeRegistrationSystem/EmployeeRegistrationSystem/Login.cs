using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeRegistrationSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter Username And Password");
            }

            else if (Username == "admin" && Password == "Admin123")
            {
                MessageBox.Show("Logged in Successfully...");
                this.Hide();
                Form frm = new Home();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect...");
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
