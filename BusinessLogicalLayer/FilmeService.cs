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
    public class FilmeService : IFilmeService
    {
        public void Insert(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Filmes.Add(filme);
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

        public void Delete(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme filmeASerExcluido = new Filme();
                db.Entry<Filme>(filmeASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Validate(Filme filme)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(filme.Nome))
                {
                    new Exception("O nome do filme deve ser informado");
                }
                else
                {
                    filme.Nome = filme.Nome.Trim();
                    //Remove espaços extras entre as palavras, ex: "A      B", ficaria "A B".
                    filme.Nome = Regex.Replace(filme.Nome, @"\s+", " ");
                    if (filme.Nome.Length < 2 || filme.Nome.Length > 50)
                    {
                        new Exception("O nome do filme deve conter entre 2 e 50 caracteres");
                    }
                }
                if (filme.Duracao <= 10)
                {
                    new Exception("Duração não pode ser menor que 10 minutos.");
                }

                if (filme.DataLancamento == DateTime.MinValue || filme.DataLancamento > DateTime.Now)
                {
                    new Exception("Data inválida.");
                }
                db.SaveChanges();
            }
        }

        Response IFilmeService.Insert(Filme filme)
        {
            throw new NotImplementedException();
        }

        Response IFilmeService.Update(Filme filme)
        {
            throw new NotImplementedException();
        }

        Response IFilmeService.Delete(Filme filme)
        {
            throw new NotImplementedException();
        }

        Response IFilmeService.Validate(Filme filme)
        {
            throw new NotImplementedException();
        }
    }
}
