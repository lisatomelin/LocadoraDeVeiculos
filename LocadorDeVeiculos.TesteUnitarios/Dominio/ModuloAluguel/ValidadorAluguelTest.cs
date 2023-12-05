using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloAluguel
{
    [TestClass]

    public class ValidadorAluguelTest
    { 
     
        private Aluguel aluguel;

        private ValidadorAluguel validador;

        public ValidadorAluguelTest()
        {
            aluguel = new Aluguel();
            validador = new ValidadorAluguel();
        }


        [TestMethod]
        public void Funcionario_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.Funcionario);
        }

        [TestMethod]
        public void Cliente_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cliente);
        }

        [TestMethod]
        public void Grupo_de_Autooveis_de_obrigatoria()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.GrupoAutomoveis);
        }

        [TestMethod]
        public void Plano_de_Cobranca_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.Cobranca);
        }

        [TestMethod]
        public void Condutor_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.Condutor);
        }

        [TestMethod]
        public void Automovel_deve_ser_obrigatorio()
        {
            var resultado = validador.TestValidate(aluguel);

            resultado.ShouldHaveValidationErrorFor(x => x.Automovel);
        }
    }
}

