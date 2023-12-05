using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloCliente;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloCondutor;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloAluguel;
using LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloCliente;
using LocadoraDeVeiculos.Infra.Orm.ModuloCobranca;
using LocadoraDeVeiculos.Infra.Orm.ModuloCondutor;
using LocadoraDeVeiculos.Infra.Orm.ModuloCupom;
using LocadoraDeVeiculos.Infra.Orm.ModuloFuncionario;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Infra.Orm.ModuloParceiro;
using LocadoraDeVeiculos.Infra.Orm.ModuloTaxasServicos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeVeiculos.TesteIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IRepositorioCliente repositorioCliente;
        protected IRepositorioCondutor repositorioCondutor;
        protected IRepositorioCupom repositorioCupom;
        protected IRepositorioParceiro repositorioParceiro;
        protected IRepositorioTaxasServicos repositorioTaxasServicos;
        protected IRepositorioCobranca repositorioCobranca;
        protected IRepositorioAluguel repositorioAluguel;
        protected IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;
        protected IRepositorioAutomovel repositorioAutomovel;
        protected IContextoPersistencia contextoPersistencia;

        public TestesIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);
            contextoPersistencia = dbContext;

            repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteEmOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
            repositorioCupom = new RepositorioCupomEmOrm(dbContext);
            repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
            repositorioTaxasServicos = new RepositorioTaxasServicosEmOrm(dbContext);
            repositorioCobranca = new RepositorioCobrancaEmOrm(dbContext);
            repositorioAluguel = new RepositorioAluguelEmOrm(dbContext);
            repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelEmOrm(dbContext);


            BuilderSetup.SetCreatePersistenceMethod<Funcionario>((Funcionario) =>
            {
                repositorioFuncionario.Inserir(Funcionario);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cliente>((Cliente) =>
            {
                repositorioCliente.Inserir(Cliente);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Automovel>((Automovel) =>
            {
                repositorioAutomovel.Inserir(Automovel);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Condutor>((Condutor) =>
            {
                repositorioCondutor.Inserir(Condutor);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cupom>((Cupom) =>
            {
                repositorioCupom.Inserir(Cupom);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>((GrupoAutomoveis) =>
            {
                repositorioGrupoAutomoveis.Inserir(GrupoAutomoveis);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>((Parceiro) =>
            {
                repositorioParceiro.Inserir(Parceiro);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Cobranca>((Cobranca) =>
            {
                repositorioCobranca.Inserir(Cobranca);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<TaxasServicos>((TaxasServicos) =>
            {
                repositorioTaxasServicos.Inserir(TaxasServicos);
                contextoPersistencia.GravarDados();
            });

            BuilderSetup.SetCreatePersistenceMethod<Aluguel>((Aluguel) =>
            {
                repositorioAluguel.Inserir(Aluguel);
                contextoPersistencia.GravarDados();
            });
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"

                
                DELETE FROM [DBO].[TBTAXASSERVICOS]

                DELETE FROM [DBO].[TBFUNCIONARIO]

                DELETE FROM [DBO].[TBCOBRANCA]

                DELETE FROM [DBO].[TBAUTOMOVEL]

                DELETE FROM [DBO].[TBGRUPOAUTOMOVEIS]

                DELETE FROM [DBO].[TBCONDUTOR]

                DELETE FROM [DBO].[TBCLIENTE]

                DELETE FROM [DBO].[TBCUPOM]

                DELETE FROM [DBO].[TBPARCEIRO];";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}
