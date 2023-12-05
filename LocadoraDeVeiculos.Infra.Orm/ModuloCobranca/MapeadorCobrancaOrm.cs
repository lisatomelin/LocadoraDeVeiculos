using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCobranca
{
    public class MapeadorCobrancaOrm : IEntityTypeConfiguration<Cobranca>
    {
        public void Configure(EntityTypeBuilder<Cobranca> builder)
        {
            builder.ToTable("TBCobranca");
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.TipoPlano).IsRequired();
            builder.Property(x => x.KmDisponivel).IsRequired(false);
            builder.Property(x => x.PrecoDiaria).IsRequired();
            builder.Property(x => x.PrecoPorKm).IsRequired(false);

            builder.HasOne(x => x.GrupoAutomoveis)
                .WithMany(c => c.listaDeCobrancas)
                .IsRequired()
                .HasConstraintName("FK_TBCobranca_TBGrupoAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
