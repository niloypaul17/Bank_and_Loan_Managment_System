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
    public partial class Account_Information : Form
    {
        SqlConnection c;

        Admin_Panel Admin_Panel=new Admin_Panel();
        string id;

        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public Account_Information(Admin_Panel admin_Panel )
        {
            InitializeComponent();
            Admin_Panel = admin_Panel;
        }

        private void Account_Information_Load(object sender, EventArgs e)
        {
            sqlconnectionM();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Student_Info", c);
            SqlCommand cmdSAV = new SqlCommand("SELECT * FROM Savings_Info", c);
            SqlCommand cmdEMP = new SqlCommand("SELECT * FROM Employee_Info", c);
            SqlCommand cmdUser = new SqlCommand("SELECT User_Id, National_id, First_Name, Middle_Name, Last_Name, Status, Balance, Photo, Email, Division, District, Street, Account_Opening_Date, Date_of_Birth, Phone_Number, Gender FROM User_INFO", c);
            DataTable dSTU = new DataTable();
            DataTable dSAV = new DataTable();
            DataTable dEMP = new DataTable();
            DataTable dUSER = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dSTU.Load(sdr);
            sdr = cmdSAV.ExecuteReader();
            dSAV.Load(sdr);
            sdr = cmdEMP.ExecuteReader();
            dEMP.Load(sdr);
            sdr=cmdUser.ExecuteReader();
            dUSER.Load(sdr);

            dataGridView1.DataSource = dUSER;
            dataGridView2.DataSource = dSTU;
            dataGridView3.DataSource = dSAV;
            dataGridView4.DataSource = dEMP;

            c.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Panel.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("User_Id ='" + textBox1.Text + "'");
                }
                else
                {
                    MessageBox.Show("INPUT USER ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Student_Account_ID  LIKE '" + textBox2.Text + "'");
                    (dataGridView3.DataSource as DataTable).DefaultView.RowFilter = string.Format("Savings_ID  LIKE '" + textBox2.Text + "'");
                    (dataGridView4.DataSource as DataTable).DefaultView.RowFilter = string.Format("Employee_ID  LIKE '" + textBox2.Text + "'");
                }
                else
                {
                    MessageBox.Show("INPUT ACCOUNT ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegPage regPage = new RegPage();
            regPage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    sqlconnectionM();
                    SqlCommand s1 = new SqlCommand("SELECT * FROM User_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                    SqlDataAdapter adapter = new SqlDataAdapter(s1);
                    DataTable DTAB = new DataTable();
                    adapter.Fill(DTAB);

                    string QuerrySTU2 = "SELECT * FROM Student_Info WHERE User_Id='" + textBox3.Text + "'";
                    string QuerrySAV2 = "SELECT * FROM Savings_Info WHERE User_Id='" + textBox3.Text + "'";
                    string QuerryEMP2 = "SELECT * FROM Employee_Info WHERE User_Id='" + textBox3.Text + "'";

                    SqlDataAdapter adapterSTU2 = new SqlDataAdapter(QuerrySTU2, c);
                    SqlDataAdapter adapterSAV2 = new SqlDataAdapter(QuerrySAV2, c);
                    SqlDataAdapter adapterEMP2 = new SqlDataAdapter(QuerryEMP2, c);

                    DataTable DSTU2 = new DataTable();
                    DataTable DSAV2 = new DataTable();
                    DataTable DEMP2 = new DataTable();

                    adapterSTU2.Fill(DSTU2);
                    adapterSAV2.Fill(DSAV2);
                    adapterEMP2.Fill(DEMP2);

                    if (DTAB.Rows.Count > 0 && DSTU2.Rows.Count > 0)
                    {
                        SqlCommand c111 = new SqlCommand("DELETE FROM Transaction_History WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r111 = c111.ExecuteReader();
                        r111.Close();
                        SqlCommand c222 = new SqlCommand("DELETE FROM CARDS_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r222 = c222.ExecuteReader();
                        r222.Close();
                        SqlCommand c333 = new SqlCommand("SELECT LOAN_ID FROM LOAN_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r33 = c333.ExecuteReader();
                        while (r33.Read())
                        {
                            id = r33.GetValue(0).ToString();
                        }
                        r33.Close();
                        SqlCommand c44 = new SqlCommand("DELETE FROM LOAN_STUDENT WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r44 = c44.ExecuteReader();
                        r44.Close();
                        SqlCommand c55 = new SqlCommand("DELETE FROM LOAN_INFO WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r55 = c55.ExecuteReader();
                        r55.Close();
                        SqlCommand s12 = new SqlCommand("DELETE FROM Student_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r12 = s12.ExecuteReader();
                        r12.Close();
                        SqlCommand s11 = new SqlCommand("DELETE FROM User_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r11 = s11.ExecuteReader();
                        r11.Close();
                        MessageBox.Show($"USER HAS BEEN REMOVE SUCCESSFULLY  !", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else if (DTAB.Rows.Count > 0 && DSAV2.Rows.Count > 0)
                    {
                        SqlCommand c111 = new SqlCommand("DELETE FROM Transaction_History WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r111 = c111.ExecuteReader();
                        r111.Close();
                        SqlCommand c222 = new SqlCommand("DELETE FROM CARDS_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r222 = c222.ExecuteReader();
                        r222.Close();
                        SqlCommand c333 = new SqlCommand("SELECT LOAN_ID FROM LOAN_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r33 = c333.ExecuteReader();
                        while (r33.Read())
                        {
                            id = r33.GetValue(0).ToString();
                        }
                        r33.Close();
                        SqlCommand c44 = new SqlCommand("DELETE FROM LOAN_SAVINGS_TABLE WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r44 = c44.ExecuteReader();
                        r44.Close();
                        SqlCommand c55 = new SqlCommand("DELETE FROM LOAN_INFO WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r55 = c55.ExecuteReader();
                        r55.Close();
                        SqlCommand s12 = new SqlCommand("DELETE FROM Savings_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r12 = s12.ExecuteReader();
                        r12.Close();
                        SqlCommand s11 = new SqlCommand("DELETE FROM User_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r11 = s11.ExecuteReader();
                        r11.Close();
                        MessageBox.Show($"USER HAS BEEN REMOVE SUCCESSFULLY  !", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else if (DTAB.Rows.Count > 0 && DEMP2.Rows.Count > 0)
                    {
                        SqlCommand c111 = new SqlCommand("DELETE FROM Transaction_History WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r111 = c111.ExecuteReader();
                        r111.Close();
                        SqlCommand c222 = new SqlCommand("DELETE FROM CARDS_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r222 = c222.ExecuteReader();
                        r222.Close();
                        SqlCommand c333 = new SqlCommand("SELECT LOAN_ID FROM LOAN_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r33 = c333.ExecuteReader();
                        while (r33.Read())
                        {
                            id = r33.GetValue(0).ToString();
                        }
                        r33.Close();
                        SqlCommand c44 = new SqlCommand("DELETE FROM LOAN_EMPLOYEE_TABLE WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r44 = c44.ExecuteReader();
                        r44.Close();
                        SqlCommand c55 = new SqlCommand("DELETE FROM LOAN_INFO WHERE LOAN_ID='" + id + "'", c);
                        SqlDataReader r55 = c55.ExecuteReader();
                        r55.Close();
                        SqlCommand s12 = new SqlCommand("DELETE FROM Employee_Info WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r12 = s12.ExecuteReader();
                        r12.Close();
                        SqlCommand s11 = new SqlCommand("DELETE FROM User_INFO WHERE User_Id='" + textBox3.Text + "'", c);
                        SqlDataReader r11 = s11.ExecuteReader();
                        r11.Close();
                        MessageBox.Show($"USER HAS BEEN REMOVE SUCCESSFULLY  !", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else
                    {
                        MessageBox.Show("INVALID USER ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("INPUT USER ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnectionM();

                SqlCommand cmd3 = new SqlCommand("SELECT * FROM Student_Info", c);
                SqlCommand cmdSAV3 = new SqlCommand("SELECT * FROM Savings_Info", c);
                SqlCommand cmdEMP3 = new SqlCommand("SELECT * FROM Employee_Info", c);
                SqlCommand cmdUser3 = new SqlCommand("SELECT User_Id, National_id, First_Name, Middle_Name, Last_Name, Status, Balance, Photo, Email, Division, District, Street, Account_Opening_Date, Date_of_Birth, Phone_Number, Gender FROM User_INFO", c);
                DataTable dSTU3 = new DataTable();
                DataTable dSAV3 = new DataTable();
                DataTable dEMP3 = new DataTable();
                DataTable dUSER3 = new DataTable();
                SqlDataAdapter STUA3 = new SqlDataAdapter(cmd3);
                SqlDataAdapter SAVA3 = new SqlDataAdapter(cmdSAV3);
                SqlDataAdapter EMPA3 = new SqlDataAdapter(cmdEMP3);
                SqlDataAdapter USER3 = new SqlDataAdapter(cmdUser3);
                STUA3.Fill(dSTU3);
                SAVA3.Fill(dSAV3);
                EMPA3.Fill(dEMP3);
                USER3.Fill(dUSER3);

                dataGridView1.DataSource = dUSER3;
                dataGridView2.DataSource = dSTU3;
                dataGridView3.DataSource = dSAV3;
                dataGridView4.DataSource = dEMP3;

                c.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            
            SqlCommand c222 = new SqlCommand("DELETE FROM Student_Info", c);
            SqlDataReader r222=c222.ExecuteReader();
            r222.Close();
            SqlCommand c333 = new SqlCommand("DELETE FROM Savings_Info", c);
            SqlDataReader r333 = c333.ExecuteReader();
            r333.Close();
            SqlCommand c444 = new SqlCommand("DELETE FROM Employee_Info", c);
            SqlDataReader r444 = c444.ExecuteReader();
            r444.Close();
            SqlCommand c111 = new SqlCommand("DELETE FROM User_INFO", c);
            SqlDataReader r111 = c111.ExecuteReader();
            r111.Close();

            MessageBox.Show("DELETED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
