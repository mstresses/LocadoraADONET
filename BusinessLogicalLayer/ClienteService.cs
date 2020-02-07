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
    public class ClienteService : IClienteService
    {
        public void Insert(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }

        public void Update(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Cliente clienteASerAtualizado = new Cliente();
                db.Entry<Cliente>(clienteASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Cliente clienteASerExcluido = new Cliente();
                db.Entry<Cliente>(clienteASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Validate(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                if (string.IsNullOrWhiteSpace(cliente.Nome))
                {
                    new Exception("O nome do cliente deve ser informado.");
                }
                else
                {
                    cliente.Nome = cliente.Nome.Trim();
                    cliente.Nome = Regex.Replace(cliente.Nome, @"\s+", " ");
                    if (cliente.Nome.Length < 2 || cliente.Nome.Length > 50)
                    {
                        new Exception("O nome do cliente deve conter entre 2 e 50 caracteres");
                    }
                }
                if (string.IsNullOrWhiteSpace(cliente.Email))
                {
                    new Exception("O email do cliente deve ser informado.");
                }
                else
                {
                    cliente.Email = cliente.Email.Trim();
                    //Remove espaços extras entre as palavras, ex: "A      B", ficaria "A B".
                    cliente.Email = Regex.Replace(cliente.Email, @"\s+", " ");
                    if (cliente.Email.Length < 5 || cliente.Email.Length > 50)
                    {
                        new Exception("O email do cliente deve conter entre 2 e 50 caracteres");
                    }
                }
                db.SaveChanges();
            }
        }
    }
}