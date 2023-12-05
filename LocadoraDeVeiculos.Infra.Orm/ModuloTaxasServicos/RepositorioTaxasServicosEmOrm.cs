using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloTaxasServicos
{
    public class RepositorioTaxasServicosEmOrm : RepositorioBaseEmOrm<TaxasServicos>, IRepositorioTaxasServicos
    {
        public RepositorioTaxasServicosEmOrm(LocadoraDeVeiculosDbContext dbContext) : base(dbContext)
        {

        }

        public TaxasServicos SelecionarPorNome(string nome)
        {
            return registros.FirstOrDefault(x => x.Nome == nome);
        }

    }
}
