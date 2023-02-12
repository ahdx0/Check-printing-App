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



namespace cheque_sysytem
{
    public partial class login : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=OHOUD_LAPTOP;Initial Catalog=ChequeSystem;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public login()
        {

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {


            try
            {

                conn.Open();
                cmd = new SqlCommand("Select count(*) from Login where name='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", conn);
             
                int i = int.Parse(cmd.ExecuteScalar().ToString());
                conn.Close();
                if (i > 0)
                {

                    Details form22 = new Details();
                    this.Hide();
                    form22.Show();
                }
                else
                {
                    MessageBox.Show("Invalid");
                }

            }
            catch
            {
                MessageBox.Show(" Error ");


            }
            finally
            {
                conn.Close();
            }
        }
    

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
