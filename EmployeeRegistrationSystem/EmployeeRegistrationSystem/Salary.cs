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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using System.Reflection.Emit;
using System.Diagnostics.Eventing.Reader;

namespace EmployeeRegistrationSystem
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-K2M7KFE\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Salary();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Enter The Employee ID");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete details where [Employee_ID]=@Employee_ID", Con);
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox10.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Delete Successfully ........");
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from details where [Employee_ID]=@Employee_ID", Con);
                    cmd.Parameters.AddWithValue("@Employee_ID", textBox10.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Data Record Found");
                        using (SqlDataReader sd = cmd.ExecuteReader())
                        {
                            sd.Read();
                            textBox7.Text = sd["Employee_Name"].ToString();
                            textBox6.Text = sd["Employee_Position"].ToString();
                        }
                    }
                    else
                     {
                         MessageBox.Show("Data Record Not Found...");
                     }
                    Con.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
private void populate()
        {
            Con.Open();
            string query = "Select * from details";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            Con.Close();
        }
        
        private void Salary_Load(object sender, EventArgs e)
        {
            populate();
        }


        int Dailybase,total;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Con.Open();
                string Query = "Select from details";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                Con.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Saved in Successfully...");
            }
            finally
            {
                Con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("Select AN Employee");
            }
            else if (textBox9.Text == "" || Convert.ToInt32(textBox9.Text) > 28)
            {
                MessageBox.Show("Enter A Valid Number of Days");
            }else
            {
                if (textBox6.Text == "Manager")
                {
                    Dailybase = 1200;
                }else if (textBox6.Text =="Senior Developer")
                {
                    Dailybase = 1000;
                }
                else if (textBox6.Text == "Junior Developer")
                {
                    Dailybase = 950;
                }else
                {
                    Dailybase = 850;
                }
                total = Dailybase = Convert.ToInt32(textBox9.Text);
                richTextBox1.Text = "Employee ID:     '"+textBox10.Text +"','"+"Employee Name:     '"+textBox7.Text + "',"+"Employee Position:     '"+textBox6.Text + "',"+"Days Worked:     '"+textBox9.Text+"',"+"Daily Salary Rs:     '"+Dailybase+"',"+"Total Amount Rs:     '"+total;

            }
        }
    }
}
