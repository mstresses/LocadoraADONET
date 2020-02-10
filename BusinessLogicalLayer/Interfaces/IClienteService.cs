using EntityLocadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IClienteService
    {
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
    }
}
