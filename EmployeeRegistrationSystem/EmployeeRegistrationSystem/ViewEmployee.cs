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
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection("Data Source=DESKTOP-K2M7KFE\\SQLEXPRESS;Initial Catalog=Employee;Integrated Security=True");
        private void Fetchempdata()
        {
            Con.Open();
            string query = "SELECT * FROM details WHERE Employee_ID='" + textBox10.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            Con.Close();
        }
        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

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
        private void button5_Click(object sender, EventArgs e)
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
                        label2.Text = sd["Employee_ID"].ToString();
                        label10.Text = sd["Employee_Name"].ToString();
                        label6.Text = sd["Employee_Address"].ToString();
                        label9.Text = sd["Employee_Gender"].ToString();
                        label4.Text = sd["Employee_Position"].ToString();
                        label20.Text = sd["Employee_Date_Of_Birth"].ToString();
                        label3.Text = sd["Employee_Phone_Number"].ToString();
                        label7.Text = sd["Employee_Education"].ToString();
                    }
                 Con.Close();
                }
                else
                {
                    MessageBox.Show("Data Record Not Found...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            label2.Text = "";
            label10.Text = "";
            label6.Text = "";
            label9.Text = "";
            label4.Text = "";
            label20.Text = "";
            label3.Text = "";
            label7.Text = "";

        }
    }
}
