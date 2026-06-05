using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Bank_and_Loan_Managment_System
{
    public partial class RegPage : Form
    {
        SqlConnection c;
        private string gmail = "@gmail.com";
        private string icloud = "@icloud.com";
        private string yahoo = "@yahoo.com";
        private string EmC,EMAIL_M;
        int[] StorE;
        int index,dif, ids, idsav, idemp;
        DateTime date1 = DateTime.Now;
        int d= DateTime.Now.Year;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public RegPage()
        {
            InitializeComponent();
            NPASSbox.UseSystemPasswordChar = true;
            CNPASSbox.UseSystemPasswordChar = true;
        }

        private void Password_Box_TextChanged(object sender, EventArgs e)
        {
            if (NPASSbox.Text.Length < 8 || PasswordStrength(NPASSbox.Text) !=4)
            {
                NPASSbox.BackColor = Color.LightCoral;
                NPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
                
            }
            else
            {
                NPASSbox.BackColor = Color.White;
                NPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (STUbutton.Checked)
            {
                OCCbox.Hide();
                OCClab.Hide();
                TINbox.Hide();
                TINlab.Hide();
                BNbox.Hide();
                BNlab.Hide();
                JDbox.Hide();
                JDlab.Hide();
                DNbox.Hide();
                DNlab.Hide();
                SIDbox.Show();
                SIDeb.Show();
                EDUbox.Show();
                EDUlab.Show();
                INSbox.Show();
                INSlab.Show();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if ( SAVbutton.Checked)
            {
                BNbox.Hide();
                BNlab.Hide();
                JDbox.Hide();
                JDlab.Hide();
                DNbox.Hide();
                DNlab.Hide();
                SIDbox.Hide();
                SIDeb.Hide();
                EDUbox.Hide();
                EDUlab.Hide();
                INSbox.Hide();
                INSlab.Hide();
                OCCbox.Show();
                OCClab.Show();
                TINbox.Show();
                TINlab.Show();
            }
        }

        private void SELECT_btn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    REGPicBox.Image = new Bitmap(openFileDialog.FileName);
                }
            }
            catch
            {
                MessageBox.Show("Please give a proper picture formate! (JPG or PNG)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (EMPbutton.Checked)
            {
                BNbox.Show();
                BNlab.Show();
                JDbox.Show();
                JDlab.Show();
                DNbox.Show();
                DNlab.Show();
                SIDbox.Hide();
                SIDeb.Hide();
                EDUbox.Hide();
                EDUlab.Hide();
                INSbox.Hide();
                INSlab.Hide();
                OCCbox.Hide();
                OCClab.Hide();
                TINbox.Hide();
                TINlab.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BNbox.Clear();
            DNbox.Clear();
            SIDbox.Clear();
            EDUbox.Text = null;
            INSbox.Clear();
            OCCbox.Clear();
            TINbox.Clear();
            FNbox.Clear();
            MNbox.Clear();
            LNbox.Clear();
            Ebox.Clear();
            NIDbox.Clear();
            PNbox.Clear();
            NPASSbox.Clear();
            CNPASSbox.Clear();
            STbox.Clear();
            SIDbox.Hide();
            SIDeb.Hide();
            EDUbox.Hide();
            EDUlab.Hide();
            INSbox.Hide();
            INSlab.Hide();
            OCCbox.Hide();
            OCClab.Hide();
            TINbox.Hide();
            TINlab.Hide();
            BNbox.Hide();
            BNlab.Hide();
            JDbox.Hide();
            JDlab.Hide();
            DNbox.Hide();
            DNlab.Hide();
            GenderCOMBbox.Text = null;
            DIVbox.Text = null;
            Distrbox.Text = null;
            STUbutton.Checked=false;
            SAVbutton.Checked=false;
            EMPbutton.Checked=false;
            REGPicBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\user_D.png");
        }

        private void GENlab_Click(object sender, EventArgs e)
        {

        }

        private void RegPage_Load(object sender, EventArgs e)
        {
            SIDbox.Hide();
            SIDeb.Hide();
            EDUbox.Hide();
            EDUlab.Hide();
            INSbox.Hide();
            INSlab.Hide();
            OCCbox.Hide();
            OCClab.Hide();
            TINbox.Hide();
            TINlab.Hide();
            BNbox.Hide();
            BNlab.Hide();
            JDbox.Hide();
            JDlab.Hide();
            DNbox.Hide();
            DNlab.Hide();
        }

        private void CNPASSbox_TextChanged(object sender, EventArgs e)
        {
            if ((CNPASSbox.Text != NPASSbox.Text || CNPASSbox.Text == "") || CNPASSbox.Text.Length < 8 || PasswordStrength(CNPASSbox.Text) !=4)
            {
                CNPASSbox.BackColor = Color.LightCoral;
                CNPASSpictureBox.Image= new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                CNPASSbox.BackColor = Color.White;
                CNPASSpictureBox.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }

        private void LOGINbutton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            string id_m, gender;
            try
            {
                gender=GenderCOMBbox.Text;

                if (STUbutton.Checked == true)
                {
                    DateTime date = DateTime.Now;
                    Student_Account s = new Student_Account();
                    id_m = s.ID_generater();
                    if (FNbox.Text != "" && LNbox.Text != "" && Ebox.Text != "" && DIVbox.Text != "" && Distrbox.Text != "" && STbox.Text != "" && NIDbox.Text != "" && PNbox.Text != "" && GenderCOMBbox.Text != "" && SIDbox.Text != "" && EDUbox.Text != "" && INSbox.Text != "" && NPASSbox.Text !=""  && CNPASSbox.Text != "" && checkNID()==true && checkPN()==true && ECheck()==true && PasswordStrength(CNPASSbox.Text)==4)
                    {
                        dif= d-DOBbox.Value.Year;
                        if (dif > 17)
                        {
                            if (NPASSbox.Text.Length > 7 && CNPASSbox.Text == NPASSbox.Text)
                            {
                                SqlCommand sql = new SqlCommand("INSERT INTO User_INFO(National_id,First_Name,Middle_Name,Last_Name,Status,Balance,Email,Division,District,Street,Account_Opening_Date,Password,Date_of_Birth,Phone_Number,Gender,Photo) VALUES(@NID,@FN,@MN,@LN,@ST,@BLA,@EM,@DIV,@DIS,@STR,@AOD,@PASS,@DOB,@PN,@GN,@PHO)", c);
                                sql.Parameters.AddWithValue("@NID", NIDbox.Text);
                                sql.Parameters.AddWithValue("@FN", FNbox.Text);
                                sql.Parameters.AddWithValue("@MN", MNbox.Text);
                                sql.Parameters.AddWithValue("@LN", LNbox.Text);
                                sql.Parameters.AddWithValue("@ST", "ACTIVE");
                                sql.Parameters.AddWithValue("@BLA", 0.00);
                                sql.Parameters.AddWithValue("@PHO", getImage());
                                sql.Parameters.AddWithValue("@EM", Ebox.Text.ToLower());
                                sql.Parameters.AddWithValue("@DIV", DIVbox.Text);
                                sql.Parameters.AddWithValue("@DIS", Distrbox.Text);
                                sql.Parameters.AddWithValue("@STR", STbox.Text);
                                sql.Parameters.AddWithValue("@AOD", date);
                                sql.Parameters.AddWithValue("@PASS", CNPASSbox.Text);
                                sql.Parameters.AddWithValue("@DOB", DOBbox.Value);
                                sql.Parameters.AddWithValue("@PN", PNbox.Text);
                                sql.Parameters.AddWithValue("@GN", gender);

                                sql.ExecuteNonQuery();
                                SqlCommand sql2 = new SqlCommand("SELECT User_Id FROM User_INFO WHERE National_id='" + NIDbox.Text + "' AND Phone_Number='"+PNbox.Text+"'", c);
                                SqlDataReader r11= sql2.ExecuteReader();

                                while (r11.Read())
                                {
                                    ids = int.Parse(r11.GetValue(0).ToString());
                                }
                                r11.Close();

                                SqlCommand sql3 = new SqlCommand("INSERT INTO Student_Info(Student_Account_ID, Student_id, Education_Level, Current_Institution, User_Id) VALUES(@SAID, @SID, @EL, @CI, @UID)", c);
                                sql3.Parameters.AddWithValue("@SAID", id_m);
                                sql3.Parameters.AddWithValue("@SID", SIDbox.Text);
                                sql3.Parameters.AddWithValue("@EL",EDUbox.Text);
                                sql3.Parameters.AddWithValue("@CI", INSbox.Text);
                                sql3.Parameters.AddWithValue("@UID", ids);
                                sql3.ExecuteNonQuery();

                                MessageBox.Show($"YOUR REGISTRATION IS SUCSESSFULL ! YOUR ID IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                c.Close();
                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide();
                            }
                            else if(CNPASSbox.Text != NPASSbox.Text)
                            {
                                MessageBox.Show("NEW PASSWORD AND CONFIRME PASSWORD DOSE NOT MATCH", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("PASSWORD MUST BE MINIMUM 8 CHARECTERS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("YOUR AGE SHOULD BE MINIMUM 18", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if(FNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP FIRST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(LNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP LAST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Ebox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(NIDbox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(PNbox.Text == "")
                    {
                        MessageBox.Show("INSURT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkNID() == false)
                    {
                        MessageBox.Show("PROVIDE VALID NID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkPN() == false)
                    {
                        MessageBox.Show("PROVIDE VALID PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(ECheck()== false)
                    {
                        MessageBox.Show("PROVIDE VALID EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(PasswordStrength(CNPASSbox.Text) != 4)
                    {
                        MessageBox.Show("[Password should contain upper and lower case, number, a symbel and minimum 8 charecters ] like. Aa1@", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("FILL UP ALL BOXES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (SAVbutton.Checked == true)
                {
                    DateTime date = DateTime.Now;
                    Savings_Account_Holder sa = new Savings_Account_Holder();
                    id_m = sa.ID_generater();
                    if (FNbox.Text != "" && LNbox.Text != "" && Ebox.Text != "" && DIVbox.Text != "" && Distrbox.Text != "" && STbox.Text != "" && NIDbox.Text != "" && PNbox.Text != "" && GenderCOMBbox.Text != "" && OCCbox.Text != "" && TINbox.Text != "" && NPASSbox.Text != "" && CNPASSbox.Text != "" && checkNID() == true && checkPN() == true && ECheck() == true && PasswordStrength(CNPASSbox.Text) == 4)
                    {
                        dif = d - DOBbox.Value.Year;
                        if (dif > 17)
                        {
                            if (NPASSbox.Text.Length > 7 && CNPASSbox.Text == NPASSbox.Text)
                            {
                                SqlCommand sql = new SqlCommand("INSERT INTO User_INFO(National_id,First_Name,Middle_Name,Last_Name,Status,Balance,Email,Division,District,Street,Account_Opening_Date,Password,Date_of_Birth,Phone_Number,Gender,Photo) VALUES(@NID,@FN,@MN,@LN,@ST,@BLA,@EM,@DIV,@DIS,@STR,@AOD,@PASS,@DOB,@PN,@GN,@PHO)", c);
                                sql.Parameters.AddWithValue("@NID", NIDbox.Text);
                                sql.Parameters.AddWithValue("@FN", FNbox.Text);
                                sql.Parameters.AddWithValue("@MN", MNbox.Text);
                                sql.Parameters.AddWithValue("@LN", LNbox.Text);
                                sql.Parameters.AddWithValue("@ST", "ACTIVE");
                                sql.Parameters.AddWithValue("@BLA", 0.00);
                                sql.Parameters.AddWithValue("@PHO", getImage());
                                sql.Parameters.AddWithValue("@EM", Ebox.Text.ToLower());
                                sql.Parameters.AddWithValue("@DIV", DIVbox.Text);
                                sql.Parameters.AddWithValue("@DIS", Distrbox.Text);
                                sql.Parameters.AddWithValue("@STR", STbox.Text);
                                sql.Parameters.AddWithValue("@AOD", date);
                                sql.Parameters.AddWithValue("@PASS", CNPASSbox.Text);
                                sql.Parameters.AddWithValue("@DOB", DOBbox.Value);
                                sql.Parameters.AddWithValue("@PN", PNbox.Text);
                                sql.Parameters.AddWithValue("@GN", gender);

                                sql.ExecuteNonQuery();

                                SqlCommand sql2 = new SqlCommand("SELECT User_Id FROM User_INFO WHERE National_id='" + NIDbox.Text + "' AND Phone_Number='" + PNbox.Text + "'", c);
                                SqlDataReader r11 = sql2.ExecuteReader();

                                while (r11.Read())
                                {
                                    idsav = int.Parse(r11.GetValue(0).ToString());
                                }
                                r11.Close();

                                SqlCommand sql3 = new SqlCommand("INSERT INTO Savings_Info(Savings_ID, Occupation, TINnumber, User_Id) VALUES(@SAVID, @OCC, @TIN, @UID)", c);
                                sql3.Parameters.AddWithValue("@SAVID", id_m);
                                sql3.Parameters.AddWithValue("@OCC", OCCbox.Text);
                                sql3.Parameters.AddWithValue("@TIN", TINbox.Text);
                                sql3.Parameters.AddWithValue("@UID", idsav);

                                sql3.ExecuteNonQuery();

                                MessageBox.Show($"YOUR REGISTRATION IS SUCSESSFULL  ! YOUR ID IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                c.Close();
                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide();
                            }
                            else if (CNPASSbox.Text != NPASSbox.Text)
                            {
                                MessageBox.Show("NEW PASSWORD AND CONFIRME PASSWORD DOSE NOT MATCH", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("PASSWORD MUST BE MINIMUM 8 CHARECTERS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("YOUR AGE SHOULD BE MINIMUM 18", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else if (FNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP FIRST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (LNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP LAST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Ebox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (NIDbox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (PNbox.Text == "")
                    {
                        MessageBox.Show("INSURT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkNID() == false)
                    {
                        MessageBox.Show("PROVIDE VALID NID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkPN() == false)
                    {
                        MessageBox.Show("PROVIDE VALID PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ECheck() == false)
                    {
                        MessageBox.Show("PROVIDE VALID EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (PasswordStrength(CNPASSbox.Text) != 4)
                    {
                        MessageBox.Show("[Password should contain upper and lower case, number, a symbel and minimum 8 charecters ] like. Aa1@", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("FILL UP ALL BOXES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (EMPbutton.Checked == true)
                {
                    DateTime date = DateTime.Now;
                    Bank_Employee bem = new Bank_Employee();
                    id_m = bem.ID_generater();
                    if (FNbox.Text != "" && LNbox.Text != "" && Ebox.Text != "" && DIVbox.Text != "" && Distrbox.Text != "" && STbox.Text != "" && GenderCOMBbox.Text != "" && NIDbox.Text != "" && PNbox.Text != "" && BNbox.Text != "" && DNbox.Text != "" && NPASSbox.Text != "" && CNPASSbox.Text != "" && checkNID() == true && checkPN() == true && ECheck() == true && PasswordStrength(CNPASSbox.Text) == 4 && JDbox.Value<=date1)
                    {
                        dif = d - DOBbox.Value.Year;
                        if (dif > 17)
                        {
                            if (NPASSbox.Text.Length > 7 && CNPASSbox.Text == NPASSbox.Text)
                            {
                                SqlCommand sql = new SqlCommand("INSERT INTO User_INFO(National_id,First_Name,Middle_Name,Last_Name,Status,Balance,Email,Division,District,Street,Account_Opening_Date,Password,Date_of_Birth,Phone_Number,Gender,Photo) VALUES(@NID,@FN,@MN,@LN,@ST,@BLA,@EM,@DIV,@DIS,@STR,@AOD,@PASS,@DOB,@PN,@GN,@PHO)", c);
                                sql.Parameters.AddWithValue("@NID", NIDbox.Text);
                                sql.Parameters.AddWithValue("@FN", FNbox.Text);
                                sql.Parameters.AddWithValue("@MN", MNbox.Text);
                                sql.Parameters.AddWithValue("@LN", LNbox.Text);
                                sql.Parameters.AddWithValue("@ST", "ACTIVE");
                                sql.Parameters.AddWithValue("@BLA", 0.00);
                                sql.Parameters.AddWithValue("@PHO", getImage());
                                sql.Parameters.AddWithValue("@EM", Ebox.Text.ToLower());
                                sql.Parameters.AddWithValue("@DIV", DIVbox.Text);
                                sql.Parameters.AddWithValue("@DIS", Distrbox.Text);
                                sql.Parameters.AddWithValue("@STR", STbox.Text);
                                sql.Parameters.AddWithValue("@AOD", date);
                                sql.Parameters.AddWithValue("@PASS", CNPASSbox.Text);
                                sql.Parameters.AddWithValue("@DOB", DOBbox.Value);
                                sql.Parameters.AddWithValue("@PN", PNbox.Text);
                                sql.Parameters.AddWithValue("@GN", gender);

                                sql.ExecuteNonQuery();

                                SqlCommand sql2 = new SqlCommand("SELECT User_Id FROM User_INFO WHERE National_id='" + NIDbox.Text + "' AND Phone_Number='" + PNbox.Text + "'", c);
                                SqlDataReader r11 = sql2.ExecuteReader();

                                while (r11.Read())
                                {
                                    idemp = int.Parse(r11.GetValue(0).ToString());
                                }
                                r11.Close();

                                SqlCommand sql3 = new SqlCommand("INSERT INTO Employee_Info(Employee_ID, Joinning_Date, Branch_Name, Desk_Name, User_Id) VALUES(@EMPID, @JD, @BN, @DN, @UID)", c);
                                sql3.Parameters.AddWithValue("@EMPID", id_m);
                                sql3.Parameters.AddWithValue("@JD", JDbox.Value);
                                sql3.Parameters.AddWithValue("@BN", BNbox.Text);
                                sql3.Parameters.AddWithValue("@DN", DNbox.Text);
                                sql3.Parameters.AddWithValue("@UID", idemp);

                                sql3.ExecuteNonQuery();

                                MessageBox.Show($"YOUR REGISTRATION IS SUCSESSFULL  ! YOUR ID IS: {id_m}", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                c.Close();
                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide();
                            }
                            else if (CNPASSbox.Text != NPASSbox.Text)
                            {
                                MessageBox.Show("NEW PASSWORD AND CONFIRME PASSWORD DOSE NOT MATCH", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("PASSWORD MUST BE MINIMUM 8 CHARECTERS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("YOUR AGE SHOULD BE MINIMUM 18", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (FNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP FIRST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (LNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP LAST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (Ebox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (NIDbox.Text == "")
                    {
                        MessageBox.Show("INSURT EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (PNbox.Text == "")
                    {
                        MessageBox.Show("INSURT PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkNID() == false)
                    {
                        MessageBox.Show("PROVIDE VALID NID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkPN() == false)
                    {
                        MessageBox.Show("PROVIDE VALID PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ECheck() == false)
                    {
                        MessageBox.Show("PROVIDE VALID EMAIL", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (PasswordStrength(CNPASSbox.Text) != 4)
                    {
                        MessageBox.Show("[Password should contain upper and lower case, number, a symbel and minimum 8 charecters ] like. Aa1@", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(JDbox.Value > date1)
                    {
                        MessageBox.Show("INPUT VALID JOINING DATE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("FILL UP ALL BOXES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("SELECT AN ACCOUNT TYPE FIRST", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private int PasswordStrength(string password)
        {
            int n = 0;
            int leng=password.Length;
            if(Regex.IsMatch(password, @"[a-z]"))
            {
                n++;
            }
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                n++;
            }
            if(Regex.IsMatch(password, @"\d"))
            {
                n++;
            }
            if( Regex.IsMatch(password, @"[^\w]"))
            {
                n++;
            }
            return n;
        }
        public byte[] getImage()
        {
            MemoryStream stream = new MemoryStream();
            REGPicBox.Image.Save(stream,REGPicBox.Image.RawFormat);
            return stream.GetBuffer();
        }

        private void Ebox_TextChanged(object sender, EventArgs e)
        {
            if(Ebox.Text == "" || ECheck()==false)
            {
                Ebox.BackColor = Color.LightCoral;
                pictureBox2.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                Ebox.BackColor = Color.White;
                pictureBox2.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }
        private bool ECheck()
        {
            string a = Ebox.Text;
            string chack;
            int ii = a.IndexOf("@");
            if (ii != -1 && ii !=0)
            {
                chack = a.Substring(ii).ToLower();
                if (chack == gmail )
                {
                    return true;
                }
                else if (chack == icloud)
                {
                    return true;
                }
                else if (chack == yahoo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void NIDbox_TextChanged(object sender, EventArgs e)
        {
            if (checkNID()==false)
            {
                NIDbox.BackColor = Color.LightCoral;
                pictureBox3.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                NIDbox.BackColor = Color.White;
                pictureBox3.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }

        private void EDUbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool checkNID()
        {
            bool valutest2 = NIDbox.Text.All(char.IsDigit);
            if (valutest2 == true)
            {
                if (NIDbox.Text.Length == 10 || NIDbox.Text.Length == 17)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void DOBlab_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PNbox_TextChanged(object sender, EventArgs e)
        {
            if (PNbox.Text == "" || checkPN()==false)
            {
                PNbox.BackColor = Color.LightCoral;
                pictureBox5.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                PNbox.BackColor = Color.White;
                pictureBox5.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }
        private bool checkPN()
        {
            bool valutest=PNbox.Text.All(char.IsDigit);
            if (valutest == true)
            {
                if (PNbox.Text.Length > 2)
                {
                    string s = PNbox.Text.Substring(0, 3);
                    if (s == "017" || s == "018" || s == "019" || s == "015" || s == "013")
                    {
                        if (PNbox.Text.Length == 11)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
