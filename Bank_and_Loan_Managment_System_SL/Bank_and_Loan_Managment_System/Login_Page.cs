using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_and_Loan_Managment_System
{
    public partial class Form1 : Form
    {
        SqlConnection c;

        private string ID, FN, MD, LN, EMAIL, NID, DIV,DIS,STR,PN, GEN, DOB, ST, CURRT, STID, EDLEV, JDATE, DESKNO, BRANCH, occ, tin;
        int ids, idsav, idemp,idS,idSAV,idEMP;
        float BALANCE;
        private void Form1_Load(object sender, EventArgs e)
        {
            PASSbox.UseSystemPasswordChar = true;
            warningbox.Hide();
            warningbox.Enabled=false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Forgot_Password forgot_Password = new Forgot_Password();
            forgot_Password.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            CARD_INFORMATION_Page cARD_INFORMATION_Page = new CARD_INFORMATION_Page();
            cARD_INFORMATION_Page.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PNbox_Enter(object sender, EventArgs e)
        {

        }

        private void PNbox_Leave(object sender, EventArgs e)
        {

        }

        private void PASSbox_Enter(object sender, EventArgs e)
        {
    
        }

        private void PASSbox_Leave(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            ADMIN_LOGIN_PAGE admin = new ADMIN_LOGIN_PAGE(this);
            this.Hide();
            admin.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            RegPage registration_Page = new RegPage();
            registration_Page.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN_LOGIN_PAGE admin=new ADMIN_LOGIN_PAGE(this);
            this.Hide();
            admin.Show();
        }

        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Full, ADD;
            sqlconnectionM();
            string Idd, Pass;

            if (IDbox.Text != "" && PASSbox.Text != "")
            {
                Idd = IDbox.Text;
                Pass = PASSbox.Text;
                try
                {
                    string QuerrySTU = "SELECT User_Id FROM Student_Info WHERE Student_Account_ID='" + IDbox.Text + "'";
                    string QuerrySAV = "SELECT User_Id FROM Savings_Info WHERE Savings_ID='" + IDbox.Text + "'";
                    string QuerryEMP = "SELECT User_Id FROM Employee_Info WHERE Employee_ID='" + IDbox.Text + "'";
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

                    string QuerrySTU2 = "SELECT * FROM User_INFO WHERE User_Id='" + idS + "' AND Password='" + PASSbox.Text + "'";
                    string QuerrySAV2 = "SELECT * FROM User_INFO WHERE User_Id='" + idSAV + "' AND Password='" + PASSbox.Text + "'";
                    string QuerryEMP2 = "SELECT * FROM User_INFO WHERE User_Id='" + idEMP + "'  AND Password='" + PASSbox.Text + "'";
                    SqlDataAdapter adapterSTU2 = new SqlDataAdapter(QuerrySTU2, c);
                    SqlDataAdapter adapterSAV2 = new SqlDataAdapter(QuerrySAV2, c);
                    SqlDataAdapter adapterEMP2 = new SqlDataAdapter(QuerryEMP2, c);

                    DataTable DSTU2 = new DataTable();
                    DataTable DSAV2 = new DataTable();
                    DataTable DEMP2 = new DataTable();

                    adapterSTU2.Fill(DSTU2);
                    adapterSAV2.Fill(DSAV2);
                    adapterEMP2.Fill(DEMP2);

                    if (DSTU.Rows.Count > 0 && DSTU2.Rows.Count > 0)
                    {

                        Idd = IDbox.Text;
                        Pass = PASSbox.Text;
                        SqlCommand com0 = new SqlCommand("SELECT Student_Account_ID, Education_Level,Current_Institution, Student_id, User_Id FROM Student_Info WHERE Student_Account_ID='" + IDbox.Text + "'", c);
                        SqlDataReader r22 = com0.ExecuteReader();

                        while (r22.Read())
                        {
                            ID = r22.GetValue(0).ToString();
                            EDLEV = r22.GetValue(1).ToString();
                            CURRT = r22.GetValue(2).ToString();
                            STID = r22.GetValue(3).ToString();
                            ids = int.Parse(r22.GetValue(4).ToString());
                        }
                        r22.Close();

                        SqlCommand com = new SqlCommand("SELECT First_Name, Middle_Name, Last_Name, Balance, Phone_Number, Email, National_id, Division, District, Street, Gender, Date_of_Birth, Status  FROM User_INFO WHERE User_Id='" + ids + "'", c);
                        SqlDataReader STAC = com.ExecuteReader();

                        while (STAC.Read())
                        {
                            FN = STAC.GetValue(0).ToString();
                            MD = STAC.GetValue(1).ToString();
                            LN = STAC.GetValue(2).ToString();
                            BALANCE = float.Parse(STAC.GetValue(3).ToString());
                            PN = STAC.GetValue(4).ToString();
                            EMAIL = STAC.GetValue(5).ToString();
                            NID = STAC.GetValue(6).ToString();
                            DIV = STAC.GetValue(7).ToString();
                            DIS = STAC.GetValue(8).ToString();
                            STR = STAC.GetValue(9).ToString();
                            GEN = STAC.GetValue(10).ToString();
                            DOB = STAC.GetValue(11).ToString();
                            ST = STAC.GetValue(12).ToString();
                        }
                        Full = FN + " " + MD + " " + LN;
                        ADD = STR + "," + DIS + "," + DIV;
                        STUDENT_page sTUDENT_Page = new STUDENT_page(Full, ID, string.Format($"{BALANCE:F2}"), NID, ADD, EMAIL, GEN, PN, DOB, ST, this, Pass, CURRT, EDLEV, STID, ids);
                        IDbox.Clear();
                        PASSbox.Clear();
                        sTUDENT_Page.Show();
                        this.Hide();
                    }
                    else if (DSAV.Rows.Count > 0 && DSAV2.Rows.Count > 0)
                    {
                        Idd = IDbox.Text;
                        Pass = PASSbox.Text;

                        SqlCommand com0 = new SqlCommand("SELECT Savings_ID, Occupation, TINnumber, User_Id FROM Savings_Info WHERE Savings_ID='" + IDbox.Text + "'", c);
                        SqlDataReader r22 = com0.ExecuteReader();

                        while (r22.Read())
                        {
                            ID = r22.GetValue(0).ToString();
                            occ = r22.GetValue(1).ToString();
                            tin = r22.GetValue(2).ToString();
                            idsav = int.Parse(r22.GetValue(3).ToString());
                        }
                        r22.Close();

                        SqlCommand com = new SqlCommand("SELECT First_Name, Middle_Name, Last_Name, Balance, Phone_Number, Email, National_id, Division, District, Street, Gender, Date_of_Birth, Status FROM User_INFO WHERE User_Id='" + idsav + "'", c);
                        SqlDataReader STAC = com.ExecuteReader();

                        while (STAC.Read())
                        {
                            FN = STAC.GetValue(0).ToString();
                            MD = STAC.GetValue(1).ToString();
                            LN = STAC.GetValue(2).ToString();
                            BALANCE = float.Parse(STAC.GetValue(3).ToString());
                            PN = STAC.GetValue(4).ToString();
                            EMAIL = STAC.GetValue(5).ToString();
                            NID = STAC.GetValue(6).ToString();
                            DIV = STAC.GetValue(7).ToString();
                            DIS = STAC.GetValue(8).ToString();
                            STR = STAC.GetValue(9).ToString();
                            GEN = STAC.GetValue(10).ToString();
                            DOB = STAC.GetValue(11).ToString();
                            ST = STAC.GetValue(12).ToString();
                        }

                        Full = FN + " " + MD + " " + LN;
                        ADD = STR + "," + DIS + "," + DIV;
                        SAVINGS_Page sAVINGS = new SAVINGS_Page(Full, ID, string.Format($"{BALANCE:F2}", BALANCE), NID, ADD, EMAIL, GEN, PN, DOB, ST, this, Pass, occ, tin, idsav);
                        IDbox.Clear();
                        PASSbox.Clear();
                        sAVINGS.Show();
                        this.Hide();
                    }
                    else if (DEMP.Rows.Count > 0 && DEMP2.Rows.Count > 0)
                    {
                        Idd = IDbox.Text;
                        Pass = PASSbox.Text;

                        SqlCommand com0 = new SqlCommand("SELECT Employee_ID, Joinning_Date, Branch_Name, Desk_Name, User_Id FROM Employee_Info WHERE Employee_ID='" + IDbox.Text + "'", c);
                        SqlDataReader r22 = com0.ExecuteReader();

                        while (r22.Read())
                        {
                            ID = r22.GetValue(0).ToString();
                            JDATE = r22.GetValue(1).ToString();
                            BRANCH = r22.GetValue(2).ToString();
                            DESKNO = r22.GetValue(3).ToString();
                            idemp = int.Parse(r22.GetValue(4).ToString());
                        }
                        r22.Close();

                        SqlCommand com = new SqlCommand("SELECT First_Name, Middle_Name, Last_Name, Balance, Phone_Number, Email, National_id, Division, District, Street, Gender, Date_of_Birth, Status  FROM User_INFO WHERE User_Id='" + idemp + "'", c);
                        SqlDataReader STAC = com.ExecuteReader();

                        while (STAC.Read())
                        {
                            FN = STAC.GetValue(0).ToString();
                            MD = STAC.GetValue(1).ToString();
                            LN = STAC.GetValue(2).ToString();
                            BALANCE = float.Parse(STAC.GetValue(3).ToString());
                            PN = STAC.GetValue(4).ToString();
                            EMAIL = STAC.GetValue(5).ToString();
                            NID = STAC.GetValue(6).ToString();
                            DIV = STAC.GetValue(7).ToString();
                            DIS = STAC.GetValue(8).ToString();
                            STR = STAC.GetValue(9).ToString();
                            GEN = STAC.GetValue(10).ToString();
                            DOB = STAC.GetValue(11).ToString();
                            ST = STAC.GetValue(12).ToString();
                        }

                        Full = FN + " " + MD + " " + LN;
                        ADD = STR + "," + DIS + "," + DIV;
                        EMPLOYEE_Page eMPLOYEE = new EMPLOYEE_Page(Full, ID, string.Format($"{BALANCE:F2}", BALANCE), NID, ADD, EMAIL, GEN, PN, DOB, ST, this, Pass, JDATE, BRANCH, DESKNO, idemp);
                        IDbox.Clear();
                        PASSbox.Clear();
                        eMPLOYEE.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("INVALID ACCOUNT ID OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        warningbox.Hide();
                        IDbox.Clear();
                        PASSbox.Clear();
                    }
                    c.Close();
                }
                catch
                {
                    MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (IDbox.Text == "" & PASSbox.Text == "")
            {
                warningbox.Text = " Account ID and Password is required";
                warningbox.Show();
            }
            else if (IDbox.Text == "")
            {
                warningbox.Text = " Account ID is required";
                warningbox.Show();
            }
            else if (PASSbox.Text == "")
            {
                warningbox.Text = " Password is required";
                warningbox.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegPage registration_Page = new RegPage();
            registration_Page.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
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

        private void PASSbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CARD_INFORMATION_Page cARD_INFORMATION_Page = new CARD_INFORMATION_Page();
            cARD_INFORMATION_Page.Show();
        }
    }
}
