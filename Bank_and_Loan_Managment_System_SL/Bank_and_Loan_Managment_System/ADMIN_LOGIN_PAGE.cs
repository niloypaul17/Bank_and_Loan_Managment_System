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

namespace Bank_and_Loan_Managment_System
{
    public partial class ADMIN_LOGIN_PAGE : Form
    {
        SqlConnection c;
        string ADMN, ADMPN, ADMID;
        Form1 formA=new Form1();
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public ADMIN_LOGIN_PAGE(Form1 form1)
        {
            InitializeComponent();
            PASSbox.UseSystemPasswordChar = true;
            formA = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formA.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                PASSbox.UseSystemPasswordChar = false;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                PASSbox.UseSystemPasswordChar = true;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            sqlconnectionM();
            try
            {
                SqlCommand sqlADMIN = new SqlCommand("SELECT * FROM ADMIN_INFO WHERE ADMIN_ID='" + IDbox.Text + "' AND SUPER_PASSWORD='" + PASSbox.Text + "'", c);
                SqlDataAdapter DataAdmin = new SqlDataAdapter(sqlADMIN);
                DataTable dt = new DataTable();
                DataAdmin.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT ADMIN_ID, ADMIN_NAME, PHONE_NUMBER FROM ADMIN_INFO WHERE ADMIN_ID='" + IDbox.Text + "' AND SUPER_PASSWORD='" + PASSbox.Text + "'",c);
                    SqlDataReader sqlADMINR = sqlCommand.ExecuteReader();

                    while (sqlADMINR.Read())
                    {
                        ADMID=sqlADMINR.GetValue(0).ToString();
                        ADMN=sqlADMINR.GetValue(1).ToString();
                        ADMPN=sqlADMINR.GetValue(2).ToString();
                    }
                    Admin_Panel admin_Panel = new Admin_Panel(ADMN, ADMPN, ADMID, formA);
                    admin_Panel.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INVALID PHONE NUMBER OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    IDbox.Clear();
                    PASSbox.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
