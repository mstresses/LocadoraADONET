using EntityLocadora;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class LocadoraTesteStrategy : DropCreateDatabaseAlways<LocadoraDbContext>
    {
        protected override void Seed(LocadoraDbContext context)
        {
            //Código pra criar dados de testes quando a base for criada
            //using (context)
            //{
            //    Genero c = new Genero()
            //    {
            //        Nome = "Neco Bernart",
            //    };
            //    context.Generos.Add(c);
            //    context.SaveChanges();
            //}
            base.Seed(context);
        }
    }
}
