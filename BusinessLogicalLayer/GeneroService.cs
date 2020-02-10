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
        private LocadoraDbContext dal = new LocadoraDbContext();
        public Response Insert(Genero genero)
        {
            Response response = Validate(genero);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Generos.Add(genero);
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Update(Genero genero)
        {
            Response response = Validate(genero);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Genero generoASerAtualizado = new Genero();
                db.Entry<Genero>(generoASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Delete(Genero genero)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Genero generoASerExcluido = new Genero();
                db.Entry<Genero>(generoASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            if (genero.ID <= 0)
            {
                response.Erros.Add("ID do cliente não foi informado.");
            }
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Validate(Genero genero)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(genero.Nome))
                {
                    response.Erros.Add("O nome do gênero deve ser informado");
                }
                else
                {
                    //Remove espaços em branco no começo e no final da string.
                    genero.Nome = genero.Nome.Trim();
                    //Remove espaços extras entre as palavras, ex: "A      B", ficaria "A B".
                    genero.Nome = Regex.Replace(genero.Nome, @"\s+", " ");
                    if (genero.Nome.Length < 2 || genero.Nome.Length > 50)
                    {
                        response.Erros.Add("O nome do gênero deve conter entre 2 e 50 caracteres");
                    }
                }
                db.SaveChanges();
                return response;
            }
        }
    }
}