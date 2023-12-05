using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloPrecos;
using LocadoraDeVeiculos.Infra.Json.ModuloPrecos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.ModuloAluguel;
using LocadoraDeVeiculos.WinFormsApp.ModuloCobranca;
using LocadoraDeVeiculos.WinFormsApp.ModuloPrecos;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {
        private TabelaCupomControl tabelaCupom;
        private ServicoCupom servicoCupom;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioParceiro repositorioParceiro;

        public ControladorCupom(ServicoCupom servicoCupom,
            IRepositorioCupom repositorioCupom, IRepositorioParceiro repositorioParceiro)
        {
            this.servicoCupom = servicoCupom;
            this.repositorioCupom = repositorioCupom;
            this.repositorioParceiro = repositorioParceiro;
        }

        public override void Inserir()
        {
            TelaCupomForm tela = new TelaCupomForm(repositorioParceiro.SelecionarTodos());

            tela.onGravarRegistro += servicoCupom.Inserir;

            tela.ConfigurarCupom(new Cupom());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCupons();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um cupom primeiro",
                "Edição de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCupomForm tela = new TelaCupomForm(repositorioParceiro.SelecionarTodos());

            tela.onGravarRegistro += servicoCupom.Editar;

            tela.ConfigurarCupom(cupomSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCupons();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um cupom primeiro",
                "Exclusão de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o Cupom?",
               "Exclusão de Cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCupom.Excluir(cupomSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Cupons",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarCupons();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCupom();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCupom == null)
                tabelaCupom = new TabelaCupomControl();

            CarregarCupons();

            return tabelaCupom;
        }

        private void CarregarCupons()
        {
            List<Cupom> cupons = repositorioCupom.SelecionarTodos(true);

            tabelaCupom.AtualizarRegistros(cupons);

            mensagemRodape = string.Format("Visualizando {0} Cupo{1} de cobrança", cupons.Count, cupons.Count == 1 ? "m" : "ns");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Email()
        {
            TelaEnviarEmailForm tela = new TelaEnviarEmailForm();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {

            }
        }
    }
}
