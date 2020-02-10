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
    public class GeneroService : IGeneroService
    {
        public void Delete(Genero genero)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Genero generoASerExcluido = new Genero();
                db.Entry<Genero>(generoASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Insert(Genero genero)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Generos.Add(genero);
                db.SaveChanges();
            }
        }

        public void Update(Genero genero)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Genero generoASerAtualizado = new Genero();
                db.Entry<Genero>(generoASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
