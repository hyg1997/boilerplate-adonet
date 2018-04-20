using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace upc.orden.repositorio
{
    public interface IClienteRepository
    {
        DataTable ReaderByDni(int dni);
    }
}
