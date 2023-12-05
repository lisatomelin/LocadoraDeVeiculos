using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloParceiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Aplicacao.ModuloParceiro
{
    public class ServicoParceiro
    {
        private IRepositorioParceiro repositorioParceiro;
        private IValidadorParceiro validadorParceiro;
        private readonly IContextoPersistencia contextoPersistencia;

        public ServicoParceiro(IRepositorioParceiro repositorioParceiro, IValidadorParceiro validadorParceiro, IContextoPersistencia contextoPersistencia)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.repositorioParceiro = repositorioParceiro;
            this.validadorParceiro = validadorParceiro;
            this.contextoPersistencia = contextoPersistencia;
        }

        public Result Inserir(Parceiro parceiro)
        {
            Log.Debug("Tentando inserir parceiro...{@d}", parceiro);

            List<string> erros = ValidarParceiro(parceiro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioParceiro.Inserir(parceiro);

                contextoPersistencia.GravarDados();

                Log.Debug("Parceiro {ParceiroId} inserida com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar inserir parceiro.";

                Log.Error(exc, msgErro + "{@d}", parceiro);

                return Result.Fail(msgErro);
            }
        }

        public Result Editar(Parceiro parceiro)
        {
            Log.Debug("Tentando editar funcionario...{@d}", parceiro);

            List<string> erros = ValidarParceiro(parceiro);

            if (erros.Count() > 0)
            {
                contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail(erros);
            }

            try
            {
                repositorioParceiro.Editar(parceiro);

                contextoPersistencia.GravarDados();

                Log.Debug("Parceiro {ParceiroId} editada com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception exc)
            {
                contextoPersistencia.DesfazerAlteracoes();

                string msgErro = "Falha ao tentar editar parceiro.";

                Log.Error(exc, msgErro + "{@d}", parceiro);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Parceiro parceiro)
        {
            Log.Debug("Tentando excluir funcionario...{@d}", parceiro);

            try
            {
                bool parceiroExiste = repositorioParceiro.Existe(parceiro);

                if (parceiroExiste == false)
                {
                    Log.Warning("Parceiro {ParceiroId} não encontrada para excluir", parceiro.Id);

                    return Result.Fail("Parceiro não encontrada");
                }

                repositorioParceiro.Excluir(parceiro);

                contextoPersistencia.GravarDados();

                Log.Debug("Parceiro {ParceiroId} excluída com sucesso", parceiro.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                contextoPersistencia.DesfazerAlteracoes();

                List<string> erros = new List<string>();

                string msgErro;

                if (ex.Message.Contains("FK_TBAluguel_TBParceiro"))
                    msgErro = "Este parceiro está relacionado com um aluguel e não pode ser excluído";

                else if (ex.Message.Contains("FK_TBCupom_TBParceiro"))
                    msgErro = "Este parceiro está relacionado com um cupom e não pode ser excluído";

                else
                    msgErro = "Falha ao tentar excluir parceiro";

                erros.Add(msgErro);

                Log.Error(ex, msgErro + " {ParceiroId}", parceiro.Id);

                return Result.Fail(erros);
            }
        }

        private List<string> ValidarParceiro(Parceiro parceiro)
        {
            var resultadoValidacao = validadorParceiro.Validate(parceiro);

            List<string> erros = new List<string>();

            if (resultadoValidacao != null)
                erros.AddRange(resultadoValidacao.Errors.Select(x => x.ErrorMessage));

            if (NomeDuplicado(parceiro))
                erros.Add($"Este nome '{parceiro.Nome}' já está sendo utilizado");

            foreach (string erro in erros)
            {
                Log.Warning(erro);
            }

            return erros;
        }

        private bool NomeDuplicado(Parceiro parceiro)
        {
            Parceiro parceiroEncontrado = repositorioParceiro.SelecionarPorNome(parceiro.Nome);

            if (parceiroEncontrado != null &&
                parceiroEncontrado.Id != parceiro.Id &&
                parceiroEncontrado.Nome == parceiro.Nome)
            {
                return true;
            }

            return false;
        }
    }
}
