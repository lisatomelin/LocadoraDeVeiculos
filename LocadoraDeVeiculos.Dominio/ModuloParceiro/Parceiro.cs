using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;

namespace LocadoraDeVeiculos.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase<Parceiro>
    {
        public string Nome { get; set; }
        public List<Cupom> Cupons { get; set; }

        public Parceiro()
        {
        }

        public Parceiro(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            Cupons = new List<Cupom>();
        }

        public Parceiro(string nome)
        {
            Nome = nome;
            Cupons = new List<Cupom>();
        }

        public override void Atualizar(Parceiro registro)
        {
            Nome = registro.Nome;
        }


        public bool AdicionarCupom(Cupom cupom)
        {
            if (Cupons.Contains(cupom))
                return false;

            Cupons.Add(cupom);

            return true;
        }
        public override string ToString()
        {
            return Nome;
        }
    }
}
