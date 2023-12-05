using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloCupom
{
    [TestClass]
    public class ValidadorCupomTest
    {
        private Cupom cupom;
        private ValidadorCupom validador;

        public ValidadorCupomTest()
        {
            cupom = new Cupom();
            validador = new ValidadorCupom();
        }

        [TestMethod]
        public void Nome_cupom_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ter_no_minimo_3_caracteres()
        {
            cupom.Nome = "ab";

            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cupom_deve_ser_composto_por_letras_e_numeros()
        {
            cupom.Nome = "Cupom @";

            var resultado = validador.TestValidate(cupom);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
