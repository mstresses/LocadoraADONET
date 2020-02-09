using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    internal class FuncionarioMapConfig : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMapConfig()
        {
            this.ToTable("FUNCIONARIOS");
            this.Property(func => func.Nome).HasMaxLength(70);
            this.Property(func => func.Email).HasMaxLength(40);
            this.Property(func => func.CPF).IsFixedLength().HasMaxLength(14);
            this.Property(func => func.DataNascimento).HasColumnType("date").IsRequired();
            this.Property(func => func.Telefone).HasMaxLength(16);
            this.Property(func => func.Senha).HasMaxLength(8);

        }
    }

}
