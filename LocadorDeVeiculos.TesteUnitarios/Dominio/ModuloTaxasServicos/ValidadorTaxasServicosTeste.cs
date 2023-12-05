using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Dominio.ModuloTaxasServicos
{
    [TestClass]
    public class ValidadorTaxasServicosTeste
    {
        private ValidadorTaxasServicos validador;
        private TaxasServicos taxasServicos;

        public ValidadorTaxasServicosTeste()
        {
            validador = new ValidadorTaxasServicos();

            taxasServicos = new TaxasServicos();
        }

        [TestMethod]
        public void Nome_taxasServicos_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(taxasServicos);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_taxasServicos_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            taxasServicos.Nome = "ab";

            //action
            var resultado = validador.TestValidate(taxasServicos);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_taxasServicos_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            taxasServicos.Nome = "Taxa de Lavação *";

            //action
            var resultado = validador.TestValidate(taxasServicos);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }


        [TestMethod]
        public void Preco_deve_ser_maior_que_zero()
        {
            //arrange
            taxasServicos.Preco = 0;

            //action
            var resultado = validador.TestValidate(taxasServicos);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Preco)
                .WithErrorMessage("'Preco' must be greater than '0'.");
        }

        [TestMethod]
        public void Deve_selecionar_plano_de_calculo()
        {
            //arrange
            taxasServicos.PrecoFixo = false;
            taxasServicos.PrecoDiaria = false;

            //action
            var resultado = validador.TestValidate(taxasServicos);


            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.PrecoFixo);
        }
    }
}
