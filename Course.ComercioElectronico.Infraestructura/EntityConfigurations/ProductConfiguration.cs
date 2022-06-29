using Course.ComercioElectronico.Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.ComercioElectronico.Infraestructura.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(256);

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            //Relacion de 1 a muchos Vrand y productType
            builder.HasOne(b => b.ProductType)
                .WithMany()
                .HasForeignKey(b => b.ProductTypeId);

            builder.HasOne(b => b.Brand)
                .WithMany()
                .HasForeignKey(b => b.BrandId);

            builder.Property(b => b.IsDeleted)
                .IsRequired();

        }
    }
}
