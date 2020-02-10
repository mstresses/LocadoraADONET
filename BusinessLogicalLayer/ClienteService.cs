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
    public class ClienteService : IClienteService
    {
        public Response Insert(Cliente cliente)
        {
            Response response = Validate(cliente);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Update(Cliente cliente)
        {
            Response response = Validate(cliente);
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Cliente clienteASerAtualizado = new Cliente();
                db.Entry<Cliente>(clienteASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }
            return response;
        }

        public Response Delete(Cliente cliente)
        {
            Response response = new Response();
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Cliente clienteASerExcluido = new Cliente();
                db.Entry<Cliente>(clienteASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            if (cliente.ID <= 0)
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

        public Response Validate(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Response response = new Response();
                if (string.IsNullOrWhiteSpace(cliente.Nome))
                {
                    response.Erros.Add("O nome do cliente deve ser informado.");
                }
                else
                {
                    cliente.Nome = cliente.Nome.Trim();
                    cliente.Nome = Regex.Replace(cliente.Nome, @"\s+", " ");
                    if (cliente.Nome.Length < 2 || cliente.Nome.Length > 50)
                    {
                        response.Erros.Add("O nome do cliente deve conter entre 2 e 50 caracteres");
                    }
                }
                if (string.IsNullOrWhiteSpace(cliente.Email))
                {
                    response.Erros.Add("O email do cliente deve ser informado.");
                }
                else
                {
                    cliente.Email = cliente.Email.Trim();
                    cliente.Email = Regex.Replace(cliente.Email, @"\s+", " ");
                    if (cliente.Email.Length < 5 || cliente.Email.Length > 50)
                    {
                        response.Erros.Add("O email do cliente deve conter entre 2 e 50 caracteres");
                    }
                }
                db.SaveChanges();
                return response;
            }
        }

        public DataResponse<Cliente> GetData()
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                DataResponse<Cliente> response = new DataResponse<Cliente>();
                try
                {
                    response.Data = db.Clientes.ToList();
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

        public DataResponse<Cliente> GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}