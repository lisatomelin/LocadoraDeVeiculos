using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloCondutor
{
    [TestClass]
    public class ValidadorCondutorTeste
    {
        //string nome, string email, string telefone, TipoClienteEnum tipoCliente, string cpf, string cnpj, string estado, string cidade, string bairro, string rua, int numeroCasa

        private Condutor condutor;
        private ValidadorCondutor validador;

        public ValidadorCondutorTeste()
        {
            condutor = new Condutor();
            validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_condutor_nao_deve_ser_nulo_ou_vazio()
        {
            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_deve_ter_no_minimo_3_caracteres()
        {
            //arrange
            condutor.Nome = "ab";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_condutor_deve_ser_composto_por_letras_e_numeros()
        {
            //arrange
            condutor.Nome = "Gabriel #";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("'Nome' deve ser composto por letras e números.");
        }

        [TestMethod]
        public void Email_condutor_deve_ser_valido()
        {
            //arrange
            condutor.Email = "emailinvalido";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("O campo Email é obrigatório");
        }

        [TestMethod]
        public void Telefone_condutor_deve_estar_no_formato_correto()
        {
            //arrange
            condutor.Telefone = "1234567890";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Telefone)
                .WithErrorMessage("O campo Telefone deve estar no formato (99) 99999-9999.");
        }

        [TestMethod]
        public void Cnh_condutor_deve_estar_no_formato_correto()
        {
            //arrange
            condutor.Cnh = "12345678901234";

            //action
            var resultado = validador.TestValidate(condutor);

            //assert
            resultado.ShouldHaveValidationErrorFor(x => x.Cnh)
                .WithErrorMessage("o campo CNH deve estar no formato 99.999.999/9999-99");
        }
    }
}
