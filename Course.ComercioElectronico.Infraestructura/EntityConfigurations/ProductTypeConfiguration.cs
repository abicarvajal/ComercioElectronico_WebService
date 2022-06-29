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
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        //Separar la configuracion para no tenerla en el DBContext
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
                builder.ToTable("ProductType");
                builder.HasKey(b => b.Code);

                builder.Property(b => b.Code)
                .HasMaxLength(4)
                .IsRequired();

                builder.Property(b => b.Description)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}
