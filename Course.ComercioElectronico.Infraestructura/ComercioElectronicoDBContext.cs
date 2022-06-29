using Course.ComercioElectronico.Dominio;
using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura
{
    public class ComercioElectronicoDBContext : DbContext
    {
        public DbSet<Catalogo> Catalogo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Brand> Brand { get; set; }

        public ComercioElectronicoDBContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //var conexion = @"Server=(localdb)\mssqllocaldb;Database=ComercioElectronico;Trusted_Connection=True";
            ////1. Configurar proveedor
            //optionsBuilder.UseSqlServer(conexion);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //con este metodo ya estamos llamando a todas las configuraciones
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<ProductType>(p =>
            //{
            //    p.ToTable("ProductType");
            //    p.HasKey(b => b.Code);

            //    p.Property(b => b.Code)
            //    .HasMaxLength(4)
            //    .IsRequired();

            //    p.Property(b => b.Description)
            //    .HasMaxLength(256)
            //    .IsRequired();

            //});

            //modelBuilder.Entity<Brand>(p =>
            //{
            //    p.ToTable("Brand");
            //    p.HasKey(b => b.Code);

            //    p.Property(b => b.Code)
            //    .HasMaxLength(4)
            //    .IsRequired();

            //    p.Property(b => b.Description)
            //    .HasMaxLength(256)
            //    .IsRequired();

            //});

            //modelBuilder.Entity<Product>(p =>
            //{
            //    p.ToTable("Product");
            //    p.HasKey(b => b.Id);

            //    p.Property(b => b.Id)
            //    .IsRequired();

            //    p.Property(b => b.Name)
            //    .HasMaxLength(100)
            //    .IsRequired();

            //});
        }
    }
}
