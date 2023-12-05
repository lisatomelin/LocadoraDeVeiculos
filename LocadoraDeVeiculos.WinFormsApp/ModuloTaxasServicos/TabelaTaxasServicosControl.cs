using GeradorTestes.WinApp;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos
{
    public partial class TabelaTaxasServicosControl : UserControl
    {
        public TabelaTaxasServicosControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight=15F },

                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "Preco", HeaderText = "Preço", FillWeight=85F },

                new DataGridViewTextBoxColumn { Name = "PlanoCalculo", HeaderText = "Plano de Calculo", FillWeight=85F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<TaxasServicos> listTaxasServicos)
        {
            grid.Rows.Clear();

            foreach (TaxasServicos taxasServicos in listTaxasServicos)
            {
                grid.Rows.Add(taxasServicos.Id, taxasServicos.Nome, taxasServicos.Preco, taxasServicos.PrecoDiaria ? "Cobrança diária" : (taxasServicos.PrecoFixo ? "Preço fixo" : ""));
            }
        }
    }
}
