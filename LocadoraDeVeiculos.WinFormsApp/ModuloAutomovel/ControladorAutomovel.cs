using FluentResults;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloPrecos;
using LocadoraDeVeiculos.Infra.Json.ModuloPrecos;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;
using LocadoraDeVeiculos.WinFormsApp.ModuloPrecos;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {
        private IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        private IRepositorioAutomovel repositorioAutomovel;
        private RepositorioPrecosJson repositorioPrecosJson;

        private ServicoAutomovel servicoAutomovel;

        private TabelaAutomovelControl tabelaAutomovel;

        public ControladorAutomovel(
            IRepositorioAutomovel repositorioAutomovel,
            IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis,
            ServicoAutomovel servicoAutomovel,
            RepositorioPrecosJson repositorioPrecosJson)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
            this.servicoAutomovel = servicoAutomovel;
            this.repositorioPrecosJson = repositorioPrecosJson;
        }

        public override void Inserir()
        {
            List<GrupoAutomoveis> gruposDeAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

            TelaAutomovelForm tela = new TelaAutomovelForm(gruposDeAutomoveis);

            tela.onGravarRegistro += servicoAutomovel.Inserir;

            tela.ConfigurarAutomovel(new Automovel());

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Edição de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<GrupoAutomoveis> gruposDeAutomoveis = repositorioGrupoAutomoveis.SelecionarTodos();

            TelaAutomovelForm tela = new TelaAutomovelForm(gruposDeAutomoveis);

            tela.onGravarRegistro += servicoAutomovel.Editar;

            tela.ConfigurarAutomovel(automovelSelecionado);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarAutomoveis();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro",
                "Exclusão de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o automóvel?",
               "Exclusão de Automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAutomovel.Excluir(automovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Automóveis", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarAutomoveis();
            }
        }

        public override ConfiguracaoToolBoxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovelControl();

            CarregarAutomoveis();

            return tabelaAutomovel;
        }

        private void CarregarAutomoveis()
        {
            List<Automovel> automoveis = repositorioAutomovel.SelecionarTodos(incluirGrupoDoAutomovel: true);

            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format("Visualizando {0} automoveis{1}", automoveis.Count, automoveis.Count == 1 ? "" : "s");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }

        public override void Filtrar()
        {
            TelaFiltroForm tela = new(repositorioGrupoAutomoveis);

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                List<Automovel> automoveis = repositorioAutomovel.SelecionarPorGrupo(tela.grupoAutomovel);

                CarregarAutomoveis(automoveis);
            }
            else if (resultado == DialogResult.Abort)
            {
                CarregarAutomoveis();
            }
        }

        private void CarregarAutomoveis(List<Automovel> automoveis)
        {
            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format($"Visualizando {automoveis.Count} automóve{0}", automoveis.Count == 1 ? "l" : "is");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape);
        }
    }
}