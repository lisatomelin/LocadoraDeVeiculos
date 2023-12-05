using LocadoraDeVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.ModuloFuncionario
{
    public class Funcionario : EntidadeBase<Funcionario>
    {
        public string Nome { get; set; }

        public DateTime DataAdmissao { get; set; }

        public decimal Salario { get; set; }

        public Funcionario()
        {
        }

        public Funcionario(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Funcionario(Guid id, string nome, DateTime dataAdmissao, decimal salario)
        {
            Id = id;
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
        }

        public override void Atualizar(Funcionario registro)
        {
            Nome = registro.Nome;
            DataAdmissao = registro.DataAdmissao;
            Salario = registro.Salario;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
