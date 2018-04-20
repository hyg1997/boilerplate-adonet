using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upc.orden.repositorio;

namespace upc.order.business
{
    public class ClienteB : ICliente
    {
        IClienteRepository CRepository;

        public ClienteB()
        {
            CRepository = new ClienteRepository();
        }
        public DataTable ReaderByDni(int dni)
        {
            return CRepository.ReaderByDni(dni);
        }
    }
}
