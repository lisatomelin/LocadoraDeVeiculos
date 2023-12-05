using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloCobranca
{
    public class Cobranca : EntidadeBase<Cobranca>
    {
        public GrupoAutomoveis GrupoAutomoveis { get; set; }

        public TipoPlanoEnum TipoPlano { get; set; }

        public decimal PrecoDiaria { get; set; }

        public decimal? PrecoPorKm { get; set; }

        public decimal? KmDisponivel { get; set; }

        public Cobranca()
        {
            
        }

        public Cobranca(GrupoAutomoveis grupoAutomoveis, TipoPlanoEnum tipoPlano, decimal precoDiaria, decimal precoPorKm)
        {
            GrupoAutomoveis = grupoAutomoveis;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
            PrecoPorKm = precoPorKm;
        }

        public Cobranca(GrupoAutomoveis grupoAutomoveis, TipoPlanoEnum tipoPlano, decimal precoDiaria, decimal precoPorKm, decimal kmDisponivel)
        {
            GrupoAutomoveis = grupoAutomoveis;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
            PrecoPorKm = precoPorKm;
            KmDisponivel = kmDisponivel;
        }

        public Cobranca(Guid id, GrupoAutomoveis grupoAutomoveis, TipoPlanoEnum tipoPlano, decimal precoDiaria)
        {
            Id = id;
            GrupoAutomoveis = grupoAutomoveis;
            TipoPlano = tipoPlano;
            PrecoDiaria = precoDiaria;
        }

        public override void Atualizar(Cobranca registro)
        {
            GrupoAutomoveis = registro.GrupoAutomoveis;
            TipoPlano = registro.TipoPlano;
            PrecoDiaria = registro.PrecoDiaria;
            PrecoPorKm = registro.PrecoPorKm;
            KmDisponivel = registro.KmDisponivel;
        }

        public override string ToString()
        {
            return TipoPlano.ToString();
        }
    }
}
