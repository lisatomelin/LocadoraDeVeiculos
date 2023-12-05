using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Cor { get; set; }

        public string Modelo { get; set; }

        public TipoCombustivelEnum TipoCombustivel { get; set; }

        public decimal CapacidadeLitros { get; set; }

        public int Ano { get; set; }

        public byte[] Foto { get; set; }

        public GrupoAutomoveis GrupoDoAutomovel { get; set; }

        public decimal KmAutomovel { get; set; }

        public Automovel()
        {
        }
        public Automovel(decimal kmAutomovel, string placa, string marca, string cor, string modelo, TipoCombustivelEnum tipoCombustivel, decimal capacidadeLitros, int ano)
        {
            KmAutomovel = kmAutomovel;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Modelo = modelo;
            TipoCombustivel = tipoCombustivel;
            CapacidadeLitros = capacidadeLitros;
            Ano = ano;
        }

        public Automovel(decimal kmAutomovel, string placa, string marca, string cor, string modelo, TipoCombustivelEnum tipoCombustivel, decimal capacidadeLitros, int ano, GrupoAutomoveis grupoDoAutomovel) : this(kmAutomovel, placa, marca, cor, modelo, tipoCombustivel, capacidadeLitros, ano)
        {
            GrupoDoAutomovel = grupoDoAutomovel;
        }


        public Automovel(decimal kmAutomovel, string placa, string marca, string cor, string modelo, TipoCombustivelEnum tipoCombustivel, decimal capacidadeLitros, int ano, Byte[] foto)
        {
            KmAutomovel = kmAutomovel;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Modelo = modelo;
            TipoCombustivel = tipoCombustivel;
            CapacidadeLitros = capacidadeLitros;
            Foto = foto;
            Ano = ano;
        }

        public override void Atualizar(Automovel registro)
        {
            Placa = registro.Placa;
            Marca = registro.Marca;
            Cor = registro.Cor; 
            Modelo = registro.Modelo;
            TipoCombustivel = registro.TipoCombustivel;
            CapacidadeLitros = registro.CapacidadeLitros;
            Foto = registro.Foto;
            Ano = registro.Ano;
        }

        public override string ToString()
        {
            return Modelo;
        }
    }
}
