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
        Response Insert(Locacao locacao);
        Response Update(Locacao locacao);
        Response Delete(Locacao locacao);
        Response Validate(Locacao locacao);
    }
}