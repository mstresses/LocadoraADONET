using BLL.Interfaces;
using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class GeneroService : IGeneroService
    {
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

        public void Delete(Genero genero)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Genero generoASerExcluido = new Genero();
                db.Entry<Genero>(generoASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Validate(Genero genero)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(genero.Nome))
                {
                    new Exception("O nome do gênero deve ser informado");
                }
                else
                {
                    //Remove espaços em branco no começo e no final da string.
                    genero.Nome = genero.Nome.Trim();
                    //Remove espaços extras entre as palavras, ex: "A      B", ficaria "A B".
                    genero.Nome = Regex.Replace(genero.Nome, @"\s+", " ");
                    if (genero.Nome.Length < 2 || genero.Nome.Length > 50)
                    {
                        new Exception("O nome do gênero deve conter entre 2 e 50 caracteres");
                    }
                }
                db.SaveChanges();
            }
        }
    }
}