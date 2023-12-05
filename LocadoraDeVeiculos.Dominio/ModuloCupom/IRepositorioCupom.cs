using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;

namespace LocadoraDeVeiculos.Dominio.ModuloCupom
{
    public interface IRepositorioCupom : IRepositorio<Cupom>
    {

        public List<Cupom> SelecionarTodos(bool incluirParceiro = false);

        public Cupom SelecionarPorNome(string nome);
    }
}
