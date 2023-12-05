using GeradorTestes.WinApp;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCobranca
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "GpAutomoveis", HeaderText = "Grupo Automoveis", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "TipoPlano", HeaderText = "Tipo do Plano", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PrecoDiaria", HeaderText = "Preço Diária", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PreçoKm", HeaderText = "Preço por Km", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "KmDisponivel", HeaderText = "Km Disponível", FillWeight=85F },
            };

            return colunas;
        }

        internal void AtualizarRegistros(List<Cobranca> cobrancas)
        {
            grid.Rows.Clear();

            foreach (Cobranca cobranca in cobrancas)
            {
                grid.Rows.Add(cobranca.Id, cobranca.GrupoAutomoveis, cobranca.TipoPlano,
                    cobranca.PrecoDiaria, cobranca.PrecoPorKm, cobranca.KmDisponivel);
            }
        }

        internal Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
