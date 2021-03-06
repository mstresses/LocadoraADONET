﻿using Entity;
using EntityLocadora;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;;

namespace DataAccessLayer
{
    public class LocadoraDbContext : DbContext
    {
        public LocadoraDbContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\900211\Desktop\ProjetoTrio\LocadoraEntity.mdf;Integrated Security=True;Connect Timeout=30")
        {
            Database.SetInitializer(new LocadoraTesteStrategy());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Properties().Where(c => c.PropertyType == typeof(string))
                        .Configure(c => c.IsRequired().IsUnicode(false));

            base.OnModelCreating(modelBuilder);
        }
    }
}
