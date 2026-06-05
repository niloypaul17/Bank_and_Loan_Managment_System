using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal class Transaction : Balance_Update, Service
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

        public string ID_Tra()
        {
            Random random = new Random();
            string a, b, c, d, e, f, total;
            a = Convert.ToString(random.Next(1, 9));
            b = Convert.ToString(random.Next(1, 9));
            c = Convert.ToString(random.Next(1, 9));
            d = Convert.ToString(random.Next(1, 9));
            e = Convert.ToString(random.Next(1, 9));
            f = Convert.ToString(random.Next(1, 9));
            total = "TRA" + a + b + c + d + e + f;
            return total;
        }
        private string Transaction_ID { get; }

        public Transaction()
        {
            Transaction_ID = ID_Tra();
            Service_ID = ID_Service();
        }

        public void Update_Balance(Double d, User user, string type)
        {
            if (type == "Transaction")
            {
                if (d > user.balance)
                {
                    Console.WriteLine("Error! not enough balance for transaction");
                }
                else if (d <= user.balance)
                {
                    user.balance = user.balance - d;

                    Console.WriteLine("Successfull transaction");
                }
            }
            else if (type == "Withdraw")
            {
                if (d > user.balance)
                {
                    Console.WriteLine("Error! not enough balance for Withdrawal");
                }
                else if (d <= user.balance)
                {
                    user.balance = user.balance - d;

                    Console.WriteLine("Successfully Withdraw");
                }
            }
            else if (type == "Depsit")
            {
                user.balance = user.balance + d;

                Console.WriteLine("Successfull Deposit");
            }

        }



    }
}
