using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomoveis
{
    public class MapeadorGrupoAutomoveisOrm : IEntityTypeConfiguration<GrupoAutomoveis>
    {
        public void Configure(EntityTypeBuilder<GrupoAutomoveis> builder)
        {
            builder.ToTable("TBGrupoAutomoveis");

            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();

            builder.Property(x => x.Nome).IsRequired();
        }
    }
}
