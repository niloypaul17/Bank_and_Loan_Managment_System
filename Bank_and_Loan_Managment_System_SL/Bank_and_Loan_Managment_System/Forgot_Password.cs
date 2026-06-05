using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Bank_and_Loan_Managment_System
{
    public partial class Forgot_Password : Form
    {
        SqlConnection c;
        int ids, idsav, idemp;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public Forgot_Password()
        {
            InitializeComponent();
            NPASSbox.UseSystemPasswordChar = true;
            CNPASSbox.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            string Pnumber, Id;
            Pnumber = PNBOX.Text;
            Id = IDBOX.Text;
            if ((PNBOX.Text != "" && IDBOX.Text != "") && (CNPASSbox.Text == NPASSbox.Text && CNPASSbox.Text.Length >7) && PasswordStrength(CNPASSbox.Text)==4)
            {
                try
                {
                    string QuerrySTU = "SELECT * FROM Student_Info WHERE Student_Account_ID= '" + IDBOX.Text + "'";
                    string QuerrySAV = "SELECT * FROM Savings_Info WHERE Savings_ID= '" + IDBOX.Text + "'";
                    string QuerryEMP = "SELECT * FROM Employee_Info WHERE Employee_ID= '" + IDBOX.Text + "'";
                    SqlDataAdapter adapterSTU = new SqlDataAdapter(QuerrySTU, c);
                    SqlDataAdapter adapterSAV = new SqlDataAdapter(QuerrySAV, c);
                    SqlDataAdapter adapterEMP = new SqlDataAdapter(QuerryEMP, c);

                    DataTable DSTU = new DataTable();
                    DataTable DSAV = new DataTable();
                    DataTable DEMP = new DataTable();

                    adapterSTU.Fill(DSTU);
                    adapterSAV.Fill(DSAV);
                    adapterEMP.Fill(DEMP);

                    if (DSTU.Rows.Count > 0)
                    {
                        SqlCommand s1 = new SqlCommand("SELECT User_Id FROM Student_Info WHERE Student_Account_ID= '" + IDBOX.Text + "'", c);
                        SqlDataReader r1 = s1.ExecuteReader();

                        while (r1.Read())
                        {
                            ids=int.Parse(r1.GetValue(0).ToString());
                        }
                        r1.Close();
                        SqlCommand sqlstU = new SqlCommand("UPDATE User_INFO SET Password=@pass WHERE User_Id='" + ids + "'", c);
                        sqlstU.Parameters.AddWithValue("@pass", CNPASSbox.Text);

                        sqlstU.ExecuteNonQuery();

                        MessageBox.Show("Your Password has been updated!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else if (DSAV.Rows.Count > 0)
                    {
                        SqlCommand s1 = new SqlCommand("SELECT User_Id FROM Savings_Info WHERE Savings_ID= '" + IDBOX.Text + "'", c);
                        SqlDataReader r1 = s1.ExecuteReader();

                        while (r1.Read())
                        {
                            idsav = int.Parse(r1.GetValue(0).ToString());
                        }
                        r1.Close();
                        SqlCommand sqlsaV = new SqlCommand("UPDATE User_INFO SET Password=@pass WHERE User_Id='" + idsav + "'", c);
                        sqlsaV.Parameters.AddWithValue("@pass", CNPASSbox.Text);

                        sqlsaV.ExecuteNonQuery();

                        MessageBox.Show("Your Password has been updated!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else if (DEMP.Rows.Count > 0)
                    {
                        SqlCommand s1 = new SqlCommand("SELECT User_Id FROM Employee_Info WHERE Employee_ID= '" + IDBOX.Text + "'", c);
                        SqlDataReader r1 = s1.ExecuteReader();

                        while (r1.Read())
                        {
                            idemp = int.Parse(r1.GetValue(0).ToString());
                        }
                        r1.Close();
                        SqlCommand sqlstU = new SqlCommand("UPDATE User_INFO SET Password=@pass WHERE User_Id='" + idemp + "'", c);
                        sqlstU.Parameters.AddWithValue("@pass", CNPASSbox.Text);

                        sqlstU.ExecuteNonQuery();

                        MessageBox.Show("Your Password has been updated!", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("NO MACHING ID OR PHONE NUMBER FOUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    c.Close();
                }
                catch
                {
                    MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (PNBOX.Text == "" && IDBOX.Text == "")
            {
                MessageBox.Show("INPUT PHONE NUMBER AND ACCOUNT ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PNBOX.Text == "")
            {
                MessageBox.Show("INPUT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (IDBOX.Text == "")
            {
                MessageBox.Show("INPUT ACCOUNT ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(NPASSbox.Text != CNPASSbox.Text)
            {
                MessageBox.Show("NEW PASSWORD DONT MACTH CONFIRME PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(CNPASSbox.Text.Length < 8)
            {
                MessageBox.Show("NEW PASSWORD'S LENGTH SHOULD BE MINIMUM 8", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordStrength(CNPASSbox.Text) != 4)
            {
                MessageBox.Show("YOUR PASSWORD MUST CONTAIN NUMBERS, UPPER AND LOWER CHARECTERS AND A SIMBOL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NPASSbox_TextChanged(object sender, EventArgs e)
        {
            if (NPASSbox.Text.Length < 8 || PasswordStrength(NPASSbox.Text) != 4)
            {
                NPASSbox.BackColor = Color.IndianRed;
                NPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");

            }
            else
            {
                NPASSbox.BackColor = Color.White;
                NPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }

        private void CNPASSbox_TextChanged(object sender, EventArgs e)
        {
            if ((CNPASSbox.Text != NPASSbox.Text || CNPASSbox.Text=="") || CNPASSbox.Text.Length <8 || PasswordStrength(CNPASSbox.Text) != 4)
            {
                CNPASSbox.BackColor = Color.IndianRed;
                CNPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                CNPASSbox.BackColor = Color.White;
                CNPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                NPASSbox.UseSystemPasswordChar = false;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                NPASSbox.UseSystemPasswordChar = true;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                CNPASSbox.UseSystemPasswordChar = false;
                pictureBox1.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                CNPASSbox.UseSystemPasswordChar = true;
                pictureBox1.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private int PasswordStrength(string password)
        {
            int n = 0;
            int leng = password.Length;
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                n++;
            }
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                n++;
            }
            if (Regex.IsMatch(password, @"\d"))
            {
                n++;
            }
            if (Regex.IsMatch(password, @"[^\w]"))
            {
                n++;
            }
            return n;
        }
    }
}
