using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloCupom;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeVeiculos.Aplicacao.ModuloCupom
{
    public class ServicoCupom
    {
        private readonly IRepositorioCupom repositorioCupom;
        private readonly IValidadorCupom validadorCupom;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoCupom(IRepositorioCupom repositorioCupom, IValidadorCupom validadorCupom, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioCupom = repositorioCupom;
            this.validadorCupom = validadorCupom;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Cupom cupom)
        {
            Log.Debug("Tentando inserir Cupom...{@d}", cupom);

            List<string> erros = ValidarCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Inserir(cupom);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {cupomId} inserido com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir cupom.";

                Log.Error(exc, msgErro + "{@d}", cupom);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Cupom cupom)
        {
            Log.Debug("Tentando editar Cupom...{@d}", cupom);

            List<string> erros = ValidarCupom(cupom);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioCupom.Editar(cupom);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {cupomId} editado com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar Cupom.";

                Log.Error(exc, msgErro + "{@d}", cupom);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Cupom cupom)
        {
            Log.Debug("Tentando excluir Cupom...{@d}", cupom);

            try
            {
                bool cupomExiste = repositorioCupom.Existe(cupom);

                if (cupomExiste == false)
                {
                    Log.Warning("Cupom {cupomId} editado com sucesso", cupom.Id);

                    return Result.Fail("Cupom não encontrado");
                }

                repositorioCupom.Excluir(cupom);

                contextoPersistencia.GravarDados();

                Log.Debug("Cupom {cupomId} excluído com sucesso", cupom.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBCupom_TBAluguel"))
                    msgErro = "Este cupom está relacionado com um aluguel e não pode ser excluído";
                else
                    msgErro = "Falha ao tentar excluir cupom";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {cupomId}", cupom.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarCupom(Cupom cupom)
        {
            var resultadoValidacao = validadorCupom.Validate(cupom);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(cupom))
                erros.Add($"Este nome '{cupom.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Cupom cupom)
        {
            Cupom cupomEncontrado = repositorioCupom.SelecionarPorNome(cupom.Nome);

            if (cupomEncontrado != null &&
            cupomEncontrado.Id != cupom.Id &&
                cupomEncontrado.Nome == cupom.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
