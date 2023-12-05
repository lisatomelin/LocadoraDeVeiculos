using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxasServicos;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos
{
    public class ControladorTaxasServicos : ControladorBase
    {
        private IRepositorioTaxasServicos repositorioTaxasServicos;

        private TabelaTaxasServicosControl tabelaTaxasServicos;

        private ServicoTaxasServicos servicoTaxasServicos;

        public ControladorTaxasServicos(
            IRepositorioTaxasServicos repositorioTaxasServicos,
            ServicoTaxasServicos servicoTaxasServicos)
        {
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.servicoTaxasServicos = servicoTaxasServicos;
        }

        public override void Inserir()
        {
            TelaTaxasServicosForm tela = new TelaTaxasServicosForm();

            tela.onGravarRegistro += servicoTaxasServicos.Inserir;

            tela.ConfigurarTaxasServicos(new TaxasServicos());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxasServicos();
            }
        }


        public override void Editar()
        {
            Guid id = tabelaTaxasServicos.ObtemIdSelecionado();

            TaxasServicos taxasServicosSelecionada = repositorioTaxasServicos.SelecionarPorId(id);

            if (taxasServicosSelecionada == null)
            {
                MessageBox.Show("Selecione um serviço primeiro",
                "Edição de Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaTaxasServicosForm tela = new TelaTaxasServicosForm();

            tela.onGravarRegistro += servicoTaxasServicos.Editar;

            tela.ConfigurarTaxasServicos(taxasServicosSelecionada);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxasServicos();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaTaxasServicos.ObtemIdSelecionado();

            TaxasServicos taxasServicosSelecionada = repositorioTaxasServicos.SelecionarPorId(id);

            if (taxasServicosSelecionada == null)
            {
                MessageBox.Show("Selecione um serviço primeiro",
                "Exclusão de Serviços", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o serviço?",
               "Exclusão de Serviços", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoTaxasServicos.Excluir(taxasServicosSelecionada);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Serviços",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarTaxasServicos();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxTaxasServicos();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaTaxasServicos == null)
                tabelaTaxasServicos = new TabelaTaxasServicosControl();

            CarregarTaxasServicos();

            return tabelaTaxasServicos;
        }

        private void CarregarTaxasServicos()
        {
            List<TaxasServicos> taxasServicos = repositorioTaxasServicos.SelecionarTodos();

            tabelaTaxasServicos.AtualizarRegistros(taxasServicos);

            mensagemRodape = string.Format("Visualizando {0} servico{1}", taxasServicos.Count, taxasServicos.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}
