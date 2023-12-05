using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAluguel;
using LocadoraDeVeiculos.Dominio.ModuloTaxasServicos;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAluguel
{
    public class ServicoAluguel
    {
        private readonly IRepositorioAluguel repositorioAluguel;
        private readonly IValidadorAluguel validadorAluguel;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.validadorAluguel = validadorAluguel;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Aluguel aluguel)
        {
            Log.Debug("Tentando inserir aluguel...{@a}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Inserir(aluguel);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} inserido com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir aluguel.";

                Log.Error(exc, msgErro + "{@a}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Aluguel aluguel)
        {
            Log.Debug("Tentando editar aluguel...{@a}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Editar(aluguel);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} editado com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar aluguel.";

                Log.Error(exc, msgErro + "{@a}", aluguel);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Aluguel aluguel)
        {
            Log.Debug("Tentando excluir aluguel...{@a}", aluguel);

            try
            {
                bool aluguelExiste = repositorioAluguel.Existe(aluguel);

                if (aluguelExiste == false)
                {
                    Log.Warning("Aluguel {aluguelId} não encontrado", aluguel.Id);

                    return Result.Fail("Aluguel não encontrado");
                }

                repositorioAluguel.Excluir(aluguel);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} editada com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro = ObterMensagemErro(ex);

                erros.Add(msgErro);

                Log.Logger.Error(ex, msgErro + " {AluguelId}", aluguel.Id);

                return Result.Fail(erros);
            }
        }

        public Result Devolucao(Aluguel aluguel)
        {
            Log.Debug("Tentando executar devolução aluguel...{@a}", aluguel);

            List<string> erros = ValidarAluguel(aluguel);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioAluguel.Editar(aluguel);

                contextoPersistencia.GravarDados();

                Log.Debug("Aluguel {AluguelId} devovido com sucesso", aluguel.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar devolver aluguel.";

                Log.Error(exc, msgErro + "{@a}", aluguel);

                return Result.Fail(msgErro);
            }
        }


        private List<string> ValidarAluguel(Aluguel aluguel)
        {
            var resultadoValidacao = validadorAluguel.Validate(aluguel);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));


            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private static string ObterMensagemErro(Exception ex)
        {
            string msgErro;

            msgErro = "Este aluguel não pode ser excluído";

            return msgErro;
        }
    }
}
