using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomoveis
{
    public class RepositorioGrupoAutomoveisEmOrm : RepositorioBaseEmOrm<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
    {
        public RepositorioGrupoAutomoveisEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }

        public GrupoAutomoveis SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

        public List<GrupoAutomoveis> SelecionarTodos(bool incluirAutomoveis = false, bool incluirCobrancas = false)
        {
            if (incluirAutomoveis && incluirCobrancas)
            {
                return registros
                        .Include(x => x.listaDeAutomoveis)
                        .Include(x => x.listaDeCobrancas)
                        .ToList();
            }

            else if (incluirAutomoveis)
            {
                return registros
                        .Include(x => x.listaDeAutomoveis)
                        .ToList();
            }

            else if (incluirCobrancas)
            {
                return registros
                        .Include(x => x.listaDeCobrancas)
                        .ToList();
            }
            return registros.ToList();
        }
    }
}
