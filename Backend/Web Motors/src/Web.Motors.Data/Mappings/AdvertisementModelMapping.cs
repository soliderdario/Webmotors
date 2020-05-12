using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Motors.Domain.Model;

namespace Web.Motors.Data.Mappings
{
    public class AdvertisementModelMapping : IEntityTypeConfiguration<AdvertisementModel>
    {
        public void Configure(EntityTypeBuilder<AdvertisementModel> builder)
        {
            builder.ToTable("tb_AnuncioWebmotors");
            builder.Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(f => f.Marca).IsRequired().HasMaxLength(45);
            builder.Property(f => f.Modelo).IsRequired().HasMaxLength(45);
            builder.Property(f => f.Versao).IsRequired().HasMaxLength(45);
            builder.Property(f => f.Ano).IsRequired();
            builder.Property(f => f.Quilometragem).IsRequired();
            builder.Property(f => f.Observacao).IsRequired().HasColumnType("text");
        }

    }
}
