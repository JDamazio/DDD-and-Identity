using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase( DbContextOptions options ) : base(options)
        {
        }

        public DbSet<Aula> Aula { get; set; }
        public DbSet<UsuarioDetail> UsuarioDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            //return "Data Source=;Initial Catalog=;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            //"Data Source=JDAMAZIO\SQLSERVER2022;Initial Catalog=db_boxnJump;Persist Security Info=True;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True"
            return @"Data Source=JDAMAZIO\SQLSERVER2022;Initial Catalog=db_bJump;Integrated Security=True;;MultipleActiveResultSets=true;TrustServerCertificate=True"; 
        }

    }
}
