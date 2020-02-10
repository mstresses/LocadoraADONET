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
    class FuncionarioService : IFuncionarioService
    {
        public void Insert(Funcionario funcionario)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario func = new Funcionario()
                {
                    Nome = "Ana",
                    Email = "annezdz@hotmail.com",
                    CPF = "043.815.299-95",
                    DataNascimento = DateTime.Now.AddYears(-20),
                    Telefone = "(47)3322-4141",
                    Senha = "ana00994",
                    EhAtivo = true
                };
                db.Funcionarios.Add(func);
                db.SaveChanges();
            }
        }


        public void Delete(Funcionario funcionario)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerExcluido = new Funcionario();
                db.Entry<Funcionario>(funcASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public void Update(Funcionario funcionario)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerAtualizado = new Funcionario();
                db.Entry<Funcionario>(funcASerAtualizado).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
