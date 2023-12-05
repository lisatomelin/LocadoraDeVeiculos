using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadorDeVeiculos.TesteUnitarios.Dominio.ModuloGrupoAutomoveis
{
    [TestClass]
    public class ValidadorGrupoAutomoveisTeste
    {
        private ValidadorGrupoAutomoveis validador;
        private GrupoAutomoveis grupoAutomoveis;

        public ValidadorGrupoAutomoveisTeste()
        {
            grupoAutomoveis = new GrupoAutomoveis();

            validador = new ValidadorGrupoAutomoveis();
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            grupoAutomoveis.Nome = "ab";

            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_GrupoAutomoveis_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            grupoAutomoveis.Nome = "@ Ford";

            //action
            var resultado = validador.TestValidate(grupoAutomoveis);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }
    }
}
