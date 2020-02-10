using EntityLocadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IFilmeService
    {
        void Insert(Filme filme);
        void Update(Filme filme);
        void Delete(Filme filme);
    }
}
