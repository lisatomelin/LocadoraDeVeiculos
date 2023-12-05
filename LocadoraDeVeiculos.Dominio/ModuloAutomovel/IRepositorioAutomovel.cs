using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorio<Automovel>
    {
        public List<Automovel> SelecionarPorGrupo(GrupoAutomoveis grupo);
        public Automovel SelecionarPorId(Guid id, bool incluirGrupoDoAutomovel = false);
        public List<Automovel> SelecionarTodos(bool incluirGrupoDoAutomovel = false);
    }
}
