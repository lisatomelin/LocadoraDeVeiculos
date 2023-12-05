using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.Compartilhado;

namespace LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel
{
    public partial class TelaFiltroForm : Form
    {
        public GrupoAutomoveis grupoAutomovel;

        public TelaFiltroForm(IRepositorioGrupoAutomoveis repositorioGrupoAutomovel)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            ConfigurarComboBox(repositorioGrupoAutomovel);
        }

        private void ConfigurarComboBox(IRepositorioGrupoAutomoveis repositorioGrupoAutomovel)
        {
            foreach (var item in repositorioGrupoAutomovel.SelecionarTodos())
            {
                txtListaGrupoAutomoveis.Items.Add(item);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            grupoAutomovel = (GrupoAutomoveis)txtListaGrupoAutomoveis.SelectedItem;
        }
    }
}
