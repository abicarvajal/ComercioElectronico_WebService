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
    public class CartItemOrderConfiguration : IEntityTypeConfiguration<CartItemOrder>
    {
        public void Configure(EntityTypeBuilder<CartItemOrder> builder)
        {
            builder.ToTable("CartItemOrder");
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code)
                .IsRequired();

            builder.Property(b => b.Quantity)
                .IsRequired();

            builder.HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId);

        }
    }
}
