using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using LoanManagement.Models;

namespace LoanManagement.Repository
{
    internal class ClientRepository : Repository<Client>
    {
        private readonly SqlConnection _conn;
        public ClientRepository(SqlConnection conn) : base(conn)
        {
            _conn = conn;
        }

        public new void Update(Client client)
        {
            var query = @"UPDATE [Client]
                  SET [Name] = @name,
                      [Bi] = @bi,
                      [Province] = @province,
                      [Address] = @address,
                      [BirthDate] = @birthDate,
                      [Genre] = @genre,
                      [Profession] = @profession,
                      [Income] = @income,
                      [PhoneNumber] = @phoneNumber,
                      [Email] = @email
                  WHERE [Id] = @id";

            _conn.Execute(query, new
            {
                id = client.Id,
                name = client.Name,
                bi = client.Bi,
                province = client.Province,
                address = client.Address,
                birthDate = client.BirthDate,
                genre = client.Genre,
                profession = client.Profession,
                income = client.Income,
                phoneNumber = client.PhoneNumber,
                email = client.Email
            });
        }
    }
}
