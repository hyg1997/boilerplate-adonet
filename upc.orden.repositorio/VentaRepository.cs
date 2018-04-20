using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upc.order.entities;

using System.Data;

namespace upc.orden.repositorio
{
    public class VentaRepository :
        IVentaRepository
    {
        SqlConnection SqlCon;
        Conexion ObjCon;

        public VentaRepository()
        {
            ObjCon=new Conexion();
        }

        public bool Create(Venta v)
        {
            SqlCon = ObjCon.GetConexion();

            SqlCommand Cmd = new SqlCommand("addOrder", SqlCon);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@producto", v.Producto);
            Cmd.Parameters.AddWithValue("@cantidad", v.Cantidad);
            Cmd.Parameters.AddWithValue("@precio", v.Precio);
            Cmd.Parameters.AddWithValue("@subtotal", v.Subtotal);
            Cmd.Parameters.AddWithValue("@descuento", v.Descuento);
            Cmd.Parameters.AddWithValue("@neto", v.Neto);
            Cmd.Parameters.AddWithValue("@idcliente", v.Objcliente.Id);

            SqlCon.Open();
            int i = Cmd.ExecuteNonQuery();
            SqlCon.Close();

            if (i >= -1)
                return true;
            else
                return false;
        }

        public bool Delete(Venta v)
        {
            SqlCon = ObjCon.GetConexion();

            SqlCommand Cmd = new SqlCommand("deleteOrder", SqlCon);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@id", v.Id);            

            SqlCon.Open();
            int i = Cmd.ExecuteNonQuery();
            SqlCon.Close();

            if (i >= -1)
                return true;
            else
                return false;
        }

        public DataTable Reader()
        {
            SqlCon = ObjCon.GetConexion();
            SqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("listOrder", SqlCon);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;
        }

        public DataTable ReaderById(int id)
        {
            SqlCon = ObjCon.GetConexion();
            SqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("listOrderById", SqlCon);
            Da.SelectCommand.CommandType = CommandType.StoredProcedure;
            Da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            return Dt;
        }

        public bool Update(Venta v)
        {
            SqlCon = ObjCon.GetConexion();

            SqlCommand Cmd = new SqlCommand("updateOrder", SqlCon);
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.AddWithValue("@id", v.Id);
            Cmd.Parameters.AddWithValue("@producto", v.Producto);
            Cmd.Parameters.AddWithValue("@cantidad", v.Cantidad);
            Cmd.Parameters.AddWithValue("@precio", v.Precio);
            Cmd.Parameters.AddWithValue("@subtotal", v.Subtotal);
            Cmd.Parameters.AddWithValue("@descuento", v.Descuento);
            Cmd.Parameters.AddWithValue("@neto", v.Neto);

            SqlCon.Open();
            int i = Cmd.ExecuteNonQuery();
            SqlCon.Close();

            if (i >= -1)
                return true;
            else
                return false;
        }
    }
}
