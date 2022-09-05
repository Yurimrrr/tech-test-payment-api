using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Entities;

namespace Payment.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base (options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        public DbSet<Seller>? Sellers { get; set; }
        public DbSet<Sale>? Sales { get; set; }

        public DbSet<StatusSale>? StatusSales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Id);
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");

            // Não tá funcionando
            /*
            modelBuilder.Entity<StatusSale>().HasData(
                new StatusSale("Aguardando Pagamento", 0),
                new StatusSale("Pagamento Aprovado", 1),
                new StatusSale("Enviado Transportadora", 2),
                new StatusSale("Cancelado", 3),
                new StatusSale("Entregue", 4)
                );
            */
            

        }
    }
}
