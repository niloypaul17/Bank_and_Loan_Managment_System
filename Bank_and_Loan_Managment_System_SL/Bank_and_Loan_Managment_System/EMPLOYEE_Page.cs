using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Bank_and_Loan_Managment_System
{
    public partial class EMPLOYEE_Page : Form
    {
        SqlConnection c;

        private string PASSW, PNN, LOANID,PNNNN;
        private float TOTAL, CURR, Cal, ShowTotal;
        int userid, a;
        private string gmail = "@GMAIL.COM";
        private string icloud = "@ICLOUD.COM";
        private string yahoo = "@YAHOO.COM";
        DateTime d1 = DateTime.Now;
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        Form1 log = new Form1();
        public EMPLOYEE_Page(string FULL_NAME, string ID, string balance, string nid, string add, string email, string gen, string PN, string DOB, string status, Form1 log, string pass, string jd, string branch, string desk, int user)
        {
            InitializeComponent();
            ENTbox.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            INFORMATIONlab.Hide();
            UPDATE_INFORMATINlab.Hide();
            OFFlab.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            MONYElab.Hide();
            textBox2.UseSystemPasswordChar = true;
            ENTPASSbox.UseSystemPasswordChar = true;
            STUDENT_NAMElab.Text = FULL_NAME;
            STDENT_IDlab.Text = ID;
            idlab.Text = ID;
            MONYElab.Text = balance;
            HISTORYview.Hide();
            WITHDRAWbtt.Hide();
            label2.Text = label2.Text + " " + FULL_NAME;
            label5.Text = label5.Text + " " + PN;
            label6.Text = label6.Text + " " + email;
            label8.Text = label8.Text + " " + nid;
            label9.Text = label9.Text + " " + gen;
            label10.Text = label10.Text + " " + DOB;
            label11.Text = label11.Text + " " + add;
            label20.Text = label20.Text + " " + jd;
            label21.Text = label21.Text + " " + desk;
            label22.Text = label22.Text + " " + branch;
            PNNNN = PN;
            statuslab.Text = status;
            statuslab.ForeColor = Color.Green;
            PNN = PN;
            PASSW = pass;
            this.log = log;
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            textBox1.Hide();
            textBox2.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            LOANview.Hide();
            CARDlab.Hide();
            LOAN_INFO.Hide();
            CARD_INFO.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            LINFOlab.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            REPASS.Hide();
            userid = user;

            sqlconnectionM();
            SqlCommand SQLPHOTO = new SqlCommand("SELECT Photo FROM User_INFO WHERE User_Id='" + userid + "'", c);

            SqlDataReader RPhoto = SQLPHOTO.ExecuteReader();
            RPhoto.Read();

            if (RPhoto.HasRows)
            {
                byte[] Img = (byte[])RPhoto[0];

                if (Img == null)
                {
                    EMPPicBox.Image = null;
                }
                else
                {
                    MemoryStream memoryStream = new MemoryStream(Img);
                    EMPPicBox.Image = Image.FromStream(memoryStream);
                }
            }

            c.Close();
        }
        public EMPLOYEE_Page()
        {
            InitializeComponent();
            ENTbox.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            INFORMATIONlab.Hide();
            UPDATE_INFORMATINlab.Hide();
            OFFlab.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            MONYElab.Hide();
            ENTPASSbox.UseSystemPasswordChar = true;
        }

        private void acclab_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.White;
            acclab.BackColor = Color.RoyalBlue;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            MoneyBUtt.Text = "Tap for Balance";
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            LOANview.Hide();
            ACCBlab.Show();
            idlab.Show();
            ABalalab.Show();
            BDTlab.Show();
            MoneyBUtt.Show();
            Sllab.Show();
            Slpic.Show();
            statuslab.Show();
            ACCpanel2.Show();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            HISTORYview.Hide();
            WITHDRAWbtt.Hide();
            LINFOlab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            textBox1.Hide();
            label20.Hide();
            label21.Hide();
            label23.Hide();
            label22.Hide();
            textBox2.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
        }

        private void allab_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM LOAN_EMPLOYEE_TABLE WHERE Employee_ID='" + STDENT_IDlab.Text + "'", c);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter.Fill(dataTable1);
            SqlCommand sqlCommand1 = new SqlCommand("SELECT LOAN_ID FROM LOAN_EMPLOYEE_TABLE WHERE Employee_ID='" + STDENT_IDlab.Text + "'", c);
            SqlDataReader sr = sqlCommand1.ExecuteReader();
            while (sr.Read())
            {
                LOANID = sr.GetValue(0).ToString();
            }
            sr.Close();
            if (dataTable1.Rows.Count > 0)
            {
                LOANlab.Hide();
                SqlCommand sqlCommand2 = new SqlCommand("SELECT LOAN_ID, LOAN_INTEREST, LOAN_AMOUNT, LOAN_VALIDITY, LOAN_VALIDITY_YEAR, STATUS FROM LOAN_INFO WHERE User_Id='" + userid + "'", c);
                SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(sqlCommand2);
                DataTable dataTable2 = new DataTable();
                sqlDataAdapter1.Fill(dataTable2);
                LOANview.DataSource = dataTable2;
                LOANview.Show();
                acclab.ForeColor = Color.RoyalBlue;
                acclab.BackColor = Color.Transparent;
                allab.ForeColor = Color.White;
                allab.BackColor = Color.RoyalBlue;
                clab.ForeColor = Color.RoyalBlue;
                clab.BackColor = Color.Transparent;
                label2.Hide();
                label5.Hide();
                label17.Hide();
                label20.Hide();
                LINFOlab.Hide();
                label21.Hide();
                checkBox2.Hide();
                pictureBox10.Hide();
                label23.Hide();
                label22.Hide();
                label18.Hide();
                label19.Hide();
                textBox1.Hide();
                textBox2.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                label6.Hide();
                label8.Hide();
                label9.Hide();
                label10.Hide();
                label11.Hide();
                ACCBlab.Hide();
                idlab.Hide();
                ABalalab.Hide();
                MONYElab.Hide();
                BDTlab.Hide();
                MoneyBUtt.Hide();
                Sllab.Hide();
                Slpic.Hide();
                statuslab.Hide();
                ACCpanel2.Hide();
                CARDlab.Hide();
                ENTbox.Hide();
                ENTlab.Hide();
                CONFIRMbtt.Hide();
                ENTPASSbox.Hide();
                ENTPASSlab.Hide();
                pictureBox4.Hide();
                checkBox1.Hide();
                EnterPHbox.Hide();
                EnterPHlab.Hide();
                HISTORYview.Hide();
                WITHDRAWbtt.Hide();
                FNlab.Hide();
                FNbox.Hide();
                MNbox.Hide();
                MNlab.Hide();
                LNbox.Hide();
                LNlab.Hide();
                Ebox.Hide();
                Elab.Hide();
                PNlab.Hide();
                PNbox.Hide();
                ADDlab.Hide();
                label16.Hide();
                label14.Hide();
                label15.Hide();
                DIVbox.Hide();
                Distrbox.Hide();
                STbox.Hide();
                button1.Hide();
                dataGridView1.Hide();
            }
            else
            {
                acclab.ForeColor = Color.RoyalBlue;
                acclab.BackColor = Color.Transparent;
                allab.ForeColor = Color.White;
                allab.BackColor = Color.RoyalBlue;
                clab.ForeColor = Color.RoyalBlue;
                clab.BackColor = Color.Transparent;
                label2.Hide();
                label5.Hide();
                label6.Hide();
                label8.Hide();
                label20.Hide();
                label21.Hide();
                label22.Hide();
                label9.Hide();
                label10.Hide();
                label11.Hide();
                ACCBlab.Hide();
                idlab.Hide();
                ABalalab.Hide();
                LINFOlab.Hide();
                MONYElab.Hide();
                label17.Hide();
                label18.Hide();
                label19.Hide();
                textBox1.Hide();
                checkBox2.Hide();
                pictureBox10.Hide();
                textBox2.Hide();
                pictureBox8.Hide();
                label23.Hide();
                pictureBox9.Hide();
                BDTlab.Hide();
                MoneyBUtt.Hide();
                Sllab.Hide();
                Slpic.Hide();
                statuslab.Hide();
                ACCpanel2.Hide();
                CARDlab.Hide();
                ENTbox.Hide();
                ENTlab.Hide();
                CONFIRMbtt.Hide();
                ENTPASSbox.Hide();
                ENTPASSlab.Hide();
                pictureBox4.Hide();
                checkBox1.Hide();
                LOANlab.Show();
                EnterPHbox.Hide();
                EnterPHlab.Hide();
                HISTORYview.Hide();
                WITHDRAWbtt.Hide();
                FNlab.Hide();
                FNbox.Hide();
                MNbox.Hide();
                MNlab.Hide();
                LNbox.Hide();
                LNlab.Hide();
                Ebox.Hide();
                Elab.Hide();
                PNlab.Hide();
                PNbox.Hide();
                ADDlab.Hide();
                label16.Hide();
                label14.Hide();
                label15.Hide();
                DIVbox.Hide();
                Distrbox.Hide();
                STbox.Hide();
                button1.Hide();
                dataGridView1.Hide();
            }
        }

        private void EMPLOYEE_Page_Load(object sender, EventArgs e)
        {
            
        }

        private void MoneyBUtt_Click(object sender, EventArgs e)
        {
            if (MoneyBUtt.Text == "Tap for Balance")
            {
                MONYElab.Show();
                MoneyBUtt.Text = "Tap to Hide";
            }
            else if (MoneyBUtt.Text == "Tap to Hide")
            {
                MONYElab.Hide();
                MoneyBUtt.Text = "Tap for Balance";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            log.Show();
            this.Hide();
        }

        private void clab_Click(object sender, EventArgs e)
        {
            sqlconnectionM();
            SqlCommand CHcard = new SqlCommand("SELECT * FROM CARDS_Info WHERE Account_ID='" + idlab.Text + "'", c);
            SqlDataAdapter adpt = new SqlDataAdapter(CHcard);

            DataTable dt = new DataTable();
            adpt.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                CARDlab.Hide();
                SqlCommand SHcard = new SqlCommand("SELECT Card_Number, Card_Type, Card_Validity FROM CARDS_Info WHERE User_Id='" + userid + "'", c);
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(SHcard);

                sqlDataAdapter.Fill(dataTable);
                dataGridView1.RowTemplate.Height = 70;
                dataGridView1.DataSource = dataTable;
                acclab.ForeColor = Color.RoyalBlue;
                acclab.BackColor = Color.Transparent;
                allab.ForeColor = Color.RoyalBlue;
                allab.BackColor = Color.Transparent;
                clab.ForeColor = Color.White;
                clab.BackColor = Color.RoyalBlue;
                label2.Hide();
                label5.Hide();
                label6.Hide();
                label8.Hide();
                label9.Hide();
                LOANlab.Hide();
                label23.Hide();
                label17.Hide();
                LINFOlab.Hide();
                label18.Hide();
                label19.Hide();
                textBox1.Hide();
                textBox2.Hide();
                label20.Hide();
                checkBox2.Hide();
                pictureBox10.Hide();
                label21.Hide();
                label22.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                LOANview.Hide();
                label10.Hide();
                label11.Hide();
                ACCBlab.Hide();
                idlab.Hide();
                ABalalab.Hide();
                MONYElab.Hide();
                BDTlab.Hide();
                MoneyBUtt.Hide();
                Sllab.Hide();
                Slpic.Hide();
                statuslab.Hide();
                ACCpanel2.Hide();
                LOANlab.Hide();
                ENTbox.Hide();
                ENTlab.Hide();
                CONFIRMbtt.Hide();
                ENTPASSbox.Hide();
                ENTPASSlab.Hide();
                pictureBox4.Hide();
                checkBox1.Hide();
                EnterPHbox.Hide();
                EnterPHlab.Hide();
                HISTORYview.Hide();
                WITHDRAWbtt.Hide();
                FNlab.Hide();
                FNbox.Hide();
                MNbox.Hide();
                MNlab.Hide();
                label20.Hide();
                label21.Hide();
                label22.Hide();
                LNbox.Hide();
                LNlab.Hide();
                Ebox.Hide();
                Elab.Hide();
                PNlab.Hide();
                PNbox.Hide();
                ADDlab.Hide();
                label16.Hide();
                label14.Hide();
                label15.Hide();
                DIVbox.Hide();
                Distrbox.Hide();
                STbox.Hide();
                button1.Hide();
                dataGridView1.Show();
            }
            else
            {
                acclab.ForeColor = Color.RoyalBlue;
                acclab.BackColor = Color.Transparent;
                allab.ForeColor = Color.RoyalBlue;
                allab.BackColor = Color.Transparent;
                clab.ForeColor = Color.White;
                clab.BackColor = Color.RoyalBlue;
                label2.Hide();
                label5.Hide();
                label6.Hide();
                label8.Hide();
                label9.Hide();
                label23.Hide();
                label10.Hide();
                label11.Hide();
                ACCBlab.Hide();
                idlab.Hide();
                ABalalab.Hide();
                LOANlab.Hide();
                LINFOlab.Hide();
                label17.Hide();
                label18.Hide();
                checkBox2.Hide();
                pictureBox10.Hide();
                label19.Hide();
                textBox1.Hide();
                textBox2.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                MONYElab.Hide();
                LOANview.Hide();
                BDTlab.Hide();
                MoneyBUtt.Hide();
                Sllab.Hide();
                Slpic.Hide();
                statuslab.Hide();
                ACCpanel2.Hide();
                LOANlab.Hide();
                ENTbox.Hide();
                ENTlab.Hide();
                CONFIRMbtt.Hide();
                ENTPASSbox.Hide();
                ENTPASSlab.Hide();
                pictureBox4.Hide();
                checkBox1.Hide();
                CARDlab.Show();
                EnterPHbox.Hide();
                EnterPHlab.Hide();
                HISTORYview.Hide();
                WITHDRAWbtt.Hide();
                FNlab.Hide();
                FNbox.Hide();
                MNbox.Hide();
                MNlab.Hide();
                LNbox.Hide();
                LNlab.Hide();
                Ebox.Hide();
                Elab.Hide();
                PNlab.Hide();
                PNbox.Hide();
                ADDlab.Hide();
                label16.Hide();
                label14.Hide();
                label15.Hide();
                DIVbox.Hide();
                Distrbox.Hide();
                STbox.Hide();
                button1.Hide();
            }
            c.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Show();
            ENTlab.Show();
            CONFIRMbtt.Show();
            ENTPASSbox.Show();
            ENTPASSlab.Show();
            pictureBox4.Show();
            checkBox1.Show();
            EnterPHbox.Show();
            EnterPHlab.Show();
            WITHDRAWbtt.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ENTPASSbox.UseSystemPasswordChar = false;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                ENTPASSbox.UseSystemPasswordChar = true;
                pictureBox4.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private void OPTIONlab_Click(object sender, EventArgs e)
        {
            if (INFORMATIONlab.Visible == false)
            {
                INFORMATIONlab.Show();
                UPDATE_INFORMATINlab.Show();
                LOAN_INFO.Show();
                CARD_INFO.Show();
                REPASS.Show();
            }
            else
            {
                INFORMATIONlab.Hide();
                UPDATE_INFORMATINlab.Hide();
                LOAN_INFO.Hide();
                CARD_INFO.Hide();
                REPASS.Hide();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (OFFlab.Visible == false)
            {
                OFFlab.Show();
            }
            else
            {
                OFFlab.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Show();
            ENTlab.Show();
            CONFIRMbtt.Show();
            ENTPASSbox.Show();
            ENTPASSlab.Show();
            pictureBox4.Show();
            checkBox1.Show();

        }

        private void HISTORYlab_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            label23.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            LINFOlab.Hide();
            label19.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            textBox1.Hide();
            textBox2.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            ENTbox.Hide();
            LOANview.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            WITHDRAWbtt.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            HISTORYview.Show();

            sqlconnectionM();
            SqlCommand cmdHistory = new SqlCommand("SELECT Transaction_ID, Type, AMOUNT, DATE_TIME FROM Transaction_History WHERE User_Id='" + userid + "' AND Password= '" + PASSW + "'", c);
            DataTable DHISTORY = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmdHistory);
            sqlDataAdapter.Fill(DHISTORY);

            HISTORYview.DataSource = DHISTORY;

            c.Close();
        }

        private void WITHDRAWbtt_Click(object sender, EventArgs e)
        {
            try
            {
                if (EnterPHbox.Text == STDENT_IDlab.Text && ENTPASSbox.Text == PASSW)
                {
                    sqlconnectionM();
                    SqlCommand com = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + userid + "'", c);
                    SqlDataReader STAC = com.ExecuteReader();
                    while (STAC.Read())
                    {
                        TOTAL = float.Parse(STAC.GetValue(0).ToString());
                    }
                    STAC.Close();
                    CURR = float.Parse(ENTbox.Text);
                    if (CURR <= TOTAL)
                    {
                        Cal = TOTAL - CURR;
                        SqlCommand sqlC = new SqlCommand("UPDATE User_INFO SET Balance=@Bala WHERE User_Id='" + userid + "'", c);
                        sqlC.Parameters.AddWithValue("@Bala", Cal);
                        sqlC.ExecuteNonQuery();
                        SqlCommand com2 = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + userid + "'", c);
                        SqlDataReader STAC2 = com.ExecuteReader();
                        while (STAC2.Read())
                        {
                            ShowTotal = float.Parse(STAC2.GetValue(0).ToString());
                        }
                        STAC2.Close();
                        MONYElab.Text = string.Format($"{ShowTotal:F2}");
                        MessageBox.Show($"YOUR WITHDRAW IS SUCSESSFULL ! AMOUNT: {ENTbox.Text} TOTAL AMOUNT: '"+string.Format($"{ShowTotal:F2}")+"'", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ENTbox.Clear();
                        EnterPHbox.Clear();
                        ENTPASSbox.Clear();

                        SqlCommand UPDATEHISTORY = new SqlCommand("INSERT INTO Transaction_History (Type, AMOUNT, Phone_Number, Password, DATE_TIME, ACCOUNT_ID, User_Id) VALUES (@TY, @AMO, @PN, @PASS, @DT, @ACCID, @ID)", c);
                        UPDATEHISTORY.Parameters.AddWithValue("@TY", "WITHDRAW");
                        UPDATEHISTORY.Parameters.AddWithValue("@AMO", CURR);
                        UPDATEHISTORY.Parameters.AddWithValue("@PN", PNN);
                        UPDATEHISTORY.Parameters.AddWithValue("@PASS", PASSW);
                        UPDATEHISTORY.Parameters.AddWithValue("@DT", d1.ToString());
                        UPDATEHISTORY.Parameters.AddWithValue("@ACCID", idlab.Text);
                        UPDATEHISTORY.Parameters.AddWithValue("@ID", userid);
                        UPDATEHISTORY.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("INSUFFICIENT BALANCE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ENTbox.Clear();
                        EnterPHbox.Clear();
                        ENTPASSbox.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("INVALID ACCOUNT ID OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ENTbox.Clear();
                    EnterPHbox.Clear();
                    ENTPASSbox.Clear();
                }
                c.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UPDATE_INFORMATINlab_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            label23.Hide();
            Slpic.Hide();
            statuslab.Hide();
            LOANview.Hide(); ;
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            LINFOlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            WITHDRAWbtt.Hide();
            HISTORYview.Hide();
            dataGridView1.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();

            FNlab.Show();
            FNbox.Show();
            MNbox.Show();
            MNlab.Show();
            LNbox.Show();
            LNlab.Show();
            Ebox.Show();
            Elab.Show();
            PNlab.Show();
            PNbox.Show();
            ADDlab.Show();
            label15.Show();
            label14.Show();
            label16.Show();
            DIVbox.Show();
            Distrbox.Show();
            STbox.Show();
            button1.Show();
            label17.Show();
            label18.Show();
            label19.Show();
            textBox1.Show();
            textBox2.Show();
            pictureBox8.Show();
            pictureBox9.Show();
            checkBox2.Show();
            pictureBox10.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sqlconnectionM();
            try
            {
                if (a == 0)
                {
                    if (textBox1.Text == STDENT_IDlab.Text && textBox2.Text == PASSW && ECheck() == true && checkPN() == true && FNbox.Text != "" && LNbox.Text != "" && DIVbox.Text != "" && Distrbox.Text != "" && STbox.Text != "" && PNbox.Text != "")
                    {
                        SqlCommand sqlC = new SqlCommand("UPDATE User_INFO SET First_Name=@FN, Middle_Name=@MN, Last_Name=@LN, Email=@EM, Division=@DIV, District=@DIS, Street=@ST, Phone_Number=@PN WHERE User_Id='" + userid + "'", c);
                        sqlC.Parameters.AddWithValue("@FN", FNbox.Text);
                        sqlC.Parameters.AddWithValue("@MN", MNbox.Text);
                        sqlC.Parameters.AddWithValue("@LN", LNbox.Text);
                        sqlC.Parameters.AddWithValue("@EM", Ebox.Text);
                        sqlC.Parameters.AddWithValue("@DIV", DIVbox.Text);
                        sqlC.Parameters.AddWithValue("@DIS", Distrbox.Text);
                        sqlC.Parameters.AddWithValue("@ST", STbox.Text);
                        sqlC.Parameters.AddWithValue("@PN", PNbox.Text);

                        sqlC.ExecuteNonQuery();

                        MessageBox.Show("YOUR INFORMATION IS UPDATED ! IF YOU WANT TO UPDATE THAN YOU NEED TO LOGIN AGAIN", "SUCCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        a = 1;

                        label2.Text = "Full Name:" + " " + FNbox.Text + " " + MNbox.Text + " " + LNbox.Text;
                        label5.Text = "Phone Number:" + " " + PNbox.Text;
                        label6.Text = "Email:" + " " + Ebox.Text;
                        label11.Text = "Address: " + " " + STbox.Text + "," + Distrbox.Text + "," + DIVbox.Text;
                        STUDENT_NAMElab.Text = FNbox.Text + " " + MNbox.Text + " " + LNbox.Text;

                        c.Close();
                    }
                    else if (FNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP FIRST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (LNbox.Text == "")
                    {
                        MessageBox.Show("FILL UP LAST NAME", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ECheck() == false)
                    {
                        MessageBox.Show("GIVE A VALID EMAIL ADDRESS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (checkPN() == false)
                    {
                        MessageBox.Show("GIVE A VALID PHONE NUMBER", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (DIVbox.Text == "" || Distrbox.Text == "" || STbox.Text == "")
                    {
                        MessageBox.Show("FILL UP ALL ADDRESS BOX", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (textBox1.Text != STDENT_IDlab.Text || textBox2.Text != PASSW)
                    {
                        MessageBox.Show("INVALID ACCOUNT ID OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("FILL UP ALL BOXES PROPERLY", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("TO UPDATE PROPERLY YOU NEED TO LOGIN AGAIN", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("FILL ALL BOXES", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Ebox_TextChanged(object sender, EventArgs e)
        {
            if (Ebox.Text == "" || ECheck() == false)
            {
                Ebox.BackColor = Color.LightCoral;
                pictureBox8.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                Ebox.BackColor = Color.White;
                pictureBox8.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }
        private bool ECheck()
        {
            string a = Ebox.Text;
            string chack;
            int ii = a.IndexOf("@");
            if (ii != -1 && ii != 0)
            {
                chack = a.Substring(ii).ToUpper();
                if (chack == gmail)
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

        private void PNbox_TextChanged(object sender, EventArgs e)
        {
            if (PNbox.Text == "" || checkPN() == false)
            {
                PNbox.BackColor = Color.LightCoral;
                pictureBox9.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\vecteezy_round-red-cross-mark_44448989.png");
            }
            else
            {
                PNbox.BackColor = Color.White;
                pictureBox9.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\Check_Mark.png");
            }
        }
        private bool checkPN()
        {
            bool valutest = PNbox.Text.All(char.IsDigit);
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

        private void LOAN_INFO_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label23.Hide();
            textBox1.Hide();
            textBox2.Hide();
            label20.Hide();
            label21.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            label22.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            ENTbox.Hide();
            LOANview.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            WITHDRAWbtt.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            HISTORYview.Hide();
            LINFOlab.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
                pictureBox10.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngegg.png");
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                pictureBox10.Image = new Bitmap("A:\\Documents\\SPRING 2024-2025\\OBJECT ORIENTED PROGRAMMING 2 [J]\\Project\\Resources\\pngwing.com.png");
            }
        }

        private void REPASS_Click(object sender, EventArgs e)
        {
            Forgot_Password forgot_Password = new Forgot_Password();
            forgot_Password.Show();
        }

        private void CARD_INFO_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            LINFOlab.Hide();
            textBox1.Hide();
            textBox2.Hide();
            label20.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            label21.Hide();
            label22.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            ENTbox.Hide();
            LOANview.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            WITHDRAWbtt.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            HISTORYview.Hide();
            label23.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CARDS_Page cARDS_Page = new CARDS_Page();
            cARDS_Page.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LOAN_EMPLOYEE lonem = new LOAN_EMPLOYEE();
            lonem.Show();
        }

        private void INFORMATIONlab_Click(object sender, EventArgs e)
        {
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            label23.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Hide();
            ENTlab.Hide();
            CONFIRMbtt.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            ENTPASSbox.Hide();
            ENTPASSlab.Hide();
            LINFOlab.Hide();
            pictureBox4.Hide();
            checkBox1.Hide();
            EnterPHbox.Hide();
            EnterPHlab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            textBox1.Hide();
            textBox2.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            LOANview.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            HISTORYview.Hide();
            dataGridView1.Hide();
            label2.Show();
            label5.Show();
            label6.Show();
            label8.Show();
            label9.Show();
            label10.Show();
            label11.Show();
            label20.Show();
            label21.Show();
            label22.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            ENTlab.Text = "Enter Amount:";
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            label2.Hide();
            label5.Hide();
            label6.Hide();
            LOANview.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            ACCBlab.Hide();
            idlab.Hide();
            ABalalab.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            label23.Hide();
            MoneyBUtt.Hide();
            label20.Hide();
            label21.Hide();
            label22.Hide();
            Sllab.Hide();
            LINFOlab.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            textBox1.Hide();
            textBox2.Hide();
            pictureBox8.Hide();
            pictureBox9.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Show();
            ENTlab.Show();
            ENTlab.Text = ENTlab.Text + " (Withdraw)";
            ENTlab.Show();
            CONFIRMbtt.Hide();
            HISTORYview.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            WITHDRAWbtt.Show();
            ENTPASSbox.Show();
            ENTPASSlab.Show();
            pictureBox4.Show();
            checkBox1.Show();
            EnterPHbox.Show();
            EnterPHlab.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            ENTlab.Text = "Enter Amount:";
            acclab.ForeColor = Color.RoyalBlue;
            acclab.BackColor = Color.Transparent;
            allab.ForeColor = Color.RoyalBlue;
            allab.BackColor = Color.Transparent;
            clab.ForeColor = Color.RoyalBlue;
            clab.BackColor = Color.Transparent;
            label2.Hide();
            label5.Hide();
            label6.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            LINFOlab.Hide();
            ACCBlab.Hide();
            idlab.Hide();
            LOANlab.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            textBox1.Hide();
            textBox2.Hide();
            pictureBox8.Hide();
            label20.Hide();
            label21.Hide();
            label23.Hide();
            label22.Hide();
            checkBox2.Hide();
            pictureBox10.Hide();
            pictureBox9.Hide();
            ABalalab.Hide();
            MONYElab.Hide();
            BDTlab.Hide();
            MoneyBUtt.Hide();
            Sllab.Hide();
            LOANview.Hide();
            Slpic.Hide();
            statuslab.Hide();
            ACCpanel2.Hide();
            LOANlab.Hide();
            CARDlab.Hide();
            ENTbox.Show();
            ENTlab.Show();
            ENTlab.Text = ENTlab.Text + " (Diposit)";
            ENTlab.Show();
            WITHDRAWbtt.Hide();
            HISTORYview.Hide();
            FNlab.Hide();
            FNbox.Hide();
            MNbox.Hide();
            MNlab.Hide();
            LNbox.Hide();
            LNlab.Hide();
            Ebox.Hide();
            Elab.Hide();
            PNlab.Hide();
            PNbox.Hide();
            ADDlab.Hide();
            label16.Hide();
            label14.Hide();
            label15.Hide();
            DIVbox.Hide();
            Distrbox.Hide();
            STbox.Hide();
            button1.Hide();
            dataGridView1.Hide();
            CONFIRMbtt.Show();
            ENTPASSbox.Show();
            ENTPASSlab.Show();
            pictureBox4.Show();
            checkBox1.Show();
            EnterPHbox.Show();
            EnterPHlab.Show();
        }

        private void CONFIRMbtt_Click(object sender, EventArgs e)
        {
            try
            {
                if (EnterPHbox.Text == STDENT_IDlab.Text && ENTPASSbox.Text == PASSW)
                {
                    sqlconnectionM();
                    SqlCommand com = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + userid + "'", c);
                    SqlDataReader STAC = com.ExecuteReader();
                    while (STAC.Read())
                    {
                        TOTAL = float.Parse(STAC.GetValue(0).ToString());
                    }
                    STAC.Close();
                    CURR = float.Parse(ENTbox.Text);
                    Cal = TOTAL + CURR;
                    SqlCommand sqlC = new SqlCommand("UPDATE User_INFO SET Balance=@Bala WHERE User_Id='" + userid + "'", c);
                    sqlC.Parameters.AddWithValue("@Bala", Cal);
                    sqlC.ExecuteNonQuery();
                    SqlCommand com2 = new SqlCommand("SELECT Balance FROM User_INFO WHERE User_Id='" + userid + "'", c);
                    SqlDataReader STAC2 = com.ExecuteReader();
                    while (STAC2.Read())
                    {
                        ShowTotal = float.Parse(STAC2.GetValue(0).ToString());
                    }
                    STAC2.Close();
                    MONYElab.Text = string.Format($"{ShowTotal:F2}");
                    MessageBox.Show($"YOUR DIPOSIT IS SUCSESSFULL ! AMOUNT: {ENTbox.Text} TOTAL AMOUNT: '" + string.Format($"{ShowTotal:F2}") + "'", "SUCSESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ENTbox.Clear();
                    EnterPHbox.Clear();
                    ENTPASSbox.Clear();

                    SqlCommand UPDATEHISTORY = new SqlCommand("INSERT INTO Transaction_History (Type, AMOUNT, Phone_Number, Password, DATE_TIME, ACCOUNT_ID, User_Id) VALUES (@TY, @AMO, @PN, @PASS, @DT, @ACCID, @ID)", c);
                    UPDATEHISTORY.Parameters.AddWithValue("@TY", "DIPOSIT");
                    UPDATEHISTORY.Parameters.AddWithValue("@AMO", CURR);
                    UPDATEHISTORY.Parameters.AddWithValue("@PN", PNN);
                    UPDATEHISTORY.Parameters.AddWithValue("@PASS", PASSW);
                    UPDATEHISTORY.Parameters.AddWithValue("@DT", d1.ToString());
                    UPDATEHISTORY.Parameters.AddWithValue("@ACCID", idlab.Text);
                    UPDATEHISTORY.Parameters.AddWithValue("@ID", userid);
                    UPDATEHISTORY.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("INVALID ACCOUNT ID OR PASSWORD", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ENTbox.Clear();
                    EnterPHbox.Clear();
                    ENTPASSbox.Clear();
                }
                c.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Somthing Went Wrong! Please try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
