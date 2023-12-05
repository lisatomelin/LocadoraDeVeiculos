using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel
{
    public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovelEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public Automovel SelecionarPorId(Guid id, bool incluirGrupoDoAutomovel = false)
        {
            if (incluirGrupoDoAutomovel)
                return registros
                    .Include(x => x.GrupoDoAutomovel)
                    .FirstOrDefault(x => x.Id == id);

            return registros.Find(id);
        }
        public List<Automovel> SelecionarTodos(bool incluirGrupoDoAutomovel = false)
        {
            if (incluirGrupoDoAutomovel)
                return registros.Include(x => x.GrupoDoAutomovel).ToList();
            return registros.ToList();
        }

        public List<Automovel> SelecionarPorGrupo(GrupoAutomoveis grupo)
        {
            return registros.Where(x => x.GrupoDoAutomovel == grupo).ToList();

        }
    }
}
