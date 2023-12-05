using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxasServicos
{
    public interface IRepositorioTaxasServicos : IRepositorio<TaxasServicos>
    {
        public TaxasServicos SelecionarPorNome(string nome);

    }
}
