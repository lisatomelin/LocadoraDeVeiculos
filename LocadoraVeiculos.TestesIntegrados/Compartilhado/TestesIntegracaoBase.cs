using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomoveis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LocadoraVeiculos.TestesIntegrados.Compartilhado
{
    public class TestesIntegracaoBase
    {
        protected IRepositorioAutomovel repositorioAutomovel;
        protected IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

        public TestesIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<LocadoraDeVeiculosDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new LocadoraDeVeiculosDbContext(optionsBuilder.Options);

            repositorioAutomovel = new RepositorioAutomovelEmOrm(dbContext);
            repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveisEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomoveis>(repositorioGrupoAutomoveis.Inserir);
        }

        protected static void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBAUTOMOVEL];                
                DELETE FROM [DBO].[TBALUGUEL];                
                DELETE FROM [DBO].[TBGRUPOAUTOMOVEIS];
                DELETE FROM [DBO].[TBDISCIPLINA];";

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
