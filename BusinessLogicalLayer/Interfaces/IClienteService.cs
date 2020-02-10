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
        Response Insert(Cliente cliente);
        Response Update(Cliente cliente);
        Response Delete(Cliente cliente);
        DataResponse<Cliente> GetData();
        DataResponse<Cliente> GetByID(int id);
        Response Validate(Cliente cliente);
    }
}