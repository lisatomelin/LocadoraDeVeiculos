using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloParceiro
{
    [TestClass]
    public class ValidadorParceiroTest
    {
        private Parceiro parceiro;
        private ValidadorParceiro validador;

        public ValidadorParceiroTest()
        {
            parceiro = new Parceiro();

            validador = new ValidadorParceiro();
        }

        [TestMethod]
        public void Nome_parceiro_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(parceiro);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_parceiro_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            parceiro.Nome = "ab";

            //action
            var resultado = validador.TestValidate(parceiro);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_parceiro_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            parceiro.Nome = "Artes @";

            //action
            var resultado = validador.TestValidate(parceiro);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
