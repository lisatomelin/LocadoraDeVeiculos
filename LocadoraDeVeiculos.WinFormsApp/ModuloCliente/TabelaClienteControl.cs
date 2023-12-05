using GeradorTestes.WinApp;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
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
                  new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", FillWeight = 15F },

                  new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", FillWeight = 35F },

                  new DataGridViewTextBoxColumn { Name = "Telefone", HeaderText = "Telefone", FillWeight = 25F },

                  new DataGridViewTextBoxColumn { Name = "Email", HeaderText = "Email", FillWeight = 25F },

                  new DataGridViewTextBoxColumn { Name = "CPF", HeaderText = "CPF", FillWeight = 25F },

                  new DataGridViewTextBoxColumn { Name = "CNPJ", HeaderText = "CNPJ", FillWeight = 25F },

                  new DataGridViewTextBoxColumn { Name = "TipoDePessoa", HeaderText = "Tipo de Pessoa", FillWeight = 20F }
            };

            return colunas;
        }

        public Guid ObtemIdSelecionado()
        {
            return grid.SelecionarId();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (var cliente in clientes)
            {
                {
                    grid.Rows.Add(
                        cliente.Id,
                        cliente.Nome,
                        cliente.Telefone,
                        cliente.Email,
                        cliente.Cpf,
                        cliente.Cnpj,
                        cliente.TipoCliente
                    );
                }
            }
        }
    }
}
