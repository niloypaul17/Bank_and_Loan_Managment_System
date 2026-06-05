using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal class Loan : Balance_Update, Service
    {
        public string Service_ID { get; }
        public DateTime Issue_Date { get; set; }
        public double amount { get; set; }

        public string ID_Service()
        {
            Random random = new Random();
            string a, b, c, d, e, f, total;
            a = Convert.ToString(random.Next(1, 9));
            b = Convert.ToString(random.Next(1, 9));
            c = Convert.ToString(random.Next(1, 9));
            d = Convert.ToString(random.Next(1, 9));
            e = Convert.ToString(random.Next(1, 9));
            f = Convert.ToString(random.Next(1, 9));
            total = "SER" + a + b + c + d + e + f;
            return total;
        }

        public string ID_Loan()
        {
            Random random = new Random();
            string a, b, c, d, e, f,g,h,i, total;
            a = Convert.ToString(random.Next(1, 9));
            b = Convert.ToString(random.Next(1, 9));
            c = Convert.ToString(random.Next(1, 9));
            d = Convert.ToString(random.Next(1, 9));
            e = Convert.ToString(random.Next(1, 9));
            f = Convert.ToString(random.Next(1, 9));
            g = Convert.ToString(random.Next(1, 9));
            h = Convert.ToString(random.Next(1, 9));
            i = Convert.ToString(random.Next(1, 9));
            total = "LNA"+a + b + c + d + e + f+ g + h + i;
            return total;
        }

        public string Loan_Number { get; }
        public double Loan_Interest { get; set; }
        private string Loan_Validity;

        public Loan()
        {
            Loan_Number = ID_Loan();
            Service_ID = ID_Service();
        }

        public void Update_Balance(Double d, User user, string type)
        {
            Issue_Date = DateTime.Now;
            amount = d;
            if (type == "Student")
            {
                user.balance = user.balance + amount;
                Loan_Interest = 0.15;
                Loan_Validity = "4 YEARS";
            }
            else if (type == "House")
            {
                user.balance = user.balance + amount;
                Loan_Interest = 0.22;
                Loan_Validity = "10 YEARS";
            }
            else if (type == "Employee")
            {
                user.balance = user.balance + amount;
                Loan_Interest = 0.20;
                Loan_Validity = "5 YEARS";
            }
        }
    }
}
