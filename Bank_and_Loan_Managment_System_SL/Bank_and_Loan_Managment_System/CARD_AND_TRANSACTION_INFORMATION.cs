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
    public partial class CARD_AND_TRANSACTION_INFORMATION : Form
    {
        SqlConnection c;
        Admin_Panel Admin_panel=new Admin_Panel();

        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public CARD_AND_TRANSACTION_INFORMATION(Admin_Panel admin_Panel)
        {
            InitializeComponent();
            Admin_panel = admin_Panel;
        }

        private void CARD_AND_TRANSICTION_INFORMATION_Load(object sender, EventArgs e)
        {
            sqlconnectionM();
            SqlCommand cmdCARD = new SqlCommand("SELECT * FROM CARDS_Info", c);
            SqlCommand cmdTRANSICTION = new SqlCommand("SELECT Transaction_ID, Type, AMOUNT, Phone_Number, DATE_TIME, ACCOUNT_ID, User_Id  FROM Transaction_History", c);
            DataTable dCARD = new DataTable();
            DataTable dTRANSICTION = new DataTable();
            SqlDataReader sdr = cmdCARD.ExecuteReader();
            dCARD.Load(sdr);
            sdr= cmdTRANSICTION.ExecuteReader();
            dTRANSICTION.Load(sdr);

            dataGridView1.DataSource = dCARD;
            dataGridView2.DataSource = dTRANSICTION;

            c.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (textBox1.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("User_Id ='" + textBox1.Text + "'");
                    (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("User_Id ='" + textBox1.Text + "'");
                }
                else
                {
                    MessageBox.Show("INPUT USER ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            //catch
            //{
               // MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnectionM();
                SqlCommand cmdCARD2 = new SqlCommand("SELECT * FROM CARDS_Info", c);
                SqlCommand cmdTRANSICTION2 = new SqlCommand("SELECT Transaction_ID, Type, AMOUNT, Phone_Number, DATE_TIME, ACCOUNT_ID, User_Id  FROM Transaction_History", c);
                DataTable dCARD2 = new DataTable();
                DataTable dTRANSICTION2 = new DataTable();
                SqlDataAdapter aCARD = new SqlDataAdapter(cmdCARD2);
                SqlDataAdapter aTRANSICTION = new SqlDataAdapter(cmdTRANSICTION2);
                aCARD.Fill(dCARD2);
                aTRANSICTION.Fill(dTRANSICTION2);

                dataGridView1.DataSource = dCARD2;
                dataGridView2.DataSource = dTRANSICTION2;
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            SqlCommand c111 = new SqlCommand("DELETE FROM Transaction_History", c);
            SqlDataReader r111 = c111.ExecuteReader();
            r111.Close();
            SqlCommand c222 = new SqlCommand("DELETE FROM CARDS_Info", c);
            SqlDataReader r222 = c222.ExecuteReader();
            r222.Close();

            MessageBox.Show("DELETED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
