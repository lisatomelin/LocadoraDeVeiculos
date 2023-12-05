using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTeste
    {
        Funcionario funcionario;

        public FuncionarioTeste()
        {
            funcionario = new Funcionario(new Guid(), "Gabriel", DateTime.Now, 2500);
        }
    }
}
