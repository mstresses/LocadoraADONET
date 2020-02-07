using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class LocadoraTesteStrategy : DropCreateDatabaseAlways<LocadoraDbContext>
    {
        protected override void Seed(LocadoraDbContext context)
        {
            base.Seed(context);
        }
    }
}