using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;

namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis
{
    public class GrupoAutomoveis : EntidadeBase<GrupoAutomoveis>
    {
        public string Nome { get; set; }

        public List<Automovel> listaDeAutomoveis { get; set; }

        public List<Cobranca> listaDeCobrancas { get; set; }

        public GrupoAutomoveis()
        {
            listaDeAutomoveis = new List<Automovel>();
            listaDeCobrancas = new List<Cobranca>();
        }

        public GrupoAutomoveis(string nome)
        {
            Nome = nome;
            listaDeAutomoveis = new List<Automovel>();
            listaDeCobrancas = new List<Cobranca>();
        }

        public GrupoAutomoveis(Guid id, string nome) : this(nome)
        {
            this.Id = id;
            listaDeAutomoveis = new List<Automovel>();
            listaDeCobrancas = new List<Cobranca>();
        }

        public override void Atualizar(GrupoAutomoveis registro)
        {
            Nome = registro.Nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public bool AdicionarAutomovel(Automovel automovel)
        {
            if (listaDeAutomoveis.Contains(automovel))
                return false;

            listaDeAutomoveis.Add(automovel);

            return true;
        }

        public bool AdicionarCobranca(Cobranca cobranca)
        {
            if (listaDeCobrancas.Contains(cobranca))
                return false;
            
            foreach(var c in listaDeCobrancas)
            {
                if (c.TipoPlano == cobranca.TipoPlano)
                {
                    return false;
                }
            }

            listaDeCobrancas.Add(cobranca);

            return true;
        }
    }
}