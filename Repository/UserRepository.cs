using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using LoanManagement.Models;

namespace LoanManagement.Repository
{
    internal class UserRepository : Repository<User>
    {
        private readonly SqlConnection _conn;
        public UserRepository(SqlConnection conn) : base(conn)
        {
            _conn = conn;
        }
        public new void Update(User user)
        {
            var query = @"UPDATE [User]
                  SET [Name] = @name,
                      [Password] = @password,
                      [DateModified] = @dateModified
                  WHERE [Id] = @id";

            _conn.Execute(query, new
            {
                id = user.Id,
                name = user.Name,
                password = user.Password,
                dateModified = user.DateModified
            });
        }
    }
}
