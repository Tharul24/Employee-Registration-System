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

namespace EmployeeRegistrationSystem
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            DisplayEmp();
        }
        readonly SqlConnection Con = new SqlConnection("Data Source=DESKTOP-K2M7KFE\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
       
        private void DisplayEmp()
        {
            try
            {

                Con.Open();
                string Query = "Select from details";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();

            }catch (Exception ex)
            {
                MessageBox.Show("ex.Message");
            }
            finally
            {
                Con.Close();
            }
        }
        
        private void button5_Click(object sender, EventArgs e)

        {
            try
            {
                if (textBox10.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {

                    Con.Open();
                    string Query = "insert into details values('" + textBox10.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + comboBox5.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + dateTimePicker2.Text + "','" + textBox9.Text + "','" + comboBox4.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Successfully Submitted...");
                    DisplayEmp();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text == "")
                {
                    MessageBox.Show("Enter The Employee ID");
                }
                else
                {
                    Con.Open();
                    string query = "delete from details Where Employee_ID = '" + textBox10.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Delete Successfully ........");
                    DisplayEmp();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            dateTimePicker2 = new DateTimePicker();
            textBox9.Text = "";
            comboBox4.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text == "" || textBox7.Text == "" || textBox9.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    Con.Open();
                    string query = "Update details set Employee_ID = '" + textBox10.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + comboBox5.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "','" + dateTimePicker2.Text + "','" + textBox9.Text + "','" + comboBox4.SelectedItem.ToString() + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Edit Data Successfully ........");
                    DisplayEmp();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Employee();
            frm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm = new Form2();
            frm.ShowDialog();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            DisplayEmp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
