using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Bank_and_Loan_Managment_System
{
    public partial class LOAN_Page : Form
    {
        SqlConnection c;
        string FPPB, FPP;
        int idd;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        DateTime date = DateTime.Now;
        public LOAN_Page()
        {
            InitializeComponent();
            CONFPassbox.UseSystemPasswordChar = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil1 = new OpenFileDialog();
            fil1.ShowDialog();
            FPPB=fil1.FileName;
            PASSPORTbox.Text = fil1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog fil2 = new OpenFileDialog();
            fil2.ShowDialog();
            FPP=fil2.FileName;
            Proofbox.Text = fil2.FileName;
        }

        private void Amountbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void LOAN_Page_Load(object sender, EventArgs e)
        {
            PASSPORTbox.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IDBOX.Text != "" && PHNBOX.Text != "" && CONFPassbox.Text != "" && PASSPORTbox.Text != "" && Amountbox.Text != "")
                {
                    if (int.Parse(Amountbox.Text) >= 10000 && int.Parse(Amountbox.Text) <= 100000)
                    {
                        sqlconnectionM();
                        SqlCommand sql1 = new SqlCommand("SELECT User_Id FROM Student_Info WHERE Student_Account_ID='" + IDBOX.Text + "'", c);
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

                        DataTable DSTU = new DataTable();

                        adapterSTU.Fill(DSTU);


                        if (DSTU.Rows.Count > 0 && d1.Rows.Count > 0)
                        {
                            string id;
                            Loan loan = new Loan();
                            id = loan.ID_Loan();
                            SqlCommand sql = new SqlCommand("INSERT INTO LOAN_INFO(LOAN_ID, LOAN_INTEREST, LOAN_AMOUNT, LOAN_VALIDITY, PHONE_NUMBER, PASSWORD, STATUS, User_Id) VALUES (@LID, @LIN, @LAM, @LV, @PN, @PASS, @ST, @ID)", c);
                            sql.Parameters.AddWithValue("@LID", id);
                            sql.Parameters.AddWithValue("@LIN", "7%");
                            sql.Parameters.AddWithValue("@LAM", float.Parse(Amountbox.Text));
                            sql.Parameters.AddWithValue("@LV", "4 YEARS");
                            sql.Parameters.AddWithValue("PN", PHNBOX.Text);
                            sql.Parameters.AddWithValue("@PASS", CONFPassbox.Text);
                            sql.Parameters.AddWithValue("@ST", "PENDING");
                            sql.Parameters.AddWithValue("@ID", idd);
                            sql.ExecuteNonQuery();

                            SqlCommand sql2 = new SqlCommand("INSERT INTO LOAN_STUDENT(Student_Id, Passport_copy_Birth_certificat_copy_path,  Proof_Of_Address_Path, LOAN_ID) VALUES('" + IDBOX.Text + "','" + FPPB + "', '" + FPP + "', '" + id + "')", c);
                            SqlDataReader sqlDataReader = sql2.ExecuteReader();

                            MessageBox.Show("YOUR LOAN REQUEST IS SUBMITTED! YOUR REQUEST STATUS IS PENDING", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            IDBOX.Clear();
                            CONFPassbox.Clear();
                            PHNBOX.Clear();
                            Amountbox.Clear();
                            PASSPORTbox.Clear();
                            Proofbox.Clear();
                        }
                        else
                        {
                            MessageBox.Show("INVALID PHONE NUMBER OR PASSWORD OR ACCOUNT ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            IDBOX.Clear();
                            CONFPassbox.Clear();
                            PHNBOX.Clear();
                            Amountbox.Clear();
                            PASSPORTbox.Clear();
                            Proofbox.Clear();
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
                else if (PASSPORTbox.Text == "")
                {
                    MessageBox.Show("INPUT Passport copy/ Birth certificat copy", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Amountbox.Text == "")
                {
                    MessageBox.Show("INSERT AMOUNT ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
