using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal interface Service
    {
        string Service_ID { get; }
        DateTime Issue_Date { get; set; }
        double amount { get; set; }

        string ID_Service();
    }
}
