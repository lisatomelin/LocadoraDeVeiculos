using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCobranca;
using LocadoraDeVeiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCobranca
{
    public class ServicoCobranca
    {
        private readonly IRepositorioCobranca repositorioCobranca;
        private readonly IValidadorCobranca validadorCobranca;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoCobranca(IRepositorioCobranca repositorioCobranca, IValidadorCobranca validadorCobranca, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCobranca = repositorioCobranca;
            this.validadorCobranca = validadorCobranca;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Cobranca cobranca)
        {
            Log.Debug("Tentando inserir Plano de cobrança...{@d}", cobranca);

            List<string> erros = ValidarCobranca(cobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCobranca.Inserir(cobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("Plano de cobrança {cobrancaId} inserido com sucesso", cobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir plano de cobrança.";

                Log.Error(exc, msgErro + "{@d}", cobranca);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Cobranca cobranca)
        {
            Log.Debug("Tentando editar plano de cobrança...{@d}", cobranca);

            List<string> erros = ValidarCobranca(cobranca);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCobranca.Editar(cobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("Plano de cobrança {cobrancaId} editado com sucesso", cobranca.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar plano de cobrança.";

                Log.Error(exc, msgErro + "{@d}", cobranca);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cobranca cobranca)
        {
            Log.Debug("Tentando excluir plano de cobrança...{@d}", cobranca);

            try
            {
                bool cobrancaExiste = repositorioCobranca.Existe(cobranca);

                if (cobrancaExiste == false)
                {
                    Log.Warning("Plano de cobrança {cobrancaId} editado com sucesso", cobranca.Id);

                    return Result.Fail("Plano de cobrança não encontrado");
                }

                repositorioCobranca.Excluir(cobranca);

                contextoPersistencia.GravarDados();

                Log.Debug("Plano de cobrança {cobrancaId} excluído com sucesso", cobranca.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAluguel_TBCobranca"))
                    msgErro = "Este plano de cobrança está relacionado com um aluguel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir plano de cobrança";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {cobrancaId}", cobranca.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCobranca(Cobranca cobranca)
        {
            var resultadoValidacao = validadorCobranca.Validate(cobranca);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

    }
}
