using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClienteService
    {
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Cliente cliente);
        void Validate(Cliente cliente);
    }
}