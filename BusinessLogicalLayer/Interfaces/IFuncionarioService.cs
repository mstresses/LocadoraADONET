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
        void Insert(Funcionario funcionario);
        void Update(Funcionario funcionario);
        void Delete(Funcionario funcionario);
        void Validate(Funcionario funcionario);
    }
}