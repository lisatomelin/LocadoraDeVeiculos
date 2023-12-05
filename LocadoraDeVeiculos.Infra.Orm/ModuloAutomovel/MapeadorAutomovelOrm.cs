using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel
{
    public class MapeadorAutomovelOrm : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builderAutomovel)
        {
            builderAutomovel.ToTable("TBAutomovel");
            builderAutomovel.Property(a => a.Id).IsRequired(true).ValueGeneratedNever();
            builderAutomovel.Property(a => a.Modelo).IsRequired(true);
            builderAutomovel.Property(a => a.Marca).IsRequired(true);
            builderAutomovel.Property(a => a.Cor).IsRequired(true);
            builderAutomovel.Property(a => a.TipoCombustivel).IsRequired(true);
            builderAutomovel.Property(a => a.CapacidadeLitros).IsRequired(true);
            builderAutomovel.Property(a => a.KmAutomovel).IsRequired(true);
            builderAutomovel.Property(a => a.Foto).HasColumnType("varbinary(max)").IsRequired(false);


            builderAutomovel.HasOne(a => a.GrupoDoAutomovel)
                .WithMany(g => g.listaDeAutomoveis)
                .IsRequired()
                .HasConstraintName("FK_TBAutomovel_TBGrupoAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
