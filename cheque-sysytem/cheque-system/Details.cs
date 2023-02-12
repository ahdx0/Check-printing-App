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


    public partial class Details : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=OHOUD_LAPTOP;Initial Catalog=ChequeSystem;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        List<CurrencyInfo> currencies = new List<CurrencyInfo>();
        private object cboCurrency;

        public Details()
        {


            InitializeComponent();

            var pos = this.PointToScreen(lblDate.Location);
            pos = picCheck.PointToClient(pos);
            lblDate.Parent = picCheck;
            lblDate.Location = pos;
            lblDate.BackColor = Color.Transparent;

            lblDate.Parent = picCheck;
            lblDate.BackColor = Color.Transparent;


            var pos1 = this.PointToScreen(lblPlace.Location);
            pos1 = picCheck.PointToClient(pos1);
            lblPlace.Parent = picCheck;
            lblPlace.Location = pos1;
            lblPlace.BackColor = Color.Transparent;

            lblPlace.Parent = picCheck;
            lblPlace.BackColor = Color.Transparent;

            var pos2 = this.PointToScreen(lblName.Location);
            pos2 = picCheck.PointToClient(pos2);
            lblName.Parent = picCheck;
            lblName.Location = pos2;
            lblName.BackColor = Color.Transparent;

            lblName.Parent = picCheck;
            lblName.BackColor = Color.Transparent;

            var pos3 = this.PointToScreen(lblamount.Location);
            pos3 = picCheck.PointToClient(pos3);
            lblamount.Parent = picCheck;
            lblamount.Location = pos3;
            lblamount.BackColor = Color.Transparent;

            lblamount.Parent = picCheck;
            lblamount.BackColor = Color.Transparent;

            var pos4 = this.PointToScreen(lblAmountNum.Location);
            pos4 = picCheck.PointToClient(pos4);
            lblAmountNum.Parent = picCheck;
            lblAmountNum.Location = pos4;
            lblAmountNum.BackColor = Color.Transparent;

            lblAmountNum.Parent = picCheck;
            lblAmountNum.BackColor = Color.Transparent;


            var pos5 = this.PointToScreen(lblDetails.Location);
            pos5 = picCheck.PointToClient(pos5);
            lblDetails.Parent = picCheck;
            lblDetails.Location = pos5;
            lblDetails.BackColor = Color.Transparent;

            lblDetails.Parent = picCheck;
            lblDetails.BackColor = Color.Transparent;

        }

    

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblPlace.Text = txtPlace.Text;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {
            
        }

        private void picCheck_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Syria));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.UAE));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.SaudiArabia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Tunisia));
            currencies.Add(new CurrencyInfo(CurrencyInfo.Currencies.Gold));
            comboBox1_SelectedIndexChanged(null, null);
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblDate.Text = DateTime.Now.ToShortDateString();

        }
        private void currency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            login list = new login();
            this.Hide();
            list.Show();
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            //Form3 list = new Form3();
            this.Hide();
            //list.Show();
        }

        private void TxtAmount_TextChanged(object sender, EventArgs e)
        {
            lblAmountNum.Text = TxtAmount.Text;

            try
            {
                ToWord toWord = new ToWord(Convert.ToDecimal(lblAmountNum.Text), currencies[Convert.ToInt32(comboBox1.SelectedValue)]);
                lblamount.Text = toWord.ConvertToEnglish();


            }
            catch (Exception ex)
            {
                lblamount.Text = string.Empty;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblamount_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
            txtName.Clear();
            TxtAmount.Clear();
            txtPlace.Clear();
            txtDetails.Clear();

        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            lblName.Text = txtName.Text;
        }

        private void txtDetails_TextChanged(object sender, EventArgs e)
        {
            lblDetails.Text = txtDetails.Text;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK) ;

            {
                printDocument1.Print();

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            RectangleF rect1 = new RectangleF(100, 145, 395, 50);//38  //(100, 155, 350, 200)
            StringFormat format1 = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            //For the reasons
            RectangleF rect2 = new RectangleF(90, 190, 340, 100);//38  //(100, 155, 350, 200)
            StringFormat format2 = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            Font f = new Font("Arial", 12, FontStyle.Regular);
            e.Graphics.DrawString(lblamount.Text, f, Brushes.Black, rect1, format1);
            e.Graphics.DrawString(lblDetails.Text, f, Brushes.Black, rect2, format2);//180, 150
            e.Graphics.DrawString(lblamount.Text, f, Brushes.Black, rect1, format1);
            e.Graphics.DrawString(lblAmountNum.Text, f, Brushes.Black, 650, 160);
            e.Graphics.DrawString(lblName.Text, f, Brushes.Black, 390, 90);
            e.Graphics.DrawString(lblPlace.Text, f, Brushes.Black, 660, 22);
            e.Graphics.DrawString(lblDate.Text, f, Brushes.Black, 620, -4);
        }
    }
    }
