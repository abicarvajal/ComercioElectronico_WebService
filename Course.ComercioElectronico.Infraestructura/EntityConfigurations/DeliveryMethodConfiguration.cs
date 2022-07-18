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
    public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.ToTable("DeliveryMethod");
            builder.HasKey(b => b.Code);

            builder.Property(b => b.Code)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)"); ;

            builder.Property(b => b.DeliveryTime)
                .IsRequired();
        }
    }
}
