using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upc.orden.repositorio
{
    public class ClienteRepository : IClienteRepository
    {
        SqlConnection SqlCon;
        Conexion Con;

        public ClienteRepository()
        {
            Con = new Conexion();
        }

        public DataTable ReaderByDni(int dni)
        {
            try
            {
                SqlCon = Con.GetConexion();
                SqlCon.Open();
                SqlDataAdapter Da = new SqlDataAdapter("listClienteByDNI", SqlCon);
                Da.SelectCommand.CommandType = CommandType.StoredProcedure;
                Da.SelectCommand.Parameters.Add("@Dni", SqlDbType.Int).Value = dni;
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                return Dt;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
