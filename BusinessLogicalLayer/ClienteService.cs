using BusinessLogicalLayer.Interfaces;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteService : IClienteService
    {

        public void Insert(Cliente cliente)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Cliente c = new Cliente()
                {
                    Nome = "Danizinho Bernart",
                    EhAtivo = true,
                    CPF = "901.917.069-49",
                    DataNascimento = DateTime.Now.AddYears(-25),
                    Email = "mooh.olive@gmail.com"
                };
                db.Clientes.Add(c);
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
    }
}