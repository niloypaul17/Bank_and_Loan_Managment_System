using System;

namespace Bank_and_Loan_Managment_System
{
    internal interface User
    {
        string Email { get; set; }
        string First_Name { get; set; }
        string Middle_Name { get; set; }
        string Last_Name { get; set; }
        string Status { get; }
        double balance { get; set; }
        int National_ID { get; set; }
        string Phone_Number { get; set; }
        string Address { get; set; }
        string Date_of_Birth { get; set; }
        string Password { get; set; }
        DateTime Account_Opening_Date { get; set; }

        string ID_generater();

    }
}
