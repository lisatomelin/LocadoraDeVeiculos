using FluentValidation.TestHelper;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.TestesUnitarios.Dominio.ModuloCliente
{
    [TestClass]
    public class ValidadorClienteTest
    {
        private Cliente cliente;
        private ValidadorCliente validador;

        public ValidadorClienteTest()
        {
            cliente = new Cliente();
            validador = new ValidadorCliente();
        }

        [TestMethod]
        public void Nome_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_deve_ter_no_minimo_6_caracteres()
        {
            cliente.Nome = "John"; 

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Nome_cliente_deve_ser_composto_por_letras()
        {
            cliente.Nome = "Cliente123";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Nome);
        }

        [TestMethod]
        public void Email_cliente_nao_deve_ser_nulo_ou_vazio()
        {
            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Email_cliente_deve_ser_um_endereco_de_email_valido()
        {
            cliente.Email = "invalid_email"; 

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [TestMethod]
        public void Telefone_cliente_deve_estar_no_formato_valido()
        {
            cliente.Telefone = "(12) 12345";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Telefone);
        }

        [TestMethod]
        public void Cpf_cliente_deve_estar_no_formato_valido()
        {
            cliente.Cpf = "123.456.789-00000";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Cpf);
        }

        //[TestMethod]
        //public void Cnpj_cliente_deve_estar_no_formato_valido()
        //{
        //    cliente.Cnpj = "12.345.678/9000000-11"; 

        //    var resultado = validador.TestValidate(cliente);

        //    resultado.ShouldHaveValidationErrorFor(x => x.Cnpj);
        //}

        [TestMethod]
        public void Estado_cliente_deve_ter_exatamente_2_caracteres()
        {
            cliente.Estado = "São Paulo";

            var resultado = validador.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(x => x.Estado);
        }


    }
}
