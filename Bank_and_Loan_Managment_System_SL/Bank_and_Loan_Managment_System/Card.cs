using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal class Card : Service
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
            total = a + b + c + d + e + f;
            return total;
        }

        public string ID_Card()
        {
            Random random = new Random();
            string a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, total;
            a = Convert.ToString(random.Next(1, 9));
            b = Convert.ToString(random.Next(1, 9));
            c = Convert.ToString(random.Next(1, 9));
            d = Convert.ToString(random.Next(1, 9));
            e = Convert.ToString(random.Next(1, 9));
            f = Convert.ToString(random.Next(1, 9));
            g = Convert.ToString(random.Next(1, 9));
            h = Convert.ToString(random.Next(1, 9));
            i = Convert.ToString(random.Next(1, 9));
            j = Convert.ToString(random.Next(1, 9));
            k = Convert.ToString(random.Next(1, 9));
            l = Convert.ToString(random.Next(1, 9));
            m = Convert.ToString(random.Next(1, 9));
            n = Convert.ToString(random.Next(1, 9));
            o = Convert.ToString(random.Next(1, 9));
            p = Convert.ToString(random.Next(1, 9));
            total = a + b + c + d + ' ' + e + f + g + h + ' ' + i + j + k + l + ' ' + m + n + o + p;
            return total;
        }

        public string Card_Number { get; }
        public string Card_Validity;

        public Card()
        {
            Card_Number = ID_Card();
            Service_ID = ID_Service();
        }

        public void Issue_Card(Double d, User user)
        {
            Issue_Date = DateTime.Now;
            amount = d;
            user.balance = user.balance + amount;
            Card_Validity = "5 YEARS";
        }
    }
}
