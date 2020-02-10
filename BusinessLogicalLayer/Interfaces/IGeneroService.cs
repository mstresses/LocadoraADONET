using EntityLocadora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IGeneroService
    {
        void Insert(Genero genero);
        void Update(Genero genero);
        void Delete(Genero genero);
      //void Validate(Genero genero);
    }
}
