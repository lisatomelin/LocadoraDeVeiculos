using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPrecos
{
    [Serializable]
    public class Precos : EntidadeBase<Precos>
    {
        public decimal Gasolina { get; set; }
        public decimal Gas { get; set; }
        public decimal Diesel { get; set; }
        public decimal Alcool { get; set; }

        public Precos()
        {
        }

        public Precos(Guid id, decimal gasolina, decimal gas, decimal diesel, decimal alcool)
        {
            this.Id = id;
            Gasolina = gasolina;
            Gas = gas;
            Diesel = diesel;
            Alcool = alcool;
        }

        public override void Atualizar(Precos registro)
        {
            Gasolina = registro.Gasolina;
            Gas = registro.Gas;
            Diesel = registro.Diesel;
            Alcool = registro.Alcool;
        }
    }
}
