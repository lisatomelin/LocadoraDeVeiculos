using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis
{
    public interface IRepositorioGrupoAutomoveis : IRepositorio<GrupoAutomoveis>
    {
        public GrupoAutomoveis SelecionarPorNome(string nome);

        public List<GrupoAutomoveis> SelecionarTodos(bool incluirAutomoveis = false, bool incluirCobrancas = false);
    }
}
