using Dominio.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Context
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Cidade
            modelBuilder.Entity<Cidade>().HasOne(p => p.Estado_fk).WithMany(b => b.Cidade).HasForeignKey(p => p.Estado);
            
            //Usuario
            modelBuilder.Entity<Usuario>().HasOne(p => p.Cidade_Fk).WithMany(b => b.Usuario).HasForeignKey(p => p.Cidade);
                
        }
    }
}
