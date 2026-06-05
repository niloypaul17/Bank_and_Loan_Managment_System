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
    public partial class Admin_Panel : Form
    {
        SqlConnection c;

        string idd,PN,PASS,Date;
        float amount,PB,total;
        int date;
        DateTime d=DateTime.Now;

        Form1 formA= new Form1();
        public void sqlconnectionM()
        {
            c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\arnob\OneDrive\Documents\BANK_AND_LOAN.mdf;Integrated Security=True;Connect Timeout=30");
            c.Open();
        }
        public Admin_Panel()
        {
            InitializeComponent();
        }

        public Admin_Panel(string name, string phone, string idadm, Form1 form1)
        {
            InitializeComponent();
            Admin_Name.Text = name;
            Admin_ID.Text = idadm;
            Admin_PN.Text = phone;
            formA= form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Account_Information account_Information = new Account_Information(this);
            account_Information.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Loan_Information loan_Information = new Loan_Information(this);
            loan_Information.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CARD_AND_TRANSACTION_INFORMATION CT=new CARD_AND_TRANSACTION_INFORMATION(this);
            CT.Show();
            this.Hide();
        }

        private void Admin_Panel_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formA.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
