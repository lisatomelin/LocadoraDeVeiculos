using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAluguel
{
    public class RepositorioAluguelEmOrm : RepositorioBaseEmOrm<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
        }
        public Aluguel SelecionarPorId(Guid id, bool incluirCupom = false)
        {
            if (incluirCupom)
            {
                return registros
                    .Include(x => x.Funcionario)
                    .Include(x => x.Cliente)
                    .Include(x => x.GrupoAutomoveis)
                    .Include(x => x.Cobranca)
                    .Include(x => x.Condutor)
                    .Include(x => x.Automovel)
                    .Include(x => x.Cupom)
                    .Include(x => x.ListaTaxasSelecionadas)
                    .FirstOrDefault(x => x.Id == id);
            }
            return registros
                .Include(x => x.Funcionario)
                .Include(x => x.Cliente)
                .Include(x => x.GrupoAutomoveis)
                .Include(x => x.Cobranca)
                .Include(x => x.Condutor)
                .Include(x => x.Automovel)
                .Include(x => x.ListaTaxasSelecionadas)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Aluguel> SelecionarTodos(bool incluirCupom = false)
        {
            if (incluirCupom)
            {
                return registros
                     .Include(x => x.Funcionario)
                     .Include(x => x.Cliente)
                     .Include(x => x.GrupoAutomoveis)
                     .Include(x => x.Cobranca)
                     .Include(x => x.Condutor)
                     .Include(x => x.Automovel)
                     .Include(x => x.Cupom)
                     .Include(x => x.ListaTaxasSelecionadas)
                     .ToList();
            }
            if (incluirCupom = false)
            {
                return registros
                     .Include(x => x.Funcionario)
                     .Include(x => x.Cliente)
                     .Include(x => x.GrupoAutomoveis)
                     .Include(x => x.Cobranca)
                     .Include(x => x.Condutor)
                     .Include(x => x.Automovel)
                     .Include(x => x.ListaTaxasSelecionadas)
                     .ToList();
            }

            return registros.ToList();
        }
    }
}
