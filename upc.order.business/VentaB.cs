using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upc.orden.repositorio;
using upc.order.entities;

namespace upc.order.business
{
    public class VentaB : IVenta
    {
        IVentaRepository VRepositorio;
        
        //Patron Inyeccion de dependencia
        //por constructor, set
        public VentaB()
        {
            VRepositorio = new VentaRepository();
        }

        public bool Create(Venta v)
        {
            return VRepositorio.Create(v);
        }

        public bool Update(Venta v)
        {
            return VRepositorio.Update(v);
        }

        public bool Delete(Venta v)
        {
            return VRepositorio.Delete(v);
        }

        public DataTable Reader()
        {
            return VRepositorio.Reader();
        }

        public DataTable ReaderById(int id)
        {
            return VRepositorio.ReaderById(id);
        }



        public double AsignarPrecio(Venta v)
        {
            switch (v.Producto)
            {
                case "Mouse": return 20;
                case "Teclado": return 35;
                case "Impresora": return 350;
                case "Monitor": return 550;
                case "Parlantes": return 50;
            }
            return 0;
        }

        public double CalcularDescuento(Venta v)
        {
            double subtotal = CalcularSubtotal(v);
            if (subtotal <= 300)
                return 0.05*subtotal;
            else if (subtotal > 300 && subtotal <= 500)
                return 0.10* subtotal;
            else
                return 0.13* subtotal;
            
        }

        public double CalcularNeto(Venta v)
        {
            return CalcularSubtotal(v) - CalcularDescuento(v);
        }

        public double CalcularSubtotal(Venta v)
        {
            return AsignarPrecio(v) * v.Cantidad;
        }

        
    }
}
