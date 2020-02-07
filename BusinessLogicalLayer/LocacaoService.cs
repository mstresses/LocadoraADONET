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
    public class LocacaoService : ILocacaoService
    {
        public void Insert(Locacao locacao)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Locacao l = new Locacao()
                {
                    Preco = 2.50,
                    Multa = 1,
                    DataLocacao = DateTime.Now,
                    DataPrevistaDevolucao = DateTime.Now.AddDays(+3),
                    FoiPago = true
                };
                db.Locacoes.Add(l);
                db.SaveChanges();
            }
        }

        public void Update(Locacao locacao)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Locacao locacaoASerAtualizada = new Locacao();
                db.Entry<Locacao>(locacaoASerAtualizada).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(Locacao locacao)
        {
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                Locacao locacaoASerExcluida = new Locacao();
                db.Entry<Locacao>(locacaoASerExcluida).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}