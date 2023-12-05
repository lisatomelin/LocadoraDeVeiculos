using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloCobranca
{
    public interface IRepositorioCobranca : IRepositorio<Cobranca>
    {
        public List<Cobranca> SelecionarTodos(bool incluirGrupoAutomoveis = false);
    }
}
