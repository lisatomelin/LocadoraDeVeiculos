using LocadoraDeVeiculos.Aplicacao.ModuloAluguel;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloCliente;
using LocadoraDeVeiculos.Aplicacao.ModuloCobranca;
using LocadoraDeVeiculos.Aplicacao.ModuloCondutor;
using LocadoraDeVeiculos.Aplicacao.ModuloCupom;
using LocadoraDeVeiculos.Aplicacao.ModuloFuncionario;
using LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.Aplicacao.ModuloParceiro;
using LocadoraDeVeiculos.Aplicacao.ModuloTaxasServicos;
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
using LocadoraDeVeiculos.Infra.Json.ModuloPrecos;
using LocadoraDeVeiculos.Infra.Json.Serializadores;
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
using LocadoraDeVeiculos.WinFormsApp.ModuloAluguel;
using LocadoraDeVeiculos.WinFormsApp.ModuloAutomovel;
using LocadoraDeVeiculos.WinFormsApp.ModuloCliente;
using LocadoraDeVeiculos.WinFormsApp.ModuloCobranca;
using LocadoraDeVeiculos.WinFormsApp.ModuloCondutor;
using LocadoraDeVeiculos.WinFormsApp.ModuloCupom;
using LocadoraDeVeiculos.WinFormsApp.ModuloFuncionario;
using LocadoraDeVeiculos.WinFormsApp.ModuloGrupoAutomoveis;
using LocadoraDeVeiculos.WinFormsApp.ModuloParceiro;
using LocadoraDeVeiculos.WinFormsApp.ModuloTaxasServicos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraDeVeiculos.WinFormsApp.Compartilhado.IoC
{
    public class IoC_ComInjecaoDespendecia : IoC
    {
        private ServiceProvider container;

        public IoC_ComInjecaoDespendecia()
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, LocadoraDeVeiculosDbContext>(OptionsBuilder =>
            {
                OptionsBuilder.UseSqlServer(connectionString);
            });

            servicos.AddTransient<ControladorAluguel>();
            servicos.AddTransient<ServicoAluguel>();
            servicos.AddTransient<IValidadorAluguel, ValidadorAluguel>();
            servicos.AddTransient<IRepositorioAluguel, RepositorioAluguelEmOrm>();

            servicos.AddTransient<RepositorioPrecosJson>();
            servicos.AddTransient<ControladorAutomovel>();
            servicos.AddTransient<ServicoAutomovel>();
            servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddTransient<IRepositorioAutomovel, RepositorioAutomovelEmOrm>();

            servicos.AddTransient<IRepositorioCliente, RepositorioClienteEmOrm>();
            servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
            servicos.AddTransient<ServicoCliente>();
            servicos.AddTransient<ControladorCliente>();

            servicos.AddTransient<IRepositorioCobranca, RepositorioCobrancaEmOrm>();
            servicos.AddTransient<IValidadorCobranca, ValidadorCobranca>();
            servicos.AddTransient<ServicoCobranca>();
            servicos.AddTransient<ControladorCobranca>();

            servicos.AddTransient<IRepositorioCondutor, RepositorioCondutorEmOrm>();
            servicos.AddTransient<IValidadorCondutor, ValidadorCondutor>();
            servicos.AddTransient<ServicoCondutor>();
            servicos.AddTransient<ControladorCondutor>();

            servicos.AddTransient<IRepositorioCupom, RepositorioCupomEmOrm>();
            servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
            servicos.AddTransient<ServicoCupom>();
            servicos.AddTransient<ControladorCupom>();

            servicos.AddTransient<IRepositorioFuncionario, RepositorioFuncionarioEmOrm>();
            servicos.AddTransient<IValidadorFuncionario, ValidadorFuncionario>();
            servicos.AddTransient<ServicoFuncionario>();
            servicos.AddTransient<ControladorFuncionario>();

            servicos.AddTransient<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisEmOrm>();
            servicos.AddTransient<IValidadorGrupoAutomoveis, ValidadorGrupoAutomoveis>();
            servicos.AddTransient<ServicoGrupoAutomoveis>();
            servicos.AddTransient<ControladorGrupoAutomoveis>();

            servicos.AddTransient<IRepositorioParceiro, RepositorioParceiroEmOrm>();
            servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
            servicos.AddTransient<ServicoParceiro>();
            servicos.AddTransient<ControladorParceiro>();

            servicos.AddTransient<IRepositorioTaxasServicos, RepositorioTaxasServicosEmOrm>();
            servicos.AddTransient<IValidadorTaxasServicos, ValidadorTaxasServicos>();
            servicos.AddTransient<ServicoTaxasServicos>();
            servicos.AddTransient<ControladorTaxasServicos>();

            servicos.AddTransient<SerializadorDadosEmJson>();
            servicos.AddTransient<ContextoDadosPrecos>();
            servicos.AddTransient<RepositorioPrecosJson>();

            container = servicos.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return container.GetService<T>();
        }
    }
}
