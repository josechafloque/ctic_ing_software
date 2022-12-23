using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cticbackend.data
{
    public class ConexionPostgreSQL
    {
        public ConexionPostgreSQL(string connectionString) => ConnectionString = connectionString;

        public string ConnectionString { get; set; }
    }
}
