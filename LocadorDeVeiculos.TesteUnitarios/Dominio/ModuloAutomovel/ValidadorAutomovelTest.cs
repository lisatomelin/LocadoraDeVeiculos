using FluentValidation;
using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloAutomovel
{
    [TestClass]
    public class ValidadorAutomovelTest
    {
        private Automovel automovel;
        private ValidadorAutomovel validador;

        public ValidadorAutomovelTest()
        {
            automovel = new Automovel();
            validador = new ValidadorAutomovel();
        }

        [TestMethod]
        public void Nome_automovel_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void GrupoDoAutomovel_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.GrupoDoAutomovel);
        }

        [TestMethod]
        public void Modelo_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Modelo);
        }

        [TestMethod]
        public void Marca_deve_ser_obrigatoria()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Marca);
        }

        [TestMethod]
        public void Cor_deve_ser_obrigatoria()
        {
            var resultado = validador.TestValidate(automovel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cor);
        }
    }
}
