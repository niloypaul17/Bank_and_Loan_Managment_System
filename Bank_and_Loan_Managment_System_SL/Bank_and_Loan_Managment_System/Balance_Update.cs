using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_and_Loan_Managment_System
{
    internal interface Balance_Update
    {
        void Update_Balance(Double d, User user, String type);
    }
}
