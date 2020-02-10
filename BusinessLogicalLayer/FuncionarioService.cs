using BLL.Interfaces;
using DAO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FuncionarioService : IFuncionarioService
    {
        public void Insert(Funcionario funcionario)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Funcionarios.Add(funcionario);
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

        public void Delete(Funcionario funcionario)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Funcionario funcASerExcluido = new Funcionario();
                db.Entry<Funcionario>(funcASerExcluido).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void Validate(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        Response IFuncionarioService.Insert(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        Response IFuncionarioService.Update(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        Response IFuncionarioService.Delete(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        Response IFuncionarioService.Validate(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }
    }
}