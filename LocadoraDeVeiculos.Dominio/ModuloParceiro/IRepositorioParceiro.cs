using FluentValidation;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public interface IRepositorioParceiro : IRepositorio<Parceiro>
    {
        public List<Parceiro> SelecionarTodos(bool incluirCupons = false);
        public Parceiro SelecionarPorNome(string nome);
    }
}
