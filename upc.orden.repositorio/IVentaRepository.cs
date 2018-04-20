using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upc.order.entities;

namespace upc.orden.repositorio
{
    public interface IVentaRepository
    {
        bool Create(Venta v);
        bool Update(Venta v);
        bool Delete(Venta v);

        DataTable Reader();

        DataTable ReaderById(int id);


    }
}
