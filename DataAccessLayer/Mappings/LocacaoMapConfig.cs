using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class LocacaoMapConfig : EntityTypeConfiguration<Locacao>
    {
        public LocacaoMapConfig()
        {
            this.ToTable("LOCACOES");
            this.Property(l => l.DataDevolucao).HasColumnType("date").IsRequired();
            this.Property(l => l.DataLocacao).HasColumnType("date").IsRequired();
            this.Property(l => l.DataPrevistaDevolucao).HasColumnType("date").IsRequired();

        }
    }
}