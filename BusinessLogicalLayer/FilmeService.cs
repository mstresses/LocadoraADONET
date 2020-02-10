using BLL.Interfaces;
using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class FilmeService : IFilmeService
    {
        public Response Insert(Filme filme)
        {
            Response response = Validate(filme);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Update(Filme filme)
        {
            Response response = Validate(filme);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme filmeASerAtualizado = new Filme();
                db.Entry<Filme>(filmeASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Delete(Filme filme)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Filme filmeASerExcluido = new Filme();
                db.Entry<Filme>(filmeASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            if (filme.ID <= 0)
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

        public Response Validate(Filme filme)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(filme.Nome))
                {
                    new Exception("O nome do filme deve ser informado");
                }
                else
                {
                    filme.Nome = filme.Nome.Trim();
                    filme.Nome = Regex.Replace(filme.Nome, @"\s+", " ");
                    if (filme.Nome.Length < 2 || filme.Nome.Length > 50)
                    {
                        response.Erros.Add("O nome do filme deve conter entre 2 e 50 caracteres");
                    }
                }
                if (filme.Duracao <= 10)
                {
                    response.Erros.Add("Duração não pode ser menor que 10 minutos.");
                }

                if (filme.DataLancamento == DateTime.MinValue || filme.DataLancamento > DateTime.Now)
                {
                    response.Erros.Add("Data inválida.");
                }
                db.SaveChanges();
                return response;
            }
        }

        public DataResponse<Filme> GetData()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                DataResponse<Filme> response = new DataResponse<Filme>();
                try
                {
                    response.Data = db.Filmes.ToList();
                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    File.WriteAllText("log.txt", ex.Message);
                    response.Sucesso = false;
                    response.Erros.Add("Erro no banco de dados, contate o adm.");
                    return response;
                }
            }
        }

        public DataResponse<Filme> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}