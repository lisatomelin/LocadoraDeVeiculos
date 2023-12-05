using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloCobranca
{
    [TestClass]
    public class ValidadorCobrancaTest
    {
        private GrupoAutomoveis grupoAutomoveis;
        private Cobranca cobranca;
        private ValidadorCobranca validador;

        public ValidadorCobrancaTest()
        {
            grupoAutomoveis = new GrupoAutomoveis();
            cobranca = new Cobranca();
            validador = new ValidadorCobranca();
        }

        [TestMethod]
        public void PrecoDiaria_deve_ser_obrigatorio_e_conter_apenas_numeros_validos()
        {
            cobranca.PrecoDiaria = 100; 

            var resultado = validador.TestValidate(cobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoDiaria);
        }

        [TestMethod]
        public void TipoPlano_deve_ser_obrigatorio_e_diferente_de_Nenhum()
        {
            cobranca.TipoPlano = TipoPlanoEnum.PlanoDiario; 

            var resultado = validador.TestValidate(cobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.TipoPlano);
        }

        [TestMethod]
        public void GrupoAutomoveis_deve_ser_obrigatorio()
        {
            cobranca.GrupoAutomoveis = grupoAutomoveis; 

            var resultado = validador.TestValidate(cobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.GrupoAutomoveis);
        }

        [TestMethod]
        public void PrecoPorKm_deve_ser_obrigatorio_para_tipos_de_plano_PlanoDiario_e_PlanoControlador()
        {
            cobranca.TipoPlano = TipoPlanoEnum.PlanoDiario; 
            cobranca.PrecoPorKm = 50; 

            var resultado = validador.TestValidate(cobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoPorKm);
        }

        [TestMethod]
        public void PrecoPorKm_nao_deve_ser_aplicavel_para_tipo_de_plano_Livre()
        {
            cobranca.TipoPlano = TipoPlanoEnum.PlanoLivre; 
            cobranca.PrecoPorKm = null;

            var resultado = validador.TestValidate(cobranca);

            resultado.ShouldNotHaveValidationErrorFor(x => x.PrecoPorKm);
        }
    }
}
