using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace upc.orden.repositorio
{
    public class Conexion
    {
        
        
        public SqlConnection GetConexion()
        {
            SqlConnection cn = new SqlConnection(
                ConfigurationManager
                .ConnectionStrings["cn"]
                .ConnectionString
            );
            return cn;
        }
    }
}
