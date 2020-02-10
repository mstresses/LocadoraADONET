using BusinessLogicalLayer.Interfaces;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FilmeService : IFilmeService
    {
        public object EntityLocadora { get; private set; }

        public void Delete(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme filmeASerExcluido = new Filme();
                db.Entry<Filme>(filmeASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Insert(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme f = new Filme()
                {
                    Nome = "Danizinho Bernart",
                    DataLancamento = DateTime.Now.AddYears(-25),
                    Classificacao = EntityLocadora.Enums.Classificacao.Dez,
                    Duracao = 120

                };
                db.Filmes.Add(f);
                db.SaveChanges();
            }
        }

        public void Update(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme filmeASerAtualizado = new Filme();
                db.Entry<Filme>(filmeASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
