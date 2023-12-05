using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloPrecos;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.Infra.Json.ModuloPrecos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinFormsApp.ModuloPrecos;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private RepositorioPrecosJson repositorioPrecosJson;
        private TabelaAluguelControl tabelaAluguel;
        private ServicoAluguel servicoAluguel;
        private IRepositorioAluguel repositorioAluguel;

        private IRepositorioFuncionario repositorioFuncionario;
        private IRepositorioCliente repositorioCliente;
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private IRepositorioCobranca repositorioCobranca;
        private IRepositorioCondutor repositorioCondutor;
        private IRepositorioAutomovel repositorioAutomovel;
        private IRepositorioCupom repositorioCupom;
        private IRepositorioTaxasServicos repositorioTaxasServicos;

        public ControladorAluguel(RepositorioPrecosJson repositorioPrecosJson, IRepositorioAluguel repositorioAluguel, IRepositorioFuncionario repositorioFuncionario, IRepositorioCliente repositorioCliente, IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis, IRepositorioCobranca repositorioCobranca, IRepositorioCondutor repositorioCondutor, IRepositorioAutomovel repositorioAutomovel, IRepositorioCupom repositorioCupom, IRepositorioTaxasServicos repositorioTaxasServicos, ServicoAluguel servico)
        {
            this.repositorioPrecosJson = repositorioPrecosJson;
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioFuncionario = repositorioFuncionario;
            this.repositorioCliente = repositorioCliente;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.repositorioCobranca = repositorioCobranca;
            this.repositorioCondutor = repositorioCondutor;
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioCupom = repositorioCupom;
            this.repositorioTaxasServicos = repositorioTaxasServicos;
            this.servicoAluguel = servico;
        }

        public override void Inserir()
        {
            List<Aluguel> aluguel = repositorioAluguel.SelecionarTodos();

            TelaAluguelForm tela = new TelaAluguelForm(repositorioFuncionario.SelecionarTodos(), repositorioCliente.SelecionarTodos(), repositorioGrupoAutomoveis.SelecionarTodos(),
                                                       repositorioCobranca.SelecionarTodos(), repositorioCondutor.SelecionarTodos(), repositorioAutomovel.SelecionarTodos(),
                                                       repositorioCupom.SelecionarTodos(), repositorioTaxasServicos.SelecionarTodos());

            tela.onGravarRegistro += servicoAluguel.Inserir;

            tela.ConfigurarAluguel(new Aluguel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Edição de Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            TelaAluguelForm tela = new TelaAluguelForm(repositorioFuncionario.SelecionarTodos(), repositorioCliente.SelecionarTodos(), repositorioGrupoAutomoveis.SelecionarTodos(),
                                                       repositorioCobranca.SelecionarTodos(), repositorioCondutor.SelecionarTodos(), repositorioAutomovel.SelecionarTodos(),
                                                       repositorioCupom.SelecionarTodos(), repositorioTaxasServicos.SelecionarTodos());

            tela.onGravarRegistro += servicoAluguel.Editar;

            tela.ConfigurarAluguel(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel automovelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Exclusão de aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o aluguel?",
               "Exclusão de alugueis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAluguel.Excluir(automovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Alugueis", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarAlugueis();
            }
        }

        public override void Email()
        {
            TelaEnviarEmailForm tela = new TelaEnviarEmailForm();

            DialogResult resultado = tela.ShowDialog();
        }

        public override void Pdf()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            TelaGerarPdfForm tela = new TelaGerarPdfForm(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAluguel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAluguel;
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos(incluirCupom: true);

            tabelaAluguel.AtualizarRegistros(alugueis);

            mensagemRodape = string.Format("Visualizando {0} aluguel{1}", alugueis.Count, alugueis.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Precos()
        {
            TelaPrecosForm tela = new TelaPrecosForm();

            tela.ConfigurarPrecos(repositorioPrecosJson.ObterRegistro());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Precos preco = tela.ObterPrecos();

                repositorioPrecosJson.Salvar(preco);
            }
        }

        public override void Devolucao()
        {
            Guid id = tabelaAluguel.ObtemIdSelecionado();

            Aluguel aluguelSelecionado = repositorioAluguel.SelecionarPorId(id);

            if (aluguelSelecionado == null)
            {
                MessageBox.Show("Selecione um aluguel primeiro",
                "Devolução de Aluguel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            TelaDevolucaoAluguelForm tela = new TelaDevolucaoAluguelForm(repositorioFuncionario.SelecionarTodos(), repositorioCliente.SelecionarTodos(), repositorioGrupoAutomoveis.SelecionarTodos(),
                                                       repositorioCobranca.SelecionarTodos(), repositorioCondutor.SelecionarTodos(), repositorioAutomovel.SelecionarTodos(),
                                                       repositorioCupom.SelecionarTodos(), repositorioTaxasServicos.SelecionarTodos());

            tela.onGravarRegistro += servicoAluguel.Devolucao;

            tela.ConfigurarAluguel(aluguelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAlugueis();
            }
        }
    }
}
