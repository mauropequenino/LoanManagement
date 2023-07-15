using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;


namespace LoanManagement.Models
{
    [Table("[User]")]
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DataCreated { get; set; }
        public DateTime DataUpdated { get; set; }
    }
}
