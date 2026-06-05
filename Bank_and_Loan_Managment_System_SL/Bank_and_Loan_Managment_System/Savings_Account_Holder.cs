using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal class Savings_Account_Holder : User
    {
        public string Email
        {

            get { return Email; }
            set
            {
                bool c = false;

                for (int i = 1; i < value.Length; i++)
                {
                    if (value[i] == '@')
                    {
                        c = true;
                        break;
                    }
                }

                if (c)
                {
                    this.Email = value;
                }
            }
        }
        public string First_Name
        {
            get
            {
                return First_Name;
            }
            set
            {
                if (value != null)
                {
                    this.First_Name = value;
                }
            }
        }

        public string Middle_Name
        {
            get
            {
                return Middle_Name;
            }
            set
            {
                if (value != null)
                {
                    this.Middle_Name = value;
                }
            }
        }
        public string Last_Name
        {
            get
            {
                return Last_Name;
            }
            set
            {
                if (value != null)
                {
                    this.Last_Name = value;
                }
            }
        }
        public string Status { get; }
        public double balance { get; set; }
        public int National_ID { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Date_of_Birth { get; set; }
        public string Password
        {
            get
            {
                return Password;
            }
            set
            {
                if (value.Length >= 8)
                {
                    this.Password = value;
                }
            }
        }
        public string ID_generater()
        {
            Random random = new Random();
            string a, b, c, d, e, f, total;
            a = Convert.ToString(random.Next(1, 9));
            b = Convert.ToString(random.Next(1, 9));
            c = Convert.ToString(random.Next(1, 9));
            d = Convert.ToString(random.Next(1, 9));
            e = Convert.ToString(random.Next(1, 9));
            f = Convert.ToString(random.Next(1, 9));
            total = "ASV" + a + b + c + d + e + f;
            return total;
        }
        public DateTime Account_Opening_Date { get; set; }

        private string Occupetion;
        public string Savings_ID { get; }
        private string TN_Number;

        public Savings_Account_Holder() { }
        public Savings_Account_Holder(string Email, string First_Name, string Middle_Name, string Last_Name, string Status, double balance, int National_ID, string Phone_Number, string Address, string Date_of_Birth, string Password, DateTime Account_Opening_Date, string Occupetion,string TN_Number)
        {
            Savings_ID = ID_generater();
            this.Email = Email;
            this.First_Name = First_Name;
            this.Middle_Name = Middle_Name;
            this.Last_Name = Last_Name;
            this.Status = Status;
            this.balance = balance;
            this.National_ID = National_ID;
            this.Phone_Number = Phone_Number;
            this.Address = Address;
            this.Date_of_Birth = Date_of_Birth;
            this.Password = Password;
            this.Account_Opening_Date = Account_Opening_Date;
            this.Occupetion = Occupetion;
            this.TN_Number = TN_Number;
        }
    }
}

