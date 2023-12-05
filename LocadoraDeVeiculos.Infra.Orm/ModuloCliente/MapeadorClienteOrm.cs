using LocadoraDeVeiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TBCliente");

            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(MAX)").IsRequired();

            //builder.HasOne(x => x.Condutor)
            //    .WithOne(x => x.Cliente)
            //    .IsRequired(false)
            //    .HasConstraintName("FK_TBCliente_TBCondutor")
            //    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
