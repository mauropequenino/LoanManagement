using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagement.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int LoanLine { get; set; }
        public decimal SalaryAmount { get; set; }
        public decimal LoanRequestAmount { get; set; }
        public decimal LoanMonthlyPaymentAmount { get; set; }
        public int LoanTermMonths { get; set; }
        public double LoanInterestRate { get; set; }
        public string LoanPurpose { get; set; }
        public string LoanPurposeDescription { get; set; }
        public DateTime LoanDateStart { get; set; }




    }
}
