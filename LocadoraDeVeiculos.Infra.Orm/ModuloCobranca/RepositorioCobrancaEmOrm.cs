using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloCobranca
{
    public class RepositorioCobrancaEmOrm : RepositorioBaseEmOrm<Cobranca>, IRepositorioCobranca
    {
        public RepositorioCobrancaEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public List<Cobranca> SelecionarTodos(bool incluirGrupoAutomoveis = false)
        {
            if (incluirGrupoAutomoveis)
                return registros.Include(x => x.GrupoAutomoveis).ToList();

            return registros.ToList();
        }
    }
}
