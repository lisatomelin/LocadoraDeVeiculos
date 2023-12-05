using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public GrupoAutomoveis GrupoAutomoveis { get; set; }
        public Cobranca Cobranca { get; set; }
        public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public decimal KmAutomovel { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DevolucaoPrevista { get; set; }
        public Cupom? Cupom { get; set; }
        public decimal ValorTotalPrevisto { get; set; }
        public List<TaxasServicos> ListaTaxasSelecionadas { get; set; }

        public decimal KmPercorrida { get; set; }
        public DateTime DataDevolucao { get; set; }
        public CombustivelNoTanqueEnum CombustivelNoTanque { get; set; }

        public Aluguel()
        {
            KmPercorrida = 0;
            ListaTaxasSelecionadas = new List<TaxasServicos>();
        }

        public Aluguel(Funcionario funcionario, Cliente cliente, GrupoAutomoveis grupoAutomoveis, Cobranca cobranca, Condutor condutor, Automovel automovel, decimal kmAutomovel, DateTime dataLocacao, DateTime devolucaoPrevista, Cupom cupom, decimal valorTotalPrevisto)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            GrupoAutomoveis = grupoAutomoveis;
            Cobranca = cobranca;
            Condutor = condutor;
            Automovel = automovel;
            KmAutomovel = kmAutomovel;
            DataLocacao = dataLocacao;
            DevolucaoPrevista = devolucaoPrevista;
            Cupom = cupom;
            ValorTotalPrevisto = valorTotalPrevisto;
            KmPercorrida = 0;
            ListaTaxasSelecionadas = new List<TaxasServicos>();
        }

        public override void Atualizar(Aluguel registro)
        {
            Funcionario = registro.Funcionario;
            Cliente = registro.Cliente;
            GrupoAutomoveis = registro.GrupoAutomoveis;
            Cobranca = registro.Cobranca;
            Condutor = registro.Condutor;
            Automovel = registro.Automovel;
            KmAutomovel = registro.KmAutomovel;
            DataLocacao = registro.DataLocacao;
            DevolucaoPrevista = registro.DevolucaoPrevista;
            Cupom = registro.Cupom;
            ValorTotalPrevisto = registro.ValorTotalPrevisto;
            ListaTaxasSelecionadas = registro.ListaTaxasSelecionadas;
        }

        public void CalcularValorTotal()
        {
            decimal valorTotal = 0;

            switch (Cobranca.TipoPlano)
            {
                case TipoPlanoEnum.PlanoDiario:

                    valorTotal += Cobranca.PrecoDiaria * (decimal)(DevolucaoPrevista - DataLocacao).TotalDays;

                    break;

                case TipoPlanoEnum.PlanoControlador:

                    decimal dias = (decimal)(DevolucaoPrevista - DataLocacao).TotalDays;

                    valorTotal += dias * Cobranca.PrecoDiaria;

                    break;

                case TipoPlanoEnum.PlanoLivre:

                    valorTotal += Cobranca.PrecoDiaria;

                    break;
            }

            valorTotal = AdicionandoValorTaxas(valorTotal);

            if(Cupom != null) 
                valorTotal = CalcularValorComCupom(valorTotal);

            ValorTotalPrevisto = valorTotal;
        }

        private decimal AdicionandoValorTaxas(decimal valorTotal)
        {
            foreach (TaxasServicos taxa in ListaTaxasSelecionadas)
            {
                if(taxa.PrecoDiaria)
                    valorTotal += taxa.Preco * (decimal)(DevolucaoPrevista - DataLocacao).TotalDays;
                else
                    valorTotal += taxa.Preco;
            }

            return valorTotal;
        }

        private decimal CalcularValorComCupom(decimal valorTotal)
        {
            valorTotal = valorTotal - Cupom.Valor;
            return valorTotal;
        }
    }
}
