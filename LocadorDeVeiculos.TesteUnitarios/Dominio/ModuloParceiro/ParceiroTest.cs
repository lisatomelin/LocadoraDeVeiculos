using FluentAssertions;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloParceiro
{
    [TestClass]
    public class ParceiroTest
    {
        Parceiro parceiro;
        Cupom cupom01;
        private Cupom cupom02;

        public ParceiroTest()
        {
            parceiro = new Parceiro("Parceiro01");

            cupom01 = new Cupom("Cupom01", 200, DateTime.Now, parceiro);
        }

        [TestMethod]
        public void Cupons_Devem_ser_diferentes_de_null()
        {
            parceiro.Cupons.Should().NotBeNull();
        }

        [TestMethod]
        public void Deve_permitir_adicionar_cupons_no_parceiro()
        {
            //Cenário -- Arrange
            cupom02 = new Cupom("Cupom02", 500, DateTime.Now, parceiro);

            //Ação -- Action
            parceiro.AdicionarCupom(cupom01);
            parceiro.AdicionarCupom(cupom02);

            //Verificação -- Assert            
            parceiro.Cupons.Count.Should().Be(2);
        }

        [TestMethod]
        public void Nao_deve_adicionar_cupons_iguais_no_parceiro()
        {
            //arrange
            cupom01 = new Cupom("Cupom01", 200, DateTime.Now, parceiro);

            //action
            parceiro.AdicionarCupom(cupom01);
            parceiro.AdicionarCupom(cupom01);

            //assert
            parceiro.Cupons.Should().HaveCount(1);
        }
    }
}
