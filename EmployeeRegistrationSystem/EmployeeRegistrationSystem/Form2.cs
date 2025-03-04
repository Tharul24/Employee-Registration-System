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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Employee();
            frm.ShowDialog();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new ViewEmployee();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Salary();
            frm.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new ViewEmployee();
            frm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Salary();
            frm.ShowDialog();
        }
    }
}
