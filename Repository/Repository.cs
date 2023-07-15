using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace LoanManagement.Repository
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _conn;

        public Repository(SqlConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<T> Get()
            => _conn.GetAll<T>();

        public T Get(Guid guid)
            => _conn.Get<T>(guid);

        public void Create(T entity)
            => _conn.Insert<T>(entity);

    }
}
