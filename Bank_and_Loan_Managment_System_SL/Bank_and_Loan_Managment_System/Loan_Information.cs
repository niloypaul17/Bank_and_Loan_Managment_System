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
    public partial class Loan_Information : Form
    {
        SqlConnection c;
        string status,Date;
        int id, date;
        float PB, AMMOUNT, TOTAL;
        DateTime d = DateTime.Now;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        Admin_Panel Admin_panel=new Admin_Panel();
        public Loan_Information(Admin_Panel admin_Panel)
        {
            InitializeComponent();
            Admin_panel = admin_Panel;
        }

        private void Loan_Information_Load(object sender, EventArgs e)
        {
            sqlconnectionM();
            SqlCommand cmdLOAN = new SqlCommand("SELECT LOAN_ID, LOAN_INTEREST, LOAN_AMOUNT, LOAN_VALIDITY, LOAN_VALIDITY_YEAR, PHONE_NUMBER, STATUS, User_Id FROM LOAN_INFO", c);
            SqlCommand cmdSTULOAN = new SqlCommand("SELECT * FROM LOAN_STUDENT", c);
            SqlCommand cmdSAVLOAN = new SqlCommand("SELECT * FROM LOAN_SAVINGS_TABLE", c);
            SqlCommand cmdEMPLOAN = new SqlCommand("SELECT * FROM LOAN_EMPLOYEE_TABLE", c);
            DataTable dSTULOAN = new DataTable();
            DataTable dSAVLOAN = new DataTable();
            DataTable dEMPLOAN = new DataTable();
            DataTable dLOAN = new DataTable();
            SqlDataReader sdr = cmdLOAN.ExecuteReader();
            dLOAN.Load(sdr);
            sdr = cmdSTULOAN.ExecuteReader();
            dSTULOAN.Load(sdr);
            sdr = cmdSAVLOAN.ExecuteReader();
            dSAVLOAN.Load(sdr);
            sdr = cmdEMPLOAN.ExecuteReader();
            dEMPLOAN.Load(sdr);

            dataGridView1.DataSource=dLOAN;
            dataGridView2.DataSource = dSTULOAN;
            dataGridView3.DataSource = dSAVLOAN;
            dataGridView4.DataSource = dEMPLOAN;

            c.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_panel.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnectionM();
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM LOAN_STUDENT WHERE LOAN_ID='" + textBox3.Text + "'", c);
                SqlCommand cmdSAV2 = new SqlCommand("SELECT * FROM LOAN_SAVINGS_TABLE WHERE LOAN_ID='" + textBox3.Text + "'", c);
                SqlCommand cmdEMP2 = new SqlCommand("SELECT * FROM LOAN_EMPLOYEE_TABLE WHERE LOAN_ID='" + textBox3.Text + "'", c);
                DataTable dSTU2 = new DataTable();
                DataTable dSAV2 = new DataTable();
                DataTable dEMP2 = new DataTable();

                SqlDataAdapter STUA2 = new SqlDataAdapter(cmd2);
                SqlDataAdapter SAVA2 = new SqlDataAdapter(cmdSAV2);
                SqlDataAdapter EMPA2 = new SqlDataAdapter(cmdEMP2);

                STUA2.Fill(dSTU2);
                SAVA2.Fill(dSAV2);
                EMPA2.Fill(dEMP2);
                if (dSTU2.Rows.Count > 0)
                {
                    SqlCommand c1 = new SqlCommand("SELECT STATUS FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    SqlDataReader r1 = c1.ExecuteReader();
                    while (r1.Read())
                    {
                        status = r1.GetValue(0).ToString();
                    }
                    r1.Close();
                    if (status == "PENDING   ")
                    {
                        SqlCommand s6 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        s6.Parameters.AddWithValue("@ST", "DECLINED");
                        s6.ExecuteNonQuery();
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN DECLINED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else if (status == "ACCEPTED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT DECLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                    else if (status == "DECLINED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT DICLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                }
                else if (dSAV2.Rows.Count > 0)
                {
                    SqlCommand c1 = new SqlCommand("SELECT STATUS FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    SqlDataReader r1 = c1.ExecuteReader();
                    while (r1.Read())
                    {
                        status = r1.GetValue(0).ToString();
                    }
                    r1.Close();
                    if (status == "PENDING   ")
                    {
                        SqlCommand s6 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        s6.Parameters.AddWithValue("@ST", "DECLINED");
                        s6.ExecuteNonQuery();
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN DECLINED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else if (status == "ACCEPTED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT DECLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                    else if (status == "DECLINED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT DICLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                }
                else if (dEMP2.Rows.Count > 0)
                {
                    SqlCommand c1 = new SqlCommand("SELECT STATUS FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    SqlDataReader r1 = c1.ExecuteReader();
                    while (r1.Read())
                    {
                        status = r1.GetValue(0).ToString();
                    }
                    r1.Close();
                    if (status == "PENDING   ")
                    {
                        SqlCommand s6 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        s6.Parameters.AddWithValue("@ST", "DECLINED");
                        s6.ExecuteNonQuery();
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN DECLINED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox3.Clear();
                    }
                    else if (status == "ACCEPTED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT DECLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                    else if (status == "DECLINED  ")
                    {
                        MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT DICLINE IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("INVALID LOANID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Clear();
                }
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
           
            SqlCommand c222 = new SqlCommand("DELETE FROM LOAN_STUDENT", c);
            SqlDataReader r222 = c222.ExecuteReader();
            r222.Close();
            SqlCommand c333 = new SqlCommand("DELETE FROM LOAN_SAVINGS_TABLE", c);
            SqlDataReader r333 = c333.ExecuteReader();
            r333.Close();
            SqlCommand c444 = new SqlCommand("DELETE FROM LOAN_EMPLOYEE_TABLE", c);
            SqlDataReader r444 = c444.ExecuteReader();
            r444.Close();
            SqlCommand c111 = new SqlCommand("DELETE FROM LOAN_INFO", c);
            SqlDataReader r111 = c111.ExecuteReader();
            r111.Close();

            MessageBox.Show("DELETED", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                sqlconnectionM();

                SqlCommand cmdLOAN2 = new SqlCommand("SELECT LOAN_ID, LOAN_INTEREST, LOAN_AMOUNT, LOAN_VALIDITY, LOAN_VALIDITY_YEAR, PHONE_NUMBER, STATUS, User_Id FROM LOAN_INFO", c);
                SqlCommand cmdSTULOAN2 = new SqlCommand("SELECT * FROM LOAN_STUDENT", c);
                SqlCommand cmdSAVLOAN2 = new SqlCommand("SELECT * FROM LOAN_SAVINGS_TABLE", c);
                SqlCommand cmdEMPLOAN2 = new SqlCommand("SELECT * FROM LOAN_EMPLOYEE_TABLE", c);
                DataTable dSTULOAN2 = new DataTable();
                DataTable dSAVLOAN2 = new DataTable();
                DataTable dEMPLOAN2 = new DataTable();
                DataTable dLOAN2 = new DataTable();
                SqlDataAdapter LOAN2 = new SqlDataAdapter(cmdLOAN2);
                SqlDataAdapter STULOAN2 = new SqlDataAdapter(cmdSTULOAN2);
                SqlDataAdapter SAVLOAN2 = new SqlDataAdapter(cmdSAVLOAN2);
                SqlDataAdapter EMPLOAN2 = new SqlDataAdapter(cmdEMPLOAN2);
                LOAN2.Fill(dLOAN2);
                STULOAN2.Fill(dSTULOAN2);
                SAVLOAN2.Fill(dSAVLOAN2);
                EMPLOAN2.Fill(dEMPLOAN2);

                dataGridView1.DataSource = dLOAN2;
                dataGridView2.DataSource = dSTULOAN2;
                dataGridView3.DataSource = dSAVLOAN2;
                dataGridView4.DataSource = dEMPLOAN2;

                c.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("LOAN_ID ='" + textBox1.Text + "'");
                }
                else
                {
                    MessageBox.Show("INPUT LOAN ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    (dataGridView2.DataSource as DataTable).DefaultView.RowFilter = string.Format("Student_Id  LIKE '" + textBox2.Text + "'");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != "")
                {
                    sqlconnectionM();
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM LOAN_STUDENT WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    SqlCommand cmdSAV1 = new SqlCommand("SELECT * FROM LOAN_SAVINGS_TABLE WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    SqlCommand cmdEMP1 = new SqlCommand("SELECT * FROM LOAN_EMPLOYEE_TABLE WHERE LOAN_ID='" + textBox3.Text + "'", c);
                    DataTable dSTU1 = new DataTable();
                    DataTable dSAV1 = new DataTable();
                    DataTable dEMP1 = new DataTable();

                    SqlDataAdapter STUA = new SqlDataAdapter(cmd1);
                    SqlDataAdapter SAVA = new SqlDataAdapter(cmdSAV1);
                    SqlDataAdapter EMPA = new SqlDataAdapter(cmdEMP1);

                    STUA.Fill(dSTU1);
                    SAVA.Fill(dSAV1);
                    EMPA.Fill(dEMP1);
                    if (dSTU1.Rows.Count > 0)
                    {
                        SqlCommand c1 = new SqlCommand("SELECT STATUS, User_Id FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        SqlDataReader r1 = c1.ExecuteReader();
                        while (r1.Read())
                        {
                            status = r1.GetValue(0).ToString();
                            id = int.Parse(r1.GetValue(1).ToString());
                        }
                        r1.Close();
                        if (status == "PENDING   ")
                        {
                            SqlCommand s2 = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + id + "'", c);
                            SqlDataReader r2 = s2.ExecuteReader();
                            while (r2.Read())
                            {
                                PB = float.Parse(r2.GetValue(0).ToString());
                            }
                            r2.Close();
                            SqlCommand s3 = new SqlCommand("SELECT LOAN_AMOUNT FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            SqlDataReader r3 = s3.ExecuteReader();
                            while (r3.Read())
                            {
                                AMMOUNT = float.Parse(r3.GetValue(0).ToString());
                            }
                            r3.Close();
                            TOTAL = PB + AMMOUNT;
                            SqlCommand s4 = new SqlCommand("UPDATE User_INFO SET Balance='" + TOTAL + "' WHERE User_Id='" + id + "'", c);
                            SqlDataReader r4 = s4.ExecuteReader();
                            r4.Close();

                            SqlCommand s5 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST,LOAN_VALIDITY_YEAR=@LVY  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            s5.Parameters.AddWithValue("@ST", "ACCEPTED");
                            s5.Parameters.AddWithValue("@LVY", d.AddYears(4));
                            s5.ExecuteNonQuery();

                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN ACCEPTED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (status == "ACCEPTED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT ACCEPT IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else if (status == "DECLINED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT ACCEPT IT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dSAV1.Rows.Count > 0)
                    {
                        SqlCommand c1 = new SqlCommand("SELECT STATUS, User_Id FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        SqlDataReader r1 = c1.ExecuteReader();
                        while (r1.Read())
                        {
                            status = r1.GetValue(0).ToString();
                            id = int.Parse(r1.GetValue(1).ToString());
                        }
                        r1.Close();
                        if (status == "PENDING   ")
                        {
                            SqlCommand s2 = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + id + "'", c);
                            SqlDataReader r2 = s2.ExecuteReader();
                            while (r2.Read())
                            {
                                PB = float.Parse(r2.GetValue(0).ToString());
                            }
                            r2.Close();
                            SqlCommand s3 = new SqlCommand("SELECT LOAN_AMOUNT FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            SqlDataReader r3 = s3.ExecuteReader();
                            while (r3.Read())
                            {
                                AMMOUNT = float.Parse(r3.GetValue(0).ToString());
                            }
                            r3.Close();
                            TOTAL = PB + AMMOUNT;
                            SqlCommand s4 = new SqlCommand("UPDATE User_INFO SET Balance='" + TOTAL + "' WHERE User_Id='" + id + "'", c);
                            SqlDataReader r4 = s4.ExecuteReader();
                            r4.Close();
                            SqlCommand s5 = new SqlCommand("SELECT LOAN_VALIDITY FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            SqlDataReader r5 = s5.ExecuteReader();
                            while (r5.Read())
                            {
                                Date = r5.GetValue(0).ToString();
                            }
                            if (Date == "7 YEARS")
                            {
                                date = 7;
                            }
                            else if (Date == "5 YEARS")
                            {
                                date = 5;
                            }
                            else if (Date == "10 YEARS")
                            {
                                date = 10;
                            }
                            else if (Date == "15 YEARS")
                            {
                                date = 15;
                            }
                            r5.Close();
                            SqlCommand s6 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST,LOAN_VALIDITY_YEAR=@LVY  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            s6.Parameters.AddWithValue("@ST", "ACCEPTED");
                            s6.Parameters.AddWithValue("@LVY", d.AddYears(date));
                            s6.ExecuteNonQuery();

                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN ACCEPTED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (status == "ACCEPTED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT ACCEPT IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else if (status == "DECLINED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT ACCEPT IT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Error{status}s{status.Length}S", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dEMP1.Rows.Count > 0)
                    {
                        SqlCommand c1 = new SqlCommand("SELECT STATUS, User_Id FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                        SqlDataReader r1 = c1.ExecuteReader();
                        while (r1.Read())
                        {
                            status = r1.GetValue(0).ToString();
                            id = int.Parse(r1.GetValue(1).ToString());
                        }
                        r1.Close();
                        if (status == "PENDING   ")
                        {
                            SqlCommand s2 = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + id + "'", c);
                            SqlDataReader r2 = s2.ExecuteReader();
                            while (r2.Read())
                            {
                                PB = float.Parse(r2.GetValue(0).ToString());
                            }
                            r2.Close();
                            SqlCommand s3 = new SqlCommand("SELECT LOAN_AMOUNT FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            SqlDataReader r3 = s3.ExecuteReader();
                            while (r3.Read())
                            {
                                AMMOUNT = float.Parse(r3.GetValue(0).ToString());
                            }
                            r3.Close();
                            TOTAL = PB + AMMOUNT;
                            SqlCommand s4 = new SqlCommand("UPDATE User_INFO SET Balance='" + TOTAL + "' WHERE User_Id='" + id + "'", c);
                            SqlDataReader r4 = s4.ExecuteReader();
                            r4.Close();
                            SqlCommand s5 = new SqlCommand("SELECT LOAN_VALIDITY FROM LOAN_INFO WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            SqlDataReader r5 = s5.ExecuteReader();
                            while (r5.Read())
                            {
                                Date = r5.GetValue(0).ToString();
                            }
                            if (Date == "7 YEARS")
                            {
                                date = 7;
                            }
                            else if (Date == "5 YEARS")
                            {
                                date = 5;
                            }
                            else if (Date == "10 YEARS")
                            {
                                date = 10;
                            }
                            else if (Date == "15 YEARS")
                            {
                                date = 15;
                            }
                            r5.Close();
                            SqlCommand s6 = new SqlCommand("UPDATE LOAN_INFO SET STATUS=@ST,LOAN_VALIDITY_YEAR=@LVY  WHERE LOAN_ID='" + textBox3.Text + "'", c);
                            s6.Parameters.AddWithValue("@ST", "ACCEPTED");
                            s6.Parameters.AddWithValue("@LVY", d.AddYears(date));
                            s6.ExecuteNonQuery();

                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS BEEN ACCEPTED!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (status == "ACCEPTED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN ACCEPTED! YOU CAN NOT ACCEPT IT AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else if (status == "DECLINED  ")
                        {
                            MessageBox.Show($"LOAN NUMBER {textBox3.Text} HAS ALREADY BEEN DECLIEND! YOU CAN NOT ACCEPT IT", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox3.Clear();
                        }
                        else
                        {
                            MessageBox.Show($"Error{status}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("INVALID LOANID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox3.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("INPUT LOANID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("SOMETHING WRONG! TRY AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
