using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCliente;

namespace LocadoraDeVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase<Condutor>
    {
        public Cliente Cliente { get; set; }

        public bool ClienteCondutor { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Cpf { get; set; }

        public string Cnh { get; set; }

        public DateTime Validade { get; set; }

        public Condutor()
        {
            
        }

        public Condutor(string nome)
        {
            Nome = nome;
        }

        public Condutor(Guid id, string nome) 
        {
            this.Id = id;
            Nome = nome;
        }

        public Condutor(Cliente cliente, bool clienteCondutor, string nome, string email, string telefone, string cpf, string cnh, DateTime validade)
        {
            Cliente = cliente;
            ClienteCondutor = clienteCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
            Cnh = cnh;
            Validade = validade;
        }

        public override void Atualizar(Condutor registro)
        {
            Cliente = registro.Cliente;
            ClienteCondutor = registro.ClienteCondutor;
            Nome = registro.Nome;
            Email = registro.Email;
            Telefone = registro.Telefone;
            Cpf = registro.Cpf;
            Cnh = registro.Cnh;
            Validade = registro.Validade;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
