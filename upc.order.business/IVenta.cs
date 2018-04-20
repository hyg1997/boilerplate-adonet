using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using upc.order.entities;

namespace upc.order.business
{
    public interface IVenta
    {
        //TODO: CRUD
        bool Create(Venta v);
        
        bool Update(Venta v);
        bool Delete(Venta v);

        DataTable Reader();

        DataTable ReaderById(int id);

        //TODO: OTHER OPERATIONS
        double AsignarPrecio(Venta v);
        double CalcularSubtotal(Venta v);
        double CalcularDescuento(Venta v);
        double CalcularNeto(Venta v);

        
    }
}
