using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAluguel
{
    public class MapeadorAluguelOrm : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("TBAluguel");
            builder.Property(x => x.Id).IsRequired().ValueGeneratedNever();
            builder.Property(x => x.KmAutomovel).IsRequired();
            builder.Property(x => x.DataLocacao).IsRequired();
            builder.Property(x => x.DevolucaoPrevista).IsRequired();
            builder.Property(x => x.ValorTotalPrevisto).IsRequired();
            builder.Property(x => x.KmPercorrida).IsRequired();
            builder.Property(x => x.DataDevolucao).IsRequired();
            builder.Property(x => x.CombustivelNoTanque).IsRequired().HasColumnType("decimal");

            builder.HasOne(x => x.Funcionario)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FuncionarioId")
                .HasConstraintName("FK_TBAluguel_TBFuncionario")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .IsRequired()
                .HasForeignKey("ClienteId")
                .HasConstraintName("FK_TBAluguel_TBCliente")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.GrupoAutomoveis)
                .WithMany()
                .IsRequired()
                .HasForeignKey("GrupoAutomoveisId")
                .HasConstraintName("FK_TBAluguel_TBGrupoAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Condutor)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CondutorId")
                .HasConstraintName("FK_TBAluguel_TBCondutor")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cobranca)
               .WithMany()
               .IsRequired()
               .HasForeignKey("CobrancaId")
               .HasConstraintName("FK_TBAluguel_TBCobranca")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Automovel)
               .WithMany()
               .IsRequired()
               .HasForeignKey("AutomovelId")
               .HasConstraintName("FK_TBAluguel_TBAutomovel")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Cupom)
               .WithMany()
               .IsRequired(false)
               .HasForeignKey("CupomId")
               .HasConstraintName("FK_TBAluguel_TBCupom")
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.ListaTaxasSelecionadas)
                .WithMany(x => x.ListaAlugueis)
                .UsingEntity(j => j.ToTable("TBAluguel_TaxasServicos"));
        }
    }
}


