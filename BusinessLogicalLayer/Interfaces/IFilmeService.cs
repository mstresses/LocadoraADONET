using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFilmeService
    {
        Response Insert(Filme filme);
        Response Update(Filme filme);
        Response Delete(Filme filme);
        Response Validate(Filme filme);
    }
}