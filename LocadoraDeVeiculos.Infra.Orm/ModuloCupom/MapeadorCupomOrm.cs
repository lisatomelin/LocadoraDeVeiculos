using LocadoraDeVeiculos.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCupom
{
    public class MapeadorCupomOrm : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("TBCupom");
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.DataValidade).IsRequired();
            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.Parceiro)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBCupom_TBParceiro")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
