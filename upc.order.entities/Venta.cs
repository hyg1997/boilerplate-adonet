using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upc.order.entities
{
    public class Venta
    {        
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }

        public double Precio { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double Neto { get; set; }

        public Cliente Objcliente { get; set; }
    }
}
