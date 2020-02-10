using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFuncionarioService
    {
        Response Insert(Funcionario funcionario);
        Response Update(Funcionario funcionario);
        Response Delete(Funcionario funcionario);
        Response Validate(Funcionario funcionario);
    }
}