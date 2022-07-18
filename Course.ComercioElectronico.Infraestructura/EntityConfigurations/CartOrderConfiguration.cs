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
    public class CartOrderConfiguration : IEntityTypeConfiguration<CartOrder>
    {

        public void Configure(EntityTypeBuilder<CartOrder> builder)
        {
            builder.ToTable("CartOrder");
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code)
                .IsRequired();

            builder.HasOne(b => b.DeliveryMethod)
                .WithMany()
                .HasForeignKey(b => b.DeliveryMethodId);

            builder.Metadata.FindNavigation(nameof(CartOrder.ProductDetail)).SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.ProductDetail).WithOne(b => b.CartOrder).HasForeignKey(b => b.CartOrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
