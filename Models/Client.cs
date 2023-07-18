using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper.Contrib.Extensions;

namespace LoanManagement.Models
{
    [Table("Client")]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bi { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public char Genre { get; set; }
        public string Profession { get; set; }
        public decimal Income { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int status { get; set; }
    }
}