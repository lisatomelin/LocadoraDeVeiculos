using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.TestesUnitarios.Dominio
{
    [TestClass]
    public class AutomovelTest
    {
        Automovel automovelFordK;
        GrupoAutomoveis grupoAutomoveis;

        public AutomovelTest()
        {
            grupoAutomoveis = new GrupoAutomoveis("Economico");

            automovelFordK = new Automovel("BRA2E19", "Ford", "Verde", "Ford Ka", TipoCombustivelEnum.Gasolina, 55, 2021, grupoAutomoveis);
        }

        [TestMethod]
        public void GrupoDeAutomoveis_Devem_ser_diferentes_de_null()
        {
            automovelFordK.GrupoDoAutomovel.Should().NotBeNull();
        }
    }
}
