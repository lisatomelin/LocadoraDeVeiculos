using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCupom
{
    public class RepositorioCupomEmOrm : RepositorioBaseEmOrm<Cupom>, IRepositorioCupom
    {
        public RepositorioCupomEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public List<Cupom> SelecionarTodos(bool incluirParceiro = false)
        {
            if (incluirParceiro)
                return registros.Include(x => x.Parceiro).ToList();

            return registros.ToList();
        }

        public Cupom SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }
    }
}
