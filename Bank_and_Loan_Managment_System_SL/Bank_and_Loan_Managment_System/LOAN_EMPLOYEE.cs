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
using static System.Net.WebRequestMethods;

namespace Bank_and_Loan_Managment_System
{
    public partial class LOAN_EMPLOYEE : Form
    {
        SqlConnection c;
        string FPPB, FPP, FPPC, Interest_Rate;
        int idd;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public LOAN_EMPLOYEE()
        {
            InitializeComponent();
            CONFPassbox.UseSystemPasswordChar = true;
            SALBOX.ReadOnly = true;
            INCBOX.ReadOnly = true;
            COMPBOX.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil1 = new OpenFileDialog();
            fil1.ShowDialog();
            FPPB = fil1.FileName;
            SALBOX.Text = fil1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil2 = new OpenFileDialog();
            fil2.ShowDialog();
            FPP = fil2.FileName;
            INCBOX.Text = fil2.FileName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil3 = new OpenFileDialog();
            fil3.ShowDialog();
            FPPC = fil3.FileName;
            COMPBOX.Text = fil3.FileName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                CONFPassbox.UseSystemPasswordChar = false;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                CONFPassbox.UseSystemPasswordChar = true;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDBOX.Text != "" && PHNBOX.Text != "" && CONFPassbox.Text != "" && SALBOX.Text != "" && INCBOX.Text != "" && COMPBOX.Text != "" && Amountbox.Text != "")
                {
                    if (int.Parse(Amountbox.Text) >= 10000 && int.Parse(Amountbox.Text) <= 500000)
                    {
                        sqlconnectionM();

                        SqlCommand sql1 = new SqlCommand("SELECT User_Id FROM Employee_Info WHERE Employee_ID='" + IDBOX.Text + "'", c);
                        SqlDataReader r12 = sql1.ExecuteReader();
                        while (r12.Read())
                        {
                            idd = int.Parse(r12.GetValue(0).ToString());
                        }
                        r12.Close();
                        SqlDataAdapter a2 = new SqlDataAdapter(sql1);
                        DataTable d1 = new DataTable();
                        a2.Fill(d1);

                        string QuerrySTU = "SELECT * FROM User_INFO WHERE Phone_Number='" + PHNBOX.Text + "' AND Password= '" + CONFPassbox.Text + "' AND User_Id='" + idd + "'";
                        SqlDataAdapter adapterSTU = new SqlDataAdapter(QuerrySTU, c);

                        DataTable DSAV = new DataTable();

                        adapterSTU.Fill(DSAV);

                        if (comboBox1.Text == "5 YEARS")
                        {
                            Interest_Rate = "7%";
                        }
                        else if (comboBox1.Text == "7 YEARS")
                        {
                            Interest_Rate = "10%";
                        }
                        else if (comboBox1.Text == "10 YEARS")
                        {
                            Interest_Rate = "12%";
                        }
                        else if (comboBox1.Text == "15 YEARS")
                        {
                            Interest_Rate = "15%";
                        }

                        if (DSAV.Rows.Count > 0)
                        {
                            string id;
                            Loan loan = new Loan();
                            id = loan.ID_Loan();
                            SqlCommand sql = new SqlCommand("INSERT INTO LOAN_INFO(LOAN_ID, LOAN_INTEREST, LOAN_AMOUNT, LOAN_VALIDITY, PHONE_NUMBER, PASSWORD, STATUS, User_Id) VALUES (@LID, @LIN, @LAM, @LV, @PN, @PASS, @ST, @ID)", c);
                            sql.Parameters.AddWithValue("@LID", id);
                            sql.Parameters.AddWithValue("@LIN", Interest_Rate);
                            sql.Parameters.AddWithValue("@LAM", float.Parse(Amountbox.Text));
                            sql.Parameters.AddWithValue("@LV", comboBox1.Text);
                            sql.Parameters.AddWithValue("PN", PHNBOX.Text);
                            sql.Parameters.AddWithValue("@PASS", CONFPassbox.Text);
                            sql.Parameters.AddWithValue("@ST", "PENDING");
                            sql.Parameters.AddWithValue("@ID", idd);
                            sql.ExecuteNonQuery();

                            SqlCommand sql2 = new SqlCommand("INSERT INTO LOAN_EMPLOYEE_TABLE(Employee_ID, Salary_statement_Pay_slip_Path,  Income_Tex_statement_for_the_last_6_months_Path,Company_Join_Aggrement_Path, LOAN_ID) VALUES('" + IDBOX.Text + "','" + FPPB + "', '" + FPP + "','" + FPPC + "', '" + id + "')", c);
                            SqlDataReader sqlDataReader = sql2.ExecuteReader();

                            MessageBox.Show("YOUR LOAN REQUEST IS SUBMITTED! YOUR REQUEST STATUS IS PENDING", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IDBOX.Clear();
                            CONFPassbox.Clear();
                            PHNBOX.Clear();
                            Amountbox.Clear();
                            SALBOX.Clear();
                            INCBOX.Clear();
                            COMPBOX.Clear();
                        }
                        else
                        {
                            MessageBox.Show("INVALID PHONE NUMBER OR PASSWORD OR ACCOUNT ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            IDBOX.Clear();
                            CONFPassbox.Clear();
                            PHNBOX.Clear();
                            Amountbox.Clear();
                            SALBOX.Clear();
                            INCBOX.Clear();
                            COMPBOX.Clear();
                        }

                        c.Close();
                    }
                    else
                    {
                        MessageBox.Show("INSERT AMOUNT CORRECTLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Amountbox.Clear();
                    }
                }
                else if (IDBOX.Text == "" && PHNBOX.Text == "" && CONFPassbox.Text == "")
                {
                    MessageBox.Show("INPUT ACCOUNT ID AND PHONE NUMBER AND PASSWORD ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (IDBOX.Text == "" && PHNBOX.Text == "")
                {
                    MessageBox.Show("INPUT ACCOUNT ID AND PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (PHNBOX.Text == "" && CONFPassbox.Text == "")
                {
                    MessageBox.Show("INPUT PHONE NUMBER AND PASSWORD ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (IDBOX.Text == "" && CONFPassbox.Text == "")
                {
                    MessageBox.Show("INPUT ACCOUNT ID AND PASSWORD ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (IDBOX.Text == "")
                {
                    MessageBox.Show("INPUT ACCOUNT ID ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (PHNBOX.Text == "")
                {
                    MessageBox.Show("INPUT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (CONFPassbox.Text == "")
                {
                    MessageBox.Show("INPUT PASSWORD ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
