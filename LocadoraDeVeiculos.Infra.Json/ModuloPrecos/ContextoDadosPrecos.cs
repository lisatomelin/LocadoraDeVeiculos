using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPrecos;
using LocadoraDeVeiculos.Infra.Json.Serializadores;

namespace LocadoraDeVeiculos.Infra.Json.ModuloPrecos
{
    [Serializable]
    public class ContextoDadosPrecos
    {
        private readonly SerializadorDadosEmJson serializador;

        public ContextoDadosPrecos()
        {
            Precos = new Precos();
        }

        public ContextoDadosPrecos(SerializadorDadosEmJson serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public Precos Precos { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Precos != null)
                this.Precos = ctx.Precos;
        }
    }
}
