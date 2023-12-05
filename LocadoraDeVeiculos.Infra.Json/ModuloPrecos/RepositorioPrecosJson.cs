using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloPrecos;

namespace LocadoraDeVeiculos.Infra.Json.ModuloPrecos
{
    public class RepositorioPrecosJson
    {
        protected ContextoDadosPrecos contextoDados;

        public RepositorioPrecosJson(ContextoDadosPrecos contexto)
        {
            contextoDados = contexto;
        }

        public void Salvar(Precos preco)
        {
            contextoDados.Precos = preco;

            contextoDados.GravarDados();
        }

        public Precos ObterRegistro()
        {
            return contextoDados.Precos;
        }
    }
}
