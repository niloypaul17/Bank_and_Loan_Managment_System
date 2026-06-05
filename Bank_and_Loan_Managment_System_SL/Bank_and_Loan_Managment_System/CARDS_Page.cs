using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_and_Loan_Managment_System
{
    public partial class CARDS_Page : Form
    {
        SqlConnection c;
        private string PN, PASS, id, id_m;
        int idS, idSAV, idEMP;
        public CARDS_Page()
        {
            InitializeComponent();
            CONFPassbox.UseSystemPasswordChar = true;
        }
        DateTime d1 = DateTime.Now;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }

        public CARDS_Page(string pnn, string pass)
        {
            InitializeComponent();
            CONFPassbox.UseSystemPasswordChar = true;
            PN = pnn;
            PASS = pass;
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
            
            string IDBOX, PASSBOX;
            IDBOX = textBox1.Text;
            PASSBOX = CONFPassbox.Text;
            if (radioButton2.Checked == true)
            {

                sqlconnectionM();


                string QuerrySTU = "SELECT User_Id FROM Student_Info WHERE Student_Account_ID='" + IDBOX + "'";
                string QuerrySAV = "SELECT User_Id FROM Savings_Info WHERE Savings_ID='" + IDBOX + "'";
                string QuerryEMP = "SELECT User_Id FROM Employee_Info WHERE Employee_ID='" + IDBOX + "'";
                SqlDataAdapter adapterSTU = new SqlDataAdapter(QuerrySTU, c);
                SqlDataAdapter adapterSAV = new SqlDataAdapter(QuerrySAV, c);
                SqlDataAdapter adapterEMP = new SqlDataAdapter(QuerryEMP, c);

                DataTable DSTU = new DataTable();
                DataTable DSAV = new DataTable();
                DataTable DEMP = new DataTable();

                adapterSTU.Fill(DSTU);
                adapterSAV.Fill(DSAV);
                adapterEMP.Fill(DEMP);

                SqlCommand s1 = new SqlCommand(QuerrySTU, c);
                SqlCommand s2 = new SqlCommand(QuerrySAV, c);
                SqlCommand s3 = new SqlCommand(QuerryEMP, c);
                SqlDataReader r1 = s1.ExecuteReader();
                while (r1.Read())
                {
                    idS = int.Parse(r1.GetValue(0).ToString());
                }
                r1.Close();
                SqlDataReader r2 = s2.ExecuteReader();
                while (r2.Read())
                {
                    idSAV = int.Parse(r2.GetValue(0).ToString());
                }
                r2.Close();
                SqlDataReader r3 = s3.ExecuteReader();
                while (r3.Read())
                {
                    idEMP = int.Parse(r3.GetValue(0).ToString());
                }
                r3.Close();

                string QuerrySTU2 = "SELECT * FROM User_INFO WHERE User_Id='" + idS + "' AND Password='" + CONFPassbox.Text + "'";
                string QuerrySAV2 = "SELECT * FROM User_INFO WHERE User_Id='" + idSAV + "' AND Password='" + CONFPassbox.Text + "'";
                string QuerryEMP2 = "SELECT * FROM User_INFO WHERE User_Id='" + idEMP + "'  AND Password='" + CONFPassbox.Text + "'";
                SqlDataAdapter adapterSTU2 = new SqlDataAdapter(QuerrySTU2, c);
                SqlDataAdapter adapterSAV2 = new SqlDataAdapter(QuerrySAV2, c);
                SqlDataAdapter adapterEMP2 = new SqlDataAdapter(QuerryEMP2, c);

                DataTable DSTU2 = new DataTable();
                DataTable DSAV2 = new DataTable();
                DataTable DEMP2 = new DataTable();

                adapterSTU2.Fill(DSTU2);
                adapterSAV2.Fill(DSAV2);
                adapterEMP2.Fill(DEMP2);

                if (DSTU.Rows.Count > 0 && DSTU2.Rows.Count >0)
                {
                    SqlCommand sqlcardstu = new SqlCommand("SELECT Student_Account_ID FROM Student_Info WHERE Student_Account_ID='" + IDBOX + "'", c);
                    SqlDataReader sqlSTUC = sqlcardstu.ExecuteReader();

                    while (sqlSTUC.Read())
                    {
                        id = sqlSTUC.GetValue(0).ToString();
                    }

                    sqlSTUC.Close();
                    Card c1 = new Card();
                    id_m = c1.Card_Number;
                    SqlCommand sqlSTUCset = new SqlCommand("INSERT INTO CARDS_Info(Card_Number, Card_Type, Card_Validity, Card_Issue_Date, Account_ID, User_Id) VALUES(@CN,@CT,@CV,@CID,@AID, @ID)", c);
                    sqlSTUCset.Parameters.AddWithValue("@CN", id_m);
                    sqlSTUCset.Parameters.AddWithValue("@CT", "DEBIT");
                    sqlSTUCset.Parameters.AddWithValue("@CV", d1.AddYears(5).ToString());
                    sqlSTUCset.Parameters.AddWithValue("@CID", d1.ToString());
                    sqlSTUCset.Parameters.AddWithValue("@AID", id);
                    sqlSTUCset.Parameters.AddWithValue("@ID", idS);

                    sqlSTUCset.ExecuteNonQuery();

                    MessageBox.Show($"YOUR CARD ID SUCCESSFULLY REGISTRARED ! YOUR CARD NUMBER IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton1.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
                else if (DSAV.Rows.Count > 0 && DSAV2.Rows.Count >0)
                {
                    SqlCommand sqlcardstu = new SqlCommand("SELECT Savings_ID FROM Savings_Info WHERE Savings_ID='" + IDBOX + "'", c);
                    SqlDataReader sqlSTUC = sqlcardstu.ExecuteReader();

                    while (sqlSTUC.Read())
                    {
                        id = sqlSTUC.GetValue(0).ToString();
                    }

                    sqlSTUC.Close();
                    Card c1 = new Card();
                    id_m = c1.Card_Number;
                    SqlCommand sqlSTUCset = new SqlCommand("INSERT INTO CARDS_Info(Card_Number, Card_Type, Card_Validity, Card_Issue_Date, Account_ID, User_Id) VALUES(@CN, @CT, @CV, @CID, @AID, @ID)", c);
                    sqlSTUCset.Parameters.AddWithValue("@CN", id_m);
                    sqlSTUCset.Parameters.AddWithValue("@CT", "DEBIT");
                    sqlSTUCset.Parameters.AddWithValue("@CV", d1.AddYears(5).ToString());
                    sqlSTUCset.Parameters.AddWithValue("@CID", d1.ToString());
                    sqlSTUCset.Parameters.AddWithValue("@AID", id);
                    sqlSTUCset.Parameters.AddWithValue("@ID", idSAV);

                    sqlSTUCset.ExecuteNonQuery();
                    MessageBox.Show($"YOUR CARD ID SUCCESSFULLY REGISTRARED ! YOUR CARD NUMBER IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton1.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
                else if (DEMP.Rows.Count > 0 && DEMP2.Rows.Count >0)
                {
                    SqlCommand sqlcardstu = new SqlCommand("SELECT Employee_ID FROM Employee_Info WHERE Employee_ID='" + IDBOX + "'", c);
                    SqlDataReader sqlSTUC = sqlcardstu.ExecuteReader();

                    while (sqlSTUC.Read())
                    {
                        id = sqlSTUC.GetValue(0).ToString();
                    }

                    sqlSTUC.Close();
                    Card c1 = new Card();
                    id_m = c1.Card_Number;
                    SqlCommand sqlSTUCset = new SqlCommand("INSERT INTO CARDS_Info(Card_Number, Card_Type, Card_Validity, Card_Issue_Date, Account_ID, User_Id) VALUES(@CN, @CT, @CV, @CID, @AID, @ID)", c);
                    sqlSTUCset.Parameters.AddWithValue("@CN", id_m);
                    sqlSTUCset.Parameters.AddWithValue("@CT", "DEBIT");
                    sqlSTUCset.Parameters.AddWithValue("@CV", d1.AddYears(5).ToString());
                    sqlSTUCset.Parameters.AddWithValue("@CID", d1.ToString());
                    sqlSTUCset.Parameters.AddWithValue("@AID", id);
                    sqlSTUCset.Parameters.AddWithValue("@ID", idEMP);

                    sqlSTUCset.ExecuteNonQuery();
                    MessageBox.Show($"YOUR CARD ID SUCCESSFULLY REGISTRARED ! YOUR CARD NUMBER IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton1.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
                else
                {
                    MessageBox.Show("INVALID PHONE NUMBER OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    radioButton1.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
                c.Close();
            }
            else if (radioButton1.Checked == true)
            {


                sqlconnectionM();

                string QuerrySTU = "SELECT User_Id FROM Student_Info WHERE Student_Account_ID='" + IDBOX + "'";
                string QuerrySAV = "SELECT User_Id FROM Savings_Info WHERE Savings_ID='" + IDBOX + "'";
                string QuerryEMP = "SELECT User_Id FROM Employee_Info WHERE Employee_ID='" + IDBOX + "'";
                SqlDataAdapter adapterSTU = new SqlDataAdapter(QuerrySTU, c);
                SqlDataAdapter adapterSAV = new SqlDataAdapter(QuerrySAV, c);
                SqlDataAdapter adapterEMP = new SqlDataAdapter(QuerryEMP, c);

                DataTable DSTU = new DataTable();
                DataTable DSAV = new DataTable();
                DataTable DEMP = new DataTable();

                adapterSTU.Fill(DSTU);
                adapterSAV.Fill(DSAV);
                adapterEMP.Fill(DEMP);

                SqlCommand s1 = new SqlCommand(QuerrySTU, c);
                SqlCommand s2 = new SqlCommand(QuerrySAV, c);
                SqlCommand s3 = new SqlCommand(QuerryEMP, c);
                SqlDataReader r1 = s1.ExecuteReader();
                while (r1.Read())
                {
                    idS = int.Parse(r1.GetValue(0).ToString());
                }
                r1.Close();
                SqlDataReader r2 = s2.ExecuteReader();
                while (r2.Read())
                {
                    idSAV = int.Parse(r2.GetValue(0).ToString());
                }
                r2.Close();
                SqlDataReader r3 = s3.ExecuteReader();
                while (r3.Read())
                {
                    idEMP = int.Parse(r3.GetValue(0).ToString());
                }
                r3.Close();

                string QuerrySTU2 = "SELECT * FROM User_INFO WHERE User_Id='" + idS + "' AND Password='" + CONFPassbox.Text + "'";
                string QuerrySAV2 = "SELECT * FROM User_INFO WHERE User_Id='" + idSAV + "' AND Password='" + CONFPassbox.Text + "'";
                string QuerryEMP2 = "SELECT * FROM User_INFO WHERE User_Id='" + idEMP + "'  AND Password='" + CONFPassbox.Text + "'";
                SqlDataAdapter adapterSTU2 = new SqlDataAdapter(QuerrySTU2, c);
                SqlDataAdapter adapterSAV2 = new SqlDataAdapter(QuerrySAV2, c);
                SqlDataAdapter adapterEMP2 = new SqlDataAdapter(QuerryEMP2, c);

                DataTable DSTU2 = new DataTable();
                DataTable DSAV2 = new DataTable();
                DataTable DEMP2 = new DataTable();

                adapterSTU2.Fill(DSTU2);
                adapterSAV2.Fill(DSAV2);
                adapterEMP2.Fill(DEMP2);

                if (DSTU.Rows.Count > 0 && DSTU2.Rows.Count >0)
                {
                    MessageBox.Show("STUDENT ACCOUNT HOLDER CAN NOT GET ANY CREDIT CARD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    radioButton2.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }

                else if (DSAV.Rows.Count > 0 && DSAV2.Rows.Count >0)
                {
                    SqlCommand sqlcardstu = new SqlCommand("SELECT Savings_ID FROM Savings_Info WHERE Savings_ID='" + IDBOX + "'", c);
                    SqlDataReader sqlSTUC = sqlcardstu.ExecuteReader();

                    while (sqlSTUC.Read())
                    {
                        id = sqlSTUC.GetValue(0).ToString();
                    }

                    sqlSTUC.Close();
                    Card c1 = new Card();
                    id_m = c1.Card_Number;
                    SqlCommand sqlSTUCset = new SqlCommand("INSERT INTO CARDS_Info(Card_Number, Card_Type, Card_Validity, Card_Issue_Date, Account_ID, User_Id) VALUES(@CN, @CT, @CV, @CID, @AID, @ID)", c);
                    sqlSTUCset.Parameters.AddWithValue("@CN", id_m);
                    sqlSTUCset.Parameters.AddWithValue("@CT", "CREDIT");
                    sqlSTUCset.Parameters.AddWithValue("@CV", d1.AddYears(5).ToString());
                    sqlSTUCset.Parameters.AddWithValue("@CID", d1.ToString());
                    sqlSTUCset.Parameters.AddWithValue("@AID", id);
                    sqlSTUCset.Parameters.AddWithValue("@ID", idSAV);

                    sqlSTUCset.ExecuteNonQuery();
                    MessageBox.Show($"YOUR CARD ID SUCCESSFULLY REGISTRARED ! YOUR CARD NUMBER IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton2.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }

                else if (DEMP.Rows.Count > 0 && DEMP2.Rows.Count >0)
                {
                    SqlCommand sqlcardstu = new SqlCommand("SELECT Employee_ID FROM Employee_Info WHERE Employee_ID='" + IDBOX + "'", c);
                    SqlDataReader sqlSTUC = sqlcardstu.ExecuteReader();

                    while (sqlSTUC.Read())
                    {
                        id = sqlSTUC.GetValue(0).ToString();
                    }

                    sqlSTUC.Close();
                    Card c1 = new Card();
                    id_m = c1.Card_Number;
                    SqlCommand sqlSTUCset = new SqlCommand("INSERT INTO CARDS_Info(Card_Number, Card_Type, Card_Validity, Card_Issue_Date, Account_ID, User_Id) VALUES(@CN, @CT, @CV, @CID, @AID, @ID)", c);
                    sqlSTUCset.Parameters.AddWithValue("@CN", id_m);
                    sqlSTUCset.Parameters.AddWithValue("@CT", "CREDIT");
                    sqlSTUCset.Parameters.AddWithValue("@CV", d1.AddYears(5).ToString());
                    sqlSTUCset.Parameters.AddWithValue("@CID", d1.ToString());
                    sqlSTUCset.Parameters.AddWithValue("@AID", id);
                    sqlSTUCset.Parameters.AddWithValue("@ID", idEMP);

                    sqlSTUCset.ExecuteNonQuery();
                    MessageBox.Show($"YOUR CARD ID SUCCESSFULLY REGISTRARED ! YOUR CARD NUMBER IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton2.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
                else
                {
                    MessageBox.Show("INVALID PHONE NUMBER OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    radioButton2.Checked = false;
                    textBox1.Clear();
                    CONFPassbox.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
