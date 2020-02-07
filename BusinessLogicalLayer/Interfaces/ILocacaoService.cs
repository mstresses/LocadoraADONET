using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILocacaoService
    {
        void Insert(Locacao locacao);
        void Update(Locacao locacao);
        void Delete(Locacao locacao);
    }
}