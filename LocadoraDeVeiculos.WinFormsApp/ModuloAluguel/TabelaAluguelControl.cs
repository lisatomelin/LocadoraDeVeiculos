using GeradorTestes.WinApp;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
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
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=10F },

                new DataGridViewTextBoxColumn { Name = "Condutor", HeaderText = "Condutor", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "Cobranca", HeaderText = "Cobrança", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "Automovel", HeaderText = "Automovel", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "DataLocacao", HeaderText = "Data Locacao", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "DevolucaoPrevista", HeaderText = "Devolução Prevista", FillWeight=25F },

                new DataGridViewTextBoxColumn { Name = "ValorTotal", HeaderText = "Valor Total", FillWeight=25F },

                //necessário
                //new DataGridViewTextBoxColumn { Name = "ValorTotalPrevisto", HeaderText = "Valor Total Previsto", FillWeight=25F },
            };

            return colunas;
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            grid.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                grid.Rows.Add(aluguel.Id, aluguel.Condutor, aluguel.Cobranca, aluguel.Automovel, aluguel.DataLocacao, aluguel.DevolucaoPrevista, aluguel.ValorTotalPrevisto);
            }
        }

        internal Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }
    }
}
